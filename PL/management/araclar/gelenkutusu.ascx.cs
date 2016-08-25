using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace PL.management.araclar
{
    public partial class mesajlar : System.Web.UI.UserControl
    {
        mesajBll mesajb = new mesajBll();
        kullaniciBll kullanicib = new kullaniciBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Session["unique-user"] != null)
                {
                    kullanici _authority = (kullanici)Session["unique-user"];
                    mesajRepeater.DataSource = mesajb.list(6, _authority.kullaniciId);
                    mesajRepeater.DataBind();
                }

                onlineRepeater.DataSource = kullanicib.list(4);
                onlineRepeater.DataBind();
            }
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            kullanici _authority = (kullanici)Session["unique-user"];

            foreach (RepeaterItem item in mesajRepeater.Items)
            {
                CheckBox chc = (CheckBox)item.FindControl("chcSil");
                if (chc.Checked)
                {
                    HiddenField gelenData = (HiddenField)item.FindControl("hfDelete");
                    mesajb.update(1, gelenData.Value);
                }
            }
            mesajRepeater.DataSource = mesajb.list(6, _authority.kullaniciId);
            mesajRepeater.DataBind();
        }

        protected void btnTumunu_Click(object sender, EventArgs e)
        {
            kullanici _authority = (kullanici)Session["unique-user"];

            //CheckBox t = (CheckBox)sender;
            //foreach (var item in mesajRepeater.Items)
            //{
            //    CheckBox chc = (CheckBox)mesajRepeater.FindControl("chcSil");
            //    chc.Checked = t.Checked;
            //}

            foreach (RepeaterItem item in mesajRepeater.Items)
            {
                CheckBox chc = (CheckBox)item.FindControl("chcSil");
                if (chc != null)
                {
                    if (chc.Checked == false)
                    {
                        chc.Checked = true;
                    }
                    else
                    {
                        chc.Checked = false;
                    }
                }
            }

            mesajRepeater.DataSource = mesajb.list(6, _authority.kullaniciId);
            mesajRepeater.DataBind();
        }
    }
}