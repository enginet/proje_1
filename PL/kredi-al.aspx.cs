using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace PL
{
    public partial class kredi_al : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void drpKredi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(drpKredi.SelectedValue=="")
            {
                tutar.Text = "";
            }

            if (drpKredi.SelectedValue == "1")
            {
                tutar.Text = "5 TL";
            }

            if (drpKredi.SelectedValue == "2")
            {
                tutar.Text = "25 TL";
            }

            if (drpKredi.SelectedValue == "3")
            {
                tutar.Text = "50 TL";
            }

            if (drpKredi.SelectedValue == "4")
            {
                tutar.Text = "80 TL";
            }

            if (drpKredi.SelectedValue == "5")
            {
                tutar.Text = "140 TL";
            }

            if (drpKredi.SelectedValue == "6")
            {
                tutar.Text = "325 TL";
            }

            if (drpKredi.SelectedValue == "7")
            {
                tutar.Text = "600 TL";
            }

            if (drpKredi.SelectedValue == "8")
            {
                tutar.Text = "1000 TL";
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(drpKredi.SelectedValue=="")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script language='javascript'>alert('Önce kredi seçiniz !');</script>", false);
            }
            else
            {
                JArray objDizi = new JArray();

                JObject obj = new JObject();
                obj.Add("islemId", 15);
                obj.Add("hizmet", "Kredi -" + drpKredi.SelectedItem.Text);
                obj.Add("miktar", tutar.Text.Replace(" TL", ""));
                obj.Add("odemeId", "");
                obj.Add("odemeTipId","3");
                objDizi.Add(obj);

                odemeBll odmb = new odemeBll();

                odmb.insert(
                    ((kullanici)Session["unique-site-user"]).kullaniciId,
                    objDizi[0]["miktar"],
                    objDizi[0]["islemId"],
                    objDizi[0]["odemeTipId"], // Bu odemetipId değeridir yani odeme yöntemi EFT & Havale olduğu için direk 3 gönderilir. İlerleyen zamanlarda diğer yöntemlerde eklendiğinde burası dinamik değer alıcaktır
                    "", // burası kart numarasıdır. Şuan sadece eft havale olduğu için kart numarası null olarak gönderilecektir
                    false // burası ödeme başarılı mı değeridir. Eft havale olduğu için burası otomatik olarak null değeri alıcaktır. kredi kartı ve mobil ödeme olduğu zaman burası dinamik olarak dolacaktır.
                    );

                objDizi[0]["odemeId"] = odmb.list(Convert.ToInt32(((kullanici)Session["unique-site-user"]).kullaniciId)).ToList().Last().odemeId;

                Session["dp"] = objDizi;

                Response.Redirect("~/odeme.aspx");
            }
        }
    }
}