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
    public partial class mahalleduzenle : System.Web.UI.UserControl
    {

        ilBll il = new ilBll();
        ilceBll ilce = new ilceBll();
        mahalleBll mahalle = new mahalleBll();
        kullaniciBll kullanicib = new kullaniciBll();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                mahalleler _mahalle = mahalle.search(Convert.ToInt32(Request.QueryString["mahalleId"]));
                txtMahalle.Value = _mahalle.mahalleAdi;


                ilceler _ilce = ilce.search(Convert.ToInt32(Request.QueryString["ilceId"]));

                drpIl.DataSource = il.list();
                drpIl.DataTextField = "ilAdi";
                drpIl.DataValueField = "ilId";
                drpIl.DataBind();

                drpIl.SelectedValue = _mahalle.ilceler.ilId.ToString();

                drpIlce.DataSource = ilce.list(Convert.ToInt32(Request.QueryString["ilId"]));
                drpIlce.DataTextField = "ilceAdi";
                drpIlce.DataValueField = "ilceId";
                drpIlce.DataBind();

                drpIlce.SelectedValue = _mahalle.ilceId.ToString();

                onlineRepeater.DataSource = kullanicib.list(4);
                onlineRepeater.DataBind();
            }

        }

        protected void drpIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpIlce.Items.Clear();

            drpIlce.DataSource = ilce.list(Convert.ToInt32(drpIl.SelectedValue));
            drpIlce.DataTextField = "ilceAdi";
            drpIlce.DataValueField = "ilceId";
            drpIlce.DataBind();

            ListItem lst = new ListItem();
            lst.Value = null;
            lst.Text = "İlçe Seçiniz";
            lst.Selected = true;

            drpIlce.Items.Insert(0, lst);
        }

        protected void Kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                mahalle.update(Request.QueryString["mahalleId"], txtMahalle.Value, drpIlce.SelectedValue);
                ilce.update(Request.QueryString["ilceId"], drpIlce.SelectedItem.Text, drpIl.SelectedValue);
                Response.Redirect("~/management/anaYonetim/bolgeYonetimi/bolge.aspx?page=mahallelistele&ilceId=" + drpIlce.SelectedValue);
            }
            catch (Exception)
            {

                throw;
            }
            ;
        }

        protected void Vazgec_Click(object sender, EventArgs e)
        {

        }
    }
}