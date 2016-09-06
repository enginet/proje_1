using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace PL.profil
{
    public partial class mesaj_oku : System.Web.UI.UserControl
    {
        mesajBll mesajb = new mesajBll();
        ilanBll ilanb = new ilanBll();
        public string picPath;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["unique-site-user"] != null)
            {
                kullanici _authority = (kullanici)Session["unique-site-user"];

                if (!Page.IsPostBack)
                {
                    if (ilanb.search(2, Request.QueryString["cla"]) != null)
                    {
                        DAL.ilan _ilan = ilanb.search(2, Request.QueryString["cla"]);
                        txtid.InnerHtml = _ilan.ilanId.ToString();
                        hypBaslik.Text = _ilan.baslik;
                        txttarih.InnerHtml = _ilan.bitisTarihi.ToString();
                        txtkategori.InnerHtml = _ilan.kategori.kategoriAdi;
                        txtIl.InnerHtml = _ilan.iller.ilAdi;
                        lblFiyat.Text = _ilan.fiyat.ToString();
                        lblFiyatTur.Text = DAL.toolkit.fiyat_Tur(_ilan.fiyatTurId);
                        picPath = _ilan.ilanResims.Where(r => r.seciliMi == true).FirstOrDefault().resim;
                    }

                    mesajRepeater.DataSource = mesajb.list(5, _authority.kullaniciId, Request.QueryString["to"], Request.QueryString["cla"]);
                    mesajRepeater.DataBind();
                }
            }
        }

        protected void Gonder_Click(object sender, EventArgs e)
        {
            kullanici _authority = (kullanici)Session["unique-site-user"];

            mesajb.insert(Request.QueryString["to"], _authority.kullaniciId, Request.QueryString["cla"], txtMesaj.Text);
            mesajRepeater.DataSource = mesajb.list(5, _authority.kullaniciId, Request.QueryString["to"], Request.QueryString["cla"]);
            mesajRepeater.DataBind();
        }
    }
}