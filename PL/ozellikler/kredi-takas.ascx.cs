using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.ozellikler
{
    public partial class kredi_takas : System.Web.UI.UserControl
    {
        ozellikBll ozellikb = new ozellikBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListItem lst = new ListItem();
                lst.Text = "Seçiniz";
                lst.Value = "";

                drpTakasli.DataSource = ozellikb.selectFieldList(105);
                drpTakasli.DataTextField = "deger";
                drpTakasli.DataValueField = "secilebilirOzellikDegerId";
                drpTakasli.DataBind();
                drpTakasli.Items.Insert(0, lst);

                secilebilirIlanOzellikBll sioBll = new secilebilirIlanOzellikBll();
                if (Request.QueryString["page"] == "duzenle" && Request.QueryString["ilan"] != "")
                {
                    if (sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 105) != null)
                    {
                        drpTakasli.SelectedValue = sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 105).ozellikDegerId.ToString();
                    }

                    if (sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 72) != null)
                    {
                        if(sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 72).ozellikDegerId.ToString()=="295")
                            chcKredi.Checked=true;
                    }
                }
            }
        }
    }
}