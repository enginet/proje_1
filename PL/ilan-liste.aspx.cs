using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using System.Web.Security;


namespace PL
{
    public partial class ilan_liste : System.Web.UI.Page
    {
        kategoriTurBll ktgTurb = new kategoriTurBll();
        kategoriBll kategorib = new kategoriBll();
        ilanBll ilanb = new ilanBll();
        seciliDopingBll seciliDopingb = new seciliDopingBll();
        kategoriTurBll kategoriTurb = new kategoriTurBll();
        girilebilirIlanOzellikBll girilenb = new girilebilirIlanOzellikBll();
        magazaBll magazab = new magazaBll();
        araBll arab = new araBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if(Request.QueryString["sea"]!=null)
                {
                    ilanRepeater.DataSource = arab.list(Request.QueryString["sea"]);
                    ilanRepeater.DataBind();



                }

                if (Request.QueryString["kategoriId"] != null && Request.QueryString["tur"] != null)
                {
                    kategoriRepeater.DataSource = ktgTurb.list(2, Request.QueryString["kategoriId"], Request.QueryString["tur"]);
                    kategoriRepeater.DataBind();
                }

                if (kategorib.search(Convert.ToInt32(kategorib.search(Convert.ToInt32(Request.QueryString["kategoriId"])).ustKategoriId))!= null)
                {
                    ustStr.InnerText = kategorib.search(Convert.ToInt32(kategorib.search(Convert.ToInt32(Request.QueryString["kategoriId"])).ustKategoriId)).kategoriAdi;
                }
                if (kategorib.search(Convert.ToInt32(Request.QueryString["kategoriId"]))!=null)
                {
                    altStr.InnerText = kategorib.search(Convert.ToInt32(Request.QueryString["kategoriId"])).kategoriAdi;
                }
                if (Request.QueryString["kategoriId"] != "4" & Request.QueryString["sub"] == null)
                {
                    ilanRepeater.DataSource = ilanb.list_admin(9, 3, Request.QueryString["kategoriId"], Request.QueryString["tur"]);
                    ilanRepeater.DataBind();

                }

                if (catKind(Request.QueryString["kategoriId"]) != true)
                {
                    ilanRepeater.DataSource = ilanb.list_admin(8, 4, Request.QueryString["kategoriId"]);
                    ilanRepeater.DataBind();
                }

            }

            if ((Request.QueryString["sub"] != null || Request.QueryString["kategoriId"] == "4"))
            {
                ilanRepeater.DataSource = ilanb.list_admin(8, 3, Request.QueryString["sub"], Request.QueryString["tur"]);
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

        public bool krediKontrol(object _income)
        {
            magaza _magaza= magazab.search(Convert.ToInt32(_income));

            if (Session["unique-site-user"] != null)
            {
                kullanici _authority = (kullanici)Session["unique-site-user"];

                if (_magaza.magazaTur.turId == 6 && _authority.kredi > 0)
                {
                    return true;
                }
                else if(_income.ToString() == null)
                {
                    return true;
                }
                else if(Convert.ToInt32(_income) == 7)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (_income.ToString() == null)
                {
                    return true;
                }
                else if (Convert.ToInt32(_income) == 7)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string degerDondur(object _income, int _id)
        {
            return girilenb.search(Convert.ToInt32(_income), _id).deger.ToString();
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("sahibinden-liste.aspx");
        }
    }
}