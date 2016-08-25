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
    public partial class hesap_anasayfa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["unique-site-user"] != null)
            {
                kullanici _authority = (kullanici)Session["unique-site-user"];
                lblUsername.Text = _authority.kullaniciAdSoyad;

                if (Request.QueryString["control"] == "anasayfa")
                {
                    PlaceHolder1.Controls.Add(Page.LoadControl("~/profil/anasayfa.ascx"));
                }
                if (Request.QueryString["control"] == "onay-bekleyen")
                {
                    PlaceHolder1.Controls.Add(Page.LoadControl("~/profil/onay-bekleyen.ascx"));

                }
                if (Request.QueryString["control"] == "odemeler")
                {
                    PlaceHolder1.Controls.Add(Page.LoadControl("~/profil/odemeler.ascx"));

                }
                if (Request.QueryString["control"] == "kayitli-arama")
                {
                    PlaceHolder1.Controls.Add(Page.LoadControl("~/profil/kayitli-arama.ascx"));

                }
                if (Request.QueryString["control"] == "magaza-profil")
                {
                    PlaceHolder1.Controls.Add(Page.LoadControl("~/profil/magaza-profil.ascx"));

                }

                if (Request.QueryString["control"] == "hesap-dondur")
                {
                    PlaceHolder1.Controls.Add(Page.LoadControl("~/profil/hesap-dondur.ascx"));

                }

                if (Request.QueryString["control"] == "favori-ilan")
                {
                    PlaceHolder1.Controls.Add(Page.LoadControl("~/profil/favori-ilan.ascx"));

                }

                if (Request.QueryString["control"] == "favori-satici")
                {
                    PlaceHolder1.Controls.Add(Page.LoadControl("~/profil/favori-satici.ascx"));

                }

                if (Request.QueryString["control"] == "arsiv")
                {
                    PlaceHolder1.Controls.Add(Page.LoadControl("~/profil/arsiv.ascx"));

                }

                if (Request.QueryString["control"] == "ilan")
                {
                    PlaceHolder1.Controls.Add(Page.LoadControl("~/profil/ilan.ascx"));

                }

                if (Request.QueryString["control"] == "magaza-ekle")
                {
                    PlaceHolder1.Controls.Add(Page.LoadControl("~/profil/magaza-ekle.ascx"));

                }

                if (Request.QueryString["control"] == "gelen-kutusu")
                {
                    PlaceHolder1.Controls.Add(Page.LoadControl("~/profil/gelen-kutusu.ascx"));

                }

                if (Request.QueryString["control"] == "gonderilen-kutusu")
                {
                    PlaceHolder1.Controls.Add(Page.LoadControl("~/profil/gonderilen-kutusu.ascx"));

                }


                if (Request.QueryString["control"] == "reklam-ekle")
                {
                    PlaceHolder1.Controls.Add(Page.LoadControl("~/profil/reklam-ekle.ascx"));

                }

                if (Request.QueryString["control"] == "reklamlar")
                {
                    PlaceHolder1.Controls.Add(Page.LoadControl("~/profil/reklamlar.ascx"));

                }

                if (Request.QueryString["control"] == "magaza-detay-ekle")
                {
                    PlaceHolder1.Controls.Add(Page.LoadControl("~/profil/magaza-detay-ekle.ascx"));

                }


                if (Request.QueryString["control"] == "favori-magaza")
                {
                    PlaceHolder1.Controls.Add(Page.LoadControl("~/profil/favori-magaza.ascx"));

                }

                if (Request.QueryString["control"] == "eposta")
                {
                    PlaceHolder1.Controls.Add(Page.LoadControl("~/profil/eposta.ascx"));

                }

                if (Request.QueryString["control"] == "cep-telefonu")
                {
                    PlaceHolder1.Controls.Add(Page.LoadControl("~/profil/cep-telefonu.ascx"));

                }

                if (Request.QueryString["control"] == "sifre-degistir")
                {
                    PlaceHolder1.Controls.Add(Page.LoadControl("~/profil/sifre-degistir.ascx"));

                }
                if (Request.QueryString["control"] == "bildirimler")
                {
                    PlaceHolder1.Controls.Add(Page.LoadControl("~/profil/bildirimler.ascx"));

                }

                if (Request.QueryString["control"] == "bildirim-oku")
                {
                    PlaceHolder1.Controls.Add(Page.LoadControl("~/profil/bildirim-oku.ascx"));

                }

                if (Request.QueryString["control"] == "kisisel-bilgiler")
                {
                    PlaceHolder1.Controls.Add(Page.LoadControl("~/profil/kisisel-bilgiler.ascx"));

                }

                if (Request.QueryString["control"] == "mesaj-oku")
                {
                    PlaceHolder1.Controls.Add(Page.LoadControl("~/profil/mesaj-oku.ascx"));

                }

                if (Request.QueryString["control"] == "reklam-onay-bekleyen")
                {
                    PlaceHolder1.Controls.Add(Page.LoadControl("~/profil/reklam-onay-bekleyen.ascx"));

                }

                if (Request.QueryString["control"] == "magaza-kullanicilar")
                {
                    PlaceHolder1.Controls.Add(Page.LoadControl("~/profil/magaza-kullanicilar.ascx"));

                }
            }
        }
    }
}