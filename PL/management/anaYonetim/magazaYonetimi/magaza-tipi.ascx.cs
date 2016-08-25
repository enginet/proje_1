using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.management.anaYonetim.magazaYonetimi
{
    public partial class magaza_tipi : System.Web.UI.UserControl
    {
        magazaKategoriBll magazaKtgb = new magazaKategoriBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            altiStn.Text = magazaKtgb.search(1,Request.QueryString["cat"], 1, 1).fiyat.ToString();
            onIkiStn.Text = magazaKtgb.search(1,Request.QueryString["cat"], 2, 1).fiyat.ToString();

            altiPre.Text = magazaKtgb.search(1,Request.QueryString["cat"], 1, 2).fiyat.ToString();
            onIkiPre.Text = magazaKtgb.search(1,Request.QueryString["cat"], 2, 2).fiyat.ToString();

            if (!Page.IsPostBack)
            {
                ListItem lst = new ListItem();
                lst.Value = magazaKtgb.search(1,Request.QueryString["cat"], 1, 1).magazaKategoriId.ToString(); 
                lst.Text = "6 Aylık Mağaza = " + (magazaKtgb.search(1,Request.QueryString["cat"], 1, 1).fiyat * 6).ToString() + " TL";
                rdStandart.Items.Insert(0, lst);


                ListItem lst_1 = new ListItem();
                lst_1.Value = magazaKtgb.search(1,Request.QueryString["cat"], 2, 1).magazaKategoriId.ToString();
                lst_1.Text = "12 Aylık Mağaza = " + (magazaKtgb.search(1,Request.QueryString["cat"], 2, 1).fiyat * 12).ToString() + " TL";
                rdStandart.Items.Insert(1, lst_1);



                ListItem lst_2 = new ListItem();
                lst_2.Value = magazaKtgb.search(1,Request.QueryString["cat"], 1, 2).magazaKategoriId.ToString();
                lst_2.Text = "6 Aylık Mağaza = " + (magazaKtgb.search(1,Request.QueryString["cat"], 1, 2).fiyat * 6).ToString() + " TL";
                rdPremium.Items.Insert(0, lst_2);


                ListItem lst_3 = new ListItem();
                lst_3.Value = magazaKtgb.search(1,Request.QueryString["cat"], 2, 2).magazaKategoriId.ToString();
                lst_3.Text = "12 Aylık Mağaza = " + (magazaKtgb.search(1,Request.QueryString["cat"], 2, 2).fiyat * 12).ToString() + " TL";
                rdPremium.Items.Insert(1, lst_3);
            }

        }

        protected void devam_Click(object sender, EventArgs e)
        {

            if (rdStandart.SelectedValue=="1" || rdStandart.SelectedValue=="2")
            {
                Response.Redirect("~/management/anaYonetim/magazaYonetimi/magaza.aspx?page=icerik&sto=" + Request.QueryString["sto"] + "&cat=1&pac=" + rdStandart.SelectedValue);
            }
            else
            {
                Response.Redirect("~/management/anaYonetim/magazaYonetimi/magaza.aspx?page=icerik&sto=" + Request.QueryString["sto"] + "&cat=1&pac=" + rdPremium.SelectedValue);
            }
        }

        protected void rdPremium_SelectedIndexChanged(object sender, EventArgs e)
        {
            rdStandart.ClearSelection();
        
        }

        protected void rdStandart_SelectedIndexChanged(object sender, EventArgs e)
        {
            rdPremium.ClearSelection();

        }
    }
}