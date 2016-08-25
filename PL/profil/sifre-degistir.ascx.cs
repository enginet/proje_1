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
            kullanici _kullanici = kll.search(5);
            if (txtEskiSifre.Value == _kullanici.sifre)
            {
              
                kll.update(
                        4,                              
                        5,    
                        txtYeniSifre.Value
                    );
                try
                {
                    DAL.toolkit.HTML_Mail_Sender("clubwomanizer588@gmail.com", "~/email-temp/single-column/build.html", "şifre değişikliği");

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}