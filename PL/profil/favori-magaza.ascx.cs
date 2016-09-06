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
    public partial class favori_magaza : System.Web.UI.UserControl
    {
         
        magazaTakipciBll magazaTkpb = new magazaTakipciBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["unique-site-user"] != null)
            {
                if (!Page.IsPostBack)
                {
                    kullanici _authority = (kullanici)Session["unique-site-user"];

                    favoriMagazaRepeater.DataSource = magazaTkpb.list(1, _authority.kullaniciId);
                    favoriMagazaRepeater.DataBind();
                    if (Request.QueryString["like"] != null)
                    {
                        magazaTkpb.delete(Request.QueryString["like"], _authority.kullaniciId);
                    }
                    favoriMagazaRepeater.DataSource = magazaTkpb.list(1, _authority.kullaniciId);
                    favoriMagazaRepeater.DataBind();
                }
            }
        }
    }
}


