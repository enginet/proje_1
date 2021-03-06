﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.management.genelAyarlar
{
    public partial class dopingucretayar : System.Web.UI.UserControl
    {
        kategoriBll kategorib = new kategoriBll();
        dopingBll dopingb = new dopingBll();
        dopingKategoriBll dopingKtgb = new dopingKategoriBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            drpKategori.DataSource = kategorib.list(0);
            drpKategori.DataTextField = "kategoriAdi";
            drpKategori.DataValueField = "kategoriId";
            drpKategori.DataBind();

            ListItem lst = new ListItem();
            lst.Value = null;
            lst.Text = "Kategori Seçiniz";
            lst.Selected = true;

            drpKategori.Items.Insert(0, lst);

            drpTur.DataSource = dopingb.list();
            drpTur.DataTextField = "dopingAdi";
            drpTur.DataValueField = "dopingId";
            drpTur.DataBind();

            ListItem lst1 = new ListItem();
            lst1.Value = null;
            lst1.Text = "Tür Seçiniz";
            lst1.Selected = true;

            drpTur.Items.Insert(0, lst1);
        }

        protected void Kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                dopingKtgb.insert(drpKategori.SelectedValue, drpTur.SelectedValue, drpSure.SelectedValue, txtFiyat.Value);
            }
            catch (Exception)
            {
                Response.Redirect("~/management/diger/diger.aspx?page=500");
            }
        }

        protected void Vazgec_Click(object sender, EventArgs e)
        {

        }
    }
}