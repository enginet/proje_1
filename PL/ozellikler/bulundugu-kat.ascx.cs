using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.ozellikler
{
    public partial class bulundugu_kat : System.Web.UI.UserControl
    {
        ozellikBll ozellikb = new ozellikBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListItem lst = new ListItem();
                lst.Text = "Seçiniz";
                lst.Value = "";

                drpBulKat.DataSource = ozellikb.selectFieldList(26);
                drpBulKat.DataTextField = "deger";
                drpBulKat.DataValueField = "secilebilirOzellikDegerId";
                drpBulKat.DataBind();
                drpBulKat.Items.Insert(0, lst);

                secilebilirIlanOzellikBll sioBll = new secilebilirIlanOzellikBll();
                if (Request.QueryString["page"] == "duzenle" && Request.QueryString["ilan"] != "")
                {
                    if (sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 26) != null)
                    {
                        drpBulKat.SelectedValue = sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 26).ozellikDegerId.ToString();
                    }
                }
            }
        }
    }
}