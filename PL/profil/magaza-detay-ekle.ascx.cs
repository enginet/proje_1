using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.IO;

namespace PL.profil
{
    public partial class magaza_detay_ekle : System.Web.UI.UserControl
    {
        kategoriBll kategorib = new kategoriBll();
        magazaBll magazab = new magazaBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            drpKategori.DataSource= kategorib.list(0);
            drpKategori.DataTextField = "kategoriAdi";
            drpKategori.DataValueField = "kategoriId";
            drpKategori.DataBind();
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                //string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                //FileUpload1.SaveAs("store_" + 15 + extension);
                magazab.update(2, 15, drpKategori.SelectedValue, drpPaket.SelectedValue, FileUpload1.FileName, drpPaketSure.SelectedValue);

            }
        }
    }
}