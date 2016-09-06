using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PL
{
    public partial class ilan_tamam : System.Web.UI.Page
    {
        public string ilanNo="";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["unique-site-user"]!=null)
            {
                if(Session["ilanNo"]!=null)
                {
                    ilanNo = Session["ilanNo"].ToString();
                }
                else
                {
                    Response.Redirect("~/kategori-secimi.aspx");
                }
            }
            else
            {
                Response.Redirect("~/giris-yap.aspx");
            }
        }
    }
}