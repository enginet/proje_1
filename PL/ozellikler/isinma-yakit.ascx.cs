using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.ozellikler
{
    public partial class isinma_yakit : System.Web.UI.UserControl
    {
        ozellikBll ozellikb = new ozellikBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListItem lst = new ListItem();
                lst.Text = "Seçiniz";
                lst.Value = "";

                drpYakitTipi.DataSource = ozellikb.selectFieldList(54);
                drpYakitTipi.DataTextField = "deger";
                drpYakitTipi.DataValueField = "secilebilirOzellikDegerId";
                drpYakitTipi.DataBind();
                drpYakitTipi.Items.Insert(0, lst);

                drpIsitmaTip.DataSource = ozellikb.selectFieldList(53);
                drpIsitmaTip.DataTextField = "deger";
                drpIsitmaTip.DataValueField = "secilebilirOzellikDegerId";
                drpIsitmaTip.DataBind();
                drpIsitmaTip.Items.Insert(0, lst);


                secilebilirIlanOzellikBll sioBll = new secilebilirIlanOzellikBll();
                if (Request.QueryString["page"] == "duzenle" && Request.QueryString["ilan"] != "")
                {
                    if (sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 53) != null)
                    {
                        drpIsitmaTip.SelectedValue = sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 53).ozellikDegerId.ToString();
                    }
                    if (sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 54) != null)
                    {
                        drpYakitTipi.SelectedValue = sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 54).ozellikDegerId.ToString();
                    }
                }
            }
        }
    }
}