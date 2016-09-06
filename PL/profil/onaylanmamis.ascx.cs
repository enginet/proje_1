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
    public partial class onaylanmamis : System.Web.UI.UserControl
    {
        ilanBll ilanb = new ilanBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["unique-site-user"] != null)
            {
                kullanici _authority = (kullanici)Session["unique-site-user"];
                {
                    onaylanmamislar.DataSource = ilanb.list(2, _authority.kullaniciId, 3, false, false);
                    onaylanmamislar.DataBind();

                    if (Request.QueryString["classified"] != null)
                    {
                        if (Request.QueryString["proc"] == "2")
                        {
                            ilanb.update(2, Request.QueryString["classified"]);
                        }
                        if (Request.QueryString["proc"] == "3")
                        {
                            ilanb.update(3, Request.QueryString["classified"]); //düzenlenecek
                        }
                        //if (Request.QueryString["proc"] == "4")
                        //{
                        //    ilanb.update(3, Request.QueryString["classified"]);
                        //}
                        onaylanmamislar.DataSource = ilanb.list(2, _authority.kullaniciId, 3, false, false);
                        onaylanmamislar.DataBind();
                    }
                }
            }
        }
    }
}