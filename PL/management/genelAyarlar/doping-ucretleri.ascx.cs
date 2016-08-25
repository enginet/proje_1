using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.management.genelAyarlar
{
    public partial class doping_ucretleri : System.Web.UI.UserControl
    {
        dopingKategoriBll dopingKtgb = new dopingKategoriBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            dopingUcretRepeater.DataSource = dopingKtgb.list();
            dopingUcretRepeater.DataBind();
        }
    }
}