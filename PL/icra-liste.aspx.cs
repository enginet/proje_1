using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL
{
    public partial class icra_liste : System.Web.UI.Page
    {
        kategoriTurBll ktgTurb = new kategoriTurBll();
        kategoriBll kategorib = new kategoriBll();
        ilanBll ilanb = new ilanBll();
        seciliDopingBll seciliDopingb = new seciliDopingBll();
        kategoriTurBll kategoriTurb = new kategoriTurBll();
        girilebilirIlanOzellikBll girilenb = new girilebilirIlanOzellikBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["kategoriId"] != null && Request.QueryString["tur"] != null)
                {
                    kategoriRepeater.DataSource = ktgTurb.list(2, Request.QueryString["kategoriId"], Request.QueryString["tur"]);
                    kategoriRepeater.DataBind();
                }


                ustStr.InnerText = kategorib.search(Convert.ToInt32(kategorib.search(Convert.ToInt32(Request.QueryString["kategoriId"])).ustKategoriId)).kategoriAdi;
                altStr.InnerText = kategorib.search(Convert.ToInt32(Request.QueryString["kategoriId"])).kategoriAdi;

                if (Request.QueryString["kategoriId"] != "4" & Request.QueryString["sub"] == null)
                {
                    ilanRepeater.DataSource = ilanb.list_admin(9, 2, Request.QueryString["kategoriId"], Request.QueryString["tur"], 2);
                    ilanRepeater.DataBind();

                }

                if (catKind(Request.QueryString["kategoriId"]) != true)
                {
                    ilanRepeater.DataSource = ilanb.list_admin(8, 2, Request.QueryString["kategoriId"], 2);
                    ilanRepeater.DataBind();
                }

            }

            if ((Request.QueryString["sub"] != null || Request.QueryString["kategoriId"] == "4"))
            {
                ilanRepeater.DataSource = ilanb.list_admin(8, 2, Request.QueryString["sub"], Request.QueryString["tur"], 2);
                ilanRepeater.DataBind();

            }
        }

        public bool doping_Tur(object _income, int _id)
        {
            if (seciliDopingb.search(_income, _id) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string degerDondur(object _income, int _id)
        {
            return girilenb.search(Convert.ToInt32(_income), _id).deger.ToString();
        }

        public bool catKind(object _income)
        {
            if (kategoriTurb.search(Convert.ToInt32(_income)) != null)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public string fiyat_Tur(object _income)
        {

            if (Convert.ToInt32(_income) == 1)
            {
                return " &#x20BA;";
            }
            else if (Convert.ToInt32(_income) == 2)
            {
                return " $";
            }
            else
            {
                return " €";
            }

        }
    }
}
