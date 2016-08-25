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
            if (Session["yeniKullanici"] == null)
            {
                Response.Redirect("~/uye-ol.aspx");
            }
        }

        protected void dogrula_Click(object sender, EventArgs e)
        {
            string[] array = Session["yeniKullanici"] as string[];
            if (array[4] == txtOnayKodu.Text)
            {
                //SHA256 mySHA256 = SHA256Managed.Create();
                //byte[] hasvalue;
                //hasvalue = mySHA256.ComputeHash(array[1]);
                kll.insert(array[0], array[3], array[2], 4);
                kullanici kllnc = kll.receiveList().Last();
                tlf.insert(kllnc.kullaniciId, array[1]);

                // session işlemleri başlatılacak
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