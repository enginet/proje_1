using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.profil
{
    public partial class bildirimler : System.Web.UI.UserControl
    {
        bildirimBll bildirimb = new bildirimBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            bildirimRepeater.DataSource = bildirimb.list(5, 1);
            bildirimRepeater.DataBind();
            if (Request.QueryString["not"] != null)
            {
                bildirimb.update(1, Request.QueryString["not"]);
            }
        }
    }
}