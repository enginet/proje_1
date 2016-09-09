using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.ozellikler
{
    public partial class arsa_ozellik : System.Web.UI.UserControl
    {
        ozellikBll ozellikb = new ozellikBll();
        secilebilirIlanOzellikBll sioBll = new secilebilirIlanOzellikBll();
        girilebilirIlanOzellikBll gio = new girilebilirIlanOzellikBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ListItem lst = new ListItem();
                lst.Text = "Seçiniz";
                lst.Value = "";

                drpGabari.DataSource = ozellikb.selectFieldList(10);
                drpGabari.DataTextField = "deger";
                drpGabari.DataValueField = "secilebilirOzellikDegerId";
                drpGabari.DataBind();
                drpGabari.Items.Insert(0, lst);
                

                drpKask.DataSource = ozellikb.selectFieldList(9);
                drpKask.DataTextField = "deger";
                drpKask.DataValueField = "secilebilirOzellikDegerId";
                drpKask.DataBind();
                drpKask.Items.Insert(0, lst);

                drpKatKar.DataSource = ozellikb.selectFieldList(11);
                drpKatKar.DataTextField = "deger";
                drpKatKar.DataValueField = "secilebilirOzellikDegerId";
                drpKatKar.DataBind();
                drpKatKar.Items.Insert(0, lst);

                if (Request.QueryString["page"] == "duzenle" && Request.QueryString["ilan"] != "")
                {
                    if (sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 11) != null)
                    {
                        drpKatKar.SelectedValue = sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 11).ozellikDegerId.ToString();
                    }

                    if (sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 9) != null)
                    {
                        drpKask.SelectedValue = sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 9).ozellikDegerId.ToString();
                    }

                    if (sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 10) != null)
                    {
                        drpGabari.SelectedValue = sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 10).ozellikDegerId.ToString();
                    }
                    

                    if (gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 12) != null)
                    {
                        txtMetreFiyat.Text = gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 12).deger;
                    }

                    if (gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 8) != null)
                    {
                        txtPaftaNo.Text = gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 8).deger;
                    }
                }
            }
        }
    }
}