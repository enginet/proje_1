using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace PL.profil
{
    public partial class reklam_ekle : System.Web.UI.UserControl
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
                lst.Text = "İl Seçiniz";
                lst.Value = "null";
                lst.Selected = true;

                drpIl.Items.Insert(0, lst);
            }
        }

        protected void Kaydet_Click(object sender, EventArgs e)
        {
            //if (FileUpload1.HasFile)
            //{ 

                string[] tarihDizi = txtTarih.Text.Split('-');
                tarihDizi[0] = tarihDizi[0].Trim();
                tarihDizi[1] = tarihDizi[1].Trim();

                DAL.reklam reklamd = rklm.search(drpReklamTur.SelectedValue, drpKonum.SelectedValue.ToString());

                vRklm.insert(reklamd.reklamId, 2, txtReklamAd.Text, "Adsiz.png", drpIl.SelectedValue, DAL.toolkit.tarihDondur(tarihDizi[0]), DAL.toolkit.tarihDondur(tarihDizi[1]), txtReklamLink.Text, false, false);

                // Ödeme tablosuna ekleme yapılacak.

                //Response.Redirect("~/management/anaYonetim/reklamYonetimi/reklam.aspx?page=listele&tip=2");
            //}
            //else
            //{
            //    Panel pnl = new Panel();
            //    pnl.Attributes["class"] = "alert alert-danger col-xs-12";
            //    Label lbl = new Label();
            //    lbl.Text = "Lütfen resim yükleyiniz";
            //    lbl.Style.Add("font-size", "18px");
            //    pnl.Controls.Add(lbl);

            //    box_body.Controls.AddAt(0, pnl);
            //}

        }

        protected void Vazgec_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/management/anaYonetim/reklamYonetimi/reklam.aspx?page=listele");
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
    }
}