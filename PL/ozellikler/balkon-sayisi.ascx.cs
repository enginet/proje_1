using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.ozellikler
{
    public partial class balkon_sayisi : System.Web.UI.UserControl
    {
        ozellikBll ozellikb = new ozellikBll();
        secilebilirIlanOzellikBll sioBll = new secilebilirIlanOzellikBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListItem lst = new ListItem();
                lst.Text = "Seçiniz";
                lst.Value = "";

                drpBalkonSayi.DataSource = ozellikb.selectFieldList(13);
                drpBalkonSayi.DataTextField = "deger";
                drpBalkonSayi.DataValueField = "secilebilirOzellikDegerId";
                drpBalkonSayi.DataBind();

                drpBalkonSayi.Items.Insert(0, lst);

                if (sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 13) != null)
                {
                    drpBalkonSayi.SelectedValue = sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 13).ozellikDegerId.ToString();
                }
            }
        }
    }
}