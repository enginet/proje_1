using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PL
{
    public partial class odeme : System.Web.UI.Page
    {
        public string mesaj = "";

        public JArray objDizi = new JArray();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["unique-site-user"] != null)
            {
                if (!IsPostBack)
                {
                    dopingKategoriBll dkb = new dopingKategoriBll();
                    objDizi = (JArray)Session["dp"];
                    if (Convert.ToBoolean(Session["ilanUcretliMi"]) == false && objDizi.Count <= 0)
                    {
                        Response.Redirect("~/ilan-tamam.aspx");
                    }
                    else
                    {
                        odemeRepeater.DataSource = objDizi.ToList();
                        odemeRepeater.DataBind();
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script language='javascript'>hesapla();</script>", false);
                }
            }
            else
            {
                Response.Redirect("~/giris-yap.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ilan-tamam.aspx");
        }

        public string odemeTipDondur(int id)
        {
            if (id == 1)
            {
                return "Kredi Kartı";
            }
            else if (id == 2)
            {
                return "Mobil Ödeme";
            }
            else
            {
                return "Eft & Havale";
            }
        }

        protected void odemeRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Sil" && e.CommandArgument.ToString() != "")
            {
                odemeBll odmB = new odemeBll();
                odmB.delete(Convert.ToInt32(e.CommandArgument));
                JArray objDizi2 = ((JArray)Session["dp"]);

                for (int i = 0; i < objDizi2.Count; i++)
                {
                    if (objDizi2[i]["odemeId"].ToString() == e.CommandArgument.ToString())
                    {
                        objDizi2[i].Remove();
                        break;
                    }
                }
                Session["dp"] = objDizi2;
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}