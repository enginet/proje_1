using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace PL.profil
{
    public partial class bildirim_oku : System.Web.UI.UserControl
    {
        bildirimBll bildirimb = new bildirimBll();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Request.QueryString["not"] != null)
            {
                DAL.bildirimler _bildirim = bildirimb.search(Convert.ToInt32(Request.QueryString["not"]));
                baslik.InnerText = _bildirim.konu;
                tarih.InnerHtml = String.Format("{0:d-MMMM-yyyy}", _bildirim.tarih.ToString());       
                mesaj.InnerHtml = _bildirim.mesaj;

            }

        }
    }
}