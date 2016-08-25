using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.ozellikler
{
    public partial class oda_yatak_kat_sayisi : System.Web.UI.UserControl
    {
        ozellikBll ozellikb = new ozellikBll();

        protected void Page_Load(object sender, EventArgs e)
        {

            girilebilirIlanOzellikBll gio = new girilebilirIlanOzellikBll();
            if (Request.QueryString["page"] == "duzenle" && Request.QueryString["ilan"] != "")
            {
                if (gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 59) != null)
                {
                    txtKatSayisiText.Text = gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 59).deger;
                }
                if (gio.search(Convert.ToInt32(Request.QueryString["ilan"]),85) != null)
                {
                    txtYatakSayisiText.Text = gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 85).deger;
                }
                if (gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 83) != null)
                {
                    txtOdaSayisiText.Text = gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 83).deger;
                }
            }
        }
    }
}