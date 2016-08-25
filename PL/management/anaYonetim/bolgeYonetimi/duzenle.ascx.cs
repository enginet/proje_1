using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace PL.management.anaYonetim.bolgeYonetimi
{
    public partial class ilduzenle : System.Web.UI.UserControl
    {
        ilBll il = new ilBll();
        kullaniciBll kullanicib = new kullaniciBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                iller _il = il.search(Convert.ToInt32(Request.QueryString["ilId"]));
                txtIl.Value = _il.ilAdi;

                    onlineRepeater.DataSource = kullanicib.list(4);
                    onlineRepeater.DataBind();          
            }
        }

        protected void Kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                il.update(Request.QueryString["ilId"], txtIl.Value);
                Response.Redirect("~/management/anaYonetim/bolgeYonetimi/bolge.aspx?page=listele");
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void Vazgeç_Click(object sender, EventArgs e)
        {

        }
    }
}