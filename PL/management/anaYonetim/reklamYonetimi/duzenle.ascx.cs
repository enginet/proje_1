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
    public partial class duzenle : System.Web.UI.UserControl
    {
        ilBll il = new ilBll();

        kullaniciBll kullanici = new kullaniciBll();

        verilenReklamBll vRklm = new verilenReklamBll();

        reklamBll rklm = new reklamBll();
        public string path="";
        int vReklamId;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //You must tell the page that you use ControlState.
            Page.RegisterRequiresControlState(this);

            drpIl.Enabled = false;
            drpKonum.Enabled = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            vReklamId = Convert.ToInt32(Request.QueryString["advertisement"]);
            if (!Page.IsPostBack)
            {
                onlineRepeater.DataSource = kullanici.list(4);
                onlineRepeater.DataBind();

                verilenReklam vRklmd = vRklm.search(Convert.ToInt32(Request.QueryString["advertisement"]));
                DAL.reklam rklmd = rklm.searchId((int)vRklmd.reklamId);

                drpIl.DataSource = il.list();
                drpIl.DataTextField = "ilAdi";
                drpIl.DataValueField = "ilId";
                drpIl.DataBind();

                ListItem lst = new ListItem();
                lst.Text = "Seçiniz";
                lst.Value = "null";
                drpIl.Items.Insert(0, lst);


                drpKullanici.DataSource = kullanici.receiveList();
                drpKullanici.DataTextField = "kullaniciAdSoyad";
                drpKullanici.DataValueField = "kullaniciId";
                drpKullanici.DataBind();


                drpKullanici.SelectedValue = vRklmd.kullaniciId.ToString();
                drpReklamTur.SelectedValue = rklmd.reklamTurId.ToString();
                txtReklamAd.Text = vRklmd.reklamAdi.ToString();
                DateTime bast = Convert.ToDateTime(vRklmd.baslangicTarihi);
                DateTime bitt = Convert.ToDateTime(vRklmd.bitisTarihi);
                txtTarih.Text = bast.ToShortDateString()+" - "+bitt.ToShortDateString();
                

                if(vRklmd.reklamLink!=null)
                {
                    txtReklamLink.Text = vRklmd.reklamLink.ToString();
                }

                path="../../../upload/reklam/"+vRklmd.reklamResim.ToString();
                reklamResim.Attributes["src"] = path;
                

                if(vRklmd.ilId!=null)
                {
                    drpIl.SelectedValue = vRklmd.ilId.ToString();
                    drpIl.Enabled = true;
                }

                if(rklmd.reklamKonumuId!=null)
                {
                    drpKonum.SelectedValue = rklmd.reklamKonumuId.ToString();
                    drpKonum.Enabled = true;

                    if(rklmd.reklamKonumuId==1 || rklmd.reklamKonumuId == 4)
                    {
                        reklamResim.Width = 728;
                        reklamResim.Height = 90;
                    }
                    if (rklmd.reklamKonumuId == 2 || rklmd.reklamKonumuId == 3 || rklmd.reklamKonumuId == 5)
                    {
                        reklamResim.Width = 230;
                        reklamResim.Height = 230;
                    }
                }
                else
                {
                    reklamResim.Width = 250;
                    reklamResim.Height = 150;
                }

            }
        }

        protected void drpReklamTur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpReklamTur.SelectedValue == "1") // site içi sçilmişse
            {
                drpKonum.Enabled = true;
                drpIl.Enabled = false;
                drpIl.SelectedValue = "null";
            }
            else if (drpReklamTur.SelectedValue == "2") // harita çevresi seçilmişse
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

        protected void Kaydet_Click(object sender, EventArgs e)
        {
            int kullaniciId = Convert.ToInt32(drpKullanici.SelectedValue);
            string reklamAdi = txtReklamAd.Text;
            int reklamTur = Convert.ToInt32(drpReklamTur.SelectedValue);


            string reklamKonum = drpKonum.SelectedValue.ToString();
            string il = drpIl.SelectedValue;
            string reklamUrl = txtReklamLink.Text;

            string[] tarihDizi = txtTarih.Text.Split('-');

            tarihDizi[0] = tarihDizi[0].Trim();
            tarihDizi[1] = tarihDizi[1].Trim();

            DateTime baslangicTar = DAL.toolkit.tarihDondur(tarihDizi[0]);
            DateTime bitisTar = DAL.toolkit.tarihDondur(tarihDizi[1]);

            DAL.reklam reklamd = rklm.search(reklamTur, reklamKonum);

            double fiyat = (double)reklamd.fiyat;
            int reklamId = reklamd.reklamId;

            string reklamResmi="";
            if(chcYeniResim.Checked)
            {
                if(FileUpload1.HasFile)
                {
                    HttpFileCollection updateFiles = Request.Files;
                    string str_image = "";

                    if (FileUpload1.HasFile)
                    {
                        string[] segments = FileUpload1.FileName.Split('.');
                        string fileExt = segments[segments.Length - 1];
                        vRklm.update(3, vReklamId, kullaniciId, reklamAdi, reklamd.reklamId, il, baslangicTar.ToShortDateString(), bitisTar.ToShortDateString(), false, true,vReklamId+"."+fileExt, txtReklamLink.Text);
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
                                str_image = vReklamId.ToString() + fileExtension;
                                string pathToSave_100 = HttpContext.Current.Server.MapPath("~/upload/reklam/") + str_image;
                                file.SaveAs(pathToSave_100);
                            }
                        }
                    }

                }
                else
                {
                    // uyarı verdirilecek
                }
            }
            else
            {

                string[] dizi = reklamResim.Attributes["src"].Split('/');

                reklamResmi = dizi[5];
                vRklm.update(3, vReklamId, kullaniciId, reklamAdi, reklamd.reklamId, il, baslangicTar.ToShortDateString(), bitisTar.ToShortDateString(), false, true, reklamResmi,txtReklamLink.Text);
                txtReklamAd.Text="adsfasdf";
            }


            // resim güncelleme ve ödeme tablosuna ekleme işlemleri yapılacak
            //Response.Redirect("~/management/anaYonetim/reklamYonetimi/reklam.aspx?page=listele&tip=2");
        }

        protected void Vazgec_Click(object sender, EventArgs e)
        {

        }

        protected void chcYeniResim_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void chcYeniResim_CheckedChanged1(object sender, EventArgs e)
        {
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtReklamAd.Text = "asdfadsf";
        }
    }
}