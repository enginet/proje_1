using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using System.IO;

namespace PL.management.anaYonetim.reklamYonetimi
{
    public partial class ekle : System.Web.UI.UserControl
    {
        ilBll il = new ilBll();

        kullaniciBll kullanici = new kullaniciBll();

        verilenReklamBll vRklm = new verilenReklamBll();

        reklamBll rklm = new reklamBll();



        protected override void OnInit(EventArgs e)
        {
            drpIl.Enabled = false;
            drpKonum.Enabled = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                drpIl.DataSource = il.list();
                drpIl.DataTextField = "ilAdi";
                drpIl.DataValueField = "ilId";
                drpIl.DataBind();

                ListItem lst = new ListItem();
                lst.Text = "Seçiniz";
                lst.Value = "null";
                lst.Selected = true;

                drpIl.Items.Insert(0, lst);

                drpKullanici.DataSource = kullanici.receiveList();
                drpKullanici.DataTextField = "kullaniciAdSoyad";
                drpKullanici.DataValueField = "kullaniciId";
                drpKullanici.DataBind();

                onlineRepeater.DataSource = kullanici.list(4);
                onlineRepeater.DataBind();
            }
        }

        protected void Kaydet_Click(object sender, EventArgs e)
        {
            if(FileUpload1.HasFile)
            {
                int kullaniciId = Convert.ToInt32(drpKullanici.SelectedValue);
                string reklamAdi = txtReklamAd.Text;
                int reklamTur = Convert.ToInt32(drpReklamTur.SelectedValue);


                string reklamKonum = drpKonum.SelectedValue.ToString();
                string il = drpIl.SelectedValue;
                string reklamResim = FileUpload1.FileName;
                string reklamUrl = txtReklamLink.Text;

                string[] tarihDizi = txtTarih.Text.Split('-');

                tarihDizi[0] = tarihDizi[0].Trim();
                tarihDizi[1] = tarihDizi[1].Trim();

                DateTime baslangicTar = DAL.toolkit.tarihDondur(tarihDizi[0]);
                DateTime bitisTar = DAL.toolkit.tarihDondur(tarihDizi[1]);

                DAL.reklam reklamd = rklm.search(reklamTur, reklamKonum);

                double fiyat = (double)reklamd.fiyat;
                int reklamId = reklamd.reklamId;

                vRklm.insert(reklamId, kullaniciId, reklamAdi, il, baslangicTar, bitisTar, reklamUrl, false, true);

                verilenReklam vr = vRklm.receiveList(false, true).Last();
                string[] segments = FileUpload1.FileName.Split('.');
                string fileExt = segments[segments.Length - 1];
                vRklm.update(4,vr.verilenReklamId,  vr.verilenReklamId+ "." + fileExt);

                HttpFileCollection updateFiles = Request.Files;
                string str_image = "";

                for (int i = 0; i < updateFiles.Count; i++)
                {

                    bool secili = false;
                    if (i == 0)
                    {
                        secili = true;
                    }

                    HttpPostedFile file = updateFiles[i];

                    string fileName = file.FileName;
                    string fileExtension = file.ContentType;

                    if (!string.IsNullOrEmpty(fileName))
                    {
                        fileExtension = Path.GetExtension(fileName);
                        str_image = vr.verilenReklamId.ToString() + fileExtension;
                        string pathToSave_100 = HttpContext.Current.Server.MapPath("~/upload/reklam/") + str_image;
                        file.SaveAs(pathToSave_100);
                    }
                }

                // Ödeme tablosuna ekleme yapılacak.

                Response.Redirect("~/management/anaYonetim/reklamYonetimi/reklam.aspx?page=listele&tip=2");
            }
            else
            {
                Panel pnl = new Panel();
                pnl.Attributes["class"] = "alert alert-danger col-xs-12";
                Label lbl = new Label();
                lbl.Text = "Lütfen resim yükleyiniz";
                lbl.Style.Add("font-size", "18px");
                pnl.Controls.Add(lbl);

                box_body.Controls.AddAt(0, pnl);
            }
            
        }

        protected void Vazgec_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/management/anaYonetim/reklamYonetimi/reklam.aspx?page=listele");
        }

        protected void drpReklamTur_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (drpReklamTur.SelectedValue == "1") // site içi sçilmişse
            {
                drpKonum.Enabled = true;
                drpIl.Enabled = false;
                drpIl.SelectedValue = "null";
            }
            else if(drpReklamTur.SelectedValue == "2") // harita çevresi seçilmişse
            {
                drpIl.Enabled = true;
                drpKonum.Enabled = false;
                drpKonum.SelectedValue = "null";
            }
            else // Her ikisi de seçilmemişse
            {
                drpIl.Enabled = false;
                drpIl.SelectedValue = "null";
                drpKonum.Enabled = false;
                drpKonum.SelectedValue = "null";
            }
        }
    }
}