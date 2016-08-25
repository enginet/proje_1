using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.ozellikler
{
    public partial class yakit_tipi : System.Web.UI.UserControl
    {
        ozellikBll ozellikb = new ozellikBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListItem lst = new ListItem();
                lst.Text = "Seçiniz";
                lst.Value = "";

                drpYakitTip.DataSource = ozellikb.selectFieldList(99);
                drpYakitTip.DataTextField = "deger";
                drpYakitTip.DataValueField = "secilebilirOzellikDegerId";
                drpYakitTip.DataBind();
                drpYakitTip.Items.Insert(0, lst);
                drpYakitTip.Items.Insert(0, lst);

                secilebilirIlanOzellikBll sioBll = new secilebilirIlanOzellikBll();
                if (Request.QueryString["page"] == "duzenle" && Request.QueryString["ilan"] != "")
                {
                    if (sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 99) != null)
                    {
                        drpYakitTip.SelectedValue = sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 99).ozellikDegerId.ToString();
                    }
                }
            }
        }
    }
}