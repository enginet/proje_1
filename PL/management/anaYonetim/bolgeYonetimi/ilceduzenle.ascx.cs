using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace PL.management.anaYonetim.bolgeYonetimi
{
    public partial class ilceduzenle : System.Web.UI.UserControl
    {
        ilBll il = new ilBll();
        ilceBll ilce = new ilceBll();
        kullaniciBll kullanicib = new kullaniciBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                drpIl.DataSource = il.list();
                drpIl.DataTextField = "ilAdi";
                drpIl.DataValueField = "ilId";
                drpIl.DataBind();

                ilceler _ilce = ilce.search(Convert.ToInt32(Request.QueryString["ilceId"]));
                txtIlce.Value = _ilce.ilceAdi;
                drpIl.SelectedValue = _ilce.ilId.ToString();


                onlineRepeater.DataSource = kullanicib.list(4);
                onlineRepeater.DataBind();
            }
        }

        protected void Kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                ilce.update(Request.QueryString["ilceId"], txtIlce.Value, drpIl.SelectedValue);
                Response.Redirect("~/management/anaYonetim/bolgeYonetimi/bolge.aspx?page=ilcelistele&ilId=" + drpIl.SelectedValue);
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void Vazgeç_Click(object sender, EventArgs e)
        {

        }
    }
}