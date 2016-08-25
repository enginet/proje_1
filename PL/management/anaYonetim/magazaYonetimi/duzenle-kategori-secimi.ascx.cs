using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.management.anaYonetim.magazaYonetimi
{
    public partial class duzenle_kategori_secimi : System.Web.UI.UserControl
    {
        kategoriBll kategorib = new kategoriBll();
        magazaBll magazab = new magazaBll();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["edit"] != null)
            {
                if (!Page.IsPostBack)
                {
                    rdKategori.DataSource = kategorib.list(0);
                    rdKategori.DataTextField = "kategoriAdi";
                    rdKategori.DataValueField = "kategoriId";
                    rdKategori.DataBind();
                }

                rdKategori.SelectedValue = magazab.search(Convert.ToInt32(Request.QueryString["edit"])).magazaKategori.kategoriId.ToString();
            }
        }


        protected void devam_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/management/anaYonetim/magazaYonetimi/magaza.aspx?page=duzenle-magaza-tipi&edit=" + Request.QueryString["edit"] + "&cat=" + rdKategori.SelectedValue);
        }
    }
}