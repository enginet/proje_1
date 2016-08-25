using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL
{
    public partial class magaza_profil : System.Web.UI.Page
    {
        ilanBll ilanb = new ilanBll();
        magazaBll magazab = new magazaBll();
        magazaTelefonBll magazaTlfb = new magazaTelefonBll();
        magazaKullaniciBll magazaKllb = new magazaKullaniciBll();
        magazaTakipciBll magazaTakipb = new magazaTakipciBll();
        seciliDopingBll seciliDopingb = new seciliDopingBll();
        int magazaId;

        protected void Page_Load(object sender, EventArgs e)
        {
            magazaId = Convert.ToInt32(Request.QueryString["store"]);
            ilanRepeater.DataSource = ilanb.list(5, magazaId);
            ilanRepeater.DataBind();

            DAL.magaza _magaza = magazab.search(magazaId);
            lblMagazaAdi.Text = _magaza.magazaAdi;
            lblAciklama.Text = _magaza.aciklama;

            telefonRepeater.DataSource = magazaTlfb.list(1, _magaza.magazaId);
            telefonRepeater.DataBind();

            kullaniciRepeater.DataSource = magazaKllb.list(1, magazaId);
            kullaniciRepeater.DataBind();

            takipciRepeater.DataSource = magazaTakipb.list_Follow(magazaId);
            takipciRepeater.DataBind();

            if (magazaTakipb.search(3, magazaId) != null)
            {
                LinkButton1.Visible = false;
            }
            else
            {
                LinkButton2.Visible = false;
            }

            //if (magazaTlfb.search(Convert.ToInt32(Request.QueryString["store"]), 3) != null)
            //{
            //    DAL.magazaTelefon _magazaTlf = magazaTlfb.search(Convert.ToInt32(Request.QueryString["store"]), 3);
            //    hypIsTlf.Text = _magazaTlf.telefon;
            //}
        }

        public bool doping_Tur(object _income, int _id)
        {
            if (seciliDopingb.search(_income, _id) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            magazaTakipb.insert(3, magazaId);
            LinkButton1.Visible = false;

        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {

            magazaTakipb.delete(magazaId, 3);
            LinkButton2.Visible = false;

        }
    }
}