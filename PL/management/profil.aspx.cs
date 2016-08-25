using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;

namespace PL.management
{
    public partial class profil : System.Web.UI.Page
    {
        kullaniciBll kullanicib = new kullaniciBll();
        telefonBll telefonb = new telefonBll();
        ilBll il = new ilBll();
        ilceBll ilce = new ilceBll();
        mahalleBll mahalle = new mahalleBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["boss"] != null)
            {
                if (!Page.IsPostBack)
                {
                    kullanici _authority = (kullanici)Session["boss"];
                    HttpRequest _request = base.Request;
                    kullanici _kullanici = kullanicib.search(_authority.kullaniciId);
                    txtAd.Text = DAL.toolkit.isimDondur(_kullanici.kullaniciAdSoyad)[0];
                    txtSoyad.Text = DAL.toolkit.isimDondur(_kullanici.kullaniciAdSoyad)[1];

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
                    txtKimlikNo.Text = _kullanici.tckimlikNo;

                    drpEgitim.SelectedValue = _kullanici.egitimDurumuId.ToString();
                    drpMeslek.SelectedValue = _kullanici.meslekId.ToString();

                    rdCinsiyet.SelectedValue = _kullanici.cinsiyetId.ToString();

                    telefonlar _telefon = telefonb.search(_authority.kullaniciId, 1);
                    txtGsm2.Text = _telefon.telefon;

                    telefonlar _telefon1 = telefonb.search(_authority.kullaniciId, 3);
                    txtSabit.Text = _telefon1.telefon;

                }

            }
            else if (Session["administrator"] != null)
            {
                if (!Page.IsPostBack)
                {
                    kullanici _authority = (kullanici)Session["administrator"];
                    HttpRequest _request = base.Request;
                    kullanici _kullanici = kullanicib.search(_authority.kullaniciId);
                    txtAd.Text = DAL.toolkit.isimDondur(_kullanici.kullaniciAdSoyad)[0];
                    txtSoyad.Text = DAL.toolkit.isimDondur(_kullanici.kullaniciAdSoyad)[1];

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
                    txtKimlikNo.Text = _kullanici.tckimlikNo;

                    drpEgitim.SelectedValue = _kullanici.egitimDurumuId.ToString();
                    drpMeslek.SelectedValue = _kullanici.meslekId.ToString();

                    rdCinsiyet.SelectedValue = _kullanici.cinsiyetId.ToString();

                    telefonlar _telefon = telefonb.search(_authority.kullaniciId, 1);
                    txtGsm2.Text = _telefon.telefon;

                    telefonlar _telefon1 = telefonb.search(_authority.kullaniciId, 3);
                    txtSabit.Text = _telefon1.telefon;
                }


            }
            else if (Session["editor"] != null)
            {
                kullanici _authority = (kullanici)Session["editor"];
                HttpRequest _request = base.Request;
                kullanici _kullanici = kullanicib.search(_authority.kullaniciId);
                txtAd.Text = DAL.toolkit.isimDondur(_kullanici.kullaniciAdSoyad)[0];
                txtSoyad.Text = DAL.toolkit.isimDondur(_kullanici.kullaniciAdSoyad)[1];

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
                txtKimlikNo.Text = _kullanici.tckimlikNo;

                drpEgitim.SelectedValue = _kullanici.egitimDurumuId.ToString();
                drpMeslek.SelectedValue = _kullanici.meslekId.ToString();

                rdCinsiyet.SelectedValue = _kullanici.cinsiyetId.ToString();

                telefonlar _telefon = telefonb.search(_authority.kullaniciId, 1);
                txtGsm2.Text = _telefon.telefon;

                telefonlar _telefon1 = telefonb.search(_authority.kullaniciId, 3);
                txtSabit.Text = _telefon1.telefon;

            }
            else
            {
                Response.Redirect("~/sysLogin/syslogin.aspx");
            }
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

        protected void Kaydet_Click(object sender, EventArgs e)
        {

            if (Session["boss"] != null)
            {

                kullanici _authority = (kullanici)Session["boss"];
                kullanicib.update(3, _authority.kullaniciId, txtAd + " " + txtSoyad, drpIl.SelectedValue, drpIlce.SelectedValue, drpMahalle.SelectedValue, txtKimlikNo.Text, drpEgitim.SelectedValue, drpMeslek.SelectedValue, rdCinsiyet.SelectedValue);
            }
            if (Session["administrator"] != null)
            {

                kullanici _authority = (kullanici)Session["administrator"];
                kullanicib.update(3, _authority.kullaniciId, txtAd + " " + txtSoyad, drpIl.SelectedValue, drpIlce.SelectedValue, drpMahalle.SelectedValue, txtKimlikNo.Text, drpEgitim.SelectedValue, drpMeslek.SelectedValue, rdCinsiyet.SelectedValue);
            }
            if (Session["editor"] != null)
            {

                kullanici _authority = (kullanici)Session["editor"];
                kullanicib.update(3, _authority.kullaniciId, txtAd + " " + txtSoyad, drpIl.SelectedValue, drpIlce.SelectedValue, drpMahalle.SelectedValue, txtKimlikNo.Text, drpEgitim.SelectedValue, drpMeslek.SelectedValue, rdCinsiyet.SelectedValue);
            }
        }
    }
}