using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace PL.management.anaYonetim.magazaYonetimi
{
    public partial class ekle : System.Web.UI.UserControl
    {
        ilBll ilb = new ilBll();
        ilceBll ilceb = new ilceBll();
        mahalleBll mahalleb = new mahalleBll();
        vergiDaireBll vergiDaireb = new vergiDaireBll();
        magazaBll magazab = new magazaBll();
        magazaTelefonBll magazaTlfb = new magazaTelefonBll();
        magazaKullaniciBll magazaKllb = new magazaKullaniciBll();
        kullaniciBll kullanicib = new kullaniciBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                drpIl.DataSource = ilb.list();
                drpIl.DataTextField = "ilAdi";
                drpIl.DataValueField = "ilId";
                drpIl.DataBind();

                ListItem lst_3 = new ListItem();
                lst_3.Value = null;
                lst_3.Text = "İl Seçiniz";
                lst_3.Selected = true;
                drpIl.Items.Insert(0, lst_3);

                drpKullanici.DataSource = kullanicib.list(3,4);
                drpKullanici.DataTextField = "kullaniciAdSoyad";
                drpKullanici.DataValueField = "kullaniciId";
                drpKullanici.DataBind();

                ListItem lst_4 = new ListItem();
                lst_4.Value = null;
                lst_4.Text = "Yönetici Seçiniz";
                lst_4.Selected = true;
                drpKullanici.Items.Insert(0, lst_4);

                onlineRepeater.DataSource = kullanicib.list(4);
                onlineRepeater.DataBind();
            }
        }

        protected void drpIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpIlce.Items.Clear();
            drpVergi.Items.Clear(); 

            drpIlce.DataSource = ilceb.list(Convert.ToInt32(drpIl.SelectedValue));
            drpIlce.DataTextField = "ilceAdi";
            drpIlce.DataValueField = "ilceId";
            drpIlce.DataBind();

            ListItem lst_4 = new ListItem();
            lst_4.Value = null;
            lst_4.Text = "İlçe Seçiniz";
            lst_4.Selected = true;
            drpIlce.Items.Insert(0, lst_4);

            drpVergi.DataSource = vergiDaireb.list(Convert.ToInt32(drpIl.SelectedValue));
            drpVergi.DataTextField = "vergiDairesi";
            drpVergi.DataValueField = "vergiDaireId";
            drpVergi.DataBind();

            ListItem lst = new ListItem();
            lst.Value = null;
            lst.Text = "Vergi Dairesi Seçiniz";
            lst.Selected = true;
            drpVergi.Items.Insert(0, lst);

        }


        protected void Kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                magazab.insert(txtMagazaAdi.Value, rdKurumsal.SelectedValue, drpIl.SelectedValue, drpIlce.SelectedValue, drpMahalle.SelectedValue, txtTcNo.Value, drpVergi.SelectedValue);
                DAL.magaza _magaza = magazab.ielist().Last();
                if (txtIsTlf.Value != "")
                {
                    magazaTlfb.insert(_magaza.magazaId, DAL.toolkit.Number_Remover(txtIsTlf.Value), 3);
                }
                if (txtIsTlf2.Value != "")
                {
                    magazaTlfb.insert(_magaza.magazaId, DAL.toolkit.Number_Remover(txtIsTlf2.Value), 4);
                }
                magazaKllb.insert(_magaza.magazaId, drpKullanici.SelectedValue, 0);

                Response.Redirect("~/management/anaYonetim/magazaYonetimi/magaza.aspx?page=kategori-secimi&sto=" + _magaza.magazaId);

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void Vazgec_Click(object sender, EventArgs e)
        {

        }



        protected void rdKurumsal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdKurumsal.SelectedValue == "True")
            {
                lblTc.InnerText = "Vergi No";
            }
            else
            {
                lblTc.InnerText = "TC Kimlik No";
            }
        }

        protected void drpIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpMahalle.Items.Clear(); 

            drpMahalle.DataSource = mahalleb.list(Convert.ToInt32(drpIlce.SelectedValue));
            drpMahalle.DataTextField = "mahalleAdi";
            drpMahalle.DataValueField = "mahalleId";
            drpMahalle.DataBind();

            ListItem lst = new ListItem();
            lst.Value = null;
            lst.Text = "Mahalle Seçiniz";
            lst.Selected = true;

            drpMahalle.Items.Insert(0, lst);
        }
    }
}