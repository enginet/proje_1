using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL
{
    public partial class yeni_sifre : System.Web.UI.Page
    {
        guvenlikKodlariBll guvenlikb = new guvenlikKodlariBll();
        kullaniciBll kullanicib = new kullaniciBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (guvenlikb.search(Request.QueryString["act"]) == null)
            {
                Response.Redirect("~/giris-yap.aspx");
            }
        }

        protected void Gonder_Click(object sender, EventArgs e)
        {
            kullanicib.update(4, kullanicib.mail_search((guvenlikb.search(Request.QueryString["act"]).cepTelefonu)).kullaniciId, txtSifre.Value);
            Response.Redirect("~/giris-yap.aspx");
        }
    }
}