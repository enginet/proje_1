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
    public partial class favori_satici : System.Web.UI.UserControl
    {
        kullaniciTakipciBll kllTkpb = new kullaniciTakipciBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["unique-site-user"] != null)
            {
                if (!Page.IsPostBack)
                {
                    kullanici _authority = (kullanici)Session["unique-site-user"];
                    favoriSaticiRepeater.DataSource = kllTkpb.list(1, _authority.kullaniciId);
                    favoriSaticiRepeater.DataBind();
                    if (Request.QueryString["like"] != null)
                    {
                        kllTkpb.delete(Request.QueryString["like"], _authority.kullaniciId);
                    }
                    favoriSaticiRepeater.DataSource = kllTkpb.list(1, _authority.kullaniciId);
                    favoriSaticiRepeater.DataBind();
                }
            }
        }
    }
}