using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.management.anaYonetim.bolgeYonetimi
{
    public partial class mahallelistele : System.Web.UI.UserControl
    {
        mahalleBll mahalle = new mahalleBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mahalleRepeater.DataSource = mahalle.list(Convert.ToInt32(Request.QueryString["ilceId"]));
                mahalleRepeater.DataBind();
            }
        }
    }
}