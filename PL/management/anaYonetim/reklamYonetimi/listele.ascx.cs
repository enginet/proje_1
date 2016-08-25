using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace PL.management.anaYonetim.reklamYonetimi
{
    public partial class listele : System.Web.UI.UserControl
    {
        ilanDataContext idc = new ilanDataContext();

        verilenReklamBll reklam = new verilenReklamBll();

        ilBll ilb = new ilBll();
        public string tip;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["advertisement"] != null)
            {
                if (Request.QueryString["tip"] == "1")
                {
                    reklam.update(2, Request.QueryString["advertisement"], false,true); // onaylama işlemini yapıyoruz
                }
                if (Request.QueryString["tip"] == "2")
                {
                    reklam.update(2, Request.QueryString["advertisement"], true,false); // pasif=true işlemini yapıyoruz
                }
                if (Request.QueryString["tip"] == "3")
                {
                    reklam.update(2, Request.QueryString["advertisement"], false,false); // pasif=false işlemini yapıyoruz
                }
            }

            // 1 onay bekleyen reklamlar
            // 2 aktif reklamlar
            // 3 pasif reklamlar
            if(Request.QueryString["tip"]=="1")
            {
                reklamRepeater.DataSource = reklam.list(1,false,false);
                tip = "1";
            }
            if (Request.QueryString["tip"] == "2")
            {
                reklamRepeater.DataSource = reklam.list(1,false, true);
                tip = "2";
            }
            if (Request.QueryString["tip"] == "3")
            {
                reklamRepeater.DataSource = reklam.list(1,true, false);
                tip = "3";
            }
            reklamRepeater.DataBind();
        }

        public string turDondur(int id)
        {
            string tur = "";

            if(id==1)
            {
                tur = "Site İçi";
            }
            else
            {
                tur = "Harita Çevresi";
            }
            return tur;
        }

        public string konumDondur(int id)
        {
            string konum = "";

            if (id == 1)
            {
                konum = "Anasayfa - 728 * 90";
            }
            else if(id==2)
            {
                konum = "Anasayfa - Sağ Üst 230 * 230";
            }
            else if (id == 3)
            {
                konum = "Anasayfa - Sağ Alt 230 * 230";
            }
            else if (id == 4)
            {
                konum = "Liste - 728 * 90";
            }
            else if (id == 5)
            {
                konum = "Detay - 230 * 230";
            }
            else
            {
                konum = "-";
            }
            return konum;
        }

        public string ilDondur(object id)
        {
            if(id !=null)
            {
                DAL.iller il = ilb.search(Convert.ToInt32(id));
                return il.ilAdi;
            }
            else
            {
                return "-";
            }
        }
    }
}