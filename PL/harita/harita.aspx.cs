using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace PL.harita
{
    public partial class harita : System.Web.UI.Page
    {

        ilanBll ilnBll = new ilanBll();
        girilebilirIlanOzellikBll gioBll = new girilebilirIlanOzellikBll();

        acilIlanBll haritab = new acilIlanBll();

        ilBll ilb = new ilBll();
        ilceBll ilceb = new ilceBll();
        mahalleBll mahalleb = new mahalleBll();
        public string mesaj = "";

        public int kredi = 0;

        protected override void OnInit(EventArgs e)
        {
            if (Session["unique-site-user"] != null)
            {
                DAL.kullanici kullnc = (DAL.kullanici)Session["unique-site-user"];
                kullaniciBll kllBll = new kullaniciBll();
                kredi = Convert.ToInt32(kllBll.search(kullnc.kullaniciId).kredi);
            }

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
                            if (item2.ID == "paftano" || item2.ID == "txtPaftaNo" || item2.ID == "metrefiyat" || item2.ID == "txtMetreFiyat")
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



        }

        protected void Page_Load(object sender, EventArgs e)
        {
            kategoriBll ktgb = new kategoriBll();
            kategori ktg = ktgb.search(Convert.ToInt32(Request.QueryString["cat"]));

            HyperLink btn = this.Master.FindControl("btn_liste") as HyperLink;

            btn.Visible = true;
            btn.NavigateUrl = "~/ilan-liste.aspx?cat=" + Request.QueryString["cat"] + "&tur=" + Request.QueryString["tur"] + "&kategoriId=" + ktg.ustKategoriId;

            if (!IsPostBack)
            {
                drpIl.DataSource = ilb.list();
                drpIl.DataTextField = "ilAdi";
                drpIl.DataValueField = "ilId";
                drpIl.DataBind();

                ListItem lst = new ListItem();
                lst.Value = "";
                lst.Text = "Seçiniz";
                drpIl.Items.Insert(0, lst);

                acilRepeater.DataSource = haritab.ilanGetir(drpIl.SelectedValue);
                acilRepeater.DataBind();

                verilenReklamBll vrb = new verilenReklamBll();
                reklamRepeater.DataSource = vrb.listHarita(2, drpIl.SelectedValue);
                reklamRepeater.DataBind();

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

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (drpIl.SelectedItem.Text == "Seçiniz")
            {
                mesaj = "Önce il seçimi yapmalısınız !";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script language='javascript'>uyariVer();</script>", false);
            }
            else
            {

                ArrayList dizi = new ArrayList();
                ArrayList dizi2 = new ArrayList();
                filtreBll fbll = new filtreBll();

                string yolla = "";
                JObject obj = new JObject();
                int kontrol = 0;
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
                                                kontrol++;
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
                                                kontrol++;
                                            }
                                            if (kontrol != 2)
                                            {
                                                dizi2.Add(obj);
                                            }
                                            kontrol = 0;
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
                                txtAra.Text
                            );

                JArray objDizi = new JArray();
                if (sonuc.Count==0)
                {
                    mesaj = "Sonuç Bulunamadı";
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "initMap", "alert(" + sonuc.Count + ");", true);
                    for (int i = 0; i < sonuc.Count; i++)
                    {
                        JObject objSonuc = JObject.FromObject((JObject)sonuc[i]);
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "initMap", "alert(" + objSonuc["koordinat"].ToString() + ");", true);
                        objDizi.Add(objSonuc);
                    }
                    string ilKoordinat = "{lat:" + ilb.search(Convert.ToInt32(drpIl.SelectedValue)).enlem + ",lng:" + ilb.search(Convert.ToInt32(drpIl.SelectedValue)).boylam + "}";
                    JObject objil = JObject.Parse(ilKoordinat);
                    objDizi.Add(objil);
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "initMap", "initMap(" + objDizi + ");", true);

                verilenReklamBll vrb = new verilenReklamBll();
                reklamRepeater.DataSource = vrb.listHarita(2, 31);
                reklamRepeater.DataBind();

                acilRepeater.DataSource = haritab.ilanGetir(drpIl.SelectedValue);
                acilRepeater.DataBind();

            }
        }

        public int kimdenDondur(object magazaId)
        {
            magazaBll mgzBll = new magazaBll();
            magazaTurBll mgzTurBll = new magazaTurBll();

            int turId = 1;

            if (magazaId != null)
            {
                int gecici = Convert.ToInt32(mgzBll.search(Convert.ToInt32(magazaId)).magazaTurId);

                turId = Convert.ToInt32(mgzTurBll.search(gecici).turId);
            }

            return turId;
        }

        public object jsonCevir(params object[] _income)
        {
            string magaza = "";
            string kimden = "";
            if (_income[13] != null)
            {
                magaza = _income[13].ToString();
                kimden = _income[4].ToString();
            }
            else
            {
                magaza = "-1";
                kimden = "-1";
            }
            string dondur = @"{
                'ilanId':" + _income[0].ToString() + "," +
                "'baslik':'" + _income[1].ToString() + "'," +
                "'fiyat':'" + _income[2].ToString() + "'," +
                "'resim':'" + _income[3].ToString() + "'," +
                "'kimden':'" + kimden + "'," +
                "'gecmisMi':0," + // buraya sorgudan gelen satış tarihi geçmiş mi değeri yazılacak
                "'metreKare':'" + _income[5].ToString() + "'," +
                "'il':'" + _income[6].ToString() + "'," +
                "'ilce':'" + _income[7].ToString() + "'," +
                "'mahalle':'" + _income[8].ToString() + "'," +
                "'acilMi':'" + Convert.ToBoolean(_income[10]) + "'," +
                "'baslangicTarihi':'" + _income[11].ToString() + "'," +
                "'magazaId':'" + magaza + "'," +
                "'ilanTurId':'" + _income[12].ToString() + "'";

            if (_income[9].ToString() != "-1")
            {
                dondur += ",'koordinat':" + _income[9] + "}";
            }
            else
            {
                dondur += ",'koordinat':-1}";
            }

            JObject dizi = JObject.Parse(dondur);
            JArray objDizi = new JArray();
            objDizi.Add(dizi);

            return objDizi;
        }

        public bool krediKontrol(object _income)
        {
            magazaBll magazab = new magazaBll();
            magaza _magaza;
            if (_income != null)
            {
                if (_income.ToString() != "-1")
                {
                    _magaza = magazab.search(Convert.ToInt32(_income));


                    if (_magaza.magazaTur.turId == 6)
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
        public string ozellikDondur(object _income, int _id)
        {
            var snc = gioBll.search(Convert.ToInt32(_income), _id);
            if (snc != null)
            {
                return snc.deger;
            }
            else
            {
                return "-1";
            }
        }

        public int krediGuncelle()
        {
            if (Session["unique-site-user"] != null)
            {
                DAL.kullanici kullnc = (DAL.kullanici)Session["unique-site-user"];
                kullaniciBll kllBll = new kullaniciBll();
                kredi = Convert.ToInt32(kllBll.search(kullnc.kullaniciId).kredi);
                return kredi;
            }
            else
            {
                return -1;
            }
        }
    }
}