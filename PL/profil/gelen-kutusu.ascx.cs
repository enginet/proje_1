using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace PL.profil
{
    public partial class gelen_kutusu : System.Web.UI.UserControl
    {
        mesajBll mesajb = new mesajBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["unique-site-user"] != null)
            {
                kullanici _authority = (kullanici)Session["unique-site-user"];

                if (!Page.IsPostBack)
                {
                    mesajRepeater.DataSource = mesajb.list(3, _authority.kullaniciId);
                    mesajRepeater.DataBind();
                    if (Request.QueryString["proc"] != null)
                    {
                        if (Request.QueryString["proc"] == "1")
                        {
                            mesajb.update(2, _authority.kullaniciId, Request.QueryString["to"], Request.QueryString["cla"]);
                            mesajb.update(3, Request.QueryString["to"], _authority.kullaniciId, Request.QueryString["cla"]);

                        }

                        mesajRepeater.DataSource = mesajb.list(3, _authority.kullaniciId);
                        mesajRepeater.DataBind();
                    }
                }
            }
        }
    }
}