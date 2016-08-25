using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.profil
{
    public partial class ilan : System.Web.UI.UserControl
    {
        ilanBll ilanb = new ilanBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            yayindaRepeater.DataSource = ilanb.list(2, 5, true, false, false);
            yayindaRepeater.DataBind();

            if (Request.QueryString["classified"] != null)
            {
                if (Request.QueryString["proc"] == "2")
                {
                    ilanb.update(3, Request.QueryString["classified"]);
                }
            }

            yayindaRepeater.DataSource = ilanb.list(2, 5, true, false, false);
            yayindaRepeater.DataBind();
        }
    }
}