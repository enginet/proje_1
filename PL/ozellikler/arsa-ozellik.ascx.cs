using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.ozellikler
{
    public partial class arsa_ozellik : System.Web.UI.UserControl
    {
        ozellikBll ozellikb = new ozellikBll();
        secilebilirIlanOzellikBll sioBll = new secilebilirIlanOzellikBll();
        girilebilirIlanOzellikBll gio = new girilebilirIlanOzellikBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListItem lst = new ListItem();
                lst.Text = "Seçiniz";
                lst.Value = "";

                drpKatKar.DataSource = ozellikb.selectFieldList(11);
                drpKatKar.DataTextField = "deger";
                drpKatKar.DataValueField = "secilebilirOzellikDegerId";
                drpKatKar.DataBind();
                drpKatKar.Items.Insert(0, lst);

                drpMalikDrm.DataSource = ozellikb.selectFieldList(106);
                drpMalikDrm.DataTextField = "deger";
                drpMalikDrm.DataValueField = "secilebilirOzellikDegerId";
                drpMalikDrm.DataBind();
                drpMalikDrm.Items.Insert(0, lst);

                drpImarDrm.DataSource = ozellikb.selectFieldList(108);
                drpImarDrm.DataTextField = "deger";
                drpImarDrm.DataValueField = "secilebilirOzellikDegerId";
                drpImarDrm.DataBind();
                drpImarDrm.Items.Insert(0, lst);


                if (Request.QueryString["page"] == "duzenle" && Request.QueryString["ilan"] != "")
                {
                    if (sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 11) != null)
                    {
                        drpKatKar.SelectedValue = sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 11).ozellikDegerId.ToString();
                    }

                    if (sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 9) != null)
                    {
                        drpKask.SelectedValue = sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 9).ozellikDegerId.ToString();
                    }

                    if (sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 10) != null)
                    {
                        drpGabari.SelectedValue = sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 10).ozellikDegerId.ToString();
                    }

                    if (gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 12) != null)
                    {
                        txtMetreFiyat.Text = gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 12).deger;
                    }

                    if (gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 8) != null)
                    {
                        txtPaftaNo.Text = gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 8).deger;
                    }
                    if (gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 106) != null)
                    {
                        drpMalikDrm.SelectedValue = gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 106).deger;
                    }

                    if (gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 107) != null)
                    {
                        txtHisseAlani.Text = gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 107).deger;
                    }
                    if (gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 108) != null)
                    {
                        drpImarDrm.SelectedValue = gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 108).deger;
                    }
                    if (gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 109) != null)
                    {
                        drpImarNitelik.SelectedValue = gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 109).deger;
                    }
                    if (gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 110) != null)
                    {
                        drpYapiNizam.SelectedValue = gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 110).deger;
                    }
                    if (gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 111) != null)
                    {
                        drpTask.SelectedValue = gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 111).deger;
                    }
                    if (gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 112) != null)
                    {
                        drpEmsal.SelectedValue = gio.search(Convert.ToInt32(Request.QueryString["ilan"]), 112).deger;
                    }
                }
            }
        }

        protected void drpMalikDrm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpMalikDrm.SelectedValue == "862")
            {
                txtHisseAlani.Visible = true;
                lblHisseAlani.Visible = true;
            }
            else
            {
                txtHisseAlani.Visible = false;
                lblHisseAlani.Visible = false;

            }
        }

        protected void drpImarDrm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpImarDrm.SelectedValue == "866")
            {
                lblImarNitelik.Visible = true;
                lblYapiNizam.Visible = true;
                lblTask.Visible = true;
                lblEmsal.Visible = true;
                lblKask.Visible = true;
                lblKat.Visible = true;
                lblGabari.Visible = true;

                drpImarNitelik.Visible = true;
                drpYapiNizam.Visible = true;
                drpTask.Visible = true;
                drpEmsal.Visible = true;
                drpKask.Visible = true;
                drpKatKar.Visible = true;
                drpGabari.Visible = true;

                ListItem lst = new ListItem();
                lst.Text = "Seçiniz";
                lst.Value = "";

                drpImarNitelik.DataSource = ozellikb.selectFieldList(109);
                drpImarNitelik.DataTextField = "deger";
                drpImarNitelik.DataValueField = "secilebilirOzellikDegerId";
                drpImarNitelik.DataBind();
                drpImarNitelik.Items.Insert(0, lst);

                drpYapiNizam.DataSource = ozellikb.selectFieldList(110);
                drpYapiNizam.DataTextField = "deger";
                drpYapiNizam.DataValueField = "secilebilirOzellikDegerId";
                drpYapiNizam.DataBind();
                drpYapiNizam.Items.Insert(0, lst);

                drpTask.DataSource = ozellikb.selectFieldList(111);
                drpTask.DataTextField = "deger";
                drpTask.DataValueField = "secilebilirOzellikDegerId";
                drpTask.DataBind();
                drpTask.Items.Insert(0, lst);

                drpEmsal.DataSource = ozellikb.selectFieldList(112);
                drpEmsal.DataTextField = "deger";
                drpEmsal.DataValueField = "secilebilirOzellikDegerId";
                drpEmsal.DataBind();
                drpEmsal.Items.Insert(0, lst);

                drpGabari.DataSource = ozellikb.selectFieldList(10);
                drpGabari.DataTextField = "deger";
                drpGabari.DataValueField = "secilebilirOzellikDegerId";
                drpGabari.DataBind();
                drpGabari.Items.Insert(0, lst);

                drpGabari.DataSource = ozellikb.selectFieldList(10);
                drpGabari.DataTextField = "deger";
                drpGabari.DataValueField = "secilebilirOzellikDegerId";
                drpGabari.DataBind();
                drpGabari.Items.Insert(0, lst);

                drpKask.DataSource = ozellikb.selectFieldList(9);
                drpKask.DataTextField = "deger";
                drpKask.DataValueField = "secilebilirOzellikDegerId";
                drpKask.DataBind();
                drpKask.Items.Insert(0, lst);
            }
            else
            {
                lblImarNitelik.Visible = false;
                lblYapiNizam.Visible = false;
                lblTask.Visible = false;
                lblEmsal.Visible = false;
                lblKask.Visible = false;
                lblKat.Visible = false;
                lblGabari.Visible = false;

                drpImarNitelik.Visible = false;
                drpYapiNizam.Visible = false;
                drpTask.Visible = false;
                drpEmsal.Visible = false;
                drpKask.Visible = false;
                drpKatKar.Visible = false;
                drpGabari.Visible = false;
            }
        }
    }
}