using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using System.Web.Security;

namespace PL.Management
{
    public partial class admin : System.Web.UI.MasterPage
    {
        mesajBll mesajb = new mesajBll();
        bildirimBll bildirimb = new bildirimBll();
        kullaniciBll kullanicib = new kullaniciBll();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["unique-user"] != null)
            {
                kullanici _authority = (kullanici)Session["unique-user"];
                HttpRequest _request = base.Request;
                userMain.InnerText = _authority.kullaniciAdSoyad;
                userJobSub.InnerText = _authority.kullaniciAdSoyad + "-" + _authority.meslekId;
                loginDate.InnerText = _authority.sonGirisTarihi.ToString();
                userNavi.InnerText = _authority.kullaniciAdSoyad;

                if (_authority.rol == 1)
                {

                    classifiedMenu.Visible = true;
                    adsMenu.Visible = true;
                    catMenu.Visible = true;
                    userMenu.Visible = true;
                    storeMenu.Visible = true;
                    areaMenu.Visible = true;
                    messageMenu.Visible = true;
                    settingsMenu.Visible = true;
                    gearsMenu.Visible = false;
                }

                else if (_authority.rol == 2)
                {

                    classifiedMenu.Visible = true;
                    adsMenu.Visible = true;
                    catMenu.Visible = true;
                    userMenu.Visible = true;
                    storeMenu.Visible = true;
                    areaMenu.Visible = true;
                    messageMenu.Visible = true;
                    settingsMenu.Visible = false;
                    gearsMenu.Visible = true;
                }

                else if (_authority.rol == 3)
                {

                    classifiedMenu.Visible = true;
                    adsMenu.Visible = true;
                    catMenu.Visible = false;
                    userMenu.Visible = false;
                    storeMenu.Visible = true;
                    areaMenu.Visible = true;
                    messageMenu.Visible = true;
                    settingsMenu.Visible = false;
                    gearsMenu.Visible = false;
                }

                mesajRepeater.DataSource = mesajb.list(1, _authority.kullaniciId);
                mesajRepeater.DataBind();

                if (mesajb.count(1, _authority.kullaniciId) != 0)
                {
                    heaLiCount.InnerText = mesajb.count(1, _authority.kullaniciId).ToString() + " adet okunmamış mesajın var.";
                    spanCount.InnerText = mesajb.count(1, _authority.kullaniciId).ToString();
                }

                bildirimRepeater.DataSource = bildirimb.list(_authority.kullaniciId, 3);
                bildirimRepeater.DataBind();

                if (bildirimb.count(_authority.kullaniciId, 3) != 0)
                {
                    headerNotCount.InnerText = bildirimb.count(_authority.kullaniciId, 3).ToString() + " adet okunmamış bildirimin var.";
                    spanNotCount.InnerText = bildirimb.count(5, 3).ToString();
                }

                kullanicib.update(5, _authority.kullaniciId, _request.Browser.Browser, _request.UserHostAddress);
                kullanicib.update(6, _authority.kullaniciId);
            }
            else
            {
                Response.Redirect("~/sysLogin/syslogin.aspx");
            }

        }

        protected void Cikis_Click(object sender, EventArgs e)
        {
            kullanici _authority = (kullanici)Session["unique-user"];
            kullanicib.update(7, _authority.kullaniciId);
            FormsAuthentication.SignOut();
            if (Request.Cookies["login"] != null)
            {
                Response.Redirect("~/sysLogin/syslock.aspx");
            }
            else
            {
                Response.Redirect("~/sysLogin/syslogin.aspx");
            }
        }
    }
}