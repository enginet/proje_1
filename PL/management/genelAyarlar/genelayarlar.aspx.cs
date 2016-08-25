using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PL.management.genelAyarlar
{
    public partial class genelayarlar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["page"] == "sanalposayar")
            {
                PlaceHolder1.Controls.Add(Page.LoadControl("~/management/genelAyarlar/sanalposayar.ascx"));
            }

            if (Request.QueryString["page"] == "dopingucretayar")
            {
                PlaceHolder1.Controls.Add(Page.LoadControl("~/management/genelAyarlar/dopingucretayar.ascx"));
            }

            if (Request.QueryString["page"] == "sanalposduzenle")
            {
                PlaceHolder1.Controls.Add(Page.LoadControl("~/management/genelAyarlar/sanalposduzenle.ascx"));
            }

            if (Request.QueryString["page"] == "ilan-ucretleri")
            {
                PlaceHolder1.Controls.Add(Page.LoadControl("~/management/genelAyarlar/ilan-ucretleri.ascx"));
            }

            if (Request.QueryString["page"] == "doping-ucretleri")
            {
                PlaceHolder1.Controls.Add(Page.LoadControl("~/management/genelAyarlar/doping-ucretleri.ascx"));
            }

            if (Request.QueryString["page"] == "ilanucretayar")
            {
                PlaceHolder1.Controls.Add(Page.LoadControl("~/management/genelAyarlar/ilanucretayar.ascx"));
            }

            if (Request.QueryString["page"] == "magazaucretayar")
            {
                PlaceHolder1.Controls.Add(Page.LoadControl("~/management/genelAyarlar/magazaucretayar.ascx"));
            }
        }
    }
}