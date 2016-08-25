using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.profil
{
    public partial class favori_satici : System.Web.UI.UserControl
    {
        kullaniciTakipciBll kllTkpb = new kullaniciTakipciBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            favoriSaticiRepeater.DataSource = kllTkpb.list(1, 5);
            favoriSaticiRepeater.DataBind();
            if (Request.QueryString["like"] != null)
            {
                kllTkpb.delete(Request.QueryString["like"], 5);
            }
            favoriSaticiRepeater.DataSource = kllTkpb.list(1, 5);
            favoriSaticiRepeater.DataBind();
        }
    }
}