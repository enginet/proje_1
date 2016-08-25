using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.management.anaYonetim.magazaYonetimi
{
    public partial class kullanici_listele : System.Web.UI.UserControl
    {
        magazaKullaniciBll magazaKll = new magazaKullaniciBll();
        magazaTakipciBll magazaTkp = new magazaTakipciBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Request.QueryString["how"]) == 1)
            {
                kullaniciRepeater.DataSource = magazaKll.list(1,Convert.ToInt32(Request.QueryString["magazaId"]));
                kullaniciRepeater.DataBind();
            }
            else if (Convert.ToInt32(Request.QueryString["how"]) == 2)
            {
                kullaniciRepeater.DataSource = magazaTkp.list(3,Convert.ToInt32(Request.QueryString["magazaId"]));
                kullaniciRepeater.DataBind();
            }
        }
    }
}