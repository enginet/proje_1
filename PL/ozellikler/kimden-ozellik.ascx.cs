using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.ozellikler
{
    public partial class kimden_ozellik : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            girilebilirIlanOzellikBll gio = new girilebilirIlanOzellikBll();
            if (Request.QueryString["page"] == "duzenle" && Request.QueryString["ilan"] != "")
            {
                if (gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 60) != null)
                {
                    txtMuammen.Text = gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 60).deger;
                }
                if (gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 61) != null)
                {
                    txtTeminat.Text = gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 61).deger;
                }
                if (gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 62) != null)
                {
                    txtSatisYeri.Text = gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 62).deger;
                }
                if (gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 63) != null)
                {
                    txtSatisTarih1.Text = gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 63).deger;
                }
                if (gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 64) != null)
                {
                    txtSatisTarih2.Text = gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 64).deger;
                }
                if (gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 65) != null)
                {
                    ozelAciklama.Text = gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 65).deger;
                }
            }

            if (Request.QueryString["page"] == "duzenle")
            {
                txtCKeditorAdi.Visible = true;
                txtSatisFiyat.Visible = true;

            }
            else
            {
                txtCKeditorAdi.Visible = false;
                txtSatisFiyat.Visible = false;
            }
        }
    }
}