﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL.management.anaYonetim.ozelAlanYonetimi
{
    public partial class alanDuzenle : System.Web.UI.UserControl
    {
        ozellikBll ozellik = new ozellikBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            drpOzelAlan.DataSource = ozellik.selectList(1);
            drpOzelAlan.DataTextField = "ozellikAdi";
            drpOzelAlan.DataValueField = "ozellikId";
            drpOzelAlan.DataBind();
        }
    }
}