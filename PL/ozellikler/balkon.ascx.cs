using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.ozellikler
{
    public partial class balkon : System.Web.UI.UserControl
    {
        ozellikBll ozellikb = new ozellikBll();
        secilebilirIlanOzellikBll sioBll = new secilebilirIlanOzellikBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            ListItem lst = new ListItem();
            lst.Text = "Seçiniz";
            lst.Value = "";

            drpBalkon.DataSource = ozellikb.selectFieldList(14);
            drpBalkon.DataTextField = "deger";
            drpBalkon.DataValueField = "secilebilirOzellikDegerId";
            drpBalkon.DataBind();

            drpBalkon.Items.Insert(0, lst);


            if (sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 14) != null)
            {
                drpBalkon.SelectedValue = sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 14).ozellikDegerId.ToString();
            }
        }
    }
}