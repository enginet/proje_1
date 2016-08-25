using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.ozellikler
{
    public partial class isitma : System.Web.UI.UserControl
    {
        ozellikBll ozellikb = new ozellikBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListItem lst = new ListItem();
                lst.Text = "Seçiniz";
                lst.Value = "";

                drpIsitma.DataSource = ozellikb.selectFieldList(55);
                drpIsitma.DataTextField = "deger";
                drpIsitma.DataValueField = "secilebilirOzellikDegerId";
                drpIsitma.DataBind();
                drpIsitma.Items.Insert(0, lst);

                secilebilirIlanOzellikBll sioBll = new secilebilirIlanOzellikBll();
                if (Request.QueryString["page"] == "duzenle" && Request.QueryString["ilan"] != "")
                {
                    if (sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 55) != null)
                    {
                        drpIsitma.SelectedValue = sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 55).ozellikDegerId.ToString();
                    }
                }
            }
        }
    }
}