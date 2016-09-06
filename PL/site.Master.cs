using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using System.Web.Security;

namespace PL
{
    public partial class site : System.Web.UI.MasterPage
    {
        mesajBll mesajb = new mesajBll();
        bildirimBll bildirimb = new bildirimBll();
        kullaniciBll kullanicib = new kullaniciBll();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["unique-site-user"] != null)
                {
                    kullanici _authority = (kullanici)Session["unique-site-user"];
                    HttpRequest _request = base.Request;


                    if (_authority.rol == 4 || _authority.rol == 3 || _authority.rol == 2 || _authority.rol == 1)
                    {
                        visitorPanel.Visible = false;
                        userPanel.Visible = true;
                        lblUserName.Text = _authority.kullaniciAdSoyad.ToString();
                        span3.InnerText = kullanicib.search(_authority.kullaniciId).kredi.ToString();
                    }

                    if (mesajb.count(1, _authority.kullaniciId) != 0)
                    {
                        span2.InnerText = mesajb.count(1, _authority.kullaniciId).ToString();
                    }

                    if (bildirimb.count(_authority.kullaniciId, 3) != 0)
                    {
                        span1.InnerText = bildirimb.count(5, 3).ToString();
                    }


                    kullanicib.update(5, _authority.kullaniciId, _request.Browser.Browser, _request.UserHostAddress);
                }
            }
        }

        protected void Cikis_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect("~/default.aspx");

        }
    }
}
