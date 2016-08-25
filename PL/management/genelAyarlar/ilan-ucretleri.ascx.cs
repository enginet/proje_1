using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.management.genelAyarlar
{
    public partial class ilan_ucretleri : System.Web.UI.UserControl
    {
        ilanUcretBll ilanUcretb = new ilanUcretBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            ilanUcretRepeater.DataSource = ilanUcretb.list();
            ilanUcretRepeater.DataBind();
        }
    }
}