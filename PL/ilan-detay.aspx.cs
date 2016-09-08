using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using Newtonsoft.Json.Linq;

namespace PL
{
    public partial class ilan_detaylari : System.Web.UI.Page
    {
        ilanBll ilanb = new ilanBll();
        ilanResimBll ilanResimb = new ilanResimBll();
        girilebilirIlanOzellikBll girilenb = new girilebilirIlanOzellikBll();
        secilebilirIlanOzellikBll secilebilirb = new secilebilirIlanOzellikBll();
        ilanFavoriBll favorib = new ilanFavoriBll();
        telefonBll telefonb = new telefonBll();
        magazaTelefonBll magazaTlfb = new magazaTelefonBll();
        magazaTakipciBll magazaTakipb = new magazaTakipciBll();
        kullaniciTakipciBll kullaniciTakipb = new kullaniciTakipciBll();
        kullaniciBll kullanicib = new kullaniciBll();
        mesajBll mesajb = new mesajBll();
        ziyaretciBll ziyaretcib = new ziyaretciBll();


        public string magazaId, kullaniciId, postResim, sellerProfil = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            verilenReklamBll vrb = new verilenReklamBll();

            verilenReklam rklm = vrb.search(2, 11);

            if (rklm != null)
            {
                kutu1Rklm.ImageUrl = ("~/upload/reklam/" + rklm.reklamResim);
            }
            else
            {
                kutu1Rklm.ImageUrl = ("~/upload/reklam/kutu.jpg");
            }

            ilan _ilan = ilanb.search(2, Convert.ToInt32(Request.QueryString["ilan"]));

            var koordinat = girilenb.search(Convert.ToInt32(Request.QueryString["ilan"]), 71);

            string gonder = "";
            if (_ilan.magazaId != null)
            {
                gonder += "{'kimden':'" + _ilan.magaza.magazaTur.turId + "','magazaId':'" + _ilan.magazaId + "'";
            }
            else
            {
                gonder += "{'kimden':-1,'magazaId':-1";
            }

            if (koordinat != null)
            {
                gonder += ",'koordinat':" + koordinat.deger + "}";
            }
            else
            {
                gonder += ",'koordinat':-1}";
            }
            JObject dizi = JObject.Parse(gonder);
            JArray objDizi = new JArray();
            objDizi.Add(dizi);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "initMap", "initMap(" + objDizi+ ");", true);

            if (_ilan.kategori.kategoriId.ToString() == "8" || _ilan.kategori.kategoriId.ToString() == "10" || _ilan.kategori.kategoriId.ToString() == "11" || _ilan.kategori.kategoriId.ToString() == "16" || _ilan.kategori.kategoriId.ToString() == "18")
            {
                PlaceHolder17.Controls.Add(Page.LoadControl("~/ozellikler/cephe.ascx"));
                PlaceHolder18.Controls.Add(Page.LoadControl("~/ozellikler/icozellik.ascx"));
                PlaceHolder19.Controls.Add(Page.LoadControl("~/ozellikler/disozellik.ascx"));
                PlaceHolder20.Controls.Add(Page.LoadControl("~/ozellikler/engelliuygun.ascx"));
                PlaceHolder21.Controls.Add(Page.LoadControl("~/ozellikler/muhit.ascx"));
                PlaceHolder22.Controls.Add(Page.LoadControl("~/ozellikler/ulasim.ascx"));
                PlaceHolder23.Controls.Add(Page.LoadControl("~/ozellikler/manzara.ascx"));
                PlaceHolder24.Controls.Add(Page.LoadControl("~/ozellikler/konuttip.ascx"));

            }
            if (_ilan.kategori.kategoriId.ToString() == "9")
            {
                PlaceHolder20.Controls.Add(Page.LoadControl("~/ozellikler/cephe.ascx"));
                PlaceHolder21.Controls.Add(Page.LoadControl("~/ozellikler/icozellik.ascx"));
                PlaceHolder22.Controls.Add(Page.LoadControl("~/ozellikler/manzara.ascx"));
                PlaceHolder23.Controls.Add(Page.LoadControl("~/ozellikler/alt-yapi.ascx"));
                PlaceHolder24.Controls.Add(Page.LoadControl("~/ozellikler/konut-ozellik.ascx"));
                PlaceHolder25.Controls.Add(Page.LoadControl("~/ozellikler/cevre-ozellik.ascx"));
                PlaceHolder26.Controls.Add(Page.LoadControl("~/ozellikler/sosyal.ascx"));
            }

            if (_ilan.kategori.kategoriId.ToString() == "12")
            {
                PlaceHolder19.Controls.Add(Page.LoadControl("~/ozellikler/cephe.ascx"));
                PlaceHolder20.Controls.Add(Page.LoadControl("~/ozellikler/icozellik.ascx"));
                PlaceHolder21.Controls.Add(Page.LoadControl("~/ozellikler/dis-cephe-ozellik.ascx"));
                PlaceHolder22.Controls.Add(Page.LoadControl("~/ozellikler/manzara.ascx"));
                PlaceHolder23.Controls.Add(Page.LoadControl("~/ozellikler/alt-yapi.ascx"));
                PlaceHolder24.Controls.Add(Page.LoadControl("~/ozellikler/konut-ozellik.ascx"));
                PlaceHolder25.Controls.Add(Page.LoadControl("~/ozellikler/cevre-ozellik.ascx"));
            }

            if (_ilan.kategori.kategoriId.ToString() == "13")
            {
                //multiselect özellikler
                PlaceHolder19.Controls.Add(Page.LoadControl("~/ozellikler/cephe.ascx"));
                PlaceHolder20.Controls.Add(Page.LoadControl("~/ozellikler/icozellik.ascx"));
                PlaceHolder21.Controls.Add(Page.LoadControl("~/ozellikler/dis-cephe-ozellik.ascx"));
                PlaceHolder22.Controls.Add(Page.LoadControl("~/ozellikler/manzara.ascx"));
                PlaceHolder23.Controls.Add(Page.LoadControl("~/ozellikler/alt-yapi.ascx"));
                PlaceHolder24.Controls.Add(Page.LoadControl("~/ozellikler/konut-ozellik.ascx"));
                PlaceHolder25.Controls.Add(Page.LoadControl("~/ozellikler/cevre-ozellik.ascx"));
                PlaceHolder26.Controls.Add(Page.LoadControl("~/ozellikler/ic-dekorasyon.ascx"));

            }
            if (_ilan.kategori.kategoriId.ToString() == "14")
            {
                PlaceHolder19.Controls.Add(Page.LoadControl("~/ozellikler/cephe.ascx"));
                PlaceHolder20.Controls.Add(Page.LoadControl("~/ozellikler/icozellik.ascx"));
                PlaceHolder21.Controls.Add(Page.LoadControl("~/ozellikler/dis-cephe-ozellik.ascx"));
                PlaceHolder22.Controls.Add(Page.LoadControl("~/ozellikler/manzara.ascx"));
                PlaceHolder23.Controls.Add(Page.LoadControl("~/ozellikler/alt-yapi.ascx"));
                PlaceHolder24.Controls.Add(Page.LoadControl("~/ozellikler/konut-ozellik.ascx"));
                PlaceHolder25.Controls.Add(Page.LoadControl("~/ozellikler/cevre-ozellik.ascx"));
            }

            if (_ilan.kategori.kategoriId.ToString() == "15")
            {
                PlaceHolder20.Controls.Add(Page.LoadControl("~/ozellikler/cephe.ascx"));
                PlaceHolder21.Controls.Add(Page.LoadControl("~/ozellikler/icozellik.ascx"));
                PlaceHolder22.Controls.Add(Page.LoadControl("~/ozellikler/dis-cephe-ozellik.ascx"));
                PlaceHolder23.Controls.Add(Page.LoadControl("~/ozellikler/manzara.ascx"));
                PlaceHolder24.Controls.Add(Page.LoadControl("~/ozellikler/alt-yapi.ascx"));
                PlaceHolder25.Controls.Add(Page.LoadControl("~/ozellikler/konut-ozellik.ascx"));
                PlaceHolder26.Controls.Add(Page.LoadControl("~/ozellikler/cevre-ozellik.ascx"));

            }
            if (_ilan.kategori.kategoriId.ToString() == "17")
            {
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/detayli-bilgi.ascx"));
            }
            if (_ilan.kategori.kategoriId.ToString() == "4")
            {
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/alt-yapi.ascx"));
                PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/konum.ascx"));
                PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/genel-ozellik.ascx"));
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/manzara.ascx"));
            }

            if (_ilan.kategori.kategoriId.ToString() == "5")
            {
                PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/detay-bilgisi.ascx"));
            }

            if (_ilan.kategori.kategoriId.ToString() == "6")
            {
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/detay-bilgisi.ascx"));

            }

            if (_ilan.kategori.kategoriId.ToString() == "35" || _ilan.kategori.kategoriId.ToString() == "40")
            {
                PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/oda-tipleri.ascx"));
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/oda-ozellik.ascx"));
                PlaceHolder13.Controls.Add(Page.LoadControl("~/ozellikler/banyo-ozellik.ascx"));
                PlaceHolder14.Controls.Add(Page.LoadControl("~/ozellikler/tesis-ozellik.ascx"));
                PlaceHolder15.Controls.Add(Page.LoadControl("~/ozellikler/yeme-icme.ascx"));
                PlaceHolder16.Controls.Add(Page.LoadControl("~/ozellikler/alt-yapi.ascx"));
                PlaceHolder17.Controls.Add(Page.LoadControl("~/ozellikler/cevre-aktivite.ascx"));
                PlaceHolder18.Controls.Add(Page.LoadControl("~/ozellikler/tesis-aktivite.ascx"));
                PlaceHolder19.Controls.Add(Page.LoadControl("~/ozellikler/toplanti-kongre.ascx"));
                PlaceHolder20.Controls.Add(Page.LoadControl("~/ozellikler/deniz-havuz-ozellik.ascx"));
                PlaceHolder21.Controls.Add(Page.LoadControl("~/ozellikler/yakinlik.ascx"));
                PlaceHolder22.Controls.Add(Page.LoadControl("~/ozellikler/ulasim.ascx"));
            }

            if (_ilan.kategori.kategoriId.ToString() == "36")
            {
                PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/oda-tipleri.ascx"));
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/oda-ozellik.ascx"));
                PlaceHolder13.Controls.Add(Page.LoadControl("~/ozellikler/banyo-ozellik.ascx"));
                PlaceHolder14.Controls.Add(Page.LoadControl("~/ozellikler/tesis-ozellik.ascx"));
                PlaceHolder15.Controls.Add(Page.LoadControl("~/ozellikler/manzara.ascx"));
                PlaceHolder16.Controls.Add(Page.LoadControl("~/ozellikler/ortak-kullanim.ascx"));
                PlaceHolder17.Controls.Add(Page.LoadControl("~/ozellikler/mutfak-ozellik.ascx"));
                PlaceHolder18.Controls.Add(Page.LoadControl("~/ozellikler/yeme-icme.ascx"));
                PlaceHolder19.Controls.Add(Page.LoadControl("~/ozellikler/alt-yapi.ascx"));
                PlaceHolder20.Controls.Add(Page.LoadControl("~/ozellikler/cevre-aktivite.ascx"));
                PlaceHolder21.Controls.Add(Page.LoadControl("~/ozellikler/tesis-aktivite.ascx"));
                PlaceHolder22.Controls.Add(Page.LoadControl("~/ozellikler/deniz-havuz-ozellik.ascx"));
                PlaceHolder23.Controls.Add(Page.LoadControl("~/ozellikler/yakinlik.ascx"));
                PlaceHolder24.Controls.Add(Page.LoadControl("~/ozellikler/ulasim.ascx"));
            }
            if (_ilan.kategori.kategoriId.ToString() == "37" || _ilan.kategori.kategoriId.ToString() == "38" || _ilan.kategori.kategoriId.ToString() == "41")
            {
                PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/oda-tipleri.ascx"));
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/oda-ozellik.ascx"));
                PlaceHolder13.Controls.Add(Page.LoadControl("~/ozellikler/banyo-ozellik.ascx"));
                PlaceHolder14.Controls.Add(Page.LoadControl("~/ozellikler/tesis-ozellik.ascx"));
                PlaceHolder15.Controls.Add(Page.LoadControl("~/ozellikler/manzara.ascx"));
                PlaceHolder18.Controls.Add(Page.LoadControl("~/ozellikler/yeme-icme.ascx"));
                PlaceHolder19.Controls.Add(Page.LoadControl("~/ozellikler/alt-yapi.ascx"));
                PlaceHolder20.Controls.Add(Page.LoadControl("~/ozellikler/cevre-aktivite.ascx"));
                PlaceHolder21.Controls.Add(Page.LoadControl("~/ozellikler/tesis-aktivite.ascx"));
                PlaceHolder22.Controls.Add(Page.LoadControl("~/ozellikler/deniz-havuz-ozellik.ascx"));
                PlaceHolder23.Controls.Add(Page.LoadControl("~/ozellikler/yakinlik.ascx"));
                PlaceHolder24.Controls.Add(Page.LoadControl("~/ozellikler/ulasim.ascx"));
            }

            if (_ilan.kategori.kategoriId.ToString() == "39")
            {
                PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/konaklama-sekli.ascx"));
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/cadir-ozellik.ascx"));
                PlaceHolder13.Controls.Add(Page.LoadControl("~/ozellikler/bungalow-ozellik.ascx"));
                PlaceHolder14.Controls.Add(Page.LoadControl("~/ozellikler/genel-ozellik.ascx"));
                PlaceHolder15.Controls.Add(Page.LoadControl("~/ozellikler/manzara.ascx"));
                PlaceHolder18.Controls.Add(Page.LoadControl("~/ozellikler/yeme-icme.ascx"));
                PlaceHolder20.Controls.Add(Page.LoadControl("~/ozellikler/cevre-aktivite.ascx"));
                PlaceHolder22.Controls.Add(Page.LoadControl("~/ozellikler/deniz-havuz-ozellik.ascx"));
                PlaceHolder23.Controls.Add(Page.LoadControl("~/ozellikler/yakinlik.ascx"));
                PlaceHolder24.Controls.Add(Page.LoadControl("~/ozellikler/ulasim.ascx"));
            }

            if (_ilan.kategori.kategoriId.ToString() == "20")
            {
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/genel-ozellik.ascx"));
            }

            if (_ilan.kategori.kategoriId.ToString() == "29")
            {
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/detay-bilgisi.ascx"));
            }

            if (_ilan.kategori.kategoriId.ToString() == "22")
            {
                PlaceHolder14.Controls.Add(Page.LoadControl("~/ozellikler/genel-ozellik.ascx"));
                PlaceHolder15.Controls.Add(Page.LoadControl("~/ozellikler/cephe.ascx"));
                PlaceHolder16.Controls.Add(Page.LoadControl("~/ozellikler/alt-yapi.ascx"));
            }
            if (_ilan.kategori.kategoriId.ToString() == "23")
            {
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/kullanim-amaci.ascx"));
                PlaceHolder13.Controls.Add(Page.LoadControl("~/ozellikler/genel-ozellik.ascx"));
                PlaceHolder14.Controls.Add(Page.LoadControl("~/ozellikler/yakinlik.ascx"));
                PlaceHolder15.Controls.Add(Page.LoadControl("~/ozellikler/manzara.ascx"));
                PlaceHolder16.Controls.Add(Page.LoadControl("~/ozellikler/cephe.ascx"));
                PlaceHolder17.Controls.Add(Page.LoadControl("~/ozellikler/alt-yapi.ascx"));
            }
            if (_ilan.kategori.kategoriId.ToString() == "24")
            {
                PlaceHolder17.Controls.Add(Page.LoadControl("~/ozellikler/yakinlik.ascx"));
                PlaceHolder18.Controls.Add(Page.LoadControl("~/ozellikler/manzara.ascx"));
                PlaceHolder19.Controls.Add(Page.LoadControl("~/ozellikler/cephe.ascx"));
                PlaceHolder20.Controls.Add(Page.LoadControl("~/ozellikler/alt-yapi.ascx"));
            }

            if (_ilan.kategori.kategoriId.ToString() == "25")
            {
                PlaceHolder18.Controls.Add(Page.LoadControl("~/ozellikler/yakinlik.ascx"));
                PlaceHolder19.Controls.Add(Page.LoadControl("~/ozellikler/manzara.ascx"));
                PlaceHolder20.Controls.Add(Page.LoadControl("~/ozellikler/cephe.ascx"));
                PlaceHolder21.Controls.Add(Page.LoadControl("~/ozellikler/alt-yapi.ascx"));
                PlaceHolder22.Controls.Add(Page.LoadControl("~/ozellikler/genel-ozellik.ascx"));
            }
            if (_ilan.kategori.kategoriId.ToString() == "26")
            {
                PlaceHolder18.Controls.Add(Page.LoadControl("~/ozellikler/kullanim-amaci.ascx"));
                PlaceHolder19.Controls.Add(Page.LoadControl("~/ozellikler/bina-ozellik.ascx"));
                PlaceHolder20.Controls.Add(Page.LoadControl("~/ozellikler/dis-cephe-ozellik.ascx"));
                PlaceHolder21.Controls.Add(Page.LoadControl("~/ozellikler/yakinlik.ascx"));
                PlaceHolder22.Controls.Add(Page.LoadControl("~/ozellikler/manzara.ascx"));
                PlaceHolder23.Controls.Add(Page.LoadControl("~/ozellikler/cephe.ascx"));
                PlaceHolder24.Controls.Add(Page.LoadControl("~/ozellikler/alt-yapi.ascx"));
            }

            if (_ilan.kategori.kategoriId.ToString() == "27")
            {
                PlaceHolder18.Controls.Add(Page.LoadControl("~/ozellikler/yakinlik.ascx"));
                PlaceHolder19.Controls.Add(Page.LoadControl("~/ozellikler/manzara.ascx"));
                PlaceHolder20.Controls.Add(Page.LoadControl("~/ozellikler/cephe.ascx"));
                PlaceHolder21.Controls.Add(Page.LoadControl("~/ozellikler/alt-yapi.ascx"));
                PlaceHolder22.Controls.Add(Page.LoadControl("~/ozellikler/genel-ozellik.ascx"));
            }

            if (_ilan.kategori.kategoriId.ToString() == "28")
            {
                PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/detay-bilgisi.ascx"));
            }
            if (_ilan.kategori.kategoriId.ToString() == "31")
            {
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/detay-bilgisi.ascx"));
            }

            if (_ilan.kategori.kategoriId.ToString() == "32")
            {
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/kuafor-detay-bilgisi.ascx"));
            }


            if (!Page.IsPostBack)
            {

                //ziyaretçi işlemleri
                ziyaretcib.AddVisitorCounter(Request.UserHostAddress.ToString(), _ilan.ilanId.ToString());


                txtid.InnerHtml = _ilan.ilanId.ToString();
                hypBaslik.Text = _ilan.baslik;
                txtTarih.InnerHtml = _ilan.bitisTarihi.ToString();
                txtkategori.InnerHtml = _ilan.kategori.kategoriAdi;
                txtIl.InnerHtml = _ilan.iller.ilAdi;
                lblPostFiyat.Text = _ilan.fiyat.ToString();

                lblPostfiyaTur.Text = DAL.toolkit.fiyat_Tur(_ilan.fiyatTurId);

                //ilan _ilan = ilanb.search(2, Convert.ToInt32(Request.QueryString["ilan"]));
                lblBaslik.Text = _ilan.baslik.ToString();
                lblTarih.Text = String.Format("{0:dd MMMM yyyy}", _ilan.baslangicTarihi);
                lblCat.Text = _ilan.kategori.kategoriAdi;
                lblIl.Text = _ilan.iller.ilAdi + "/" + _ilan.ilceler.ilceAdi + "/" + _ilan.mahalleler.mahalleAdi;
                lblIlanTarih.Text = String.Format("{0:dd MMMM yyyy}", _ilan.baslangicTarihi);
                lblNo.Text = _ilan.ilanId.ToString();
                lblTip.Text = DAL.toolkit.donustur(_ilan.ilanTurId) + " " + _ilan.kategori.kategoriAdi;
                lblAciklama.InnerHtml = _ilan.aciklama;
                lblVisitor.Text = ziyaretcib.GetCount(_ilan.ilanId).ToString() + " kişi görüntüledi";

                if (ilanResimb.search(Request.QueryString["ilan"]) != null)
                {
                    postResim = _ilan.ilanResims.FirstOrDefault().resim.ToString();
                    sliderRepeater.DataSource = ilanResimb.list(1, Request.QueryString["ilan"]);
                    sliderRepeater.DataBind();
                    pagerRepeater.DataSource = ilanResimb.list(1, Request.QueryString["ilan"]);
                    pagerRepeater.DataBind();
                    foundImage.Visible = true;
                    lblFiyat.Text = fiyat_Tur(_ilan.fiyatTurId) + " " + _ilan.fiyat.ToString();

                }
                else
                {
                    notImage.Visible = true;
                    notlblFiyat.Text = fiyat_Tur(_ilan.fiyatTurId) + " " + _ilan.fiyat.ToString();


                }

                secilebilirRepeater.DataSource = secilebilirb.list(1, _ilan.ilanId);
                secilebilirRepeater.DataBind();

                girilenRepeater.DataSource = girilenb.list(1, _ilan.ilanId);
                girilenRepeater.DataBind();

                if (_ilan.magazaId == null)
                {
                    lblkimden.Text = "Sahibinden";
                    lblkimdenTop.Text = "Sahibinden";

                    lblSatici.Text = _ilan.kullanici.kullaniciAdSoyad;
                    sellerProfil = _ilan.kullanici.profilResim;
                    user_img.Visible = true;
                    if (_ilan.numaraYayinlansinMi == true)
                    {
                        telefonRepater.DataSource = telefonb.list(2, _ilan.kullaniciId);
                        telefonRepater.DataBind();
                    }

                    if (Session["unique-site-user"] != null)
                    {
                        kullanici _authority = (kullanici)Session["unique-site-user"];
                        if (kullaniciTakipb.search(_ilan.kullaniciId, _authority.kullaniciId) != null)
                        {
                            LinkButton1.Visible = false;
                        }
                        else
                        {
                            LinkButton2.Visible = false;
                        }
                    }
                    else
                    {
                        LinkButton2.Visible = false;
                    }

                    kullaniciId = _ilan.kullaniciId.ToString();

                }
                else
                {
                    if (_ilan.magaza.magazaTur.turId == 6 || _ilan.magaza.magazaTur.turId == 1 || _ilan.magaza.magazaTur.turId == 2 || _ilan.magaza.magazaTur.turId == 3 || _ilan.magaza.magazaTur.turId == 4 || _ilan.magaza.magazaTur.turId == 5 || _ilan.magaza.magazaTur.turId == 9)
                    {
                        if (Session["unique-site-user"] != null)
                        {
                            kullanici _authority = (kullanici)Session["unique-site-user"];
                            kullanicib.update(3, _authority.kullaniciId, _authority.kredi - 1);
                        }
                    }

                    magazaId = _ilan.magazaId.ToString();
                    lblSatici.Text = _ilan.magaza.magazaAdi;
                    store_img.Visible = true;
                    sellerProfil = _ilan.magaza.magazaLogo;

                    if (Session["unique-site-user"] != null)
                    {
                        kullanici _authority = (kullanici)Session["unique-site-user"];
                        if (magazaTakipb.search(_authority.kullaniciId, _ilan.magazaId) != null)
                        {
                            LinkButton1.Visible = false;
                        }
                        else
                        {
                            LinkButton2.Visible = false;
                        }
                    }
                    else
                    {
                        LinkButton2.Visible = false;
                    }



                    if (_ilan.numaraYayinlansinMi == true)
                    {

                        telefonRepater.DataSource = magazaTlfb.list(1, _ilan.magazaId);
                        telefonRepater.DataBind();
                    }

                    if (_ilan.magaza.magazaTur.turId == 7)
                    {
                        lblkimden.Text = "Emlak Ofisinden";
                        lblkimdenTop.Text = "Emlak Ofisinden";

                    }

                    if (_ilan.magaza.magazaTur.turId == 1)
                    {
                        lblkimden.Text = "Belediyeden";
                        lblkimdenTop.Text = "Belediyeden";

                    }
                    if (_ilan.magaza.magazaTur.turId == 5)
                    {
                        lblkimden.Text = "Bankadan";
                        lblkimdenTop.Text = "Bankadan";

                    }
                    if (_ilan.magaza.magazaTur.turId == 3)
                    {
                        lblkimden.Text = "İzale-i Şuyundan";
                        lblkimdenTop.Text = "İzale-i Şuyundan";

                    }
                    if (_ilan.magaza.magazaTur.turId == 2)
                    {
                        lblkimden.Text = "İcradan";
                        lblkimdenTop.Text = "İcradan";

                    }
                    if (_ilan.magaza.magazaTur.turId == 4)
                    {
                        lblkimden.Text = "Milli Hazine";
                        lblkimdenTop.Text = "Milli Hazine";

                    }
                    if (_ilan.magaza.magazaTur.turId == 9)
                    {
                        lblkimden.Text = "Özelleştirme İdaresi";
                        lblkimdenTop.Text = "Özelleştirme İdaresi";

                    }
                    if (_ilan.magaza.magazaTur.turId == 8)
                    {
                        lblkimden.Text = "İnşaat Firması";
                        lblkimdenTop.Text = "İnşaat Firması";

                    }
                    if (_ilan.magaza.magazaTur.turId == 6)
                    {
                        lblkimden.Text = "Kamu Kurumularından";
                        lblkimdenTop.Text = "Kamu Kurumularından";

                    }
                }
                if (Session["unique-site-user"] != null)
                {
                    kullanici _authority = (kullanici)Session["unique-site-user"];
                    if (favorib.search(Request.QueryString["ilan"], _authority.kullaniciId) != null)
                    {
                        favoriLink.Visible = false;
                    }
                    else
                    {
                        favoriCikar.Visible = false;
                    }
                }
                else
                {
                    favoriCikar.Visible = false;
                }
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

        protected void favoriLink_Click(object sender, EventArgs e)
        {
            if (Session["unique-site-user"] != null)
            {
                kullanici _authority = (kullanici)Session["unique-site-user"];

                if (favorib.search(Request.QueryString["ilan"], _authority.kullaniciId) == null)
                {
                    favorib.insert(Request.QueryString["ilan"], _authority.kullaniciId);
                }
                favoriLink.Visible = false;
                favoriCikar.Visible = true;
            }
            else
            {
                Response.Redirect("~/giris-yap.aspx");
            }
        }

        protected void favoriCikar_Click(object sender, EventArgs e)
        {
            if (Session["unique-site-user"] != null)
            {
                kullanici _authority = (kullanici)Session["unique-site-user"];

                if (favorib.search(Request.QueryString["ilan"], _authority.kullaniciId) != null)
                {
                    favorib.delete(Request.QueryString["ilan"], _authority.kullaniciId);
                }

                favoriLink.Visible = true;
                favoriCikar.Visible = false;
            }
            else
            {
                Response.Redirect("~/giris-yap.aspx");
            }
        }

        protected void Gonder_Click(object sender, EventArgs e)
        {
            ilan _ilan = ilanb.search(2, Convert.ToInt32(Request.QueryString["ilan"]));
            kullanici _authority = (kullanici)Session["unique-site-user"];

            mesajb.insert(_ilan.kullaniciId, _authority.kullaniciId, _ilan.ilanId, txtMesaj.InnerText);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            ilan _ilan = ilanb.search(2, Convert.ToInt32(Request.QueryString["ilan"]));

            if (_ilan.magazaId == null)
            {
                Response.Redirect("~/satici-profil.aspx?seller=" + _ilan.kullaniciId);

            }
            else
            {
                Response.Redirect("~/magaza-profil.aspx?store=" + _ilan.magazaId);

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (Session["unique-site-user"] != null)
            {
                kullanici _authority = (kullanici)Session["unique-site-user"];

                ilan _ilan = ilanb.search(2, Convert.ToInt32(Request.QueryString["ilan"]));

                if (_ilan.magazaId == null)
                {
                    kullaniciTakipb.insert(_ilan.kullaniciId, _authority.kullaniciId);
                }
                else
                {
                    magazaTakipb.insert(_authority.kullaniciId, _ilan.magazaId);
                }
                LinkButton1.Visible = false;
                LinkButton2.Visible = true;
            }
            else
            {
                Response.Redirect("~/giris-yap.aspx");

            }
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (Session["unique-site-user"] != null)
            {
                kullanici _authority = (kullanici)Session["unique-site-user"];
                ilan _ilan = ilanb.search(2, Convert.ToInt32(Request.QueryString["ilan"]));

                if (_ilan.magazaId == null)
                {
                    kullaniciTakipb.delete(_ilan.kullaniciId, _authority.kullaniciId);
                }
                else
                {
                    magazaTakipb.delete(_ilan.magazaId, _authority.kullaniciId);
                }

                LinkButton1.Visible = true;
                LinkButton2.Visible = false;
            }
            else
            {
                Response.Redirect("~/giris-yap.aspx");

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