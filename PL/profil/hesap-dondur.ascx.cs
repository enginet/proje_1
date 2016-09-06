using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;

namespace PL.profil
{
    public partial class hesap_dondur : System.Web.UI.UserControl
    {
        kullaniciBll kullanicib = new kullaniciBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["unique-site-user"] != null)
            {
                kullanici _authority = (kullanici)Session["unique-site-user"];
            }

        }
        protected void Iptal_Click(object sender, EventArgs e)
        {
            kullanici _authority = (kullanici)Session["unique-site-user"];
            kullanicib.update(2, _authority.kullaniciId, true);
            Response.Redirect("~/giris-yap.aspx");
        }
    }
}