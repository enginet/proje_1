using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace PL.management.anaYonetim.kullaniciYonetimi
{
    public partial class duzenle : System.Web.UI.UserControl
    {
        kullaniciBll kll = new kullaniciBll();
        telefonBll tlf = new telefonBll();
        ilBll il = new ilBll();
        ilceBll ilce = new ilceBll();
        mahalleBll mahalle = new mahalleBll();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                // Tüm bilgiler çekildi
                kullanici _kullanici = kll.search(Convert.ToInt32(Request.QueryString["user"]));
                //telefonlar _tlfd = tlf.search(Convert.ToInt32(Request.QueryString["user"]));

                drpIl.DataSource = il.list();
                drpIl.DataTextField = "ilAdi";
                drpIl.DataValueField = "ilId";
                drpIl.DataBind();

                drpIl.SelectedValue = _kullanici.ilId.ToString();

                drpIlce.DataSource = ilce.list(Convert.ToInt32(drpIl.SelectedValue));
                drpIlce.DataTextField = "ilceAdi";
                drpIlce.DataValueField = "ilceId";
                drpIlce.DataBind();

                drpIlce.SelectedValue = _kullanici.ilceId.ToString();

                drpMahalle.DataSource = mahalle.list(Convert.ToInt32(drpIlce.SelectedValue));
                drpMahalle.DataTextField = "mahalleAdi";
                drpMahalle.DataValueField = "mahalleId";
                drpMahalle.DataBind();

                drpMahalle.SelectedValue = _kullanici.mahalleId.ToString();


                string[] adSoyad = DAL.toolkit.isimDondur(_kullanici.kullaniciAdSoyad);

                txtAd.Text = adSoyad[0].ToString();
                txtSoyad.Text = adSoyad[1].ToString();
                txtSifre.Text = _kullanici.sifre;
                txtEmail.Text = _kullanici.email;
                txtKrediSayi.Text = _kullanici.kredi.ToString();
                txtKimlikNo.Text = _kullanici.tckimlikNo;


                drpEgitim.SelectedValue = _kullanici.egitimDurumuId.ToString();
                drpIl.SelectedValue = _kullanici.ilId.ToString();
                drpYetki.SelectedValue = _kullanici.rol.ToString();

                rdCinsiyet.SelectedValue = _kullanici.cinsiyetId.ToString();

                //Telefon güncelleme işlemi yapılacak

                telefonlar _tlfd = tlf.search(Convert.ToInt32(Request.QueryString["user"]),1);
                if(_tlfd != null)
                    txtGsm1.Text = _tlfd.telefon;
                telefonlar _tlfd1 = tlf.search(Convert.ToInt32(Request.QueryString["user"]), 3);
                if (_tlfd1 != null)
                    txtSabit.Text = _tlfd1.telefon;

                onlineRepeater.DataSource = kll.list(4);
                onlineRepeater.DataBind();
            }
        }

        protected void Kaydet_Click(object sender, EventArgs e)
        {
            int il = Convert.ToInt32(drpIl.SelectedValue.ToString());
            int ilce = Convert.ToInt32(drpIlce.SelectedValue.ToString());
            int mahalle = Convert.ToInt32(drpMahalle.SelectedValue.ToString());
            int yetki = Convert.ToInt32(drpYetki.SelectedValue.ToString());
            int egitim = Convert.ToInt32(drpEgitim.SelectedValue.ToString());
            bool cinsiyet = Convert.ToBoolean(rdCinsiyet.SelectedValue);
            string isim = txtAd.Text + " " + txtSoyad.Text;


            //ad + soyad,şifre,email,il,ilçe,mahalle,krediSayısı,kimlikNo,egitimDurumu,Cinsiyet,rol(yetki)
            kll.update(
                    1,                              // Tüm bilgilerin güncellenmesi için kontrol değeri gönderiyoruz
                    Request.QueryString["user"],    // Hangi kullanıcının bilgilerinin güncellenmesi gerektiği bilgisini tutuyoruz
                    isim,
                    txtSifre.Text,
                    txtEmail.Text,
                    il,
                    ilce,
                    mahalle,
                    Convert.ToInt32(txtKrediSayi.Text),
                    txtKimlikNo.Text,
                    egitim,
                    cinsiyet,
                    yetki
                );

            if(txtGsm1.Text!="")
            {
                tlf.update(Request.QueryString["user"], txtGsm1.Text, 1);
            }
            else
            {
                // burda uyarı verilecek
            }
            //if(txtGsm2.Text!="")
            //{
            //    tlf.update(Request.QueryString["user"], txtGsm2.Text, 2);
            //}
            //else
            //{
            //    tlf.deleteTlf(Request.QueryString["user"], 2);
            //}
            if(txtSabit.Text!="")
            {
                tlf.update(Request.QueryString["user"], txtSabit.Text, 3);
            }
            else
            {
                tlf.deleteTlf(Request.QueryString["user"], 3);
            }
            Response.Redirect("~/management/anaYonetim/kullaniciYonetimi/kullanici.aspx?page=listele");
        }

        protected void Vazgec_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/management/anaYonetim/kullaniciYonetimi/kullanici.aspx?page=listele");
        }

        protected void drpIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpIlce.Items.Clear();
            drpMahalle.Items.Clear();

            drpIlce.DataSource = ilce.list(Convert.ToInt32(drpIl.SelectedValue));
            drpIlce.DataTextField = "ilceAdi";
            drpIlce.DataValueField = "ilceId";
            drpIlce.DataBind();

            ListItem lst = new ListItem();
            lst.Value = null;
            lst.Text = "İlçe Seçiniz";
            lst.Selected = true;

            drpIlce.Items.Insert(0, lst);
        }

        protected void drpIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpMahalle.Items.Clear();

            drpMahalle.DataSource = mahalle.list(Convert.ToInt32(drpIlce.SelectedValue));
            drpMahalle.DataTextField = "mahalleAdi";
            drpMahalle.DataValueField = "mahalleId";
            drpMahalle.DataBind();

            ListItem lst = new ListItem();
            lst.Value = null;
            lst.Text = "Mahalle Seçiniz";
            lst.Selected = true;

            drpMahalle.Items.Insert(0, lst);

        }
    }
}