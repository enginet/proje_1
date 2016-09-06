using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

namespace DAL
{
    public class fotograf
    {
        public static void yukle(HttpPostedFile img, int boyut,string dosyaAdi, string ilanNo,int islemNo)
        {
            System.Drawing.Image orjinalFoto = null;
            orjinalFoto = System.Drawing.Image.FromStream(img.InputStream);
            KucukBoyut(orjinalFoto, boyut, dosyaAdi,ilanNo,islemNo);
        }
        protected static void KucukBoyut(System.Drawing.Image orjinalFoto, int boyut, string dosyaAdi,string ilnNo,int islem)
        {
            System.Drawing.Bitmap islenmisFotograf = null;
            System.Drawing.Graphics grafik = null;

            int hedefGenislik = boyut;
            int hedefYukseklik = boyut;
            int new_width, new_height;

            new_height = (int)Math.Round(((float)orjinalFoto.Height * (float)boyut) / (float)orjinalFoto.Width);
            new_width = hedefGenislik;
            hedefYukseklik = new_height;
            new_width = new_width > hedefGenislik ? hedefGenislik : new_width;
            new_height = new_height > hedefYukseklik ? hedefYukseklik : new_height;

            islenmisFotograf = new System.Drawing.Bitmap(hedefGenislik, hedefYukseklik);
            grafik = System.Drawing.Graphics.FromImage(islenmisFotograf);
            grafik.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), new System.Drawing.Rectangle(0, 0, hedefGenislik, hedefYukseklik));
            int paste_x = (hedefGenislik - new_width) / 2;
            int paste_y = (hedefYukseklik - new_height) / 2;

            grafik.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            grafik.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            grafik.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;

            System.Drawing.Imaging.ImageCodecInfo codec = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()[1];
            System.Drawing.Imaging.EncoderParameters eParams = new System.Drawing.Imaging.EncoderParameters(1);
            eParams.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 95L);

            grafik.DrawImage(orjinalFoto, paste_x, paste_y, new_width, new_height);

            if(islem==1)
            {
                string watermark = "kralilan.com";

                Graphics graf = Graphics.FromImage(islenmisFotograf);
                //ilan numarası yazdırma işlemi yapılıyor.
                graf.DrawString(ilnNo, new Font("Century Gothic", 10), SystemBrushes.WindowText, new Point(5, 5));
                //resmin şeffaflık (alpha) değeri ve renk değerleri belirleniyor.
                SolidBrush firca = new SolidBrush(Color.FromArgb(45, 0, 0, 0));
                //resmin köşegen uzunluğu pisagor denklemiyle hesaplanıyor.
                double kosegen = Math.Sqrt(islenmisFotograf.Width * islenmisFotograf.Width + islenmisFotograf.Height * islenmisFotograf.Height);
                Rectangle kutu = new Rectangle();
                //bu 3 satırda ise yazının başlama noktası (x,y koordinatları) ve ayrıca font boyutu ayarlanıyor.
                //bunun için aşağıdaki gibi yaklaşık değerler kullandım 1,3..... 1,6.... gibi siz bu rakamlarla oynama yapabilirsiniz.
                kutu.X = (int)(kosegen / 4);
                float yazi = (float)(kosegen / watermark.Length * 0.8);
                kutu.Y = -(int)(yazi / 0.8);
                Font fnt = new Font("Century Gothic", yazi, FontStyle.Bold);//font tipi ve boyutu       
                                                                            //can alıcı noktamız burası
                                                                            //burada köşegen eğimini aşağıdaki formülle hesaplıyoruz.
                float egim = (float)(Math.Atan2(islenmisFotograf.Height, islenmisFotograf.Width) * 180 / System.Math.PI);
                graf.RotateTransform(egim);
                StringFormat sf = new StringFormat();
                graf.DrawString(watermark, fnt, firca, kutu, sf);

                islenmisFotograf.Save(HttpContext.Current.Server.MapPath("/upload/ilan/" + dosyaAdi));
            }
            else
            {
                islenmisFotograf.Save(HttpContext.Current.Server.MapPath("/upload/reklam/" + dosyaAdi));
            }
        }
    }
}
