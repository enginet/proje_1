using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.management.genelAyarlar
{
    public partial class ilanucretayar : System.Web.UI.UserControl
    {
        ilanUcretBll ilanUcretb = new ilanUcretBll();
        kategoriBll kategorib = new kategoriBll();


        protected void Page_Load(object sender, EventArgs e)
        {
            drpKategori.DataSource = kategorib.list(0);
            drpKategori.DataTextField = "kategoriAdi";
            drpKategori.DataValueField = "kategoriId";
            drpKategori.DataBind();

            ListItem lst = new ListItem();
            lst.Value = null;
            lst.Text = "Kategori Seçiniz";
            lst.Selected = true;

            drpKategori.Items.Insert(0, lst);

        }
        protected void Kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                ilanUcretb.update(drpKategori.SelectedValue, txtFiyat.Value);

            }
            catch (Exception)
            {

                Response.Redirect("~/management/diger/diger.aspx?page=500");

            }
        }

        protected void Vazgec_Click(object sender, EventArgs e)
        {

        }
    }
}