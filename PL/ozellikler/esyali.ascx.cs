using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace PL.ozellikler
{
    public partial class esyali : System.Web.UI.UserControl
    {
        ozellikBll ozellikb = new ozellikBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            secilebilirIlanOzellikBll sioBll = new secilebilirIlanOzellikBll();
            if (Request.QueryString["page"] == "duzenle" && Request.QueryString["ilan"] != "")
            {
                if (sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 47) != null)
                {
                    if (sioBll.search(Convert.ToInt32(Request.QueryString["ilan"]), 47).ozellikDegerId.ToString() == "229")
                        chcEsya.Checked = true;
                }
            }
        }
    }
}