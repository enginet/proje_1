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
    public partial class kisisel_bilgiler : System.Web.UI.UserControl
    {
        ilceBll ilceb = new ilceBll();
        mahalleBll mahalleb = new mahalleBll();
        kullaniciBll kll = new kullaniciBll();
        ilBll ilb = new ilBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["unique-site-user"] != null)
            {
                kullanici _authority = (kullanici)Session["unique-site-user"];

                if (!Page.IsPostBack)
                {
                    kullanici _kullanici = kll.search(_authority.kullaniciId);

                    drpIl.DataSource = ilb.list();
                    drpIl.DataTextField = "ilAdi";
                    drpIl.DataValueField = "ilId";
                    drpIl.DataBind();

                    drpIl.SelectedValue = _kullanici.ilId.ToString();

                    drpIlce.DataSource = ilceb.list(Convert.ToInt32(drpIl.SelectedValue));
                    drpIlce.DataTextField = "ilceAdi";
                    drpIlce.DataValueField = "ilceId";
                    drpIlce.DataBind();

                    drpIlce.SelectedValue = _kullanici.ilceId.ToString();

                    drpMahalle.DataSource = mahalleb.list(Convert.ToInt32(drpIlce.SelectedValue));
                    drpMahalle.DataTextField = "mahalleAdi";
                    drpMahalle.DataValueField = "mahalleId";
                    drpMahalle.DataBind();

                    drpMahalle.SelectedValue = _kullanici.mahalleId.ToString();


                    string[] adSoyad = DAL.toolkit.isimDondur(_kullanici.kullaniciAdSoyad);

                    txtAd.Value = adSoyad[0].ToString();
                    txtSoyad.Value = adSoyad[1].ToString();
                    txtKimlikNo.Value = _kullanici.tckimlikNo;
                    txtTarih.Value = _kullanici.dogumTarihi.ToString();

                    drpEgitim.SelectedValue = _kullanici.egitimDurumuId.ToString();
                    drpIl.SelectedValue = _kullanici.ilId.ToString();
                    rdCinsiyet.SelectedValue = _kullanici.cinsiyetId.ToString();
                }
            }
        }

        protected void drpIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpIlce.DataSource = ilceb.list(Convert.ToInt32(drpIl.SelectedValue));
            drpIlce.DataTextField = "ilceAdi";
            drpIlce.DataValueField = "ilceId";
            drpIlce.DataBind();

        }

        protected void drpIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpMahalle.DataSource = mahalleb.list(Convert.ToInt32(drpIlce.SelectedValue));
            drpMahalle.DataTextField = "mahalleAdi";
            drpMahalle.DataValueField = "mahalleId";
            drpMahalle.DataBind();
        }


        protected void Guncelle_Click(object sender, EventArgs e)
        {
            kullanici _authority = (kullanici)Session["unique-site-user"];

            //ad + soyad,şifre,email,il,ilçe,mahalle,krediSayısı,kimlikNo,egitimDurumu,Cinsiyet,rol(yetki)
            kll.update(
                    1,                              // Tüm bilgilerin güncellenmesi için kontrol değeri gönderiyoruz
                    _authority.kullaniciId,    // Hangi kullanıcının bilgilerinin güncellenmesi gerektiği bilgisini tutuyoruz
                    txtAd.Value + " " + txtSoyad.Value,
                    drpIl.SelectedValue,
                    drpIlce.SelectedValue,
                    drpMahalle.SelectedValue,
                    txtKimlikNo.Value,
                    drpEgitim.SelectedValue,
                    rdCinsiyet.SelectedValue,
                    txtTarih.Value,
                    4                  
                );
        }
    }
}
