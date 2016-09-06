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
        ilanResimBll ilanResimb = new ilanResimBll();
        kullaniciBll kullanicib = new kullaniciBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                kategoriRepeater.DataSource = kategorib.list(1);
                kategoriRepeater.DataBind();

                anaVitrinRepeater.DataSource = seciliDpngb.list(1);
                anaVitrinRepeater.DataBind();

                acilRepeater.DataSource = seciliDpngb.list(2);
                acilRepeater.DataBind();

                sonSaatRepeater.DataSource = seciliDpngb.list(4);
                sonSaatRepeater.DataBind();

                //lblCountUst.Text = kategorib.count(1, 1).ToString();
                //popIlRepeater.DataSource = ilb.qlist(1);
                //popIlRepeater.DataBind();

                //popKatRepeater.DataSource = kategorib.qlist(1);
                //popKatRepeater.DataBind();
                verilenReklamBll vrb = new verilenReklamBll();
                verilenReklam rklm = vrb.search(2, 7);
                if (rklm != null)
                {
                    dkdrtgnRklm.ImageUrl = ("~/upload/reklam/" + rklm.reklamResim);
                }
                else
                {
                    dkdrtgnRklm.ImageUrl = ("~/upload/reklam/dkdrt.jpg");
                }

                rklm = vrb.search(2, 8);
                if (rklm != null)
                {
                    kutu1Rklm.ImageUrl = ("~/upload/reklam/" + rklm.reklamResim);
                }
                else
                {
                    kutu1Rklm.ImageUrl = ("~/upload/reklam/kutu.jpg");
                }

                rklm = vrb.search(2, 9);
                if (rklm != null)
                {
                    kutu2Rklm.ImageUrl = ("~/upload/reklam/" + rklm.reklamResim);
                }
                else
                {
                    kutu2Rklm.ImageUrl = ("~/upload/reklam/kutu.jpg");
                }
            }
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
            //Response.Redirect("~/ilan-liste.aspx?sea=" + txtAra.Value);
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

        public string classiPic(object _income)
        {
            if(ilanResimb.search(_income)!=null)
            {
                return ilanResimb.search(_income).resim;
            }
            else
            {
                return "not-found-image.jpg";
            }
        }

        public bool krediKontrol(object _income)
        {
            magaza _magaza;
            if (_income != null)
            {
                if (_income.ToString() != "-1")
                {
                    _magaza = magazab.search(Convert.ToInt32(_income));


                    if (_magaza.magazaTur.turId == 6 || _magaza.magazaTur.turId == 1 || _magaza.magazaTur.turId == 2 || _magaza.magazaTur.turId == 3 || _magaza.magazaTur.turId == 4 || _magaza.magazaTur.turId == 5 || _magaza.magazaTur.turId == 9)
                    {
                        if (Session["unique-site-user"] != null)
                        {
                            kullanici _authority = (kullanici)Session["unique-site-user"];

                            if (_authority.kredi > 0)
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
                            return false;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

    }
}