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
        public string magazaPaket;
        protected void Page_Load(object sender, EventArgs e)
        {
            magazaKategori _magazaKat = magazaKatb.search(2, Request.QueryString["pac"]);
            if (_magazaKat.paketSureId == 1)
            {

                magazaFiyat = Convert.ToDouble(_magazaKat.fiyat * 6).ToString();
                if (_magazaKat.paketSureId == 1)
                {
                    magazaPaket = "6 Aylık Standart";
                }
                else
                {
                    magazaPaket = "6 Aylık Premium";

                }
            }
            else
            {
                magazaFiyat = Convert.ToDouble(_magazaKat.fiyat * 12).ToString();
                if (_magazaKat.paketSureId == 1)
                {
                    magazaPaket = "12 Aylık Standart";
                }
                else
                {
                    magazaPaket = "12 Aylık Premium";

                }
            }
        }

        protected void devam_Click(object sender, EventArgs e)
        {

        }
    }
}