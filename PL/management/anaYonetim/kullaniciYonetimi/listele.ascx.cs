using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.management.anaYonetim.kullaniciYonetimi
{
    public partial class listele1 : System.Web.UI.UserControl
    {
        kullaniciBll kullanici = new kullaniciBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["user"] != null)
            {
                kullanici.update(2, Request.QueryString["user"], true);
                Response.Redirect("~/management/anaYonetim/kullaniciYonetimi/kullanici.aspx?page=listele");
            }

            if (Request.QueryString["tip"] == "yonetici")
            {
                kullaniciRepeater.DataSource = kullanici.list(3,1);
                kullaniciRepeater.DataBind();
            }

            if (Request.QueryString["tip"]=="admin")
            {
                kullaniciRepeater.DataSource = kullanici.list(3,2);
                kullaniciRepeater.DataBind();
            }

            if (Request.QueryString["tip"] == "editor")
            {
                kullaniciRepeater.DataSource = kullanici.list(3,3);
                kullaniciRepeater.DataBind();
            }

            if (Request.QueryString["tip"] == "uye")
            {
                kullaniciRepeater.DataSource = kullanici.list(3,4);
                kullaniciRepeater.DataBind();
            }
        }
    }
}