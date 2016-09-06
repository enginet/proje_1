using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using System.Security.Cryptography;

namespace PL
{
    public partial class cep_aktivasyon : System.Web.UI.Page
    {
        kullaniciBll kll = new kullaniciBll();
        telefonBll tlf = new telefonBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["yeniKullanici"] == null || Session["mobile-act"] == null)
            //{
            //    Response.Redirect("~/uye-ol.aspx");
            //}
        }

        protected void dogrula_Click(object sender, EventArgs e)
        {
            if (Session["yeniKullanici"] != null)
            {
                string[] array = Session["yeniKullanici"] as string[];
                if (array[4] == txtOnayKodu.Text)
                {

                    kll.insert(array[0], array[3], array[2], 4);
                    kullanici kllnc = kll.receiveList().Last();
                    tlf.insert(kllnc.kullaniciId, array[1]);
                    Response.Redirect("~/giris-yap.aspx");
                }
                else
                {
                    Panel pnl = new Panel();
                    pnl.Attributes["class"] = "alert alert-danger";
                    Label lbl = new Label();
                    lbl.Text = "Onay kodu yanlış, Lütfen kontrol ediniz";
                    pnl.Controls.Add(lbl);
                    onay.Controls.Add(pnl);
                }
            }

            if (Session["unique-site-user"] != null)
            {
                if (Session["mobile-act"] != null)
                {

                    kullanici _authority = (kullanici)Session["unique-site-user"];

                    string[] array = Session["mobile-act"] as string[];
                    if (array[1] == txtOnayKodu.Text)

                        tlf.update(_authority.kullaniciId, array[0], 1);
                    Response.Redirect("~/profil/profil.aspx?control=cep-telefonu");
                }
                else
                {
                    Panel pnl = new Panel();
                    pnl.Attributes["class"] = "alert alert-danger";
                    Label lbl = new Label();
                    lbl.Text = "Onay kodu yanlış, Lütfen kontrol ediniz";
                    pnl.Controls.Add(lbl);
                    onay.Controls.Add(pnl);
                }
            }
        }
    }
}