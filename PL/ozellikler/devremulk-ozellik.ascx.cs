using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.ozellikler
{
    public partial class devremulk_ozellik : System.Web.UI.UserControl
    {
        ozellikBll ozellikb = new ozellikBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListItem lst = new ListItem();
                lst.Text = "Seçiniz";
                lst.Value = "";

                drpDonem.DataSource = ozellikb.selectFieldList(39);
                drpDonem.DataTextField = "deger";
                drpDonem.DataValueField = "secilebilirOzellikDegerId";
                drpDonem.DataBind();
                drpDonem.Items.Insert(0, lst);


                drpTipi.DataSource = ozellikb.selectFieldList(41);
                drpTipi.DataTextField = "deger";
                drpTipi.DataValueField = "secilebilirOzellikDegerId";
                drpTipi.DataBind();
                drpTipi.Items.Insert(0, lst);

                drpSure.DataSource = ozellikb.selectFieldList(40);
                drpSure.DataTextField = "deger";
                drpSure.DataValueField = "secilebilirOzellikDegerId";
                drpSure.DataBind();
                drpSure.Items.Insert(0, lst);

                secilebilirIlanOzellikBll sioBll = new secilebilirIlanOzellikBll();
                if (Request.QueryString["page"] == "duzenle" && Request.QueryString["ilan"] != "")
                {
                    if (sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 39) != null)
                    {
                        drpDonem.SelectedValue = sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 39).ozellikDegerId.ToString();
                    }
                    if (sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 40) != null)
                    {
                        drpSure.SelectedValue = sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 40).ozellikDegerId.ToString();
                    }
                    if (sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 41) != null)
                    {
                        drpTipi.SelectedValue = sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 41).ozellikDegerId.ToString();
                    }

                    girilebilirIlanOzellikBll gio = new girilebilirIlanOzellikBll();
                    if (gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 83) != null)
                    {
                        txtOdaSayisi.Text = gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 83).deger;
                    }
                }

            }
        }
    }
}