using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL
{
    public partial class arama_sonuclari : System.Web.UI.Page
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
    }
}