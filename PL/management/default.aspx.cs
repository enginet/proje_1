using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace PL.Management
{
    public partial class Default : System.Web.UI.Page
    {
        kullaniciBll kullanicib = new kullaniciBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                kullaniciRepeater.DataSource = kullanicib.list(2);
                kullaniciRepeater.DataBind();

                using (ilanDataContext idc = new ilanDataContext())
                {
                    classifiedCount.Text = idc.ilans.Count().ToString();
                    userCount.Text = idc.kullanicis.Count().ToString();
                    storeCount.Text = idc.magazas.Count().ToString();
                    visitorCount.Text = Application["totalvisitor"].ToString();
                }
            }
        }
    }
}
