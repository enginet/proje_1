using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.ozellikler
{
    public partial class konut_sekli : System.Web.UI.UserControl
    {
        ozellikBll ozellikb = new ozellikBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListItem lst = new ListItem();
                lst.Text = "Seçiniz";
                lst.Value = "";

                drpKonutSek.DataSource = ozellikb.selectFieldList(69);
                drpKonutSek.DataTextField = "deger";
                drpKonutSek.DataValueField = "secilebilirOzellikDegerId";
                drpKonutSek.DataBind();
                drpKonutSek.Items.Insert(0, lst);

                secilebilirIlanOzellikBll sioBll = new secilebilirIlanOzellikBll();
                if (Request.QueryString["page"] == "duzenle" && Request.QueryString["ilan"] != "")
                {
                    if (sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 69) != null)
                    {
                        drpKonutSek.SelectedValue = sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 69).ozellikDegerId.ToString();
                    }
                }
            }
        }
    }
}