using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.IO;

namespace PL.management.anaYonetim.magazaYonetimi
{
    public partial class duzenle_icerik : System.Web.UI.UserControl
    {
        magazaTurBll magazaTurb = new magazaTurBll();
        magazaBll magazab = new magazaBll();
        magazaKategoriBll magazaKtgb = new magazaKategoriBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["cat"] != null)
                {
                    drpTur.DataSource = magazaTurb.list(Convert.ToInt32(Request.QueryString["cat"]));
                    drpTur.DataTextField = "turId";
                    drpTur.DataValueField = "magazaTurId";
                    drpTur.DataBind();
                }

                DAL.magaza _magaza = magazab.search(Convert.ToInt32(Request.QueryString["edit"]));
                txtMagazaAd.Text = _magaza.magazaAdi;
                txtAciklama.Text = _magaza.aciklama;
                drpTur.SelectedValue = _magaza.magazaTurId.ToString();
                magazaResim.Attributes["src"] = "../../../upload/magaza/" + _magaza.magazaLogo;

            }
        }

        protected void devam_Click(object sender, EventArgs e)
        {
            //string[] segments = FileUpload1.FileName.Split('.');
            //string fileExt = segments[segments.Length - 1];
            DateTime magazaSure = default(DateTime);

            if (magazaKtgb.search(2,Request.QueryString["pac"]).paketSureId == 1)
            {
                magazaSure = DateTime.Now.AddMonths(6);
            }
            if (magazaKtgb.search(2,Request.QueryString["pac"]).paketSureId == 2)
            {
                magazaSure = DateTime.Now.AddMonths(12);
            }

            //magazab.update(2, Request.QueryString["sto"], Request.QueryString["pac"], drpTur.SelectedValue, txtMagazaAd.Text, Request.QueryString["sto"] + "." + fileExt, magazaSure,txtAciklama.Text);

            string[] segments = FileUpload1.FileName.Split('.');
            string fileExt = segments[segments.Length - 1];
            if (chcYeniResim.Checked)
            {
                if (FileUpload1.HasFile)
                {
                    HttpFileCollection updateFiles = Request.Files;
                    string str_image = "";

                    if (FileUpload1.HasFile)
                    {

                        for (int i = 0; i < updateFiles.Count; i++)
                        {

                            bool secili = false;
                            if (i == 0)
                            {
                                secili = true;
                            }

                            HttpPostedFile file = updateFiles[i];

                            string fileName = file.FileName;
                            string fileExtension = file.ContentType;

                            if (!string.IsNullOrEmpty(fileName))
                            {
                                fileExtension = Path.GetExtension(fileName);
                                str_image = Request.QueryString["edit"] + fileExtension;
                                string pathToSave_100 = HttpContext.Current.Server.MapPath("~/upload/magaza/") + str_image;
                                file.SaveAs(pathToSave_100);
                            }
                        }
                    }

                }
            }
            magazab.update(2, Request.QueryString["edit"], Request.QueryString["pac"], drpTur.SelectedValue, txtMagazaAd.Text, Request.QueryString["edit"] + "." + fileExt, magazaSure, txtAciklama.Text);
            Response.Redirect("~/management/anaYonetim/magazaYonetimi/magaza.aspx?page=listele&proc=3");

        }
    }
}