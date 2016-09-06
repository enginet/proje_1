using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;

namespace PL.management.anaYonetim.kullaniciYonetimi
{
    public partial class ekle : System.Web.UI.UserControl
    {
        kullaniciBll kll = new kullaniciBll();

        telefonBll tlf = new telefonBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            onlineRepeater.DataSource = kll.list(4);
            onlineRepeater.DataBind();
        }

        protected void Kaydet_Click(object sender, EventArgs e)
        {
            kll.insert(txtAd.Text + " " + txtSoyad.Text, DAL.toolkit.SHA1Hash_Encryption(txtSifre.Text), txtEmail.Text, Convert.ToInt32(drpYetki.SelectedValue));

            kullanici kllnc = kll.receiveList().LastOrDefault(); // son kayıt çekiliyor
            tlf.insert(kllnc.kullaniciId, txtGsm1.Text);

            Response.Redirect("~/management/anaYonetim/kullaniciYonetimi/kullanici.aspx?page=listele&tip=uye");
        }

        protected void Vazgec_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/management/anaYonetim/kullaniciYonetimi/kullanici.aspx?page=listele&tip=uye");
        }
    }
}