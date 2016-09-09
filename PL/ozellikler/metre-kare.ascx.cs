using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace PL.ozellikler
{
    public partial class metre_kare : System.Web.UI.UserControl
    {
        girilebilirIlanOzellikBll gio = new girilebilirIlanOzellikBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["page"] == "duzenle" && Request.QueryString["ilan"] != "")
                {
                    if (gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 78) != null)
                    {
                        txtMetre.Text = gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 78).deger;
                    }
                }
            }
        }
    }
}