using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.profil
{
    public partial class gönderilen_kutusu : System.Web.UI.UserControl
    {
        mesajBll mesajb = new mesajBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            mesajRepeater.DataSource = mesajb.list(4, 2);
            mesajRepeater.DataBind();
            if (Request.QueryString["proc"] != null)
            {
                if (Request.QueryString["proc"] == "1")
                {
                    mesajb.update(2, 2, Request.QueryString["to"], Request.QueryString["cla"]);
                    mesajb.update(3, Request.QueryString["to"], 2, Request.QueryString["cla"]);

                }

                mesajRepeater.DataSource = mesajb.list(4, 2);
                mesajRepeater.DataBind();
            }
        }
    }
}