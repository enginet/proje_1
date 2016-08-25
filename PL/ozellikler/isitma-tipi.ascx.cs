using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.ozellikler
{
    public partial class isitma_tipi : System.Web.UI.UserControl
    {
        ozellikBll ozellikb = new ozellikBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListItem lst = new ListItem();
                lst.Text = "Seçiniz";
                lst.Value = "";

                drpIsitmaTipi.DataSource = ozellikb.selectFieldList(56);
                drpIsitmaTipi.DataTextField = "deger";
                drpIsitmaTipi.DataValueField = "secilebilirOzellikDegerId";
                drpIsitmaTipi.DataBind();
                drpIsitmaTipi.Items.Insert(0, lst);

                secilebilirIlanOzellikBll sioBll = new secilebilirIlanOzellikBll();
                if (Request.QueryString["page"] == "duzenle" && Request.QueryString["ilan"] != "")
                {
                    if (sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 56) != null)
                    {
                        drpIsitmaTipi.SelectedValue = sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 56).ozellikDegerId.ToString();
                    }
                }
            }

        }
    }
}