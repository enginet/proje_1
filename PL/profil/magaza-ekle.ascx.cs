using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.profil
{
    public partial class mağaza_ekle : System.Web.UI.UserControl
    {

        ilBll ilb = new ilBll();
        ilceBll ilceb = new ilceBll();
        mahalleBll mahalleb = new mahalleBll();
        vergiDaireBll vergiDaireb = new vergiDaireBll();
        magazaBll magazab = new magazaBll();
        magazaTelefonBll magazaTlfb = new magazaTelefonBll();
        magazaKullaniciBll magazaKllb = new magazaKullaniciBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                drpIl.DataSource = ilb.list();
                drpIl.DataTextField = "ilAdi";
                drpIl.DataValueField = "ilId";
                drpIl.DataBind();
            }
        }

        protected void drpIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpIlce.DataSource = ilceb.list(Convert.ToInt32(drpIl.SelectedValue));
            drpIlce.DataTextField = "ilceAdi";
            drpIlce.DataValueField = "ilceId";
            drpIlce.DataBind();

            drpVergi.DataSource = vergiDaireb.list(1);
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
            if (rdBireyseli.SelectedValue == "true")
            {
                lblTc.InnerText = "Vergi No";
            }
            else
            {
                lblTc.InnerText = "TC Kimlik No";
            }

            //if (rdBireyseli.SelectedValue == "true")
            //{
            //    vergiPnl.Visible = true;
            //    gercekPnl.Visible = true;

            //    drpVergi.DataSource = vergiDaireb.list(1);
            //    drpVergi.DataTextField = "vergiDairesi";
            //    drpVergi.DataValueField = "vergiDaireId";
            //    drpVergi.DataBind();
            //}
            //else
            //{
            //    vergiPnl.Visible = false;
            //    gercekPnl.Visible = false;
            //}
        }

        //protected void rdGercek_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (rdGercek.SelectedValue == "false")
        //    {
        //        lblTc.InnerText = "Vergi No";
        //    }
        //    else
        //    {
        //        lblTc.InnerText = "TC Kimlik No";
        //    }
        //}

        protected void btnKaydet_Click(object sender, EventArgs e)
        {

            magazab.insert(txtMagazaAdi.Value, rdBireyseli.SelectedValue, drpIl.SelectedValue, drpIlce.SelectedValue, drpMahalle.SelectedValue, txtTcNo.Value, drpVergi.SelectedValue);
            DAL.magaza _magaza = magazab.ielist().Last();
            magazaTlfb.insert(_magaza.magazaId, txtCepTlf.Text, 1);
            magazaTlfb.insert(_magaza.magazaId, txtIsTlf.Text, 2);
            magazaTlfb.insert(_magaza.magazaId, txtIsTlf2.Text, 2);
        }
    }
}