using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.management.anaYonetim.kategoriYonetimi
{
    public partial class ekle : System.Web.UI.UserControl
    {
        kategoriBll kategori = new kategoriBll();

        protected void Kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                kategori.insert(txtKategori.Value, Request.QueryString["kategoriId"]);
                Response.Redirect("~/management/anaYonetim/kategoriYonetimi/kategoriler.aspx?page=listele&kategoriId=" + Request.QueryString["kategoriId"]);
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