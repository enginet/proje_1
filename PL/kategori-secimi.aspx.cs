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
    public partial class kategori_secimi : System.Web.UI.Page
    {
        kategoriBll ktg = new kategoriBll();
        kategoriTurBll ktgT = new kategoriTurBll();

        ilanBll ilnBll = new ilanBll();

        magazaKullaniciBll mkul = new magazaKullaniciBll();
        magazaKategoriBll mkat = new magazaKategoriBll();
        magazaBll mgzB = new magazaBll();

        public string mesaj = "";

        protected override void OnInit(EventArgs e)
        {

            ListBox1.SelectedIndexChanged += Lst_SelectedIndexChanged;
            ListBox2.SelectedIndexChanged += Lst_SelectedIndexChanged;
            ListBox3.SelectedIndexChanged += Lst_SelectedIndexChanged;
            ListBox4.SelectedIndexChanged += Lst_SelectedIndexChanged;
            ListBox5.SelectedIndexChanged += Lst_SelectedIndexChanged;

            cat_2.Visible = false;
            cat_3.Visible = false;
            cat_4.Visible = false;
            cat_5.Visible = false;

            devam.Enabled = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["unique-site-user"]!=null)
            {
                if (!IsPostBack)
                {
                    ListBox1.DataSource = ktg.list(Convert.ToInt32(0));
                    ListBox1.DataTextField = "kategoriAdi";
                    ListBox1.DataValueField = "kategoriId";
                    ListBox1.DataBind();
                }
            }
            else
            {
                Response.Redirect("~/giris-yap.aspx");
            }
        }

        private void Lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            ListBox list = new ListBox();

            if (listBox == ListBox1)
            {
                ListBox2.Items.Clear();
                ListBox3.Items.Clear();
                ListBox4.Items.Clear();
                ListBox5.Items.Clear();

                cat_2.Visible = false;
                cat_3.Visible = false;
                cat_4.Visible = false;
                cat_5.Visible = false;

                list = ListBox2;

                IEnumerable<kategori> sonuc = ktg.list(Convert.ToInt32(listBox.SelectedValue));
                if (sonuc.Any())
                {
                    cat_2.Visible = true;

                    list.DataSource = sonuc;
                    list.DataTextField = "kategoriAdi";
                    list.DataValueField = "kategoriId";
                    list.DataBind();
                    devam.Enabled = false;

                }
                else
                {
                    Label lbl = new Label();
                    lbl.Text = "Seçim Tamamlandı !";
                    lbl.Attributes["class"] = "tamam";

                    Panel pnl = new Panel();
                    pnl.Attributes["class"] = "categories";
                    pnl.Controls.Add(lbl);

                    cats.Controls.Add(pnl);
                    ViewState["id"] = Convert.ToInt32(ListBox1.SelectedValue);
                    devam.Enabled = true;
                }
            }
            else if (listBox == ListBox2)
            {
                ListBox3.Items.Clear();
                ListBox4.Items.Clear();
                ListBox5.Items.Clear();

                cat_3.Visible = false;
                cat_4.Visible = false;
                cat_5.Visible = false;

                list = ListBox3;

                // Her ik tablodan da bilgi çekiyoruz ilk önce kategoriTur tablosundaki verileri karşılaştırıyoruz.
                IEnumerable<object> sonuclar = (IEnumerable<object>)ktgT.list(1, ListBox2.SelectedValue);
                IEnumerable<kategori> sonuc = ktg.list(Convert.ToInt32(ListBox2.SelectedValue));

                if (sonuclar.Any()) // kategoriTur tablosunda satılık kiralık vb. değeri var mı
                {
                    cat_3.Visible = true;
                    foreach (object key in sonuclar.ToList())
                    {
                        if (key.ToString() == "{ turId = 1 }")
                        {
                            ListItem li = new ListItem();
                            li.Text = "Satılık";
                            li.Value = "1";
                            ListBox3.Items.Add(li);
                        }
                        if (key.ToString() == "{ turId = 2 }")
                        {
                            ListItem li = new ListItem();
                            li.Text = "Kiralık";
                            li.Value = "2";
                            ListBox3.Items.Add(li);
                        }
                        if (key.ToString() == "{ turId = 3 }")
                        {
                            ListItem li = new ListItem();
                            li.Text = "Günlük Kiralık";
                            li.Value = "3";
                            ListBox3.Items.Add(li);
                        }
                        if (key.ToString() == "{ turId = 4 }")
                        {
                            ListItem li = new ListItem();
                            li.Text = "Devren";
                            li.Value = "4";
                            ListBox3.Items.Add(li);
                        }
                        if (key.ToString() == "{ turId = 5 }")
                        {
                            ListItem li = new ListItem();
                            li.Text = "Devren Kiralık";
                            li.Value = "5";
                            ListBox3.Items.Add(li);
                        }
                        if (key.ToString() == "{ turId = 6 }")
                        {
                            ListItem li = new ListItem();
                            li.Text = "Devren Satılık Konut";
                            li.Value = "6";
                            ListBox3.Items.Add(li);
                        }
                    }
                    devam.Enabled = false;
                }
                else if (sonuc.Any()) // kategori tablosunda alt kategoriler var mı
                {
                    cat_3.Visible = true;
                    ListBox3.DataSource = sonuc;
                    ListBox3.DataTextField = "kategoriAdi";
                    ListBox3.DataValueField = "kategoriId";
                    ListBox3.DataBind();
                    devam.Enabled = false;
                }
                else
                {
                    Label lbl = new Label();
                    lbl.Text = "Seçim Tamamlandı !";
                    lbl.Attributes["class"] = "tamam";

                    Panel pnl = new Panel();
                    pnl.Attributes["class"] = "categories";
                    pnl.Controls.Add(lbl);

                    cats.Controls.Add(pnl);
                    ViewState["id"] = Convert.ToInt32(ListBox2.SelectedValue);
                    devam.Enabled = true;
                }
            }
            else if (listBox == ListBox3)
            {
                ListBox4.Items.Clear();
                ListBox5.Items.Clear();

                cat_4.Visible = false;
                cat_5.Visible = false;

                list = ListBox4;


                IEnumerable<object> sonuclar = (IEnumerable<object>)ktgT.list(2, ListBox2.SelectedValue, ListBox3.SelectedValue);
                IEnumerable<kategori> sonuc = ktg.list(Convert.ToInt32(ListBox3.SelectedValue));
                if (sonuclar.Any())
                {
                    cat_4.Visible = true;
                    ListBox4.DataSource = sonuclar;
                    ListBox4.DataTextField = "kategoriAdi";
                    ListBox4.DataValueField = "kategoriId";
                    ListBox4.DataBind();
                    devam.Enabled = false;
                    ViewState["ilanTur"] = Convert.ToInt32(ListBox3.SelectedValue);
                }
                else if (ListBox1.SelectedValue != "1" || (ListBox2.SelectedValue != "4" && ListBox2.SelectedValue != "5")) // emlak kategorisi değiise veya (arsa ve bina değilse)
                {
                    //ListBox1.Items.Add(ListBox2.SelectedValue);
                    if (sonuc.Any())
                    {
                        cat_4.Visible = true;
                        ListBox4.DataSource = sonuc;
                        ListBox4.DataTextField = "kategoriAdi";
                        ListBox4.DataValueField = "kategoriId";
                        ListBox4.DataBind();
                        devam.Enabled = false;
                    }
                    else
                    {
                        Label lbl = new Label();
                        lbl.Text = "Seçim Tamamlandı !";
                        lbl.Attributes["class"] = "tamam";

                        Panel pnl = new Panel();
                        pnl.Attributes["class"] = "categories";
                        pnl.Controls.Add(lbl);

                        cats.Controls.Add(pnl);
                        devam.Enabled = true;
                        ViewState["id"] = Convert.ToInt32(ListBox3.SelectedValue);
                    }
                }
                else
                {
                    Label lbl = new Label();
                    lbl.Text = "Seçim Tamamlandı !";
                    lbl.Attributes["class"] = "tamam";

                    Panel pnl = new Panel();
                    pnl.Attributes["class"] = "categories";
                    pnl.Controls.Add(lbl);

                    cats.Controls.Add(pnl);
                    devam.Enabled = true;
                    ViewState["ilanTur"] = Convert.ToInt32(ListBox3.SelectedValue);
                    ViewState["id"] = Convert.ToInt32(ListBox2.SelectedValue);
                }
            }
            else if (listBox == ListBox4)
            {
                ListBox5.Items.Clear();

                cat_5.Visible = false;
                list = ListBox5;

                IEnumerable<kategori> sonuc = ktg.list(Convert.ToInt32(ListBox4.SelectedValue));
                if (sonuc.Any())
                {
                    cat_5.Visible = true;
                    ListBox5.DataSource = sonuc;
                    ListBox5.DataTextField = "kategoriAdi";
                    ListBox5.DataValueField = "kategoriId";
                    ListBox5.DataBind();
                    devam.Enabled = false;
                }
                else
                {
                    Label lbl = new Label();
                    lbl.Text = "Seçim Tamamlandı !";
                    lbl.Attributes["class"] = "tamam";

                    Panel pnl = new Panel();
                    pnl.Attributes["class"] = "categories";
                    pnl.Controls.Add(lbl);

                    cats.Controls.Add(pnl);
                    devam.Enabled = true;
                    ViewState["id"] = Convert.ToInt32(ListBox4.SelectedValue);
                }
            }
        }

        protected void devam_Click1(object sender, EventArgs e)
        {

            // kullanıcının mağazasının olup olmadığı kontrol edilmesi gerekir
            DAL.magazaKullanici magazaKul = mkul.search(2, ((kullanici)Session["unique-site-user"]).kullaniciId);

            Session["cat"] = null;
            Session["tur"] = null;
            Session["mgz"] = null;


            if (magazaKul != null) // eğer mağazası var ise
            {
                DAL.magaza mgz = mgzB.search(magazaKul.magazaId);

                if (mgz.pasifMi == false && mgz.silindiMi == false)
                {
                    DAL.magazaKategori mgzKat = mkat.search(2, mgz.magazaKategoriId);

                    if (mgzKat.kategoriId.ToString() != ListBox1.SelectedValue) // seçilen ilan kategorisi mağaza kategorisine eşit değilse
                    {
                        if (ilnBll.ilanSayisi(((kullanici)Session["unique-site-user"]).kullaniciId) < 2) // ilan sayısı 2 veya daha büyük değilse
                        {
                            if (ListBox2.SelectedValue == "14" || ListBox2.SelectedValue == "18")
                            {
                                Session["cat"] = ViewState["id"];
                                Response.Redirect("~/ilan-form.aspx");
                            }
                            else if (ListBox2.SelectedValue == "12")
                            {
                                Session["cat"] = ViewState["id"];
                                Session["tur"] = ViewState["ilanTur"];
                                Response.Redirect("~/ilan-form.aspx");
                            }
                            else
                            {
                                Session["cat"] = ViewState["id"];
                                Session["tur"] = ViewState["ilanTur"];
                                Response.Redirect("~/ilan-form.aspx");
                            }
                        }
                        else
                        {
                            if (ViewState["ilanTur"] != null)
                            {
                                Session["tur"] = ViewState["ilanTur"];
                            }
                            Session["cat"] = ViewState["id"];
                            mesaj = "Vermek istediğiniz kategori mağazanızın kategorisi dışında ve yayında 2 adet ilanınız olduğu için ücretsiz ilan veremezsiniz !";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script language='javascript'>uyariVer();</script>", false);
                        }
                    }
                    else
                    {
                        if (ListBox2.SelectedValue == "14" || ListBox2.SelectedValue == "18")
                        {
                            Session["cat"] = ViewState["id"];
                            Session["mgz"] = mgz.magazaId;
                            Response.Redirect("~/ilan-form.aspx");
                        }
                        else if (ListBox2.SelectedValue == "12")
                        {
                            Session["cat"] = ViewState["id"];
                            Session["mgz"] = mgz.magazaId;
                            Session["tur"] = ViewState["ilanTur"];
                            Response.Redirect("~/ilan-form.aspx");
                        }
                        else
                        {
                            Session["cat"] = ViewState["id"];
                            Session["mgz"] = mgz.magazaId;
                            Session["tur"] = ViewState["ilanTur"];
                            Response.Redirect("~/ilan-form.aspx");
                        }
                    }
                }
            }
            else
            {
                kullanici kll = (kullanici)Session["unique-site-user"];
                if (ilnBll.ilanSayisi(kll.kullaniciId) < 2) // ilan sayısı 2 veya daha büyük değilse
                {
                    if (ListBox2.SelectedValue == "14" || ListBox2.SelectedValue == "18")
                    {
                        Session["cat"] = ViewState["id"];
                        Response.Redirect("~/ilan-form.aspx");
                    }
                    else if (ListBox2.SelectedValue == "12")
                    {
                        Session["cat"] = ViewState["id"];
                        Session["tur"] = ViewState["ilanTur"];
                        Response.Redirect("~/ilan-form.aspx");
                    }
                    else
                    {
                        Session["cat"] = ViewState["id"];
                        Session["tur"] = ViewState["ilanTur"];
                        Response.Redirect("~/ilan-form.aspx");
                    }
                }
                else
                {
                    if (ViewState["ilanTur"] != null)
                    {
                        Session["tur"] = ViewState["ilanTur"];
                    }
                    Session["cat"] = ViewState["id"];
                    mesaj = "En fazla 2 (iki) adet ücretsiz ilan verebilirsiniz";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script language='javascript'>uyariVer();</script>", false);
                }
            }


        }

        protected void devamEt_Click(object sender, EventArgs e)
        {
            Session["ilanUcretliMi"] = true;
            Response.Redirect("~/ilan-form.aspx");
        }
    }
}