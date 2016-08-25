using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.profil
{
    public partial class reklamlar : System.Web.UI.UserControl
    {
        verilenReklamBll verilenReklamb = new verilenReklamBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            reklamRepeater.DataSource = verilenReklamb.list(2, false, true, 5);
            reklamRepeater.DataBind();

            if (Request.QueryString["ads"] != null)
            {
                verilenReklamb.update(2, Request.QueryString["ads"], false, false);
            }
            reklamRepeater.DataSource = verilenReklamb.list(2, false, true, 5);
            reklamRepeater.DataBind();
        }
    }
}