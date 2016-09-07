using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using System.Collections;
using Newtonsoft.Json.Linq;

namespace PL
{
    public partial class ilan_doping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dopingKategoriBll dkb = new dopingKategoriBll();


            if (!IsPostBack)
            {
                if (Session["unique-site-user"] != null)
                {

                    drpAnasayfa.Items.Clear();
                    drpAramaSonuc.Items.Clear();
                    drpKategoriVitrin.Items.Clear();
                    drpUstSirada.Items.Clear();
                    drpAcil.Items.Clear();
                    drpKucukFoto.Items.Clear();
                    drpKalinYazi.Items.Clear();

                    ListItem lst = new ListItem();
                    lst.Text = "Seçiniz";
                    lst.Value = "";

                    drpAnasayfa.DataSource = dkb.list(2, 1, 1);
                    drpAnasayfa.DataTextField = "deneme";
                    drpAnasayfa.DataValueField = "dopingKategoriId";
                    drpAnasayfa.DataBind();
                    drpAnasayfa.Items.Insert(0, lst);

                    drpAramaSonuc.DataSource = dkb.list(2, 1, 2);
                    drpAramaSonuc.DataTextField = "deneme";
                    drpAramaSonuc.DataValueField = "dopingKategoriId";
                    drpAramaSonuc.DataBind();
                    drpAramaSonuc.Items.Insert(0, lst);

                    drpUstSirada.DataSource = dkb.list(2, 1, 3);
                    drpUstSirada.DataTextField = "deneme";
                    drpUstSirada.DataValueField = "dopingKategoriId";
                    drpUstSirada.DataBind();
                    drpUstSirada.Items.Insert(0, lst);

                    drpKategoriVitrin.DataSource = dkb.list(2, 1, 4);
                    drpKategoriVitrin.DataTextField = "deneme";
                    drpKategoriVitrin.DataValueField = "dopingKategoriId";
                    drpKategoriVitrin.DataBind();
                    drpKategoriVitrin.Items.Insert(0, lst);

                    drpAcil.DataSource = dkb.list(2, 1, 5);
                    drpAcil.DataTextField = "deneme";
                    drpAcil.DataValueField = "dopingKategoriId";
                    drpAcil.DataBind();
                    drpAcil.Items.Insert(0, lst);

                    drpKucukFoto.DataSource = dkb.list(2, 1, 6);
                    drpKucukFoto.DataTextField = "deneme";
                    drpKucukFoto.DataValueField = "dopingKategoriId";
                    drpKucukFoto.DataBind();
                    drpKucukFoto.Items.Insert(0, lst);

                    drpKalinYazi.DataSource = dkb.list(2, 1, 7);
                    drpKalinYazi.DataTextField = "deneme";
                    drpKalinYazi.DataValueField = "dopingKategoriId";
                    drpKalinYazi.DataBind();
                    drpKalinYazi.Items.Insert(0, lst);


                    if (Session["dp"] != null)
                    {
                        JArray objDizi = (JArray)Session["dp"];

                        for (int i = 0; i < objDizi.Count; i++)
                        {
                            if (objDizi[i]["islemId"].ToString() == "1")
                            {
                                drpAnasayfa.SelectedValue = objDizi[i]["secili"].ToString();
                            }
                            if (objDizi[i]["islemId"].ToString() == "2")
                            {
                                drpAramaSonuc.SelectedValue = objDizi[i]["secili"].ToString();
                            }
                            if (objDizi[i]["islemId"].ToString() == "3")
                            {
                                drpKategoriVitrin.SelectedValue = objDizi[i]["secili"].ToString();
                            }
                            if (objDizi[i]["islemId"].ToString() == "4")
                            {
                                drpUstSirada.SelectedValue = objDizi[i]["secili"].ToString();
                            }
                            if (objDizi[i]["islemId"].ToString() == "5")
                            {
                                drpAcil.SelectedValue = objDizi[i]["secili"].ToString();
                            }
                            if (objDizi[i]["islemId"].ToString() == "6")
                            {
                                drpKucukFoto.SelectedValue = objDizi[i]["secili"].ToString();
                            }
                            if (objDizi[i]["islemId"].ToString() == "7")
                            {
                                drpKalinYazi.SelectedValue = objDizi[i]["secili"].ToString();
                            }
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/giris-yap.aspx");
                }
            }
        }

        protected void devam_Click(object sender, EventArgs e)
        {
            ArrayList secilenDopingler = new ArrayList();
            JArray objDizi = new JArray();

            if (drpAnasayfa.SelectedValue != "")
            {
                JObject obj = new JObject();
                obj.Add("islemId", 1);
                string[] hafta = drpAnasayfa.SelectedItem.Text.Split('(');
                obj.Add("hizmet", "Anasayfa Vitrini (" + hafta[0].Trim() + ")");
                obj.Add("miktar", hafta[1].Replace("TL)", "").Trim());
                obj.Add("odemeTipId", "3"); // buraya ödeme tipi gelecek ileride
                obj.Add("odemeId", "");
                obj.Add("secili", drpAnasayfa.SelectedValue);

                objDizi.Add(obj);
            }
            if (drpAramaSonuc.SelectedValue != "")
            {
                JObject obj = new JObject();
                obj.Add("islemId", 2);
                string[] hafta = drpAramaSonuc.SelectedItem.Text.Split('(');
                obj.Add("hizmet", "Arama Sonuç Vitrini (" + hafta[0].Trim() + ")");
                obj.Add("miktar", hafta[1].Replace("TL)", "").Trim());
                obj.Add("odemeTipId", "3");
                obj.Add("odemeId", "");
                obj.Add("secili", drpAramaSonuc.SelectedValue);

                objDizi.Add(obj);
            }
            if (drpKategoriVitrin.SelectedValue != "")
            {
                JObject obj = new JObject();
                obj.Add("islemId", 3);
                string[] hafta = drpKategoriVitrin.SelectedItem.Text.Split('(');
                obj.Add("hizmet", "Kategori Vitrini (" + hafta[0].Trim() + ")");
                obj.Add("miktar", hafta[1].Replace("TL)", "").Trim());
                obj.Add("odemeTipId", "3");
                obj.Add("odemeId", "");
                obj.Add("secili", drpKategoriVitrin.SelectedValue);

                objDizi.Add(obj);
            }
            if (drpUstSirada.SelectedValue != "")
            {
                JObject obj = new JObject();
                obj.Add("islemId", 4);
                string[] hafta = drpUstSirada.SelectedItem.Text.Split('(');
                obj.Add("hizmet", "Üst Sıradayım (" + hafta[0].Trim() + ")");
                obj.Add("miktar", hafta[1].Replace("TL)", "").Trim());
                obj.Add("odemeTipId", "3");
                obj.Add("odemeId", "");
                obj.Add("secili", drpUstSirada.SelectedValue);

                objDizi.Add(obj);
            }
            if (drpAcil.SelectedValue != "")
            {
                JObject obj = new JObject();
                obj.Add("islemId", 5);
                string[] hafta = drpAcil.SelectedItem.Text.Split('(');
                obj.Add("hizmet", "Acil Acil (" + hafta[0].Trim() + ")");
                obj.Add("miktar", hafta[1].Replace("TL)", "").Trim());
                obj.Add("odemeTipId", "3");
                obj.Add("odemeId", "");
                obj.Add("secili", drpAcil.SelectedValue);

                objDizi.Add(obj);
            }
            if (drpKucukFoto.SelectedValue != "")
            {
                JObject obj = new JObject();
                obj.Add("islemId", 6);
                string[] hafta = drpKucukFoto.SelectedItem.Text.Split('(');
                obj.Add("hizmet", "Küçük Fotoğraf (" + hafta[0].Trim() + ")");
                obj.Add("miktar", hafta[1].Replace("TL)", "").Trim());
                obj.Add("odemeTipId", "3");
                obj.Add("odemeId", "");
                obj.Add("secili", drpKucukFoto.SelectedValue);

                objDizi.Add(obj);
            }
            if (drpKalinYazi.SelectedValue != "")
            {
                JObject obj = new JObject();
                obj.Add("islemId", 7);
                string[] hafta = drpKalinYazi.SelectedItem.Text.Split('(');
                obj.Add("hizmet", "Kalın Yazı & Renkli Çerçeve (" + hafta[0].Trim() + ")");
                obj.Add("miktar", hafta[1].Replace("TL)", "").Trim());
                obj.Add("odemeTipId", "3");
                obj.Add("odemeId", "");
                obj.Add("secili", drpKalinYazi.SelectedValue);

                objDizi.Add(obj);
            }


            odemeBll odmb = new odemeBll();

            for (int i = 0; i < objDizi.Count; i++)
            {
                odmb.insert(
                    ((kullanici)Session["unique-site-user"]).kullaniciId,
                    objDizi[i]["miktar"],
                    objDizi[i]["islemId"],
                    objDizi[i]["odemeTipId"], // Bu odemetipId değeridir yani odeme yöntemi EFT & Havale olduğu için direk 3 gönderilir. İlerleyen zamanlarda diğer yöntemlerde eklendiğinde burası dinamik değer alıcaktır
                    "", // burası kart numarasıdır. Şuan sadece eft havale olduğu için kart numarası null olarak gönderilecektir
                    false // burası ödeme başarılı mı değeridir. Eft havale olduğu için burası otomatik olarak null değeri alıcaktır. kredi kartı ve mobil ödeme olduğu zaman burası dinamik olarak dolacaktır.
                    );

                objDizi[i]["odemeId"] = odmb.list(Convert.ToInt32(((kullanici)Session["unique-site-user"]).kullaniciId)).ToList().Last().odemeId;

            }

            Session["dp"] = objDizi;

            Response.Redirect("~/odeme.aspx");
        }
    }
}