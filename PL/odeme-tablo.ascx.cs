using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using Newtonsoft.Json.Linq;

namespace PL
{
    public partial class odeme_tablo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
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
    }
}