using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace PL.management.anaYonetim.magazaYonetimi
{
    public partial class ödeme : System.Web.UI.UserControl
    {
        magazaKategoriBll magazaKatb = new magazaKategoriBll();
        public string magazaFiyat;
        protected void Page_Load(object sender, EventArgs e)
        {
            magazaFiyat = Convert.ToDouble(magazaKatb.search(2, Request.QueryString["pac"]).fiyat).ToString();
        }

        protected void devam_Click(object sender, EventArgs e)
        {

        }
    }
}