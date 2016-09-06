using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL
{
    public partial class kategoriler : System.Web.UI.Page
    {
        kategoriTurBll ktgTurb = new kategoriTurBll();
        ilBll ilb = new ilBll();
        ilceBll ilceb = new ilceBll();
        mahalleBll mahalleb = new mahalleBll();
        kategoriBll kategorib = new kategoriBll();
        seciliDopingBll seciliDopingb = new seciliDopingBll();
        public string _valueCat;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //drpIl.DataSource = ilb.list();
                //drpIl.DataTextField = "ilAdi";
                //drpIl.DataValueField = "ilId";
                //drpIl.DataBind();

                //ListItem lst = new ListItem();
                //lst.Value = null;
                //lst.Text = "İl Seçiniz";
                //lst.Selected = true;

                //drpIl.Items.Insert(0, lst);

                drpKategori.DataSource = kategorib.list(Convert.ToInt32(Request.QueryString["kategoriId"]));
                drpKategori.DataTextField = "kategoriAdi";
                drpKategori.DataValueField = "kategoriId";
                drpKategori.DataBind();

                ListItem lst_1 = new ListItem();
                lst_1.Value = null;
                lst_1.Text = "Kategori Seçiniz";
                lst_1.Selected = true;

                drpKategori.Items.Insert(0, lst_1);

                drpTur.DataSource = ktgTurb.list(3, Request.QueryString["kategoriId"]);
                drpTur.DataTextField = "turAdi";
                drpTur.DataValueField = "turId";
                drpTur.DataBind();

                ListItem lst_2 = new ListItem();
                lst_2.Value = null;
                lst_2.Text = "Tür Seçiniz";
                lst_2.Selected = true;

                drpTur.Items.Insert(0, lst_2);


            }

            if (Request.QueryString["kategoriId"] != null)
            {
                kategoriRepeater.DataSource = ktgTurb.list(1, Request.QueryString["kategoriId"]);
                kategoriRepeater.DataBind();

                kategoriVitrinRepeater.DataSource = seciliDopingb.list(3, Request.QueryString["kategoriId"]);
                kategoriVitrinRepeater.DataBind();
            }

            _valueCat = kategoriOzellik(Convert.ToInt32(Request.QueryString["kategoriId"])).Split('#')[0];
            icon.Attributes["class"] = kategoriOzellik(Convert.ToInt32(Request.QueryString["kategoriId"])).Split('#')[1];


        }

        //protected void drpIl_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    drpIlce.DataSource = ilceb.list(Convert.ToInt32(drpIl.SelectedValue));
        //    drpIlce.DataTextField = "ilceAdi";
        //    drpIlce.DataValueField = "ilceId";
        //    drpIlce.DataBind();

        //    ListItem lst = new ListItem();
        //    lst.Value = null;
        //    lst.Text = "İlçe Seçiniz";
        //    lst.Selected = true;

        //    drpIlce.Items.Insert(0, lst);
        //}

        //protected void drpIlce_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    drpMahalle.DataSource = mahalleb.list(Convert.ToInt32(drpIlce.SelectedValue));
        //    drpMahalle.DataTextField = "mahalleAdi";
        //    drpMahalle.DataValueField = "mahalleId";
        //    drpMahalle.DataBind();

        //    ListItem lst = new ListItem();
        //    lst.Value = null;
        //    lst.Text = "Mahalle Seçiniz";
        //    lst.Selected = true;

        //    drpMahalle.Items.Insert(0, lst);
        //}

        public bool subCat(object _income)
        {
            if (kategorib.ustKategoriSearch(Convert.ToInt32(_income))!=null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public string kategoriOzellik(int _income)
        {
            if (_income == 2)
            {
                return "KONUT#fa fa-home ";
            }
            if (_income == 3)
            {
                return "İŞYERİ#fa fa-industry ";
            }
            if (_income == 4)
            {
                return "ARSA#fa fa-object-ungroup";
            }
            if (_income == 5)
            {
                return "BİNA#fa fa-building ";
            }
            if (_income == 6)
            {
                return "DEVREMÜLK#fa fa-object-group";
            }
            if (_income == 7)
            {
                return "TURİSTİK TESİS#fa fa-sun-o";
            }
            else
            {
                return "KONUT#fa fa-home";

            }
        }

        protected void lnkAra_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/ilan-liste.aspx?kategoriId={0}&tur={1}&cat={2}", Request.QueryString["kategoriId"], drpTur.SelectedValue, drpKategori.SelectedValue));
        }

        protected void lnkHaritaAra_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/harita/harita.aspx?tur={0}&cat={1}", drpTur.SelectedValue, drpKategori.SelectedValue));
        }
    }
}
