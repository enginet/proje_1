﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL
{
    public partial class eposta_aktivasyon : System.Web.UI.Page
    {
        guvenlikKodlariBll guvenlikb = new guvenlikKodlariBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(guvenlikb.search(Request.QueryString["act"])!=null)
            {
                Response.Redirect("~/yeni-sifre.aspx?act="+ Request.QueryString["act"]);
                icon.Attributes["class"] = "fa fa-check ln-shadow-logo shape-0";
            }
            else
            {
                icon.Attributes["class"] = "fa fa-times ln-shadow-logo shape-0";
            }
        }

    }
}