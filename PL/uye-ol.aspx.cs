using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;


namespace PL
{
    public partial class uye_ol : System.Web.UI.Page
    {

        kullaniciBll kll = new kullaniciBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UyeOl_Click(object sender, EventArgs e)
        {
            if (uyelikSozlesme.Checked)
            {

                if (kll.kullanici_varmi(txtEmail.Text, DAL.toolkit.Number_Remover(txtTlf.Text)))
                {
                    string onay_Kod = DAL.toolkit.guvenlik_kodu();
                    string[] dizi = { txtAd.Text + " " + txtSoyad.Text, DAL.toolkit.Number_Remover(txtTlf.Text), txtEmail.Text, txtSifre.Text, onay_Kod };
                    Session["yeniKullanici"] = dizi;

                    List<string> numara = new List<string>();
                    numara.Add(DAL.toolkit.Number_Remover(txtTlf.Text));
                    string mesaj = "Onay Kodunuz : " + onay_Kod + "\nGuvenliginiz icin bu kodu kimseyle paylasmayiniz.";
                    if (DAL.toolkit.sms_gonder(mesaj, numara))
                    {
                        Response.Redirect("~/cep-aktivasyon.aspx");
                    }
                    else
                    {

                        Panel pnl = new Panel();
                        pnl.Attributes["class"] = "alert alert-danger";
                        Label lbl = new Label();
                        lbl.Text = "Gönderme Başarısız";
                        pnl.Controls.Add(lbl);

                        uyelikField.Controls.AddAt(0, pnl);
                    }
                }
                else
                {
                    Panel pnl = new Panel();
                    pnl.Attributes["class"] = "alert alert-danger";
                    Label lbl = new Label();
                    lbl.Text = "Bu cep telefonu veya email zaten mevcut !";
                    pnl.Controls.Add(lbl);
                    uyelikField.Controls.Add(pnl);
                }

            }
            else
            {
                Panel pnl = new Panel();
                pnl.Attributes["class"] = "alert alert-danger";
                Label lbl = new Label();
                lbl.Text = "Lütfen üyelik sözleşmesini okuyup kabul edin.";
                pnl.Controls.Add(lbl);

                uyelikField.Controls.AddAt(0, pnl);

            }
        }
    }
}