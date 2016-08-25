using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace PL
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(System.Web.Routing.RouteTable.Routes);
        }

        public void RegisterRoutes(System.Web.Routing.RouteCollection routes)
        {
            //routes.MapPageRoute("kategori", "emlak/{kategoriAd}/{kategoriId}", "~/kategoriler.aspx");
            //routes.MapPageRoute("kategoriTur", "{kategoriId}/{turAd}/{tur}", "~/ilan-liste.aspx");
            //routes.MapPageRoute("bilgilerim", "{control}", "~/profil/anasayfa.ascx");

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }


    }
}