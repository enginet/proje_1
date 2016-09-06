using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.sysLogin
{
    public partial class syslogin : System.Web.UI.Page
    {
        kullaniciBll kullanicib = new kullaniciBll();
        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void Giris_Click(object sender, EventArgs e)
        {
            if (kullanicib.loginOn(txtMail.Value,  DAL.toolkit.SHA1Hash_Encryption(txtSifre.Value)))
            {
                Response.Redirect("~/management/default.aspx");
            }
            else
            {
                Response.Redirect("~/sysLogin/syslogin.aspx");
            }
        }
    }
}