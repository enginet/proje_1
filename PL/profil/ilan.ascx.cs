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
    public partial class ilan : System.Web.UI.UserControl
    {
        ilanBll ilanb = new ilanBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["unique-site-user"] != null)
            {
                kullanici _authority = (kullanici)Session["unique-site-user"];

                if (!Page.IsPostBack)
                {
                    yayindaRepeater.DataSource = ilanb.list(2, _authority.kullaniciId, true, false, false);
                    yayindaRepeater.DataBind();
                }

                if (Request.QueryString["classified"] != null)
                {
                    if (Request.QueryString["proc"] == "2")
                    {
                        ilanb.update(3, Request.QueryString["classified"]);
                    }
                }

                yayindaRepeater.DataSource = ilanb.list(2, _authority.kullaniciId, true, false, false);
                yayindaRepeater.DataBind();
            }
        }
    }
}