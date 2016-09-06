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
    public partial class cep_telefonu : System.Web.UI.UserControl
    {

        kullaniciBll kullanicib = new kullaniciBll();
        guvenlikKodlariBll guvenlib = new guvenlikKodlariBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["unique-site-user"] != null)
            {
                kullanici _authority = (kullanici)Session["unique-site-user"];
                txtGsm1.Text = _authority.telefonlars.Where(t => t.telefonTur.ToString() == "1").FirstOrDefault().telefon;
            }
            else
            {
                Response.Redirect("~/giris-yap.aspx");
            }
        }
        protected void Degistir_Click(object sender, EventArgs e)
        {
            string onay_Kod = DAL.toolkit.guvenlik_kodu();
            string[] dizi = { DAL.toolkit.Number_Remover(txtGsm1.Text), onay_Kod };
            Session["mobile-act"] = dizi;

            guvenlib.insert(DAL.toolkit.Number_Remover(txtGsm1.Text), onay_Kod);
            List<string> numara = new List<string>();
            numara.Add(DAL.toolkit.Number_Remover(txtGsm1.Text));
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



            //info = "E-posta aktivasyonu için gönderilen aktivasyon linki:";
            //string GuidKey = Guid.NewGuid().ToString();

            //detail = "http://netteilanver.com/eposta-aktivasyon.aspx?act=" + GuidKey;
            //if (kullanicib.mail_search(txtMail.Value) != null && guvenlib.sec_search(txtMail.Value) == null)
            //{
            //    kullanici _kullanici = kullanicib.mail_search(txtMail.Value);
            //    kullanicib.mail_search(txtMail.Value);
            //    guvenlib.insert(_kullanici.email, GuidKey);
            //    DAL.toolkit.HTML_Mail_Sender(_kullanici.email, "~/email-temp/single-column/build.html", "E-posta aktivasyonu", "E-posta aktivasyonu", _kullanici.kullaniciAdSoyad, info, detail);
            //}
            //else if (kullanicib.mail_search(txtMail.Value) != null && guvenlib.sec_search(txtMail.Value) != null)
            //{
            //    kullanici _kullanici = kullanicib.mail_search(txtMail.Value);
            //    kullanicib.mail_search(txtMail.Value);
            //    guvenlib.update(txtMail.Value, GuidKey);
            //    DAL.toolkit.HTML_Mail_Sender(_kullanici.email, "~/email-temp/single-column/build.html", "E-posta aktivasyonu", "E-posta aktivasyonu", _kullanici.kullaniciAdSoyad, info, detail);
            //}
        }
    }
}