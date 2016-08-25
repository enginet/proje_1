using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.management.anaYonetim.bolgeYonetimi
{
    public partial class ekle : System.Web.UI.UserControl
    {
        ilBll il = new ilBll();
        kullaniciBll kullanicib = new kullaniciBll();
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                onlineRepeater.DataSource = kullanicib.list(4);
                onlineRepeater.DataBind();
            }
        }

        protected void Kaydet_Click(object sender, EventArgs e)
        {
            il.insert(txtIl.Value);
            Response.Redirect("~/management/anaYonetim/bolgeYonetimi/bolge.aspx?page=listele");
        }

        protected void Vazgec_Click(object sender, EventArgs e)
        {

        }
    }
}