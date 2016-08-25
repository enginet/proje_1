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
    public partial class ilan_form1 : System.Web.UI.Page
    {

        ilBll ilb = new ilBll();
        ilceBll ilceb = new ilceBll();
        mahalleBll mahalleb = new mahalleBll();

        ilanBll ilnBll = new ilanBll();

        secilebilirIlanOzellikBll soBll = new secilebilirIlanOzellikBll();
        //girilebilirIlanOzellikBll goBll = new girilebilirIlanOzellikBll();

        protected override void OnInit(EventArgs e)
        {
            PlaceHolder1.Controls.Add(Page.LoadControl("~/ozellikler/kimden-ozellik.ascx"));
            PlaceHolder1.Visible = false;


            // Burda her bir kategorinin Id değeri bilinmesi gerekir.
            // Her bir gelen kategoriye göre o kategoriye ait alanlar çekilir

            // 8 daire / 10 müstakil ev / 11 yalı / 16 yazlık / 18 kooperatif
            if (Request.QueryString["cat"] == "8" || Request.QueryString["cat"] == "10" || Request.QueryString["cat"] == "11" || Request.QueryString["cat"] == "16" || Request.QueryString["cat"] == "18")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/oda-sayisi.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/bulundugu-kat.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/kat-sayisi.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/isitma.ascx"));
                PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/banyo-sayisi.ascx"));
                PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/esyali.ascx"));
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/kullanim-durumu.ascx"));
                PlaceHolder13.Controls.Add(Page.LoadControl("~/ozellikler/site-icerisinde.ascx"));
                PlaceHolder14.Controls.Add(Page.LoadControl("~/ozellikler/aidat.ascx"));
                PlaceHolder15.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder16.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

                //multiselect özellikler
                PlaceHolder17.Controls.Add(Page.LoadControl("~/ozellikler/cephe.ascx"));
                PlaceHolder18.Controls.Add(Page.LoadControl("~/ozellikler/icozellik.ascx"));
                PlaceHolder19.Controls.Add(Page.LoadControl("~/ozellikler/disozellik.ascx"));
                PlaceHolder20.Controls.Add(Page.LoadControl("~/ozellikler/engelliuygun.ascx"));
                PlaceHolder21.Controls.Add(Page.LoadControl("~/ozellikler/muhit.ascx"));
                PlaceHolder22.Controls.Add(Page.LoadControl("~/ozellikler/ulasim.ascx"));
                PlaceHolder23.Controls.Add(Page.LoadControl("~/ozellikler/manzara.ascx"));
                PlaceHolder24.Controls.Add(Page.LoadControl("~/ozellikler/konuttip.ascx"));

            }
            // 9 residence
            if (Request.QueryString["cat"] == "9")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/oda-sayisi-text.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/salon-sayisi-text.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi-text.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/bulundugu-kat-text.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/kat-sayisi-text.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/konut-sekli.ascx"));
                PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/isinma-yakit.ascx"));
                PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/balkon.ascx"));
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/banyo-sayisi-text.ascx"));
                PlaceHolder13.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                PlaceHolder14.Controls.Add(Page.LoadControl("~/ozellikler/kullanim-durumu.ascx"));
                PlaceHolder15.Controls.Add(Page.LoadControl("~/ozellikler/site-icerisinde.ascx"));
                PlaceHolder16.Controls.Add(Page.LoadControl("~/ozellikler/aidat.ascx"));
                PlaceHolder17.Controls.Add(Page.LoadControl("~/ozellikler/zemin-etudu.ascx"));
                PlaceHolder18.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder19.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

                //multiselect özellikler
                PlaceHolder20.Controls.Add(Page.LoadControl("~/ozellikler/cephe.ascx"));
                PlaceHolder21.Controls.Add(Page.LoadControl("~/ozellikler/icozellik.ascx"));
                PlaceHolder22.Controls.Add(Page.LoadControl("~/ozellikler/manzara.ascx"));
                PlaceHolder23.Controls.Add(Page.LoadControl("~/ozellikler/alt-yapi.ascx"));
                PlaceHolder24.Controls.Add(Page.LoadControl("~/ozellikler/konut-ozellik.ascx"));
                PlaceHolder25.Controls.Add(Page.LoadControl("~/ozellikler/cevre-ozellik.ascx"));
                PlaceHolder26.Controls.Add(Page.LoadControl("~/ozellikler/sosyal.ascx"));

            }
            // 12 çiftlik evi
            if (Request.QueryString["cat"] == "12")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/bina-arazi-metre.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/oda-sayisi-text.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/salon-sayisi-text.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi-text.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/kat-sayisi-text.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/isinma-yakit.ascx"));
                PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/yapi-tipi.ascx"));
                PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/balkon.ascx"));
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/banyo-sayisi-text.ascx"));
                PlaceHolder13.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                PlaceHolder14.Controls.Add(Page.LoadControl("~/ozellikler/kullanim-durumu.ascx"));
                PlaceHolder15.Controls.Add(Page.LoadControl("~/ozellikler/tapu-durum.ascx"));
                PlaceHolder16.Controls.Add(Page.LoadControl("~/ozellikler/zemin-etudu.ascx"));
                PlaceHolder17.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder18.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

                //multiselect özellikler
                PlaceHolder19.Controls.Add(Page.LoadControl("~/ozellikler/cephe.ascx"));
                PlaceHolder20.Controls.Add(Page.LoadControl("~/ozellikler/icozellik.ascx"));
                PlaceHolder21.Controls.Add(Page.LoadControl("~/ozellikler/dis-cephe-ozellik.ascx"));
                PlaceHolder22.Controls.Add(Page.LoadControl("~/ozellikler/manzara.ascx"));
                PlaceHolder23.Controls.Add(Page.LoadControl("~/ozellikler/alt-yapi.ascx"));
                PlaceHolder24.Controls.Add(Page.LoadControl("~/ozellikler/konut-ozellik.ascx"));
                PlaceHolder25.Controls.Add(Page.LoadControl("~/ozellikler/cevre-ozellik.ascx"));

            }

            // 13 köşk & konak
            if (Request.QueryString["cat"] == "13")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/bina-arazi-metre.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/oda-sayisi-text.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/salon-sayisi-text.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi-text.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/kat-sayisi-text.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/isinma-yakit.ascx"));
                PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/yapi-tipi.ascx"));
                PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/balkon.ascx"));
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/banyo-sayisi-text.ascx"));
                PlaceHolder13.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                PlaceHolder14.Controls.Add(Page.LoadControl("~/ozellikler/kullanim-durumu.ascx"));
                PlaceHolder15.Controls.Add(Page.LoadControl("~/ozellikler/tapu-durum.ascx"));
                PlaceHolder16.Controls.Add(Page.LoadControl("~/ozellikler/zemin-etudu.ascx"));
                PlaceHolder17.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder18.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

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

            // 14 yalı
            if (Request.QueryString["cat"] == "14")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/bina-arazi-metre.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/oda-sayisi-text.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/salon-sayisi-text.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi-text.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/kat-sayisi-text.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/isinma-yakit.ascx"));
                PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/yapi-tipi.ascx"));
                PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/balkon.ascx"));
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/banyo-sayisi-text.ascx"));
                PlaceHolder13.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                PlaceHolder14.Controls.Add(Page.LoadControl("~/ozellikler/kullanim-durumu.ascx"));
                PlaceHolder15.Controls.Add(Page.LoadControl("~/ozellikler/tapu-durum.ascx"));
                PlaceHolder16.Controls.Add(Page.LoadControl("~/ozellikler/zemin-etudu.ascx"));
                PlaceHolder17.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder18.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

                //multiselect özellikler
                PlaceHolder19.Controls.Add(Page.LoadControl("~/ozellikler/cephe.ascx"));
                PlaceHolder20.Controls.Add(Page.LoadControl("~/ozellikler/icozellik.ascx"));
                PlaceHolder21.Controls.Add(Page.LoadControl("~/ozellikler/dis-cephe-ozellik.ascx"));
                PlaceHolder22.Controls.Add(Page.LoadControl("~/ozellikler/manzara.ascx"));
                PlaceHolder23.Controls.Add(Page.LoadControl("~/ozellikler/alt-yapi.ascx"));
                PlaceHolder24.Controls.Add(Page.LoadControl("~/ozellikler/konut-ozellik.ascx"));
                PlaceHolder25.Controls.Add(Page.LoadControl("~/ozellikler/cevre-ozellik.ascx"));

            }

            // 15 yalı dairesi
            if (Request.QueryString["cat"] == "15")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/oda-sayisi-text.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/salon-sayisi-text.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi-text.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/bulundugu-kat-text.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/kat-sayisi-text.ascx"));
                PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/isinma-yakit.ascx"));
                PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/yapi-tipi.ascx"));
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/balkon.ascx"));
                PlaceHolder13.Controls.Add(Page.LoadControl("~/ozellikler/banyo-sayisi-text.ascx"));
                PlaceHolder14.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                PlaceHolder15.Controls.Add(Page.LoadControl("~/ozellikler/kullanim-durumu.ascx"));
                PlaceHolder16.Controls.Add(Page.LoadControl("~/ozellikler/tapu-durum.ascx"));
                PlaceHolder17.Controls.Add(Page.LoadControl("~/ozellikler/zemin-etudu.ascx"));
                PlaceHolder18.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder19.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

                //multiselect özellikler
                PlaceHolder20.Controls.Add(Page.LoadControl("~/ozellikler/cephe.ascx"));
                PlaceHolder21.Controls.Add(Page.LoadControl("~/ozellikler/icozellik.ascx"));
                PlaceHolder22.Controls.Add(Page.LoadControl("~/ozellikler/dis-cephe-ozellik.ascx"));
                PlaceHolder23.Controls.Add(Page.LoadControl("~/ozellikler/manzara.ascx"));
                PlaceHolder24.Controls.Add(Page.LoadControl("~/ozellikler/alt-yapi.ascx"));
                PlaceHolder25.Controls.Add(Page.LoadControl("~/ozellikler/konut-ozellik.ascx"));
                PlaceHolder26.Controls.Add(Page.LoadControl("~/ozellikler/cevre-ozellik.ascx"));

            }

            // 17 prefabrik ev
            if (Request.QueryString["cat"] == "17")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/oda-sayisi-text.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/kat-sayisi-text.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/banyo-sayisi-text.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/dis-cephe-durum.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/isitma.ascx"));
                PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

                //multiselect özellikler
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/detayli-bilgi.ascx"));

            }
            // 4 arsa
            if (Request.QueryString["cat"] == "4")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/arsa-ozellik.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/tapu-durum.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

                //multiselect özellikler
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/alt-yapi.ascx"));
                PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/konum.ascx"));
                PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/genel-ozellik.ascx"));
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/manzara.ascx"));

            }
            // 5 bina
            if (Request.QueryString["cat"] == "5")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/daire-sayisi.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/kat-sayisi.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/isitma.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

                //multiselect özellikler
                PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/detay-bilgisi.ascx"));

            }
            // 6 devremülk
            if (Request.QueryString["cat"] == "6")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/devremulk-ozellik.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

                //multiselect özellikler
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/detay-bilgisi.ascx"));

            }
            // 35 otel / 42 tatil köyü
            if (Request.QueryString["cat"] == "35" || Request.QueryString["cat"] == "40")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/acik-kapali-metre.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/yildiz-sayisi.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/oda-yatak-kat-sayisi.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/zemin-etudu.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

                //multiselect özellikler
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
            // 36 apart otel
            if (Request.QueryString["cat"] == "36")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/acik-kapali-metre.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/apart-sayisi.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/oda-yatak-kat-sayisi.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/zemin-etudu.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

                //multiselect özellikler
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
            // 37 butik otel / 38 pansiyon / 41 motel
            if (Request.QueryString["cat"] == "37" || Request.QueryString["cat"] == "38" || Request.QueryString["cat"] == "41")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/acik-kapali-metre.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/oda-yatak-kat-sayisi.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/zemin-etudu.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

                //multiselect özellikler
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

            // 39 kamp yeri
            if (Request.QueryString["cat"] == "39")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

                //multiselect özellikler
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

            // 42 plaj
            if (Request.QueryString["cat"] == "42")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/kapasite.ascx"));

            }
            // 21 atölye
            if (Request.QueryString["cat"] == "21")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
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
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/yapi-tipi.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/kullanim-durumu.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

                //multiselect özellikler
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/genel-ozellik.ascx"));

            }
            // 29 büro & ofis
            if (Request.QueryString["cat"] == "29")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/oda-sayisi.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/aidat.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/isitma.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/durum.ascx"));
                PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

                //multiselect özellikler
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/detay-bilgisi.ascx"));

            }
            // 22 depo & antrepo
            if (Request.QueryString["cat"] == "22")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/giris-yuksek.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi-text.ascx"));
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

                //multiselect özellikler
                PlaceHolder14.Controls.Add(Page.LoadControl("~/ozellikler/genel-ozellik.ascx"));
                PlaceHolder15.Controls.Add(Page.LoadControl("~/ozellikler/cephe.ascx"));
                PlaceHolder16.Controls.Add(Page.LoadControl("~/ozellikler/alt-yapi.ascx"));

            }
            // 23 dükkan & mağaza
            if (Request.QueryString["cat"] == "23")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/bolum-oda-sayisi.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/aidat.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/isitma.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/durum.ascx"));
                PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (Request.QueryString["tur"] == "2" || Request.QueryString["tur"] == "3" || Request.QueryString["tur"] == "5")
                {
                    PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

                //multiselect özellikler
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/kullanim-amaci.ascx"));
                PlaceHolder13.Controls.Add(Page.LoadControl("~/ozellikler/genel-ozellik.ascx"));
                PlaceHolder14.Controls.Add(Page.LoadControl("~/ozellikler/yakinlik.ascx"));
                PlaceHolder15.Controls.Add(Page.LoadControl("~/ozellikler/manzara.ascx"));
                PlaceHolder16.Controls.Add(Page.LoadControl("~/ozellikler/cephe.ascx"));
                PlaceHolder17.Controls.Add(Page.LoadControl("~/ozellikler/alt-yapi.ascx"));

            }
            // 24 fabrika
            if (Request.QueryString["cat"] == "24")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/acik-kapali-metre.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/bolum-oda-sayisi.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/bina-adedi.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/kat-sayisi-text.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/giris-yuksek.ascx"));
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

                //multiselect özellikler
                PlaceHolder17.Controls.Add(Page.LoadControl("~/ozellikler/yakinlik.ascx"));
                PlaceHolder18.Controls.Add(Page.LoadControl("~/ozellikler/manzara.ascx"));
                PlaceHolder19.Controls.Add(Page.LoadControl("~/ozellikler/cephe.ascx"));
                PlaceHolder20.Controls.Add(Page.LoadControl("~/ozellikler/alt-yapi.ascx"));

            }

            // imalathane de kaldım. Gerisi yapılacak.

        }


        protected void Page_Load(object sender, EventArgs e)
        {
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
            }
        }

        protected void drpIl_SelectedIndexChanged(object sender, EventArgs e)
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
        }

        protected void drpIlce_SelectedIndexChanged(object sender, EventArgs e)
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

        protected void devam_Click1(object sender, EventArgs e)
        {
            // ilk olarak ilansahibi bilgileri kaydedilir.
            //shb.insert(txtAd.Text + " " + txtSoyad.Text);

            // sonra telefonlarını ekliyoruz
            //ilanSahibi ishb = shb.list().Last();

            //shpTlf.insert(ishb.ilanSahibiId, DAL.toolkit.Number_Remover(txtCepTlf.Text), 1);
            //shpTlf = new sahipTelefonlarBll();
            //shpTlf.insert(ishb.ilanSahibiId, DAL.toolkit.Number_Remover(txtIsTlf.Text), 3);

            // sonra ilan bilgilerini ekliyoruz
            ilnBll.insert(
                    Request.QueryString["tur"], // ilan türü
                    Request.QueryString["cat"], // ilan kategorisi
                    txtFiyat.Text, // fiyat
                    1, // fiyat türü (TL)
                    1, // Buraya kimden giriş yapılmışsa
                    2, // buraya oturum açan kullanıcının id değeri gelecek 
                    drpIl.SelectedValue,
                    drpIlce.SelectedValue,
                    drpMahalle.SelectedValue,
                    txtBaslik.Text,
                    txtCKeditorAdi.Text,
                    //ishb.ilanSahibiId, // ilansahibiId
                    1, // onay durumu
                    numaraYayinlansin.Checked // numara yayınlansın mı
                );

            DAL.ilan iln = ilnBll.list().Last();



            foreach (Control item in box_footer.Controls)
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
                                    soBll.insert(iln.ilanId, ((DropDownList)item3).SelectedValue);
                                }
                            }
                            else if (item3 is TextBox)
                            {
                                if (((TextBox)item3).Text != "")
                                {
                                    //goBll.insert(iln.ilanId, ((TextBox)item3).Attributes["Value"], ((TextBox)item3).Text);
                                }
                            }
                            else
                            {
                                foreach (Control item4 in item3.Controls)
                                {
                                    foreach (Control item5 in item4.Controls)
                                    {
                                        if (item5 is CheckBox)
                                        {
                                            if (((CheckBox)item5).Checked)
                                            {
                                                soBll.insert(iln.ilanId, ((CheckBox)item5).Attributes["value"]);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}