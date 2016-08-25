using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.management.anaYonetim.bolgeYonetimi
{
    public partial class mahalleekle : System.Web.UI.UserControl
    {
        ilBll il = new ilBll();
        ilceBll ilce = new ilceBll();
        mahalleBll mahalle = new mahalleBll();
        kullaniciBll kullanicib = new kullaniciBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                drpIl.DataSource = il.list();
                drpIl.DataTextField = "ilAdi";
                drpIl.DataValueField = "ilId";
                drpIl.DataBind();

                drpIl.SelectedValue = Request.QueryString["ilId"];

                drpIlce.DataSource = ilce.list(Convert.ToInt32(drpIl.SelectedValue));
                drpIlce.DataTextField = "ilceAdi";
                drpIlce.DataValueField = "ilceId";
                drpIlce.DataBind();

                drpIlce.SelectedValue = Request.QueryString["ilceId"];
                drpIl.Enabled = false;
                drpIlce.Enabled = false;

                onlineRepeater.DataSource = kullanicib.list(4);
                onlineRepeater.DataBind();

            }
        }

        protected void drpIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpIlce.DataSource = ilce.list(Convert.ToInt32(drpIl.SelectedValue));
            drpIlce.DataTextField = "ilceAdi";
            drpIlce.DataValueField = "ilceId";
            drpIlce.DataBind();
        }

        protected void Kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                mahalle.insert(txtMahalle.Value, drpIlce.SelectedValue);
                Response.Redirect("~/management/anaYonetim/bolgeYonetimi/bolge.aspx?page=mahallelistele&ilceId=" + drpIlce.SelectedValue);
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