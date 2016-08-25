using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace PL.management.anaYonetim.ilanYonetimi
{
    public partial class ilan_duzenle : System.Web.UI.UserControl
    {


        ilBll ilb = new ilBll();
        ilceBll ilceb = new ilceBll();
        mahalleBll mahalleb = new mahalleBll();

        magazaBll mgzBll = new magazaBll();
        magazaTurBll mgzTurBll = new magazaTurBll();

        ilanResimBll ir = new ilanResimBll();

        ilanBll ilnBll = new ilanBll();

        secilebilirIlanOzellikBll soBll = new secilebilirIlanOzellikBll();
        girilebilirIlanOzellikBll goBll = new girilebilirIlanOzellikBll();
        secilebilirOzellikDegerBll sodBll = new secilebilirOzellikDegerBll();

        public int  ilanId,
                    kategoriId,
                    turId,
                    ilId,
                    ilceId,
                    mahalleId;

        public string magazaId = "";

        protected override void OnInit(EventArgs e)
        {
            PlaceHolder1.Controls.Add(Page.LoadControl("~/ozellikler/kimden-ozellik.ascx"));
            PlaceHolder1.Visible = false;

            ilanId = Convert.ToInt32(Request.QueryString["ilan"]);
            
            DAL.ilan iln = ilnBll.search(2, ilanId);

            kategoriId  = iln.kategoriId;
            turId       = (int)iln.ilanTurId;
            ilId        = iln.ilId;
            ilceId      = iln.ilceId;
            mahalleId   = iln.mahalleId;

            drpKimden.SelectedValue = "1";

            txtBaslik.Text = iln.baslik;
            txtCKeditorAdi.Text = iln.aciklama;
            txtFiyat.Text = iln.fiyat.ToString();



            if(iln.magazaId!=null)
            {
                magazaId = iln.magazaId.ToString();

                DAL: magaza mgz = mgzBll.search(Convert.ToInt32(magazaId));

                DAL.magazaTur mgzTr = mgzTurBll.search(Convert.ToInt32(mgz.magazaTurId));

                drpKimden.SelectedValue = mgzTr.turId.ToString();
            }



            // 8 daire / 10 müstakil ev / 11 yalı / 16 yazlık / 18 kooperatif
            if (kategoriId.ToString() == "8" || kategoriId.ToString() == "10" || kategoriId.ToString() == "11" || kategoriId.ToString() == "16" || kategoriId.ToString() == "18")
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

                if (turId.ToString() == "2" || turId.ToString() == "3" || turId.ToString() == "5")
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
            if (kategoriId.ToString() == "9")
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

                if (turId.ToString() == "2" || turId.ToString() == "3" || turId.ToString() == "5")
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
            if (kategoriId.ToString() == "12")
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

                if (turId.ToString() == "2" || turId.ToString() == "3" || turId.ToString() == "5")
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
            if (kategoriId.ToString() == "13")
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

                if (turId.ToString() == "2" || turId.ToString() == "3" || turId.ToString() == "5")
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
            if (kategoriId.ToString() == "14")
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

                if (turId.ToString() == "2" || turId.ToString() == "3" || turId.ToString() == "5")
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
            if (kategoriId.ToString() == "15")
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

                if (turId.ToString() == "2" || turId.ToString() == "3" || turId.ToString() == "5")
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
            if (kategoriId.ToString() == "17")
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

                if (turId.ToString() == "2" || turId.ToString() == "3" || turId.ToString() == "5")
                {
                    PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

                //multiselect özellikler
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/detayli-bilgi.ascx"));

            }
            // 4 arsa
            if (kategoriId.ToString() == "4")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/arsa-ozellik.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/tapu-durum.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (turId.ToString() == "2" || turId.ToString() == "3" || turId.ToString() == "5")
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
            if (kategoriId.ToString() == "5")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/daire-sayisi.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/kat-sayisi.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/isitma.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (turId.ToString() == "2" || turId.ToString() == "3" || turId.ToString() == "5")
                {
                    PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

                //multiselect özellikler
                PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/detay-bilgisi.ascx"));

            }
            // 6 devremülk
            if (kategoriId.ToString() == "6")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/devremulk-ozellik.ascx"));

                if (turId.ToString() == "2" || turId.ToString() == "3" || turId.ToString() == "5")
                {
                    PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

                //multiselect özellikler
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/detay-bilgisi.ascx"));

            }
            // 35 otel / 42 tatil köyü
            if (kategoriId.ToString() == "35" || kategoriId.ToString() == "40")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/acik-kapali-metre.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/yildiz-sayisi.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/oda-yatak-kat-sayisi.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/zemin-etudu.ascx"));

                if (turId.ToString() == "2" || turId.ToString() == "3" || turId.ToString() == "5")
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
            if (kategoriId.ToString() == "36")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/acik-kapali-metre.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/apart-sayisi.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/oda-yatak-kat-sayisi.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/zemin-etudu.ascx"));

                if (turId.ToString() == "2" || turId.ToString() == "3" || turId.ToString() == "5")
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
            if (kategoriId.ToString() == "37" || kategoriId.ToString() == "38" || kategoriId.ToString() == "41")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/acik-kapali-metre.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/oda-yatak-kat-sayisi.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/zemin-etudu.ascx"));

                if (turId.ToString() == "2" || turId.ToString() == "3" || turId.ToString() == "5")
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
            if (kategoriId.ToString() == "39")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));

                if (turId.ToString() == "2" || turId.ToString() == "3" || turId.ToString() == "5")
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
            if (kategoriId.ToString() == "42")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/kapasite.ascx"));

            }
            // 21 atölye
            if (kategoriId.ToString() == "21")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/durum.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (turId.ToString() == "2" || turId.ToString() == "3" || turId.ToString() == "5")
                {
                    PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

            }
            // 20 büfe
            if (kategoriId.ToString() == "20")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/yapi-tipi.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/yapi-durum.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/kullanim-durumu.ascx"));

                if (turId.ToString() == "2" || turId.ToString() == "3" || turId.ToString() == "5")
                {
                    PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

                //multiselect özellikler
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/genel-ozellik.ascx"));

            }
            // 29 büro & ofis
            if (kategoriId.ToString() == "29")
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

                if (turId.ToString() == "2" || turId.ToString() == "3" || turId.ToString() == "5")
                {
                    PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

                //multiselect özellikler
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/detay-bilgisi.ascx"));

            }
            // 22 depo & antrepo
            if (kategoriId.ToString() == "22")
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

                if (turId.ToString() == "2" || turId.ToString() == "3" || turId.ToString() == "5")
                {
                    PlaceHolder13.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

                //multiselect özellikler
                PlaceHolder14.Controls.Add(Page.LoadControl("~/ozellikler/genel-ozellik.ascx"));
                PlaceHolder15.Controls.Add(Page.LoadControl("~/ozellikler/cephe.ascx"));
                PlaceHolder16.Controls.Add(Page.LoadControl("~/ozellikler/alt-yapi.ascx"));

            }
            // 23 dükkan & mağaza
            if (kategoriId.ToString() == "23")
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

                if (turId.ToString() == "2" || turId.ToString() == "3" || turId.ToString() == "5")
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
            if (kategoriId.ToString() == "24")
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

                if (turId.ToString() == "2" || turId.ToString() == "3" || turId.ToString() == "5")
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
            if (kategoriId.ToString() == "25")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
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

                if (turId.ToString() == "2" || turId.ToString() == "3" || turId.ToString() == "5")
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
            if (kategoriId.ToString() == "26")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
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

                if (turId.ToString() == "2" || turId.ToString() == "3" || turId.ToString() == "5")
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
            if (kategoriId.ToString() == "27")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
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

                if (turId.ToString() == "2" || turId.ToString() == "3" || turId.ToString() == "5")
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
            if (kategoriId.ToString() == "28")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/bolum-oda-sayisi.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/isitma.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (turId.ToString() == "2" || turId.ToString() == "3" || turId.ToString() == "5")
                {
                    PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

                //multiselect özellikler
                PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/detay-bilgisi.ascx"));
            }
            // 30 market
            if (kategoriId.ToString() == "30")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/isitma.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (turId.ToString() == "2" || turId.ToString() == "3" || turId.ToString() == "5")
                {
                    PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }
            }
            // 31 Restoran lokanta
            if (kategoriId.ToString() == "31")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/isitma.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/aidat.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/kapasite.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/masa-sayisi.ascx"));
                PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (turId.ToString() == "2" || turId.ToString() == "3" || turId.ToString() == "5")
                {
                    PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

                //multiselect özellikler
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/detay-bilgisi.ascx"));
            }
            // 32 Kuaför Güzellik Merkezi
            if (kategoriId.ToString() == "32")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                PlaceHolder5.Controls.Add(Page.LoadControl("~/ozellikler/oda-sayisi.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/isitma.ascx"));
                PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/aidat.ascx"));
                PlaceHolder8.Controls.Add(Page.LoadControl("~/ozellikler/bina-yasi.ascx"));
                PlaceHolder9.Controls.Add(Page.LoadControl("~/ozellikler/bulundugu-kat.ascx"));
                PlaceHolder10.Controls.Add(Page.LoadControl("~/ozellikler/kredi-takas.ascx"));

                if (turId.ToString() == "2" || turId.ToString() == "3" || turId.ToString() == "5")
                {
                    PlaceHolder11.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }

                //multiselect özellikler
                PlaceHolder12.Controls.Add(Page.LoadControl("~/ozellikler/kuafor-detay-bilgisi.ascx"));
            }
            // 33 Tekel Bayi
            if (kategoriId.ToString() == "33")
            {
                PlaceHolder2.Controls.Add(Page.LoadControl("~/ozellikler/koordinat.ascx"));
                PlaceHolder3.Controls.Add(Page.LoadControl("~/ozellikler/ada-parsel.ascx"));
                PlaceHolder4.Controls.Add(Page.LoadControl("~/ozellikler/metre-kare.ascx"));
                PlaceHolder6.Controls.Add(Page.LoadControl("~/ozellikler/isitma.ascx"));

                if (turId.ToString() == "2" || turId.ToString() == "3" || turId.ToString() == "5")
                {
                    PlaceHolder7.Controls.Add(Page.LoadControl("~/ozellikler/depozito.ascx"));
                }
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                drpIl.DataSource = ilb.list();
                drpIl.DataTextField = "ilAdi";
                drpIl.DataValueField = "ilId";
                drpIl.DataBind();

                drpIl.SelectedValue = ilId.ToString();

                drpIlce.DataSource = ilceb.list(Convert.ToInt32(drpIl.SelectedValue));
                drpIlce.DataTextField = "ilceAdi";
                drpIlce.DataValueField = "ilceId";
                drpIlce.DataBind();

                drpIlce.SelectedValue = ilceId.ToString();

                drpMahalle.DataSource = mahalleb.list(Convert.ToInt32(drpIlce.SelectedValue));
                drpMahalle.DataTextField = "mahalleAdi";
                drpMahalle.DataValueField = "mahalleId";
                drpMahalle.DataBind();

                drpMahalle.SelectedValue = mahalleId.ToString();
            }
        }

        protected void drpKimden_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpKimden.SelectedValue != "1" && drpKimden.SelectedValue != "2" && drpKimden.SelectedValue != "10" && drpKimden.SelectedValue != "")
            {
                PlaceHolder1.Visible = true;
            }
            else
            {
                PlaceHolder1.Visible = false;
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

        protected void Kaydet_Click(object sender, EventArgs e)
        {
            ilnBll.update(
                    1, // ilanın tüm bilgilerini güncelleyeceğimizi metoda bildiriyoruz
                    ilanId,
                    txtFiyat.Text,
                    1, // fiyat türünün TL olduğunu gönderdik
                    magazaId,
                    drpIl.SelectedValue,
                    drpIlce.SelectedValue,
                    drpMahalle.SelectedValue,
                    txtBaslik.Text,
                    txtCKeditorAdi.Text,
                    1, // Yonetici panelinden düzenleme yapılıdğı için direk onaylı olarak güncelleme işlemi yapılmaktadır
                    1 // numara yayınlasın
                );


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
                                soBll.update(ilanId,((DropDownList)item3).Attributes["name"], ((DropDownList)item3).SelectedValue);
                            }
                            else if (item3 is TextBox)
                            {
                                goBll.update(ilanId, ((TextBox)item3).Attributes["name"], ((TextBox)item3).Text);
                            }
                            else if (item3 is CheckBox) // Eğer checkbox tek ise
                            {
                                string[] gonder = ((CheckBox)item3).Attributes["value"].Split('_');
                                if (((CheckBox)item3).Checked)
                                {
                                    secilebilirOzellikDeger sd = sodBll.search(Convert.ToInt32(gonder[0]));
                                    soBll.update(ilanId, sd.ozellikId, gonder[0]);
                                }
                                else
                                {
                                    secilebilirOzellikDeger sd = sodBll.search(Convert.ToInt32(gonder[0]));
                                    soBll.update(ilanId, sd.ozellikId, gonder[0]);
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
                                                int ozellikId = Convert.ToInt32(((CheckBox)item5).Attributes["value"]);
                                                if(soBll.checkBoxKontrol(ilanId,ozellikId)) // eğer bu özellik veritabanına kayıtlı değil ise
                                                {
                                                    soBll.insert(ilanId, ((CheckBox)item5).Attributes["value"]);
                                                }
                                            }
                                            else
                                            {
                                                soBll.deleteGroupCheckBox(ilanId, ((CheckBox)item5).Attributes["value"]); // eğer ceckbox seçili değilse bu özelliği bu ilandan kaldır.
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

        protected void Vazgeç_Click(object sender, EventArgs e)
        {

        }
    }
}