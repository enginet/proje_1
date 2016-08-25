using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace PL.management.anaYonetim.kategoriYonetimi
{
    public partial class duzenle : System.Web.UI.UserControl
    {
        kategoriBll kategorib = new kategoriBll();

        protected void Page_Load(object sender, EventArgs e)
        {

            kategori _kategori = kategorib.search(Convert.ToInt32(Request.QueryString["kategoriId"]));
            txtKategori.Value = _kategori.kategoriAdi;

        }

        protected void Kaydet_Click(object sender, EventArgs e)
        {
            kategori _kategori = kategorib.search(Convert.ToInt32(Request.QueryString["kategoriId"]));

            try
            {
                kategorib.update(Request.QueryString["kategoriId"], txtKategori.Value);
                Response.Redirect("~/management/anaYonetim/kategoriYonetimi/kategoriler.aspx?page=listele&kategoriId=" + _kategori.ustKategoriId);

            }
            catch (Exception)
            {

                throw;
            }
            }

        protected void Vazgec_Click(object sender, EventArgs e)
        {

        }
    }
}