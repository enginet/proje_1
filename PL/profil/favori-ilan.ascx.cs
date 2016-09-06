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
    public partial class favori : System.Web.UI.UserControl
    {
        ilanFavoriBll favorib = new ilanFavoriBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["unique-site-user"] != null)
            {
                kullanici _authority = (kullanici)Session["unique-site-user"];

                if (!Page.IsPostBack)
                {
                    favoriIlanRepeater.DataSource = favorib.list(1, _authority.kullaniciId);
                    favoriIlanRepeater.DataBind();

                    if (Request.QueryString["like"] != null)
                    {
                        favorib.delete(Request.QueryString["like"], _authority.kullaniciId);
                    }

                    favoriIlanRepeater.DataSource = favorib.list(1, _authority.kullaniciId);
                    favoriIlanRepeater.DataBind();
                }
            }
        }
    }
}