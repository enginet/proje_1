using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.management.anaYonetim.kategoriYonetimi
{
    public partial class listele : System.Web.UI.UserControl
    {
        kategoriBll kategori = new kategoriBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            kategoriRepeater.DataSource = kategori.list(Convert.ToInt32(Request.QueryString["kategoriId"]));
            kategoriRepeater.DataBind();
        }
    }
}