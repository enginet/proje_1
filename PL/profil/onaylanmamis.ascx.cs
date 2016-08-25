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
    public partial class onaylanmamis : System.Web.UI.UserControl
    {
        ilanBll ilanb = new ilanBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            onayBekleyenRepeater.DataSource = ilanb.list(2, 5, false, false, false);
            onayBekleyenRepeater.DataBind();

            if (Request.QueryString["classified"] != null)
            {
                if (Request.QueryString["proc"] == "2")
                {
                    ilanb.update(2, Request.QueryString["classified"]);
                }
                if (Request.QueryString["proc"] == "3")
                {
                    ilanb.update(3, Request.QueryString["classified"]); //düzenlenecek
                }
                //if (Request.QueryString["proc"] == "4")
                //{
                //    ilanb.update(3, Request.QueryString["classified"]);
                //}
                onayBekleyenRepeater.DataSource = ilanb.list(2, 5, false, false, false);
                onayBekleyenRepeater.DataBind();
            }
        }
    }
}