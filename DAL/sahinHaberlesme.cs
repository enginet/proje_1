using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserModel
    {
        private string _Username;

        public string username
        {
            get { return _Username; }
            set { _Username = value; }
        }
        private string _Password;

        public string password
        {
            get { return _Password; }
            set { _Password = value; }
        }

    }

    public class SingleSms
    {
        public string apikey { get; set; }
        public string type = "single";
        public string orjin { get; set; }
        public string gonderimzamani { get; set; }
        public string dil { get; set; }
        public string flashsms { get; set; }
        public string mesajmetni { get; set; }
        public string[] numaralar { get; set; }
    }

  public class apimodel
    {
        public string apikey { get; set; }
    }

   public static  class sahinHaberlesme
    {

        public static string getbasliklar()
        {
            apimodel post = new apimodel();
            post.apikey = apikey;
            string json = JsonConvert.SerializeObject(apikey);

            string result = apipost("/settings/getOrgins", json);
            return result;
        }
        public static string getkontur()
        {
            apimodel post = new apimodel();
            post.apikey = apikey;
            string json = JsonConvert.SerializeObject(apikey);

            string result = apipost("/reports/getcredit", json);
            return result;
        }
        public static string apipost(string Url, string Json)
        {
            string result = "";
            string _Url = "http://apiv5.basscell.com" + Url;
            using (WebClient wc = new WebClient())
            {
                result = wc.UploadString(_Url, Json);
            }
            return result;

        }


        private static string _apikey;

        public static string simdi()
        {
            DateTime theDate = DateTime.Now;
            return theDate.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public static string apikey
        {
            get { return _apikey; }
            set { _apikey = value; }
        }

        public static string singlesmsgonder(string orjin, List<string> numaralar, string mesajmetni, string gonderimzamani, string dil, string flashsms)
        {
            SingleSms singlesms = new SingleSms();
            singlesms.orjin = orjin;
            singlesms.mesajmetni = mesajmetni;
            singlesms.gonderimzamani = gonderimzamani;
            singlesms.flashsms = "0";
            singlesms.dil = dil;
            singlesms.numaralar = numaralar.ToArray();
            singlesms.apikey = apikey;
            string json = JsonConvert.SerializeObject(singlesms);
            string result = apipost("/sms/sendsms", json);
            return result;
        }

    }
}
