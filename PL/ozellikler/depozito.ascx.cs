using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
namespace PL.ozellikler
{
    public partial class depozito : System.Web.UI.UserControl
    {
        ozellikBll ozellikb = new ozellikBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListItem lst = new ListItem();
                lst.Text = "Seçiniz";
                lst.Value = "";

                drpDepozito.DataSource = ozellikb.selectFieldList(36);
                drpDepozito.DataTextField = "deger";
                drpDepozito.DataValueField = "secilebilirOzellikDegerId";
                drpDepozito.DataBind();

                drpDepozito.Items.Insert(0, lst);

                secilebilirIlanOzellikBll sioBll = new secilebilirIlanOzellikBll();
                if (Request.QueryString["page"] == "duzenle" && Request.QueryString["ilan"] != "")
                {
                    if (sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 36) != null)
                    {
                        drpDepozito.SelectedValue = sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 36).ozellikDegerId.ToString();
                    }
                }
            }
        }
    }
}