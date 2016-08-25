using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Collections;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Drawing;

namespace DAL
{
    public class toolkit
    {
        public static string Number_Remover(string numara)
        {
            return numara = numara.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");
        }

        public static bool sms_gonder(string mesaj, List<string> numaralar)
        {
            UserModel model = new UserModel();
            model.username = "05325070367";
            model.password = "3284310";
            string json = JsonConvert.SerializeObject(model);
            string result = sahinHaberlesme.apipost("/core/loginUser", json);
            JObject serverresponse = JObject.Parse(result);
            string status = (string)serverresponse["status"];
            string apikey = (string)serverresponse["token"];
            string result2 = "";

            if (status == "success")
            {
                sahinHaberlesme.apikey = apikey;

                result2 = sahinHaberlesme.singlesmsgonder("NETTEILANVR", numaralar, mesaj, sahinHaberlesme.simdi(), "tr", "0");
                JObject jObject = JObject.Parse(result2);

                if (jObject["status"].ToString() == "success")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static Bitmap pictureWatermark(HttpPostedFile Dosya, string yol, string watermark, string waternumber)
        {
            Bitmap resim = new Bitmap(Dosya.InputStream);

            if (!string.IsNullOrEmpty(watermark))
            {
                Graphics graf = Graphics.FromImage(resim);
                //ilan numarası yazdırma işlemi yapılıyor.
                graf.DrawString(waternumber, new Font("Century Gothic", 10), SystemBrushes.WindowText, new Point(5, 5));
                //resmin şeffaflık (alpha) değeri ve renk değerleri belirleniyor.
                SolidBrush firca = new SolidBrush(Color.FromArgb(45, 0, 0, 0));
                //resmin köşegen uzunluğu pisagor denklemiyle hesaplanıyor.
                double kosegen = Math.Sqrt(resim.Width * resim.Width + resim.Height * resim.Height);
                Rectangle kutu = new Rectangle();
                //bu 3 satırda ise yazının başlama noktası (x,y koordinatları) ve ayrıca font boyutu ayarlanıyor.
                //bunun için aşağıdaki gibi yaklaşık değerler kullandım 1,3..... 1,6.... gibi siz bu rakamlarla oynama yapabilirsiniz.
                kutu.X = (int)(kosegen / 4);
                float yazi = (float)(kosegen / watermark.Length * 0.8);
                kutu.Y = -(int)(yazi / 0.8);
                Font fnt = new Font("Century Gothic", yazi, FontStyle.Bold);//font tipi ve boyutu       
                                                                            //can alıcı noktamız burası
                                                                            //burada köşegen eğimini aşağıdaki formülle hesaplıyoruz.
                float egim = (float)(Math.Atan2(resim.Height, resim.Width) * 180 / System.Math.PI);
                graf.RotateTransform(egim);
                StringFormat sf = new StringFormat();
                graf.DrawString(watermark, fnt, firca, kutu, sf);
            }

            return resim;

        }

        public static string fiyat_Tur(object _income)
        {

            if (Convert.ToInt32(_income) == 1)
            {
                return " &#x20BA;";
            }
            else if (Convert.ToInt32(_income) == 2)
            {
                return " $";
            }
            else
            {
                return " €";
            }

        }
        public static string guvenlik_kodu()
        {
            ArrayList secilenler = new ArrayList(); // seçilen rakamlar bu diziye aktarılacak ve bir sonraki seçimde burdan kontrol edilecek.

            bool kontrol = true; // eğer kod gerçekleşmişse döngüyü kırmak için kullanılır.

            Random rnd = new Random();

            string kod = ""; // geri döndürülecek Kod

            while (kontrol)
            {
                if (kod.Length < 6) // üretilecek kodun 6 basamaklı olduğu kontrol ediliyor
                {
                    int sayi = rnd.Next(10); // 0 ile 10 arasında bir sayı üretiliyor
                    if (secilenler.IndexOf(sayi) < 0) // sayının önceden üretilip üretilmediği kontrol ediliyor.
                    {
                        kod += sayi.ToString(); // eğer üretilmediyse geri döndürülecek kod içerisine alınıyor.
                        secilenler.Add(sayi); // sayı önceden üretilen sayılar içerisine atılıyor
                    }
                }
                else
                {
                    kontrol = false; // eğer kodun boyutu 6 veya daha fazlaysa döngüyü kırıyor.
                }
            }

            return kod;
        }

        public static string UrlDonustur(object Yazi)
        {
            try
            {
                string strSonuc = Yazi.ToString().Trim();

                strSonuc = strSonuc.Replace("-", "+");
                strSonuc = strSonuc.Replace(" ", "+");

                strSonuc = strSonuc.Replace("ç", "c");
                strSonuc = strSonuc.Replace("Ç", "C");

                strSonuc = strSonuc.Replace("ğ", "g");
                strSonuc = strSonuc.Replace("Ğ", "G");

                strSonuc = strSonuc.Replace("ı", "i");
                strSonuc = strSonuc.Replace("İ", "I");

                strSonuc = strSonuc.Replace("ö", "o");
                strSonuc = strSonuc.Replace("Ö", "O");

                strSonuc = strSonuc.Replace("ş", "s");
                strSonuc = strSonuc.Replace("Ş", "S");

                strSonuc = strSonuc.Replace("ü", "u");
                strSonuc = strSonuc.Replace("Ü", "U");

                strSonuc = strSonuc.Trim();
                strSonuc = new System.Text.RegularExpressions.Regex("[^a-zA-Z0-9+]").Replace(strSonuc, "");
                strSonuc = strSonuc.Trim();
                strSonuc = strSonuc.Replace("+", "-");
                return strSonuc.ToLower();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string donustur(object _income)
        {
            if (_income != null)
            {

                if (_income.ToString() == "1")
                {
                    return "Satılık";
                }
                else if (_income.ToString() == "2")
                {
                    return "Kiralık";
                }
                else if (_income.ToString() == "3")
                {
                    return "Günlük Kiralık";
                }
                else if (_income.ToString() == "4")
                {
                    return "Devren";
                }
                else
                {
                    return "Devren Kiralık";
                }
            }
            else
            {
                return "";
            }
        }


        // Veritabanındaki birleştirilmiş isimleri parçalayıp geri döndermek için
        public static string[] isimDondur(string _income)
        {
            string[] dondur = new string[2];
            string[] dizi = _income.Split(' ');

            dondur[0] = "";
            dondur[1] = dizi[dizi.Length - 1]; // soyismi ataması yapıldı

            if (dizi.Length > 2)
            {
                for (int i = 0; i < dizi.Length - 1; i++)
                {
                    dondur[0] += " " + dizi[i];
                }
            }
            else
            {
                dondur[0] = dizi[0];
            }

            return dondur;
        }

        public static void HTML_Mail_Sender(params object[] _income)
        {

            MailMessage Msg = new MailMessage();
            Msg.From = new MailAddress("clubwomanizer588@gmail.com");
            Msg.To.Add(_income[0].ToString());//Mesajın gideceği müşterinin mail adresi Sayfa yüklenirken lblmail a atmıştık oradan çekiyoruz.
            StreamReader reader = new StreamReader(System.Web.Hosting.HostingEnvironment.MapPath(_income[1].ToString())); // Oluşturmuş olduğumuz Mail.html dosyanın yolu
            string readFile = reader.ReadToEnd();
            string StrContent = "";
            StrContent = readFile;
            //Burada html sayfada oluşturmuş olduğumuz [title],[mail] gibi alanları mail.aspx tarafında oluşturduğumuz lbltitle ve lblmail alanları ile eşleştirip değiştirmesini söylüyoruz.
            StrContent = StrContent.Replace("[title]", _income[3].ToString());
            StrContent = StrContent.Replace("[username]", _income[4].ToString());
            StrContent = StrContent.Replace("[info]", _income[5].ToString());
            StrContent = StrContent.Replace("[detail]", _income[6].ToString());
            Msg.Subject = _income[2].ToString();//mesaj konumuz yine labellardan çektiriyoruz.
            Msg.Body = StrContent.ToString();
            Msg.IsBodyHtml = true;//mail gövdesinde html e izin veriyoruz.
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            NetworkCred.UserName = "clubwomanizer588@gmail.com";
            NetworkCred.Password = "q1w2e3r4t5y6u7";
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587; //Port
            smtp.EnableSsl = true;
            smtp.Send(Msg);

        }
        public static DateTime tarihDondur(string tarih)
        {
            tarih = tarih.Replace("/", "-");
            return Convert.ToDateTime(tarih);
        }

        public static string HTMLTag_Remover(string _income)
        {
            //_income = System.Net.WebUtility.HtmlDecode(_income);
            //_income = Regex.Replace(_income, @"<!--?\w+((\s+\w+(\s*=\s*(?:"".*?""|'.*?'|[^'""-->\s]+))?)+\s*|\s*)/?>", string.Empty);
            if (_income.Length > 50)
            {
                _income = _income.Substring(0, 50);
            }

            return _income;
        }

        public static byte[] byte_Converter(string _income)
        {

            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            return ByteConverter.GetBytes(_income);

        }

        public static byte[] Byte8(string _income)
        {
            char[] arrayChar = _income.ToCharArray();
            byte[] arrayByte = new byte[arrayChar.Length];
            for (int i = 0; i < arrayByte.Length; i++)
            {
                arrayByte[i] = Convert.ToByte(arrayChar[i]);
            }
            return arrayByte;
        }

        public static string SHA512_Encryption(string _income)
        {
            SHA512Managed sifre = new SHA512Managed();
            byte[] arrPass = byte_Converter(_income);
            byte[] aryHash = sifre.ComputeHash(arrPass);
            return BitConverter.ToString(aryHash);
        }
    }


}

