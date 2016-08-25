using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace PL.profil
{
    public partial class ansayfa : System.Web.UI.UserControl
    {

        ilanBll ilanb = new ilanBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["unique-site-user"] != null)
            {
                kullanici _authority = (kullanici)Session["unique-site-user"];
                if (ilanb.search(1, _authority.kullaniciId) != null)
                {
                    DAL.ilan _ilan = ilanb.search(1, _authority.kullaniciId);
                    txtid.InnerHtml = _ilan.ilanId.ToString();
                    hypBaslik.Text = _ilan.baslik;
                    txttarih.InnerHtml = _ilan.bitisTarihi.ToString();
                    txtkategori.InnerHtml = _ilan.kategori.kategoriAdi;
                    txtIl.InnerHtml = _ilan.iller.ilAdi;
                    lblUsername.Text = _authority.kullaniciAdSoyad;

                    enSonİlan.Visible = true;
                }
                else
                {
                    enSonİlan.Visible = false;
                }
            }
        }
    }
}