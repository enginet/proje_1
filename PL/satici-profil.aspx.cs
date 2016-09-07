using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace PL
{
    public partial class satici_profil : System.Web.UI.Page
    {
        ilanBll ilanb = new ilanBll();
        telefonBll telefonb = new telefonBll();
        kullaniciTakipciBll kulllaniciTkpb = new kullaniciTakipciBll();
        magazaBll magazab = new magazaBll();
        magazaTelefonBll magazaTlfb = new magazaTelefonBll();
        magazaKullaniciBll magazaKllb = new magazaKullaniciBll();
        magazaTakipciBll magazaTakipb = new magazaTakipciBll();
        seciliDopingBll seciliDopingb = new seciliDopingBll();
        kullaniciBll kullanicib = new kullaniciBll();
        int saticiId;

        protected void Page_Load(object sender, EventArgs e)
        {
            saticiId = Convert.ToInt32(Request.QueryString["seller"]);
            ilanRepeater.DataSource = ilanb.list(4, saticiId);
            ilanRepeater.DataBind();

            DAL.kullanici _kullanici = kullanicib.search(saticiId);
            lblSellerName.Text = _kullanici.kullaniciAdSoyad;

            telefonRepeater.DataSource = telefonb.list(2, _kullanici.kullaniciId);
            telefonRepeater.DataBind();

            takipciRepeater.DataSource = kulllaniciTkpb.list(3,_kullanici.kullaniciId);
            takipciRepeater.DataBind();

            takipEdilenRepeater.DataSource = kulllaniciTkpb.list(4, _kullanici.kullaniciId);
            takipEdilenRepeater.DataBind();

            if (kulllaniciTkpb.search(3, _kullanici.kullaniciId) != null)
            {
                LinkButton1.Visible = false;
            }
            else
            {
                LinkButton2.Visible = false;
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            DAL.kullanici _kullanici = kullanicib.search(saticiId);
            if (Session["unique-site-user"] != null)
            {
                kullanici _authority = (kullanici)Session["unique-site-user"];

                kulllaniciTkpb.insert(_kullanici.kullaniciId, _authority.kullaniciId);
                LinkButton1.Visible = false;
            }

        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            DAL.kullanici _kullanici = kullanicib.search(saticiId);
            if (Session["unique-site-user"] != null)
            {
                kullanici _authority = (kullanici)Session["unique-site-user"];
                kulllaniciTkpb.delete(_kullanici.kullaniciId, _authority.kullaniciId);
                LinkButton2.Visible = false;
            }
        }

        public string telefonTurDondur(object _income)
        {
            if (Convert.ToInt32(_income) == 1)
            {
                return "Cep";
            }
            else if (Convert.ToInt32(_income) == 2)
            {
                return "Cep 2";
            }
            else if (Convert.ToInt32(_income) == 3)
            {
                return "İş";
            }
            else if (Convert.ToInt32(_income) == 4)
            {
                return "İş 2";
            }
            else
            {
                return "Cep";
            }
        }
    }
}