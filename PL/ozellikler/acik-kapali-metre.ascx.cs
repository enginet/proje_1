using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DAL;
using BLL;

namespace PL.ozellikler
{
    public partial class acik_kapali_metre : System.Web.UI.UserControl
    {
        ozellikBll ozellikB = new ozellikBll();
        girilebilirIlanOzellikBll gio = new girilebilirIlanOzellikBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["page"] == "duzenle" && Request.QueryString["ilan"] != "")
            {
                
                if (gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 1) != null)
                {
                    txtAcikMetreKare.Text = gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 1).deger;
                }

                if (gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 2) != null)
                {
                    txtKapaliMetreKare.Text = gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 2).deger;
                }
            }
        }
    }
}