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
    public partial class _default : System.Web.UI.Page
    {
        kategoriBll kategorib = new kategoriBll();
        seciliDopingBll seciliDpngb = new seciliDopingBll();
        ilBll ilb = new ilBll();
        kategoriTurBll kategoriTurb = new kategoriTurBll();
        magazaBll magazab = new magazaBll();
        araBll arab = new araBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            kategoriRepeater.DataSource = kategorib.list(1);
            kategoriRepeater.DataBind();

            anaVitrinRepeater.DataSource = seciliDpngb.list(1);
            anaVitrinRepeater.DataBind();

            acilRepeater.DataSource = seciliDpngb.list(2);
            acilRepeater.DataBind();

            sonSaatRepeater.DataSource = seciliDpngb.list(4);
            sonSaatRepeater.DataBind();


            //popIlRepeater.DataSource = ilb.qlist(1);
            //popIlRepeater.DataBind();

            //popKatRepeater.DataSource = kategorib.qlist(1);
            //popKatRepeater.DataBind();

        }

        public bool catKind(object _income)
        {
            if (kategoriTurb.search(Convert.ToInt32(_income)) != null)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        protected void Ara_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ilan-liste.aspx?sea=" + txtAra.Value);
             
        }

        public string fiyat_Tur(object _income)
        {

            if (Convert.ToInt32(_income) == 1)
            {
                return " &#x20BA;";
            }
            else if (Convert.ToInt32(_income) == 2)
            {
                return " $";
            }
            else
            {
                return " €";
            }
        }


        public bool krediKontrol(object _income)
        {
            magaza _magaza = magazab.search(Convert.ToInt32(_income));

            if (Session["unique-site-user"] != null)
            {
                kullanici _authority = (kullanici)Session["unique-site-user"];

                if (_magaza.magazaTur.turId == 6 && _authority.kredi > 0)
                {
                    return true;
                }
                else if (_income.ToString() == null)
                {
                    return true;
                }
                else if (Convert.ToInt32(_income) == 7)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (_income.ToString() == null)
                {
                    return true;
                }
                else if (Convert.ToInt32(_income) == 7)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}