using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.ozellikler
{
    public partial class apart_sayisi : System.Web.UI.UserControl
    {
        ozellikBll ozellikb = new ozellikBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ListItem lst = new ListItem();
                lst.Text = "Seçiniz";
                lst.Value = "";

                drpApartSayisi.DataSource = ozellikb.selectFieldList(7);
                drpApartSayisi.DataTextField = "deger";
                drpApartSayisi.DataValueField = "secilebilirOzellikDegerId";
                drpApartSayisi.DataBind();
                drpApartSayisi.Items.Insert(0, lst);

                secilebilirIlanOzellikBll sioBll = new secilebilirIlanOzellikBll();
                if (Request.QueryString["page"] == "duzenle" && Request.QueryString["ilan"] != "")
                {
                    if (sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 7) != null)
                    {
                        drpApartSayisi.SelectedValue = sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 7).ozellikDegerId.ToString();
                    }
                }
            }
        }
    }
}