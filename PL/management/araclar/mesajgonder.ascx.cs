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
    public partial class mesajgonder : System.Web.UI.UserControl
    {
        kullaniciBll kullanicib = new kullaniciBll();
        mesajBll mesajb = new mesajBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                onlineRepeater.DataSource = kullanicib.list(4);
                onlineRepeater.DataBind();


                drpKime.DataSource = kullanicib.receiveList();
                drpKime.DataTextField = "kullaniciAdSoyad";
                drpKime.DataValueField = "kullaniciId";
                drpKime.DataBind();
            }

            if (Session["unique-user"] != null)
            {
                kullanici _authority = (kullanici)Session["unique-user"];
                txtKimden.Value = _authority.kullaniciAdSoyad;
            }

        }

        protected void Kaydet_Click(object sender, EventArgs e)
        {

            if (Session["unique-user"] != null)
            {
                kullanici _authority = (kullanici)Session["unique-user"];
                try
                {
                    mesajb.insert(drpKime.SelectedValue, _authority.kullaniciId, null, txtCKeditorAdi.Text);
                    Response.Redirect("~/management/araclar/araclar.aspx?page=gonderilen-kutusu");
                }
                catch (Exception)
                {

                    //Response.Redirect("~/management/diger/diger.aspx?page=500");
                }
            }
        }

        protected void Vazgec_Click(object sender, EventArgs e)
        {

        }
    }
}