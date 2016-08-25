using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.ozellikler
{
    public partial class zemin_etudu : System.Web.UI.UserControl
    {
        ozellikBll ozellikb = new ozellikBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListItem lst = new ListItem();
                lst.Text = "Seçiniz";
                lst.Value = "";

                drpZeminEtudu.DataSource = ozellikb.selectFieldList(104);
                drpZeminEtudu.DataTextField = "deger";
                drpZeminEtudu.DataValueField = "secilebilirOzellikDegerId";
                drpZeminEtudu.DataBind();
                drpZeminEtudu.Items.Insert(0, lst);

                secilebilirIlanOzellikBll sioBll = new secilebilirIlanOzellikBll();
                if (Request.QueryString["page"] == "duzenle" && Request.QueryString["ilan"] != "")
                {
                    if (sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 104) != null)
                    {
                        drpZeminEtudu.SelectedValue = sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 104).ozellikDegerId.ToString();
                    }
                }
            }
        }
    }
}