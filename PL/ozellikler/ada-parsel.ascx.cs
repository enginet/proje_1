using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.ozellikler
{
    public partial class ada_parsel : System.Web.UI.UserControl
    {

        girilebilirIlanOzellikBll gio = new girilebilirIlanOzellikBll();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["page"] == "duzenle" && Request.QueryString["ilan"] != "")
            {
                if (gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 3) != null)
                {
                    txtAdaNo.Text = gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 3).deger;
                }

                if (gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 4) != null)
                {
                    txtParselNo.Text = gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 4).deger;
                }
            }
        }
    }
}