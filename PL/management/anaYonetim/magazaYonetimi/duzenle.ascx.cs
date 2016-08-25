﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace PL.management.anaYonetim.magazaYonetimi
{
    public partial class duzenle : System.Web.UI.UserControl
    {
        ilBll ilb = new ilBll();
        ilceBll ilceb = new ilceBll();
        mahalleBll mahalleb = new mahalleBll();
        vergiDaireBll vergiDaireb = new vergiDaireBll();
        magazaBll magazab = new magazaBll();
        magazaTelefonBll magazaTlfb = new magazaTelefonBll();
        kullaniciBll kullanicib = new kullaniciBll();

        protected void Page_Load(object sender, EventArgs e)
        {

            DAL.magaza _magaza = magazab.search(Convert.ToInt32(Request.QueryString["magazaId"]));
            txtMagazaAdi.Value = _magaza.magazaAdi;
            txtTcNo.Value = _magaza.vergiNo;

            if (magazaTlfb.search(Convert.ToInt32(Request.QueryString["magazaId"]), 3) != null)
            {
                magazaTelefon _telefon = magazaTlfb.search(Convert.ToInt32(Request.QueryString["magazaId"]), 3);
                txtIsTlf.Value = _telefon.telefon;
            }

            if (magazaTlfb.search(Convert.ToInt32(Request.QueryString["magazaId"]), 4) != null)
            {
                magazaTelefon _telefon2 = magazaTlfb.search(Convert.ToInt32(Request.QueryString["magazaId"]), 4);
                txtIsTlf2.Value = _telefon2.telefon;
            }

            if (!IsPostBack)
            {
                drpIl.DataSource = ilb.list();
                drpIl.DataTextField = "ilAdi";
                drpIl.DataValueField = "ilId";
                drpIl.DataBind();

                ListItem lst_3 = new ListItem();
                lst_3.Value = null;
                lst_3.Text = "il Seçiniz";
                lst_3.Selected = true;
                drpIl.Items.Insert(0, lst_3);

                drpIl.SelectedValue = _magaza.ilId.ToString();

                drpIlce.DataSource = ilceb.list(Convert.ToInt32(drpIl.SelectedValue));
                drpIlce.DataTextField = "ilceAdi";
                drpIlce.DataValueField = "ilceId";
                drpIlce.DataBind();

                ListItem lst_2 = new ListItem();
                lst_2.Value = null;
                lst_2.Text = "İlçe Seçiniz";
                lst_2.Selected = true;
                drpIlce.Items.Insert(0, lst_2);

                drpIlce.SelectedValue = _magaza.ilceId.ToString();

                drpMahalle.DataSource = mahalleb.list(Convert.ToInt32(drpIlce.SelectedValue));
                drpMahalle.DataTextField = "mahalleAdi";
                drpMahalle.DataValueField = "mahalleId";
                drpMahalle.DataBind();

                ListItem lst_1 = new ListItem();
                lst_1.Value = null;
                lst_1.Text = "Mahalle Seçiniz";
                lst_1.Selected = true;
                drpMahalle.Items.Insert(0, lst_1);

                drpMahalle.SelectedValue = _magaza.mahalleId.ToString();

                drpVergi.DataSource = vergiDaireb.list(Convert.ToInt32(drpIl.SelectedValue));
                drpVergi.DataTextField = "vergiDairesi";
                drpVergi.DataValueField = "vergiDaireId";
                drpVergi.DataBind();

                ListItem lst = new ListItem();
                lst.Value = null;
                lst.Text = "Vergi Dairesi Seçiniz";
                lst.Selected = true;
                drpVergi.Items.Insert(0, lst);

                drpVergi.SelectedValue = _magaza.vergiDaireId.ToString();

                rdKurumsal.SelectedValue = _magaza.kurumsalMi.ToString();

                if (rdKurumsal.SelectedValue == "True")
                {
                    lblTc.InnerText = "Vergi No";
                }
                else
                {
                    lblTc.InnerText = "TC Kimlik No";
                }

                onlineRepeater.DataSource = kullanicib.list(4);
                onlineRepeater.DataBind();
            }
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

        protected void drpIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpIlce.Items.Clear();
            drpMahalle.Items.Clear();
            drpVergi.Items.Clear();

            drpIlce.DataSource = ilceb.list(Convert.ToInt32(drpIl.SelectedValue));
            drpIlce.DataTextField = "ilceAdi";
            drpIlce.DataValueField = "ilceId";
            drpIlce.DataBind();

            ListItem lst_1 = new ListItem();
            lst_1.Value = null;
            lst_1.Text = "İlçe Seçiniz";
            lst_1.Selected = true;

            drpIlce.Items.Insert(0, lst_1);


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


        protected void Kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                magazab.update(4, Convert.ToInt32(Request.QueryString["magazaId"]), txtMagazaAdi.Value, rdKurumsal.SelectedValue, drpIl.SelectedValue, drpIlce.SelectedValue, drpMahalle.SelectedValue, txtTcNo.Value, drpVergi.SelectedValue);

                if (txtIsTlf.Value != "" && magazaTlfb.search(Convert.ToInt32(Request.QueryString["magazaId"]), 3) != null)
                {
                    magazaTlfb.update(Convert.ToInt32(Request.QueryString["magazaId"]), 3, DAL.toolkit.Number_Remover(txtIsTlf.Value));
                }
                else if (txtIsTlf.Value != "" && magazaTlfb.search(Convert.ToInt32(Request.QueryString["magazaId"]), 3) == null)
                {
                    magazaTlfb.insert(Convert.ToInt32(Request.QueryString["magazaId"]), DAL.toolkit.Number_Remover(txtIsTlf.Value), 3);
                }
                else
                {
                    magazaTelefon _telefon = magazaTlfb.search(Convert.ToInt32(Request.QueryString["magazaId"]), 3);
                    magazaTlfb.delete(_telefon.magazaTelefonId);
                }

                ///////////////////////////////////////////////////////////////
                if (txtIsTlf2.Value != "" && magazaTlfb.search(Convert.ToInt32(Request.QueryString["magazaId"]), 4) != null)
                {
                    magazaTlfb.update(Convert.ToInt32(Request.QueryString["magazaId"]), 4, DAL.toolkit.Number_Remover(txtIsTlf2.Value));
                }
                else if (txtIsTlf2.Value != "" && magazaTlfb.search(Convert.ToInt32(Request.QueryString["magazaId"]), 4) == null)
                {
                    magazaTlfb.insert(Convert.ToInt32(Request.QueryString["magazaId"]), DAL.toolkit.Number_Remover(txtIsTlf2.Value), 4);
                }
                else
                {
                    magazaTelefon _telefon = magazaTlfb.search(Convert.ToInt32(Request.QueryString["magazaId"]), 4);
                    magazaTlfb.delete(_telefon.magazaTelefonId);
                }

                Response.Redirect("~/management/anaYonetim/magazaYonetimi/magaza.aspx?page=duzenle-kategori-secimi&edit=" + Request.QueryString["magazaId"]);

            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void Vazgec_Click(object sender, EventArgs e)
        {

        }
    }
}