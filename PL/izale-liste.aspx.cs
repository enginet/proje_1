using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Newtonsoft.Json.Linq;
using System.Collections;
using DAL;

namespace PL
{
    public partial class izale_liste : System.Web.UI.Page
    {
        kategoriTurBll ktgTurb = new kategoriTurBll();
        kategoriBll kategorib = new kategoriBll();
        ilanBll ilanb = new ilanBll();
        seciliDopingBll seciliDopingb = new seciliDopingBll();
        kategoriTurBll kategoriTurb = new kategoriTurBll();
        girilebilirIlanOzellikBll girilenb = new girilebilirIlanOzellikBll();
        magazaBll magazab = new magazaBll();
        araBll arab = new araBll();
        ilBll ilb = new ilBll();
        ilceBll ilceb = new ilceBll();
        mahalleBll mahalleb = new mahalleBll();
        public string mesaj = "";

        protected override void OnInit(EventArgs e)
        {

            // 4 arsa
            if (Request.QueryString["cat"] == "4")
            {
                PlaceHolder1.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare-arama.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/arsa-ozellik.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

                foreach (Control item in PlaceHolder4.Controls)
                {
                    foreach (Control item2 in item.Controls)
                    {
                        if (item2.ID == "pafta" || item2.ID == "metrekarefiyat")
                        {
                            item2.Visible = false;
                        }
                    }
                }
            }

            // 8 daire / 10 müstakil ev / 11 yalı / 16 yazlık / 18 kooperatif
            if (Request.QueryString["cat"] == "8" || Request.QueryString["cat"] == "10" || Request.QueryString["cat"] == "11" || Request.QueryString["cat"] == "16" || Request.QueryString["cat"] == "18")
            {
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare-arama.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/oda-sayisi.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/bulundugu-kat.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/kat-sayisi.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/isitma.ascx"));
                PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/banyo-sayisi.ascx"));
                PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/esyali.ascx"));
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/kullanim-durumu.ascx"));
                PlaceHolder13.Controls.Add(Page.LoadControl("~/ozellikler/site-icerisinde.ascx"));
                PlaceHolder15.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder16.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }
            }

            // 9 residence
            if (Request.QueryString["cat"] == "9")
            {
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare-arama.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/oda-sayisi-arama.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/salon-sayisi-arama.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi-arama.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/bulundugu-kat-arama.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/kat-sayisi-arama.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/konut-sekli.ascx"));
                PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/isinma-yakit.ascx"));
                PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/balkon.ascx"));
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/banyo-sayisi-arama.ascx"));
                PlaceHolder13.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                PlaceHolder14.Controls.Add(Page.LoadControl("~/ozellikler/kullanim-durumu.ascx"));
                PlaceHolder15.Controls.Add(Page.LoadControl("~/ozellikler/site-icerisinde.ascx"));
                PlaceHolder17.Controls.Add(Page.LoadControl("~/ozellikler/zemin-etudu.ascx"));
                PlaceHolder18.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder19.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }
            }

            // 12 çiftlik evi / 13 köşk & konak / 14 yalı
            if (Request.QueryString["cat"] == "12")
            {
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/bina-arazi-metre-arama.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/oda-sayisi-arama.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/salon-sayisi-arama.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi-arama.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/kat-sayisi-arama.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/isinma-yakit.ascx"));
                PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/yapi-tipi.ascx"));
                PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/balkon.ascx"));
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/banyo-sayisi-arama.ascx"));
                PlaceHolder13.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                PlaceHolder14.Controls.Add(Page.LoadControl("~/ozellikler/kullanim-durumu.ascx"));
                PlaceHolder15.Controls.Add(Page.LoadControl("~/ozellikler/tapu-durum.ascx"));
                PlaceHolder16.Controls.Add(Page.LoadControl("~/ozellikler/zemin-etudu.ascx"));
                PlaceHolder17.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder18.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }
            }

            // 15 yalı dairesi
            if (Request.QueryString["cat"] == "15")
            {
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare-arama.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/oda-sayisi-arama.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/salon-sayisi-arama.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi-arama.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/bulundugu-kat-arama.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/kat-sayisi-arama.ascx"));
                PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/isinma-yakit.ascx"));
                PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/yapi-tipi.ascx"));
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/balkon.ascx"));
                PlaceHolder13.Controls.Add(Page.LoadControl("~/ozellikler/banyo-sayisi-arama.ascx"));
                PlaceHolder14.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                PlaceHolder15.Controls.Add(Page.LoadControl("~/ozellikler/kullanim-durumu.ascx"));
                PlaceHolder16.Controls.Add(Page.LoadControl("~/ozellikler/tapu-durum.ascx"));
                PlaceHolder17.Controls.Add(Page.LoadControl("~/ozellikler/zemin-etudu.ascx"));
                PlaceHolder18.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder19.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

            }

            // 17 prefabrik ev
            if (Request.QueryString["cat"] == "17")
            {
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare-arama.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/oda-sayisi-arama.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/kat-sayisi-arama.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/banyo-sayisi-arama.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/dis-cephe-durum.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/isitma.ascx"));
                PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

            }

            // 5 bina
            if (Request.QueryString["cat"] == "5")
            {
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare-arama.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/daire-sayisi.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/kat-sayisi.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/isitma.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

            }
            // 6 devremülk
            if (Request.QueryString["cat"] == "6")
            {
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/devremulk-ozellik.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

            }
            // 35 otel / 42 tatil köyü
            if (Request.QueryString["cat"] == "35" || Request.QueryString["cat"] == "40")
            {
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/acik-kapali-metre-arama.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/yildiz-sayisi.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/oda-yatak-kat-sayisi-arama.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/zemin-etudu.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

            }
            // 36 apart otel
            if (Request.QueryString["cat"] == "36")
            {
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/acik-kapali-metre-arama.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/apart-sayisi.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/oda-yatak-kat-sayisi-arama.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/zemin-etudu.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

            }
            // 37 butik otel / 38 pansiyon / 41 motel
            if (Request.QueryString["cat"] == "37" || Request.QueryString["cat"] == "38" || Request.QueryString["cat"] == "41")
            {
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/acik-kapali-metre-arama.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/oda-yatak-kat-sayisi-arama.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/zemin-etudu.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

            }

            // 39 kamp yeri
            if (Request.QueryString["cat"] == "39")
            {
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare-arama.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

            }

            // 42 plaj
            if (Request.QueryString["cat"] == "42")
            {
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/kapasite-arama.ascx"));
            }
            // 21 atölye
            if (Request.QueryString["cat"] == "21")
            {
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/durum.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

            }
            // 20 büfe
            if (Request.QueryString["cat"] == "20")
            {
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare-arama.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/yapi-tipi.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/kullanim-durumu.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

            }
            // 29 büro & ofis
            if (Request.QueryString["cat"] == "29")
            {
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare-arama.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/oda-sayisi.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/isitma.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/durum.ascx"));
                PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

            }
            // 22 depo & antrepo
            if (Request.QueryString["cat"] == "22")
            {
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare-arama.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/giris-yuksek-arama.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi-arama.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/isinma-yakit.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/kullanim-durumu.ascx"));
                PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/tapu-durum.ascx"));
                PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/zemin-etudu.ascx"));
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder13.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

            }
            // 23 dükkan & mağaza
            if (Request.QueryString["cat"] == "23")
            {
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare-arama.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/bolum-oda-sayisi-arama.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/isitma.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/durum.ascx"));
                PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

            }
            // 24 fabrika
            if (Request.QueryString["cat"] == "24")
            {
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/acik-kapali-metre-arama.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/bolum-oda-sayisi-arama.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/bina-adedi.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/kat-sayisi-arama.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/giris-yuksek-arama.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/isinma-yakit.ascx"));
                PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/kullanim-durumu.ascx"));
                PlaceHolder13.Controls.Add(Page.LoadControl("~/ozellikler/tapu-durum.ascx"));
                PlaceHolder14.Controls.Add(Page.LoadControl("~/ozellikler/zemin-etudu.ascx"));
                PlaceHolder15.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder16.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

            }
            // 25 İşhanı Katı
            if (Request.QueryString["cat"] == "25")
            {
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare-arama.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/bolum-oda-sayisi-arama.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/kat-sayisi-arama.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/bulundugu-kat.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/isinma-yakit.ascx"));
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                PlaceHolder13.Controls.Add(Page.LoadControl("~/ozellikler/kullanim-durumu.ascx"));
                PlaceHolder14.Controls.Add(Page.LoadControl("~/ozellikler/tapu-durum.ascx"));
                PlaceHolder15.Controls.Add(Page.LoadControl("~/ozellikler/zemin-etudu.ascx"));
                PlaceHolder16.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder17.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

            }
            // 26 Komple Bina
            if (Request.QueryString["cat"] == "26")
            {
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare-arama.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/bina-tipi.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/kat-sayisi-arama.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/isinma-yakit.ascx"));
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                PlaceHolder13.Controls.Add(Page.LoadControl("~/ozellikler/kullanim-durumu.ascx"));
                PlaceHolder15.Controls.Add(Page.LoadControl("~/ozellikler/zemin-etudu.ascx"));
                PlaceHolder16.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder17.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

            }
            // 27 Plaza Katı
            if (Request.QueryString["cat"] == "27")
            {
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare-arama.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/bolum-oda-sayisi-arama.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/kat-sayisi-text.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/bulundugu-kat.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/isinma-yakit.ascx"));
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                PlaceHolder13.Controls.Add(Page.LoadControl("~/ozellikler/kullanim-durumu.ascx"));
                PlaceHolder14.Controls.Add(Page.LoadControl("~/ozellikler/tapu-durum.ascx"));
                PlaceHolder15.Controls.Add(Page.LoadControl("~/ozellikler/zemin-etudu.ascx"));
                PlaceHolder16.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder17.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }
            }
            // 28 İmalathane
            if (Request.QueryString["cat"] == "28")
            {
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare-arama.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/bolum-oda-sayisi-arama.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/isitma.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }
            }
            // 30 market
            if (Request.QueryString["cat"] == "30")
            {
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare-arama.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/isitma.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }
            }
            // 31 Restoran lokanta
            if (Request.QueryString["cat"] == "31")
            {
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare-arama.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/isitma.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/kapasite-arama.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/masa-sayisi-arama.ascx"));
                PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }
            }
            // 32 Kuaför Güzellik Merkezi
            if (Request.QueryString["cat"] == "32")
            {
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare-arama.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/oda-sayisi.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/isitma.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/bulundugu-kat.ascx"));
                PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }
            }
            // 33 Tekel Bayi
            if (Request.QueryString["cat"] == "33")
            {
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare-arama.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/isitma.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }
            }

            if ((Request.QueryString["cat"] != null || Request.QueryString["tur"] !=null))
            {
                tum_ilanlar.InnerText = ilanb.countIlanListe(1,Request.QueryString["cat"],Request.QueryString["tur"]).ToString();
                sahibinden.InnerText = ilanb.countIlanListe(2, Request.QueryString["cat"], Request.QueryString["tur"]).ToString();
                emlakcidan.InnerText = ilanb.countIlanListe(3, Request.QueryString["cat"], Request.QueryString["tur"]).ToString();
                bankadan.InnerText = ilanb.countIlanListe(4, Request.QueryString["cat"], Request.QueryString["tur"]).ToString();
                belediyeden.InnerText = ilanb.countIlanListe(5, Request.QueryString["cat"], Request.QueryString["tur"]).ToString();
                icradan.InnerText = ilanb.countIlanListe(6, Request.QueryString["cat"], Request.QueryString["tur"]).ToString();
                izaleyi_suyu.InnerText = ilanb.countIlanListe(7, Request.QueryString["cat"], Request.QueryString["tur"]).ToString();
                milli_hazineden.InnerText = ilanb.countIlanListe(8, Request.QueryString["cat"], Request.QueryString["tur"]).ToString();
                ozellestirme_dairesinden.InnerText = ilanb.countIlanListe(9, Request.QueryString["cat"], Request.QueryString["tur"]).ToString();
                kamu_kurumlarindan.InnerText = ilanb.countIlanListe(10, Request.QueryString["cat"], Request.QueryString["tur"]).ToString();
                insaat_firmasindan.InnerText = ilanb.countIlanListe(11, Request.QueryString["cat"], Request.QueryString["tur"]).ToString();
            }
        }


        protected void drpIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpIl.SelectedValue == "")
            {
                drpMahalle.Items.Clear();
                drpIlce.Items.Clear();
            }
            else
            {
                drpMahalle.Items.Clear();

                drpIlce.DataSource = ilceb.list(Convert.ToInt32(drpIl.SelectedValue));
                drpIlce.DataTextField = "ilceAdi";
                drpIlce.DataValueField = "ilceId";
                drpIlce.DataBind();

                ListItem lst = new ListItem();
                lst.Value = "";
                lst.Text = "Seçiniz";
                drpIlce.Items.Insert(0, lst);
                drpMahalle.Items.Insert(0, lst);
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            ArrayList dizi = new ArrayList();
            ArrayList dizi2 = new ArrayList();
            filtreBll fbll = new filtreBll();

            string yolla = "";
            JObject obj = new JObject();
            foreach (Control item in yurt.Controls)
            {
                if (item is PlaceHolder)
                {
                    foreach (Control item2 in item.Controls)
                    {
                        foreach (Control item3 in item2.Controls)
                        {
                            if (item3 is DropDownList)
                            {
                                if (((DropDownList)item3).SelectedValue != "")
                                {
                                    dizi.Add(((DropDownList)item3).SelectedValue);
                                }
                            }
                            if (item3 is TextBox)
                            {
                                if (item3.ID != "txtMetreFiyat" && item3.ID != "txtPaftaNo")
                                {
                                    string[] gecici = ((TextBox)item3).Attributes["name"].Split('_');
                                    if (gecici[1] == "1")
                                    {
                                        if (((TextBox)item3).Text != "")
                                        {
                                            yolla = "{'ozellikId':'" + gecici[0] + "','minDeger':'" + ((TextBox)item3).Text + "'}";
                                        }
                                        else
                                        {
                                            yolla = "{'ozellikId':'" + gecici[0] + "','minDeger':'-1'}";
                                        }

                                        obj = JObject.Parse(yolla);
                                    }
                                    else
                                    {

                                        if (((TextBox)item3).Text != "")
                                        {
                                            obj.Add("maxDeger", ((TextBox)item3).Text);
                                        }
                                        else
                                        {
                                            obj.Add("maxDeger", "-1");
                                        }
                                        dizi2.Add(obj);
                                    }
                                }

                            }
                        }
                    }
                }
            }
            //var sorgu = fbll.haritaFiltre(dizi);
            //string[] sonuc = fbll.haritaFiltre(dizi);

            ArrayList fiyat = new ArrayList();

            fiyat.Add(txtMinFiyat.Text);
            fiyat.Add(txtMaxFiyat.Text);
            //string kelime = "";

            ArrayList sonuc = fbll.haritaFiltre(
                            drpIl.SelectedValue,
                            drpIlce.SelectedValue,
                            drpMahalle.SelectedValue,
                            Request.QueryString["cat"],
                            Request.QueryString["tur"],
                            drpKimden.SelectedValue,
                            fiyat,
                            RadioButtonList1.SelectedValue,
                            dizi,
                            dizi2,
                            txtAra.Text,
                            1
                        );
            JArray objDizi = new JArray();
            for (int i = 0; i < sonuc.Count; i++)
            {
                JObject objSonuc = JObject.FromObject((JObject)sonuc[i]);
                objDizi.Add(objSonuc);
            }

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script language='javascript'>alert('" + sonuc + "');</script>", false);

            var ilanTablo = objDizi.ToList();

            ilanRepeater.DataSource = ilanTablo;
            ilanRepeater.DataBind();
        }

        protected void drpIlce_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (drpIlce.SelectedValue == "")
            {
                drpMahalle.Items.Clear();
            }
            else
            {
                drpMahalle.DataSource = mahalleb.list(Convert.ToInt32(drpIlce.SelectedValue));
                drpMahalle.DataTextField = "mahalleAdi";
                drpMahalle.DataValueField = "mahalleId";
                drpMahalle.DataBind();

                ListItem lst = new ListItem();
                lst.Value = "";
                lst.Text = "Seçiniz";
                drpMahalle.Items.Insert(0, lst);
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LinkButton1.Attributes["href"] = "harita/harita.aspx" + "?cat=" + Request.QueryString["cat"] + "&tur=" + Request.QueryString["tur"];
                verilenReklamBll vrb = new verilenReklamBll();
                DAL.verilenReklam rklm = vrb.search(2, 10);
                if (rklm != null)
                {
                    dkdrtgnRklm.ImageUrl = ("~/upload/reklam/" + rklm.reklamResim);
                }
                else
                {
                    dkdrtgnRklm.ImageUrl = ("~/upload/reklam/dkdrt.jpg");
                }
                drpIl.DataSource = ilb.list();
                drpIl.DataTextField = "ilAdi";
                drpIl.DataValueField = "ilId";
                drpIl.DataBind();

                ListItem lst = new ListItem();
                lst.Value = "";
                lst.Text = "Seçiniz";
                drpIl.Items.Insert(0, lst);

                if (Request.QueryString["kategoriId"] != null && Request.QueryString["tur"] != null)
                {
                    kategoriRepeater.DataSource = ktgTurb.list(2, Request.QueryString["kategoriId"], Request.QueryString["tur"]);
                    kategoriRepeater.DataBind();
                }


                ustStr.InnerText = kategorib.search(Convert.ToInt32(kategorib.search(Convert.ToInt32(Request.QueryString["kategoriId"])).ustKategoriId)).kategoriAdi;
                altStr.InnerText = kategorib.search(Convert.ToInt32(Request.QueryString["kategoriId"])).kategoriAdi;

                if (Request.QueryString["kategoriId"] != "4" & Request.QueryString["cat"] == null)
                {
                    ilanRepeater.DataSource = ilanb.list_admin(9, 2, Request.QueryString["kategoriId"], Request.QueryString["tur"], 3);
                    ilanRepeater.DataBind();

                }

                if (catKind(Request.QueryString["kategoriId"]) != true)
                {
                    ilanRepeater.DataSource = ilanb.list_admin(8, 2, Request.QueryString["kategoriId"], 3);
                    ilanRepeater.DataBind();
                }

            }

            if ((Request.QueryString["cat"] != null || Request.QueryString["kategoriId"] == "4"))
            {
                ilanRepeater.DataSource = ilanb.list_admin(8, 2, Request.QueryString["cat"], Request.QueryString["tur"], 3);
                ilanRepeater.DataBind();

            }

            if ((Request.QueryString["cat"] != null || Request.QueryString["tur"] != null))
            {
                tum_ilanlar.InnerText = ilanb.countIlanListe(1, Request.QueryString["cat"], Request.QueryString["tur"]).ToString();
                sahibinden.InnerText = ilanb.countIlanListe(2, Request.QueryString["cat"], Request.QueryString["tur"]).ToString();
                emlakcidan.InnerText = ilanb.countIlanListe(3, Request.QueryString["cat"], Request.QueryString["tur"]).ToString();
                bankadan.InnerText = ilanb.countIlanListe(4, Request.QueryString["cat"], Request.QueryString["tur"]).ToString();
                belediyeden.InnerText = ilanb.countIlanListe(5, Request.QueryString["cat"], Request.QueryString["tur"]).ToString();
                icradan.InnerText = ilanb.countIlanListe(6, Request.QueryString["cat"], Request.QueryString["tur"]).ToString();
                izaleyi_suyu.InnerText = ilanb.countIlanListe(7, Request.QueryString["cat"], Request.QueryString["tur"]).ToString();
                milli_hazineden.InnerText = ilanb.countIlanListe(8, Request.QueryString["cat"], Request.QueryString["tur"]).ToString();
                ozellestirme_dairesinden.InnerText = ilanb.countIlanListe(9, Request.QueryString["cat"], Request.QueryString["tur"]).ToString();
                kamu_kurumlarindan.InnerText = ilanb.countIlanListe(10, Request.QueryString["cat"], Request.QueryString["tur"]).ToString();
                insaat_firmasindan.InnerText = ilanb.countIlanListe(11, Request.QueryString["cat"], Request.QueryString["tur"]).ToString();
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
            magaza _magaza;
            if (_income != null)
            {
                if (_income.ToString() != "-1")
                {
                    _magaza = magazab.search(Convert.ToInt32(_income));

                    if (_magaza.magazaTur.turId == 6 || _magaza.magazaTur.turId == 1 || _magaza.magazaTur.turId == 2 || _magaza.magazaTur.turId == 3 || _magaza.magazaTur.turId == 4 || _magaza.magazaTur.turId == 5 || _magaza.magazaTur.turId == 9)
                    //if (_magaza.magazaTur.turId == 6)
                    {
                        if (Session["unique-site-user"] != null)
                        {
                            kullanici _authority = (kullanici)Session["unique-site-user"];

                            if (_authority.kredi > 0)
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
                            return false;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
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
    }
}
