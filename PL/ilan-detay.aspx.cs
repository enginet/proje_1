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

        public string magazaId, kullaniciId, postResim;

        protected void Page_Load(object sender, EventArgs e)
        {
            ilan _ilan = ilanb.search(2, Convert.ToInt32(Request.QueryString["ilan"]));

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
            if (_ilan.magaza.magazaTur.turId == 6)
            {
                if (Session["unique-site-user"] != null)
                {
                    kullanici _authority = (kullanici)Session["unique-site-user"];
                    kullanicib.update(3, _authority.kullaniciId, _authority.kredi - 1);
                }
            }
            if (!Page.IsPostBack)
            {

                foreach (Control item in box_footer.Controls)
                {
                    if (item is PlaceHolder)
                    {
                        foreach (Control item2 in item.Controls)
                        {
                            foreach (Control item3 in item2.Controls)
                            {
                                foreach (Control item4 in item3.Controls)
                                {
                                    foreach (Control item5 in item4.Controls)
                                    {
                                        if (item5 is CheckBox)
                                        {
                                            ((CheckBox)item5).Enabled = false;

                                        }

                                    }
                                }
                            }
                        }
                    }
                }

                txtid.InnerHtml = _ilan.ilanId.ToString();
                hypBaslik.Text = _ilan.baslik;
                txtTarih.InnerHtml = _ilan.bitisTarihi.ToString();
                txtkategori.InnerHtml = _ilan.kategori.kategoriAdi;
                txtIl.InnerHtml = _ilan.iller.ilAdi;
                lblPostFiyat.Text = _ilan.fiyat.ToString();
                postResim = _ilan.ilanResims.Where(r => r.seciliMi == true).FirstOrDefault().resim.ToString();
                lblPostfiyaTur.Text = DAL.toolkit.fiyat_Tur(_ilan.fiyatTurId);

                //ilan _ilan = ilanb.search(2, Convert.ToInt32(Request.QueryString["ilan"]));
                lblBaslik.Text = _ilan.baslik.ToString();
                lblTarih.Text = _ilan.baslangicTarihi.ToString();
                lblCat.Text = _ilan.kategori.kategoriAdi;
                lblIl.Text = _ilan.iller.ilAdi + "/" + _ilan.ilceler.ilceAdi + "/" + _ilan.mahalleler.mahalleAdi;
                lblFiyat.Text = fiyat_Tur(_ilan.fiyatTurId) + " " + _ilan.fiyat.ToString();
                lblIlanTarih.Text = _ilan.baslangicTarihi.ToString();
                lblNo.Text = _ilan.ilanId.ToString();
                lblTip.Text = DAL.toolkit.donustur(_ilan.ilanTurId) + " " + _ilan.kategori.kategoriAdi;
                lblAciklama.InnerHtml = _ilan.aciklama;

                sliderRepeater.DataSource = ilanResimb.list(1, Request.QueryString["ilan"]);
                sliderRepeater.DataBind();

                pagerRepeater.DataSource = ilanResimb.list(1, Request.QueryString["ilan"]);
                pagerRepeater.DataBind();

                secilebilirRepeater.DataSource = secilebilirb.list(1, _ilan.ilanId);
                secilebilirRepeater.DataBind();

                girilenRepeater.DataSource = girilenb.list(1, _ilan.ilanId);
                girilenRepeater.DataBind();

                if (_ilan.magazaId == null)
                {
                    lblkimden.Text = "Sahibinden";
                    lblSatici.Text = _ilan.kullanici.kullaniciAdSoyad;
                    if (_ilan.numaraYayinlansinMi == true)
                    {
                        telefonRepater.DataSource = telefonb.list(2, _ilan.kullaniciId);
                        telefonRepater.DataBind();
                    }

                    if (kullaniciTakipb.search(_ilan.kullaniciId, 3) != null)
                    {
                        LinkButton1.Visible = false;
                    }
                    else
                    {
                        LinkButton2.Visible = false;
                    }

                    kullaniciId = _ilan.kullaniciId.ToString();
                    HyperLink1.Visible = false;

                }
                else
                {
                    magazaId = _ilan.magazaId.ToString();
                    lblSatici.Text = _ilan.magaza.magazaAdi;
                    if (magazaTakipb.search(3, _ilan.magazaId) != null)
                    {
                        LinkButton1.Visible = false;
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

                    if (_ilan.magaza.magazaTur.turId == 2)
                    {
                        lblkimden.Text = "Emlak Ofisi";
                    }

                    if (_ilan.magaza.magazaTur.turId == 3)
                    {
                        lblkimden.Text = "Belediye";
                    }
                    if (_ilan.magaza.magazaTur.turId == 4)
                    {
                        lblkimden.Text = "Banka";
                    }
                    if (_ilan.magaza.magazaTur.turId == 5)
                    {
                        lblkimden.Text = "İzale-i Şuyu";
                    }
                    if (_ilan.magaza.magazaTur.turId == 6)
                    {
                        lblkimden.Text = "İcra";
                    }
                    if (_ilan.magaza.magazaTur.turId == 7)
                    {
                        lblkimden.Text = "Milli Hazine";
                    }
                    if (_ilan.magaza.magazaTur.turId == 9)
                    {
                        lblkimden.Text = "Özelleştirme İdaresi";
                    }
                    if (_ilan.magaza.magazaTur.turId == 10)
                    {
                        lblkimden.Text = "İnşaat Firması";
                    }
                    if (_ilan.magaza.magazaTur.turId == 11)
                    {
                        lblkimden.Text = "Kamu Kurumu";
                    }
                }

                if (favorib.search(Request.QueryString["ilan"], 3) != null)
                {
                    favoriLink.Visible = false;
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

            if (favorib.search(Request.QueryString["ilan"], 3) == null)
            {
                favorib.insert(Request.QueryString["ilan"], 3);
            }
            favoriLink.Visible = false;
            favoriCikar.Visible = true;
        }

        protected void favoriCikar_Click(object sender, EventArgs e)
        {
            if (favorib.search(Request.QueryString["ilan"], 3) != null)
            {
                favorib.delete(Request.QueryString["ilan"], 3);
            }

            favoriLink.Visible = true;
            favoriCikar.Visible = false;
        }

        protected void Gonder_Click(object sender, EventArgs e)
        {            
            ilan _ilan = ilanb.search(2, Convert.ToInt32(Request.QueryString["ilan"]));
            kullanici _authority = (kullanici)Session["unique-site-user"];

            mesajb.insert(_ilan.kullaniciId, _authority.kullaniciId, _ilan.ilanId, txtMesaj.InnerText);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            ilan _ilan = ilanb.search(2, Convert.ToInt32(Request.QueryString["ilan"]));

            if (_ilan.magazaId == null)
            {
                kullaniciTakipb.insert(_ilan.kullaniciId, 3);
            }
            else
            {
                magazaTakipb.insert(3, _ilan.magazaId);
            }
            LinkButton1.Visible = false;
            LinkButton2.Visible = true;
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            ilan _ilan = ilanb.search(2, Convert.ToInt32(Request.QueryString["ilan"]));

            if (_ilan.magazaId == null)
            {
                kullaniciTakipb.delete(_ilan.kullaniciId, 3);
            }
            else
            {
                magazaTakipb.delete(_ilan.magazaId, 3);
            }

            LinkButton1.Visible = true;
            LinkButton2.Visible = false;
        }
    }
}