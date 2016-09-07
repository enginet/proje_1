using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using System.IO;
using System.Drawing;

namespace PL
{
    public partial class ilan_form1 : System.Web.UI.Page
    {

        ilBll ilb = new ilBll();
        ilceBll ilceb = new ilceBll();
        mahalleBll mahalleb = new mahalleBll();

        ilanBll ilnBll = new ilanBll();

        ilanResimBll ir = new ilanResimBll();

        secilebilirIlanOzellikBll soBll = new secilebilirIlanOzellikBll();
        girilebilirIlanOzellikBll goBll = new girilebilirIlanOzellikBll();

        magazaKullaniciBll mkul = new magazaKullaniciBll();
        magazaBll mgzB = new magazaBll();

        string magazaId = "", kategoriId = "", ilanTurId = "";

        protected override void OnInit(EventArgs e)
        {
            PlaceHolder1.Controls.Add(Page.LoadControl("~/ozellikler/kimden-ozellik.ascx"));
            PlaceHolder1.Visible = false;

            // Burda her bir kategorinin Id değeri bilinmesi gerekir.
            // Her bir gelen kategoriye göre o kategoriye ait alanlar çekilir

            // 8 daire / 10 müstakil ev / 11 yalı / 16 yazlık / 18 kooperatif

            if (Session["unique-site-user"] != null)
            {
                if (Session["cat"] != null)
                {
                    if (Session["cat"].ToString() == "8" || Session["cat"].ToString() == "10" || Session["cat"].ToString() == "11" || Session["cat"].ToString() == "16" || Session["cat"].ToString() == "18")
                    {

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

                        if (Session["tur"].ToString() == "2" || Session["tur"].ToString() == "3" || Session["tur"].ToString() == "5")
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
                    if (Session["cat"].ToString() == "9")
                    {

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

                        if (Session["tur"].ToString() == "2" || Session["tur"].ToString() == "3" || Session["tur"].ToString() == "5")
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
                    if (Session["cat"].ToString() == "12")
                    {

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

                        if (Session["tur"].ToString() == "2" || Session["tur"].ToString() == "3" || Session["tur"].ToString() == "5")
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
                    if (Session["cat"].ToString() == "13")
                    {

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

                        if (Session["tur"].ToString() == "2" || Session["tur"].ToString() == "3" || Session["tur"].ToString() == "5")
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
                    if (Session["cat"].ToString() == "14")
                    {

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

                        if (Session["tur"].ToString() == "2" || Session["tur"].ToString() == "3" || Session["tur"].ToString() == "5")
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
                    if (Session["cat"].ToString() == "15")
                    {

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

                        if (Session["tur"].ToString() == "2" || Session["tur"].ToString() == "3" || Session["tur"].ToString() == "5")
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
                    if (Session["cat"].ToString() == "17")
                    {

                        PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                        PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                        PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/oda-sayisi-text.ascx"));
                        PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/kat-sayisi-text.ascx"));
                        PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/banyo-sayisi-text.ascx"));
                        PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/dis-cephe-durum.ascx"));
                        PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/isitma.ascx"));
                        PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                        if (Session["tur"].ToString() == "2" || Session["tur"].ToString() == "3" || Session["tur"].ToString() == "5")
                        {
                            PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                        }

                        //multiselect özellikler
                        PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/detayli-bilgi.ascx"));

                    }
                    // 4 arsa
                    if (Session["cat"].ToString() == "4")
                    {
                        PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                        PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                        PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/arsa-ozellik.ascx"));
                        PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/tapu-durum.ascx"));
                        PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                        if (Session["tur"].ToString() == "2" || Session["tur"].ToString() == "3" || Session["tur"].ToString() == "5")
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
                    if (Session["cat"].ToString() == "5")
                    {

                        PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                        PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                        PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/daire-sayisi.ascx"));
                        PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/kat-sayisi.ascx"));
                        PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/isitma.ascx"));
                        PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                        PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                        if (Session["tur"].ToString() == "2" || Session["tur"].ToString() == "3" || Session["tur"].ToString() == "5")
                        {
                            PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                        }

                        //multiselect özellikler
                        PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/detay-bilgisi.ascx"));

                    }
                    // 6 devremülk
                    if (Session["cat"].ToString() == "6")
                    {
                        PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/devremulk-ozellik.ascx"));

                        if (Session["tur"].ToString() == "2" || Session["tur"].ToString() == "3" || Session["tur"].ToString() == "5")
                        {
                            PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                        }

                        //multiselect özellikler
                        PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/detay-bilgisi.ascx"));

                    }
                    // 35 otel / 42 tatil köyü
                    if (Session["cat"].ToString() == "35" || Session["cat"].ToString() == "40")
                    {

                        PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                        PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/acik-kapali-metre.ascx"));
                        PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/yildiz-sayisi.ascx"));
                        PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/oda-yatak-kat-sayisi.ascx"));
                        PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                        PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                        PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/zemin-etudu.ascx"));

                        if (Session["tur"].ToString() == "2" || Session["tur"].ToString() == "3" || Session["tur"].ToString() == "5")
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
                    if (Session["cat"].ToString() == "36")
                    {

                        PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                        PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/acik-kapali-metre.ascx"));
                        PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/apart-sayisi.ascx"));
                        PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/oda-yatak-kat-sayisi.ascx"));
                        PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                        PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                        PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/zemin-etudu.ascx"));

                        if (Session["tur"].ToString() == "2" || Session["tur"].ToString() == "3" || Session["tur"].ToString() == "5")
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
                    if (Session["cat"].ToString() == "37" || Session["cat"].ToString() == "38" || Session["cat"].ToString() == "41")
                    {

                        PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                        PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/acik-kapali-metre.ascx"));
                        PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/oda-yatak-kat-sayisi.ascx"));
                        PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                        PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                        PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/zemin-etudu.ascx"));

                        if (Session["tur"].ToString() == "2" || Session["tur"].ToString() == "3" || Session["tur"].ToString() == "5")
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
                    if (Session["cat"].ToString() == "39")
                    {

                        PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                        PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));

                        if (Session["tur"].ToString() == "2" || Session["tur"].ToString() == "3" || Session["tur"].ToString() == "5")
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
                    if (Session["cat"].ToString() == "42")
                    {

                        PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                        PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                        PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/kapasite.ascx"));

                    }
                    // 21 atölye
                    if (Session["cat"].ToString() == "21")
                    {

                        PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                        PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/durum.ascx"));
                        PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                        if (Session["tur"].ToString() == "2" || Session["tur"].ToString() == "3" || Session["tur"].ToString() == "5")
                        {
                            PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                        }

                    }
                    // 20 büfe
                    if (Session["cat"].ToString() == "20")
                    {

                        PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                        PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                        PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/yapi-tipi.ascx"));
                        PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                        PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/kullanim-durumu.ascx"));

                        if (Session["tur"].ToString() == "2" || Session["tur"].ToString() == "3" || Session["tur"].ToString() == "5")
                        {
                            PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                        }

                        //multiselect özellikler
                        PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/genel-ozellik.ascx"));

                    }
                    // 29 büro & ofis
                    if (Session["cat"].ToString() == "29")
                    {

                        PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                        PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                        PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/oda-sayisi.ascx"));
                        PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                        PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/aidat.ascx"));
                        PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/isitma.ascx"));
                        PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/durum.ascx"));
                        PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                        if (Session["tur"].ToString() == "2" || Session["tur"].ToString() == "3" || Session["tur"].ToString() == "5")
                        {
                            PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                        }

                        //multiselect özellikler
                        PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/detay-bilgisi.ascx"));

                    }
                    // 22 depo & antrepo
                    if (Session["cat"].ToString() == "22")
                    {

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

                        if (Session["tur"].ToString() == "2" || Session["tur"].ToString() == "3" || Session["tur"].ToString() == "5")
                        {
                            PlaceHolder13.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                        }

                        //multiselect özellikler
                        PlaceHolder14.Controls.Add(Page.LoadControl("~/ozellikler/genel-ozellik.ascx"));
                        PlaceHolder15.Controls.Add(Page.LoadControl("~/ozellikler/cephe.ascx"));
                        PlaceHolder16.Controls.Add(Page.LoadControl("~/ozellikler/alt-yapi.ascx"));

                    }
                    // 23 dükkan & mağaza
                    if (Session["cat"].ToString() == "23")
                    {

                        PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                        PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                        PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/bolum-oda-sayisi.ascx"));
                        PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/aidat.ascx"));
                        PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/isitma.ascx"));
                        PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                        PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/durum.ascx"));
                        PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                        if (Session["tur"].ToString() == "2" || Session["tur"].ToString() == "3" || Session["tur"].ToString() == "5")
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
                    if (Session["cat"].ToString() == "24")
                    {

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

                        if (Session["tur"].ToString() == "2" || Session["tur"].ToString() == "3" || Session["tur"].ToString() == "5")
                        {
                            PlaceHolder16.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                        }

                        //multiselect özellikler
                        PlaceHolder17.Controls.Add(Page.LoadControl("~/ozellikler/yakinlik.ascx"));
                        PlaceHolder18.Controls.Add(Page.LoadControl("~/ozellikler/manzara.ascx"));
                        PlaceHolder19.Controls.Add(Page.LoadControl("~/ozellikler/cephe.ascx"));
                        PlaceHolder20.Controls.Add(Page.LoadControl("~/ozellikler/alt-yapi.ascx"));

                    }
                    // 25 İşhanı Katı
                    if (Session["cat"].ToString() == "25")
                    {

                        PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                        PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                        PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/bolum-oda-sayisi.ascx"));
                        PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/kat-sayisi-text.ascx"));
                        PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/bulundugu-kat.ascx"));
                        PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                        PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/aidat.ascx"));
                        PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/isinma-yakit.ascx"));
                        PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                        PlaceHolder13.Controls.Add(Page.LoadControl("~/ozellikler/kullanim-durumu.ascx"));
                        PlaceHolder14.Controls.Add(Page.LoadControl("~/ozellikler/tapu-durum.ascx"));
                        PlaceHolder15.Controls.Add(Page.LoadControl("~/ozellikler/zemin-etudu.ascx"));
                        PlaceHolder16.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                        if (Session["tur"].ToString() == "2" || Session["tur"].ToString() == "3" || Session["tur"].ToString() == "5")
                        {
                            PlaceHolder17.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                        }

                        //multiselect özellikler
                        PlaceHolder18.Controls.Add(Page.LoadControl("~/ozellikler/yakinlik.ascx"));
                        PlaceHolder19.Controls.Add(Page.LoadControl("~/ozellikler/manzara.ascx"));
                        PlaceHolder20.Controls.Add(Page.LoadControl("~/ozellikler/cephe.ascx"));
                        PlaceHolder21.Controls.Add(Page.LoadControl("~/ozellikler/alt-yapi.ascx"));
                        PlaceHolder22.Controls.Add(Page.LoadControl("~/ozellikler/genel-ozellik.ascx"));

                    }
                    // 26 Komple Bina
                    if (Session["cat"].ToString() == "26")
                    {

                        PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                        PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                        PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/bina-tipi.ascx"));
                        PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/kat-sayisi-text.ascx"));
                        PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                        PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/isinma-yakit.ascx"));
                        PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                        PlaceHolder13.Controls.Add(Page.LoadControl("~/ozellikler/kullanim-durumu.ascx"));
                        PlaceHolder15.Controls.Add(Page.LoadControl("~/ozellikler/zemin-etudu.ascx"));
                        PlaceHolder16.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                        if (Session["tur"].ToString() == "2" || Session["tur"].ToString() == "3" || Session["tur"].ToString() == "5")
                        {
                            PlaceHolder17.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                        }

                        //multiselect özellikler
                        PlaceHolder18.Controls.Add(Page.LoadControl("~/ozellikler/kullanim-amaci.ascx"));
                        PlaceHolder19.Controls.Add(Page.LoadControl("~/ozellikler/bina-ozellik.ascx"));
                        PlaceHolder20.Controls.Add(Page.LoadControl("~/ozellikler/dis-cephe-ozellik.ascx"));
                        PlaceHolder21.Controls.Add(Page.LoadControl("~/ozellikler/yakinlik.ascx"));
                        PlaceHolder22.Controls.Add(Page.LoadControl("~/ozellikler/manzara.ascx"));
                        PlaceHolder23.Controls.Add(Page.LoadControl("~/ozellikler/cephe.ascx"));
                        PlaceHolder24.Controls.Add(Page.LoadControl("~/ozellikler/alt-yapi.ascx"));

                    }
                    // 27 Plaza Katı
                    if (Session["cat"].ToString() == "27")
                    {

                        PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                        PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                        PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/bolum-oda-sayisi.ascx"));
                        PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/kat-sayisi-text.ascx"));
                        PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/bulundugu-kat.ascx"));
                        PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                        PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/aidat.ascx"));
                        PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/isinma-yakit.ascx"));
                        PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                        PlaceHolder13.Controls.Add(Page.LoadControl("~/ozellikler/kullanim-durumu.ascx"));
                        PlaceHolder14.Controls.Add(Page.LoadControl("~/ozellikler/tapu-durum.ascx"));
                        PlaceHolder15.Controls.Add(Page.LoadControl("~/ozellikler/zemin-etudu.ascx"));
                        PlaceHolder16.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                        if (Session["tur"].ToString() == "2" || Session["tur"].ToString() == "3" || Session["tur"].ToString() == "5")
                        {
                            PlaceHolder17.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                        }

                        //multiselect özellikler
                        PlaceHolder18.Controls.Add(Page.LoadControl("~/ozellikler/yakinlik.ascx"));
                        PlaceHolder19.Controls.Add(Page.LoadControl("~/ozellikler/manzara.ascx"));
                        PlaceHolder20.Controls.Add(Page.LoadControl("~/ozellikler/cephe.ascx"));
                        PlaceHolder21.Controls.Add(Page.LoadControl("~/ozellikler/alt-yapi.ascx"));
                        PlaceHolder22.Controls.Add(Page.LoadControl("~/ozellikler/genel-ozellik.ascx"));
                    }
                    // 28 İmalathane
                    if (Session["cat"].ToString() == "28")
                    {

                        PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                        PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                        PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/bolum-oda-sayisi.ascx"));
                        PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                        PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/isitma.ascx"));
                        PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                        if (Session["tur"].ToString() == "2" || Session["tur"].ToString() == "3" || Session["tur"].ToString() == "5")
                        {
                            PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                        }

                        //multiselect özellikler
                        PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/detay-bilgisi.ascx"));
                    }
                    // 30 market
                    if (Session["cat"].ToString() == "30")
                    {

                        PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                        PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                        PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/isitma.ascx"));
                        PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                        if (Session["tur"].ToString() == "2" || Session["tur"].ToString() == "3" || Session["tur"].ToString() == "5")
                        {
                            PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                        }
                    }
                    // 31 Restoran lokanta
                    if (Session["cat"].ToString() == "31")
                    {

                        PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                        PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                        PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                        PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/isitma.ascx"));
                        PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/aidat.ascx"));
                        PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/kapasite.ascx"));
                        PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/masa-sayisi.ascx"));
                        PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                        if (Session["tur"].ToString() == "2" || Session["tur"].ToString() == "3" || Session["tur"].ToString() == "5")
                        {
                            PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                        }

                        //multiselect özellikler
                        PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/detay-bilgisi.ascx"));
                    }
                    // 32 Kuaför Güzellik Merkezi
                    if (Session["cat"].ToString() == "32")
                    {

                        PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                        PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                        PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/oda-sayisi.ascx"));
                        PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/isitma.ascx"));
                        PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/aidat.ascx"));
                        PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                        PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/bulundugu-kat.ascx"));
                        PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                        if (Session["tur"].ToString() == "2" || Session["tur"].ToString() == "3" || Session["tur"].ToString() == "5")
                        {
                            PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                        }

                        //multiselect özellikler
                        PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/kuafor-detay-bilgisi.ascx"));
                    }
                    // 33 Tekel Bayi
                    if (Session["cat"].ToString() == "33")
                    {

                        PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                        PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                        PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/isitma.ascx"));

                        if (Session["tur"].ToString() == "2" || Session["tur"].ToString() == "3" || Session["tur"].ToString() == "5")
                        {
                            PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/kategori-secimi.aspx");
                }
            }
            else
            {
                Response.Redirect("~/giris-yap.aspx");
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["unique-site-user"] != null)
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
                if (Session["cat"] != null)
                {
                    kategoriId = Session["cat"].ToString();
                }

                if (Session["tur"] != null)
                {
                    ilanTurId = Session["tur"].ToString();
                }

                if (Session["mgz"] != null)
                {
                    magazaId = Session["mgz"].ToString();
                }
            }
            else
            {
                Response.Redirect("~/giris-yap.aspx");
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
            string onay = "2";

            if(magazaId!="") // ilan mağaza tarafından veriliyorsa onay gerektirmeyecek
            {
                onay = "1";
            }

            // ilan bilgileri ekleme işlemi
            ilnBll.insert(
                    Session["tur"].ToString(), // ilan türü
                    Session["cat"].ToString(), // ilan kategorisi
                    txtFiyat.Text, // fiyat
                    1, // fiyat türü (TL)
                    ((kullanici)Session["unique-site-user"]).kullaniciId,
                    magazaId,
                    drpIl.SelectedValue,
                    drpIlce.SelectedValue,
                    drpMahalle.SelectedValue,
                    txtBaslik.Text,
                    txtCKeditorAdi.Text,
                    onay, // onay durumu
                    numaraYayinlansin.Checked // numara yayınlansın mı
                );

            DAL.ilan iln = ilnBll.list().Last(); // ilan resmi ve detayları için eklenen son ilanın id değerini almamız gerek

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
                                    goBll.insert(iln.ilanId, ((TextBox)item3).Attributes["name"], ((TextBox)item3).Text);
                                }
                            }
                            else if (item3 is CheckBox) // Eğer checkbox tek ise
                            {
                                string[] gonder = ((CheckBox)item3).Attributes["value"].Split('_');
                                if (((CheckBox)item3).Checked)
                                {
                                    soBll.insert(iln.ilanId, gonder[0]);
                                }
                                else
                                {
                                    soBll.insert(iln.ilanId, gonder[1]);
                                }
                            }
                            else // eğer control group checkbox ise
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

            HttpFileCollection updateFiles = Request.Files;
            string str_image = "";
            Bitmap resim;
            if (FileUpload1.HasFile)
            {
                for (int i = 0; i < updateFiles.Count; i++)
                {

                    bool secili = false;
                    if (i == 0)
                    {
                        secili = true;
                    }


                    HttpPostedFile file = updateFiles[i];

                    string fileName = file.FileName;
                    string fileExtension = Path.GetExtension(fileName);
                    str_image = iln.ilanId.ToString() + "_" + (i + 1).ToString() + fileExtension;

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "initMap", "alert(" + str_image + ");", true);
                    ir.insert(iln.ilanId, str_image, secili);

                    DAL.fotograf.yukle(file, 480, str_image, iln.ilanId.ToString(), 1);
                }
            }

            Session["ilanNo"] = iln.ilanId;

            Response.Redirect("~/ilan-doping.aspx");
        }
    }
}