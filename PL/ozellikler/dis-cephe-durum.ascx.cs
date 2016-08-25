using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.ozellikler
{
    public partial class dis_cephe_durum : System.Web.UI.UserControl
    {
        ozellikBll ozellikb = new ozellikBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListItem lst = new ListItem();
                lst.Text = "Seçiniz";
                lst.Value = "";

                drpDisCephe.DataSource = ozellikb.selectFieldList(42);
                drpDisCephe.DataTextField = "deger";
                drpDisCephe.DataValueField = "secilebilirOzellikDegerId";
                drpDisCephe.DataBind();
                drpDisCephe.Items.Insert(0, lst);

                secilebilirIlanOzellikBll sioBll = new secilebilirIlanOzellikBll();
                if (Request.QueryString["page"] == "duzenle" && Request.QueryString["ilan"] != "")
                {
                    if (sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 42) != null)
                    {
                        drpDisCephe.SelectedValue = sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 42).ozellikDegerId.ToString();
                    }
                }
            }
        }
    }
}