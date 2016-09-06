using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace PL
{
    public partial class sifremi_unuttum : System.Web.UI.Page
    {
        kullaniciBll kullanicib = new kullaniciBll();
        guvenlikKodlariBll guvenlib = new guvenlikKodlariBll();
        string info, detail;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if(txtMail.Value=="")
            //{
            //    if(kullanicib.mail_search(txtMail.Value)!=null)
            //    {
            //        try
            //        {
            //            DAL.toolkit.HTML_Mail_Sender(txtMail.Value, "~/email-temp/single-column/build.html", "şifre değişikliği","şifre değişikliği",);
            //        }
            //        catch (Exception)
            //        {

            //            throw;
            //        }
            //    }
            //}
        }

        protected void Gonder_Click(object sender, EventArgs e)
        {
            info = "Şifremi unuttum değişikliği için gönderilen aktivasyon linki:";
            string GuidKey = Guid.NewGuid().ToString();

            detail = "http://netteilanver.com/yeni-sifre.aspx?act=" + GuidKey;
            if (kullanicib.mail_search(txtMail.Value) != null && guvenlib.sec_search(txtMail.Value) == null)
            {
                kullanici _kullanici = kullanicib.mail_search(txtMail.Value);
                kullanicib.mail_search(txtMail.Value);
                guvenlib.insert(_kullanici.email, GuidKey);
                DAL.toolkit.HTML_Mail_Sender(_kullanici.email, "~/email-temp/single-column/build.html", "Şifremi unuttum", "Şifremi unuttum", _kullanici.kullaniciAdSoyad, info, detail);
            }
            else if (kullanicib.mail_search(txtMail.Value) != null && guvenlib.sec_search(txtMail.Value) != null)
            {
                kullanici _kullanici = kullanicib.mail_search(txtMail.Value);
                kullanicib.mail_search(txtMail.Value);
                guvenlib.update(txtMail.Value, GuidKey);
                DAL.toolkit.HTML_Mail_Sender(_kullanici.email, "~/email-temp/single-column/build.html", "Şifremi unuttum", "Şifremi unuttum", _kullanici.kullaniciAdSoyad, info, detail);
            }
        }
    }
}