using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PL.management.anaYonetim.ilanYonetimi
{
    public partial class ilan_verildi : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ilanNo.InnerText = Session["ilanNo"].ToString();
            //Session.Remove("ilanNo");
        }
    }
}