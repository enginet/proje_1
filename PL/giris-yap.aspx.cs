using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL
{
    public partial class giris_yap : System.Web.UI.Page
    {
        kullaniciBll kullanicib = new kullaniciBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["login"] != null)
            {
                txtMail.Value = Request.Cookies["login"]["username"].ToString();
            }
        }

        protected void Giris_Click(object sender, EventArgs e)
        {
            if (kullanicib.userLoginOn(txtMail.Value, txtSifre.Value))
            {
                Response.Redirect("~/default.aspx");
            }
            else
            {
                Response.Redirect("~/giris-yap.aspx");
            }
        }

        protected void chcBeniHatirla_CheckedChanged(object sender, EventArgs e)
        {
            if (txtMail.Value != null && txtSifre.Value != null)
            {
                if (chcBeniHatirla.Checked)
                {
                    HttpCookie cook = new HttpCookie("login");
                    cook["username"] = txtMail.Value;
                    //cook["password"] = txtSifre.Value;
                    cook.Expires = DateTime.Now.AddDays(3);
                    Response.Cookies.Add(cook);
                }
            }
        }
    }
}