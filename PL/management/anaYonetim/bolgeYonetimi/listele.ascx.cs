using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.management.anaYonetim.bolgeYonetimi
{
    public partial class listele : System.Web.UI.UserControl
    {
        ilBll il = new ilBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ilRepeater.DataSource = il.list();
                ilRepeater.DataBind();
            }
        }
    }
}