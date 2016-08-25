using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.management.anaYonetim.bolgeYonetimi
{
    public partial class ilceListele : System.Web.UI.UserControl
    {
        ilceBll ilce = new ilceBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            ilceRepeater.DataSource = ilce.list(Convert.ToInt32(Request.QueryString["ilId"]));
            ilceRepeater.DataBind();

        }

    }
}