using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.profil
{
    public partial class reklam_onay_bekleyen : System.Web.UI.UserControl
    {
        verilenReklamBll verilenReklamb = new verilenReklamBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            reklamRepeater.DataSource = verilenReklamb.list(2, false, false, 5);
            reklamRepeater.DataBind();

            if (Request.QueryString["ads"] != null)
            {
                verilenReklamb.update(2, Request.QueryString["ads"], false, true);
            }
            reklamRepeater.DataSource = verilenReklamb.list(2, false, false, 5);
            reklamRepeater.DataBind();
        }
    }
}