using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using System.IO;

namespace PL.management.anaYonetim.magazaYonetimi
{

    public partial class icerik : System.Web.UI.UserControl
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
            }
        }

        protected void devam_Click(object sender, EventArgs e)
        {
            string[] segments = FileUpload1.FileName.Split('.');
            string fileExt = segments[segments.Length - 1];
            DateTime magazaSure = default(DateTime);

            if (magazaKtgb.search(Request.QueryString["pac"]).paketSureId == 1)
            {
                magazaSure = DateTime.Now.AddMonths(6);
            }
            if (magazaKtgb.search(Request.QueryString["pac"]).paketSureId == 2)
            {
                magazaSure = DateTime.Now.AddMonths(12);
            }

            //magazab.update(2, Request.QueryString["sto"], Request.QueryString["pac"], drpTur.SelectedValue, txtMagazaAd.Text, Request.QueryString["sto"] + "." + fileExt, magazaSure,txtAciklama.Text);

            magazab.update(2, 3, Request.QueryString["pac"], drpTur.SelectedValue, txtMagazaAd.Text, Request.QueryString["sto"] + "." + fileExt, magazaSure, txtAciklama.Text);

            HttpFileCollection updateFiles = Request.Files;
            string str_image = "";

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
                    str_image = Request.QueryString["sto"] + fileExtension;
                    string pathToSave_100 = HttpContext.Current.Server.MapPath("~/upload/magaza/") + str_image;
                    file.SaveAs(pathToSave_100);
                }

            }

            Response.Redirect("~/management/anaYonetim/magazaYonetimi/magaza.aspx?page=odeme&pac=" + Request.QueryString["pac"]);
        }
    }
}