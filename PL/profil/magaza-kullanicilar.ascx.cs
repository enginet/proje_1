using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.profil
{
    public partial class magaza_kullanıcılar : System.Web.UI.UserControl
    {
        magazaKullaniciBll magazaKllb = new magazaKullaniciBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            kullaniciRepeater.DataSource = magazaKllb.list(1, 16);
            kullaniciRepeater.DataBind();
            if (Request.QueryString["us"] != null)
            {
                magazaKllb.delete(16, Request.QueryString["us"]);
            }
            kullaniciRepeater.DataSource = magazaKllb.list(1, 16);
            kullaniciRepeater.DataBind();
        }
    }
}