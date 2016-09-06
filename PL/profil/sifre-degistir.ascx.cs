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
    public partial class sifre_degistir : System.Web.UI.UserControl
    {
        kullaniciBll kll = new kullaniciBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Guncelle_Sifre_Click(object sender, EventArgs e)
        {
            if (Session["unique-site-user"] != null)
            {
                kullanici _authority = (kullanici)Session["unique-site-user"];
                kullanici _kullanici = kll.search(_authority.kullaniciId);

                if (txtEskiSifre.Value == _kullanici.sifre)
                {

                    kll.update(
                            4,
                            _authority.kullaniciId,
                            txtYeniSifre.Value
                        );
                    try
                    {
                        DAL.toolkit.HTML_Mail_Sender(_authority.email, "~/email-temp/single-column/build.html", "şifre değişikliği");
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }
    }
}