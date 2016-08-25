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
    public partial class magaza_profil : System.Web.UI.UserControl
    {
        ilBll ilb = new ilBll();
        ilceBll ilceb = new ilceBll();
        mahalleBll mahalleb = new mahalleBll();
        vergiDaireBll vergiDaireb = new vergiDaireBll();
        magazaBll magazab = new magazaBll();
        magazaTelefonBll magazaTlfb = new magazaTelefonBll();
        kategoriBll kategorib = new kategoriBll();
        kullaniciBll kullanicib = new kullaniciBll();
        magazaKullaniciBll magazaKllb = new magazaKullaniciBll();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (magazab.search(16) != null)
            {

                DAL.magaza _magaza = magazab.search(16);
                txtMagazaAdi.Value = _magaza.magazaAdi;
                h3MagazaAdi.InnerHtml = _magaza.magazaAdi;
                txtTcNo.Value = _magaza.vergiNo;

                magazaTelefon _telefon = magazaTlfb.search(16, 3);
                txtIsTlf.Text = _telefon.telefon;

                magazaTelefon _telefon1 = magazaTlfb.search(16, 4);
                txtIsTlf2.Text = _telefon1.telefon;


                if (!IsPostBack)
                {
                    drpIl.DataSource = ilb.list();
                    drpIl.DataTextField = "ilAdi";
                    drpIl.DataValueField = "ilId";
                    drpIl.DataBind();

                    drpIl.SelectedValue = _magaza.ilId.ToString();

                    drpIlce.DataSource = ilceb.list(Convert.ToInt32(drpIl.SelectedValue));
                    drpIlce.DataTextField = "ilceAdi";
                    drpIlce.DataValueField = "ilceId";
                    drpIlce.DataBind();

                    drpIlce.SelectedValue = _magaza.ilceId.ToString();

                    drpMahalle.DataSource = mahalleb.list(Convert.ToInt32(drpIlce.SelectedValue));
                    drpMahalle.DataTextField = "mahalleAdi";
                    drpMahalle.DataValueField = "mahalleId";
                    drpMahalle.DataBind();

                    drpMahalle.SelectedValue = _magaza.mahalleId.ToString();

                    rdBireyseli.SelectedValue = _magaza.kurumsalMi.ToString();

                    drpVergi.DataSource = vergiDaireb.list(Convert.ToInt32(drpIl.SelectedValue));
                    drpVergi.DataTextField = "vergiDairesi";
                    drpVergi.DataValueField = "vergiDaireId";
                    drpVergi.DataBind();

                    ListItem lst = new ListItem();
                    lst.Value = null;
                    lst.Text = "Vergi Dairesi Seçiniz";
                    lst.Selected = true;
                    drpVergi.Items.Insert(0, lst);


                    //drpKategori.DataSource = kategorib.list(0);
                    //drpKategori.DataTextField = "kategoriAdi";
                    //drpKategori.DataValueField = "kategoriId";
                    //drpKategori.DataBind();

                    //drpKategori.SelectedValue = _magaza.kategoriKimden.kategoriId.ToString();
                    //drpPaket.SelectedValue = _magaza.magazaPaketId.ToString();

                    drpKullanici.DataSource = kullanicib.receiveList();
                    drpKullanici.DataTextField = "kullaniciAdSoyad";
                    drpKullanici.DataValueField = "kullaniciId";
                    drpKullanici.DataBind();

                }
            }
        }

        protected void drpIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpIlce.DataSource = ilceb.list(Convert.ToInt32(drpIl.SelectedValue));
            drpIlce.DataTextField = "ilceAdi";
            drpIlce.DataValueField = "ilceId";
            drpIlce.DataBind();

            drpVergi.DataSource = vergiDaireb.list(Convert.ToInt32(drpIl.SelectedValue));
            drpVergi.DataTextField = "vergiDairesi";
            drpVergi.DataValueField = "vergiDaireId";
            drpVergi.DataBind();


        }

        protected void drpIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpMahalle.DataSource = mahalleb.list(Convert.ToInt32(drpIlce.SelectedValue));
            drpMahalle.DataTextField = "mahalleAdi";
            drpMahalle.DataValueField = "mahalleId";
            drpMahalle.DataBind();
        }

        protected void rdBireyseli_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Convert.ToInt32(rdBireyseli.SelectedValue) == 2)
            {
                lblTc.InnerText = "Vergi No";
            }
            else
            {
                lblTc.InnerText = "TC Kimlik No";
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            magazab.update(4, 16, txtMagazaAdi.Value, rdBireyseli.SelectedValue, drpIl.SelectedValue, drpIlce.SelectedValue, drpMahalle.SelectedValue, txtTcNo.Value, drpVergi.SelectedValue);
        }

        protected void Ekle_Click(object sender, EventArgs e)
        {
            magazaKllb.insert(16, drpKullanici.SelectedValue, 1);
        }
    }
}
