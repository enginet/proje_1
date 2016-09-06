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
        public string sellerProfil = "";
        public string classifiedPic = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["unique-site-user"] != null)
            {
                kullanici _authority = (kullanici)Session["unique-site-user"];
                if (ilanb.search(1, _authority.kullaniciId) != null)
                {
                    DAL.ilan _ilan = ilanb.search(1, _authority.kullaniciId);
                    Label1.Text = _ilan.ilanId.ToString();
                    hypBaslik.Text = _ilan.baslik;
                    txttarih.InnerHtml = _ilan.bitisTarihi.ToString();
                    txtkategori.InnerHtml = _ilan.kategori.kategoriAdi;
                    txtIl.InnerHtml = _ilan.iller.ilAdi;
                    lblFiyat.Text = _ilan.fiyat.ToString();
                    lblFiyatTur.Text = DAL.toolkit.fiyat_Tur(_ilan.fiyatTurId);

                    lblUsername.Text = _authority.kullaniciAdSoyad;
                    sellerProfil = _authority.profilResim;
                    classifiedPic = _ilan.ilanResims.Where(i => i.seciliMi == true).FirstOrDefault().resim;
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