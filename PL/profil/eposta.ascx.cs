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
    public partial class eposta : System.Web.UI.UserControl
    {

        kullaniciBll kullanicib = new kullaniciBll();
        guvenlikKodlariBll guvenlib = new guvenlikKodlariBll();
        string info, detail;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["unique-site-user"] != null)
            {
                kullanici _authority = (kullanici)Session["unique-site-user"];
                txtMail.Value = _authority.email;
            }
            else
            {
                Response.Redirect("~/giris-yap.aspx");
            }
        }
        protected void Degistir_Click(object sender, EventArgs e)
        {

            info = "E-posta aktivasyonu için gönderilen aktivasyon linki:";
            string GuidKey = Guid.NewGuid().ToString();

            detail = "http://netteilanver.com/eposta-aktivasyon.aspx?act=" + GuidKey;
            if (kullanicib.mail_search(txtMail.Value) != null && guvenlib.sec_search(txtMail.Value) == null)
            {
                kullanici _kullanici = kullanicib.mail_search(txtMail.Value);
                kullanicib.mail_search(txtMail.Value);
                guvenlib.insert(_kullanici.email, GuidKey);
                DAL.toolkit.HTML_Mail_Sender(_kullanici.email, "~/email-temp/single-column/build.html", "E-posta aktivasyonu", "E-posta aktivasyonu", _kullanici.kullaniciAdSoyad, info, detail);
            }
            else if (kullanicib.mail_search(txtMail.Value) != null && guvenlib.sec_search(txtMail.Value) != null)
            {
                kullanici _kullanici = kullanicib.mail_search(txtMail.Value);
                kullanicib.mail_search(txtMail.Value);
                guvenlib.update(txtMail.Value, GuidKey);
                DAL.toolkit.HTML_Mail_Sender(_kullanici.email, "~/email-temp/single-column/build.html", "E-posta aktivasyonu", "E-posta aktivasyonu", _kullanici.kullaniciAdSoyad, info, detail);
            }
        }
    }
}