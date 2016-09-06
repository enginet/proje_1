using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Linq.Expressions;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BLL
{
    public class filtreBll
    {
        ilanDataContext idc = new ilanDataContext();
        public ArrayList haritaFiltre(params object[] _income)
        {
            // 1. , 2. ve 3. parametreler il ilçe mahalle id değerleridir.
            // 4. parametre kategoriId değeridir.
            // 5. parametre ilanturid değeridir.
            // 6. parametre kimdenid değeridir.
            // 7. fiyat
            // 8. parametre ilan tarihi parametresidir.
            // 9. parametre dinamik olarak gelen seçilebilir filtreleme parametreleridir.
            // 10. parametre dinamik olarak gelen girilebilir filtreleme parametreleridir.
            // 11. parametre filtrelenen veriler arasında arama yapılabilmesi için (ilan numarası ve ilan başlığında) gelen değerdir.


            // kimden, metrekare ve koordinat
            //var query = from sio in idc.secilebilirIlanOzelliks
            //            join i in idc.ilans on sio.ilanId equals i.ilanId
            //            where i.pasifMi == false & i.onay == 1 & i.silindiMi == false & i.kategoriId == Convert.ToInt32(_income[3])


            JArray objDizi = new JArray();
            var query = from i in idc.ilans.Where(i => i.kategoriId == Convert.ToInt32(_income[3])).Where(i => i.pasifMi == false).Where(i => i.onay == 1).Where(i => i.silindiMi == false)
                            //join sio in idc.secilebilirIlanOzelliks
                            //on i.ilanId equals sio.ilanId

                            //join gio in idc.girilenIlanOzelliks on i.ilanId equals gio.ilanId
                        group new { i } by new
                        {
                            i.ilanId,
                            i.baslik,
                            i.fiyat,
                            i.ilanResims.Where(r => r.seciliMi == true).FirstOrDefault().resim,
                            i.baslangicTarihi,
                            i.ilanTurId,
                            i.iller.ilAdi,
                            i.ilceler.ilceAdi,
                            i.mahalleler.mahalleAdi,
                            i.ilId,
                            i.ilceId,
                            i.mahalleId,
                            i.magaza,
                            i.magazaId
                        }
                        into gro
                        select new
                        {
                            gro.Key.ilanId,
                            gro.Key.baslik,
                            gro.Key.fiyat,
                            gro.Key.resim,
                            gro.Key.baslangicTarihi,
                            gro.Key.ilanTurId,
                            gro.Key.ilAdi,
                            gro.Key.ilceAdi,
                            gro.Key.mahalleAdi,
                            gro.Key.ilId,
                            gro.Key.ilceId,
                            gro.Key.mahalleId,
                            gro.Key.magazaId,
                            gro.Key.magaza.magazaTur.turId
                        };

            if (_income[7].ToString() != "")
            {
                if (_income[7].ToString() == "1")
                {
                    query = query.Where(q => q.baslangicTarihi >= DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0, 0)));
                }
                else if (_income[7].ToString() == "3")
                {
                    query = query.Where(q => q.baslangicTarihi >= DateTime.Now.Subtract(new TimeSpan(3, 0, 0, 0, 0)));
                }
                else if (_income[7].ToString() == "7")
                {
                    query = query.Where(q => q.baslangicTarihi >= DateTime.Now.Subtract(new TimeSpan(7, 0, 0, 0, 0)));
                }
                else if (_income[7].ToString() == "15")
                {
                    query = query.Where(q => q.baslangicTarihi >= DateTime.Now.Subtract(new TimeSpan(15, 0, 0, 0, 0)));
                }
                else
                {
                    query = query.Where(q => q.baslangicTarihi >= DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0, 0)));
                }
            }

            // ilk önce il ilçe ve mahalle ye göre filtreleme yapılır.
            if (_income[0].ToString() != "") // ilin boş olup olmadığı kontrol ediliyor
            {
                query = query.Where(q => q.ilId == Convert.ToUInt32(_income[0]));
            }
            if (_income[1].ToString() != "")
            {
                query = query.Where(q => q.ilceId == Convert.ToInt32(_income[1]));
            }
            if (_income[2].ToString() != "")
            {
                query = query.Where(q => q.mahalleId == Convert.ToUInt32(_income[2]));
            }


            // ilan türüne göre filtreleme yapılır
            if (_income[4].ToString() != "")
            {
                query = query.Where(q => q.ilanTurId == Convert.ToInt32(_income[4]));
            }

            if (_income[5].ToString() != "")
            {
                if (Convert.ToInt32(_income[5]) != 1)
                {
                    query = query.Where(q => q.turId == Convert.ToInt32(_income[5]));
                }
                else
                {
                    query = query.Where(q => q.magazaId == null);
                }
            }

            ArrayList fiyat = new ArrayList();
            fiyat = (ArrayList)_income[6];

            if (fiyat.Count != 0)
            {
                if (fiyat[1].ToString() != "" && fiyat[0].ToString() != "")
                {
                    query = query.Where(q => q.fiyat >= Convert.ToDouble(fiyat[0]) & q.fiyat <= Convert.ToDouble(fiyat[1]));
                }
                if (fiyat[1].ToString() == "" && fiyat[0].ToString() != "")
                {
                    query = query.Where(q => q.fiyat >= Convert.ToDouble(fiyat[0]));
                }
                if (fiyat[1].ToString() != "" && fiyat[0].ToString() == "")
                {
                    query = query.Where(q => q.fiyat <= Convert.ToDouble(fiyat[1]));
                }
            }
            ArrayList secilebilirDizi = new ArrayList();
            secilebilirDizi = (ArrayList)_income[8];

            ArrayList girilebilirDizi = new ArrayList();
            girilebilirDizi = (ArrayList)_income[9];

            var secilebilirTablo = from q in query
                                   join sio in idc.secilebilirIlanOzelliks
                                   on q.ilanId equals sio.ilanId
                                   select new
                                   {
                                       q.ilanId,
                                       q.baslik,
                                       q.fiyat,
                                       q.resim,
                                       q.baslangicTarihi,
                                       q.ilanTurId,
                                       q.ilAdi,
                                       q.ilceAdi,
                                       q.mahalleAdi,
                                       sio.ozellikDegerId,
                                       q.ilId,
                                       q.ilceId,
                                       q.mahalleId,
                                       q.magazaId,
                                       q.turId
                                   };

            var secilebilirSonuc = secilebilirTablo.Where(q => q.ilanId == -1).ToList();
            if (secilebilirDizi.Count > 1)
            {
                var query2 = secilebilirTablo.Where(sio => sio.ozellikDegerId == Convert.ToInt32(secilebilirDizi[0])).ToList();

                var swap = secilebilirTablo.Where(sio => sio.ozellikDegerId == -1).ToList();
                ArrayList silinecekler = new ArrayList();
                for (int k = 1; k < secilebilirDizi.Count; k++)
                {
                    for (int l = 0; l < query2.Count; l++)
                    {
                        swap = secilebilirTablo.Where(t => t.ilanId == Convert.ToInt32(query2.ElementAt(l).ilanId) & t.ozellikDegerId == Convert.ToInt32(secilebilirDizi[k])).ToList();
                        if (swap.Count != 0)
                        {
                            var allItem = new
                            {
                                ilanId = swap.ElementAt(0).ilanId,
                                baslik = swap.ElementAt(0).baslik,
                                fiyat = swap.ElementAt(0).fiyat,
                                resim = swap.ElementAt(0).resim,
                                baslangicTarihi = swap.ElementAt(0).baslangicTarihi,
                                ilanTurId = swap.ElementAt(0).ilanTurId,
                                ilAdi = swap.ElementAt(0).ilAdi,
                                ilceAdi = swap.ElementAt(0).ilceAdi,
                                mahalleAdi = swap.ElementAt(0).mahalleAdi,
                                ozellikDegerId = swap.ElementAt(0).ozellikDegerId,
                                ilId = swap.ElementAt(0).ilId,
                                ilceId = swap.ElementAt(0).ilceId,
                                mahalleId = swap.ElementAt(0).mahalleId,
                                magazaId = swap.ElementAt(0).magazaId,
                                turId = swap.ElementAt(0).turId

                            };

                            var kontrol = secilebilirSonuc.Where(q => q.ilanId == Convert.ToInt32(swap.ElementAt(0).ilanId)).ToList();
                            if (kontrol.Count == 0)
                            {
                                secilebilirSonuc.Add(allItem);
                            }
                        }
                        else // eğer o ilan id ye ait koşul sağlanmadıysa o ilan query2 tablosundan silinecek.
                        {
                            silinecekler.Add(query2.ElementAt(l).ilanId);
                        }
                    }
                }
                for (int m = 0; m < silinecekler.Count; m++)
                {
                    secilebilirSonuc.RemoveAll(q => q.ilanId == Convert.ToInt32(silinecekler[m]));
                }
                silinecekler.Clear();
            }
            else if (secilebilirDizi.Count == 0)
            {
                secilebilirSonuc = secilebilirTablo.ToList();
            }
            else
            {
                secilebilirSonuc = secilebilirTablo.Where(q => q.ozellikDegerId == Convert.ToInt32(secilebilirDizi[0])).ToList();
            }

            if (secilebilirSonuc.Count > 0)
            {
                var araTablo = from ss in secilebilirSonuc
                               join gio in idc.girilenIlanOzelliks on ss.ilanId equals gio.ilanId
                               select new
                               {
                                   ss.ilanId,
                                   ss.baslik,
                                   ss.fiyat,
                                   ss.resim,
                                   ss.baslangicTarihi,
                                   ss.ilanTurId,
                                   ss.ilAdi,
                                   ss.ilceAdi,
                                   ss.mahalleAdi,
                                   ss.ozellikDegerId,
                                   ss.ilId,
                                   ss.ilceId,
                                   ss.mahalleId,
                                   ss.magazaId,
                                   ss.turId,
                                   gio.ozellikId,
                                   gio.deger
                               };


                var girilebilirSonuc = araTablo.Where(q => q.deger == "").ToList();
                if (girilebilirDizi.Count > 0)
                {
                    if (girilebilirDizi.Count == 1)
                    {
                        JObject dizi = JObject.FromObject(girilebilirDizi[0]);
                        var query2 = araTablo.Where(q => q.ilanId == -1).ToList();
                        if (dizi["minDeger"].ToString() != "-1" & dizi["maxDeger"].ToString() != "-1")
                        {
                            query2 = araTablo.Where(q => q.ozellikId == Convert.ToInt32(dizi["ozellikId"])).Where(q => Convert.ToInt32(q.deger) <= Convert.ToInt32(dizi["maxDeger"]) & Convert.ToInt32(q.deger) >= Convert.ToInt32(dizi["minDeger"])).ToList();
                        }
                        if (dizi["minDeger"].ToString() != "-1" & dizi["maxDeger"].ToString() == "-1")
                        {
                            query2 = araTablo.Where(q => q.ozellikId == Convert.ToInt32(dizi["ozellikId"])).Where(q => Convert.ToInt32(q.deger) >= Convert.ToInt32(dizi["minDeger"])).ToList();
                        }
                        if (dizi["minDeger"].ToString() == "-1" & dizi["maxDeger"].ToString() != "-1")
                        {
                            query2 = araTablo.Where(q => q.ozellikId == Convert.ToInt32(dizi["ozellikId"])).Where(q => Convert.ToInt32(q.deger) <= Convert.ToInt32(dizi["maxDeger"])).ToList();
                        }

                        if (query2.Count != 0)
                        {
                            for (int i = 0; i < query2.Count; i++)
                            {
                                var swap = araTablo.Where(q => q.ilanId == query2.ElementAt(i).ilanId).FirstOrDefault();
                                var allItem = new
                                {
                                    ilanId = swap.ilanId,
                                    baslik = swap.baslik,
                                    fiyat = swap.fiyat,
                                    resim = swap.resim,
                                    baslangicTarihi = swap.baslangicTarihi,
                                    ilanTurId = swap.ilanTurId,
                                    ilAdi = swap.ilAdi,
                                    ilceAdi = swap.ilceAdi,
                                    mahalleAdi = swap.mahalleAdi,
                                    ozellikDegerId = swap.ozellikDegerId,
                                    ilId = swap.ilId,
                                    ilceId = swap.ilceId,
                                    mahalleId = swap.mahalleId,
                                    magazaId = swap.magazaId,
                                    turId = swap.turId,
                                    ozellikId = swap.ozellikId,
                                    deger = swap.deger

                                };
                                var kontrol = girilebilirSonuc.Where(q => q.ilanId == Convert.ToInt32(swap.ilanId)).ToList();
                                if (kontrol.Count == 0)
                                {
                                    girilebilirSonuc.Add(allItem);
                                }
                            }
                        }
                    }
                    else
                    {
                        JObject objTest = JObject.FromObject(girilebilirDizi[0]);

                        var query2 = araTablo.Where(q => q.ozellikId == -1).ToList();

                        if (objTest["minDeger"].ToString() != "-1" && objTest["maxDeger"].ToString() != "-1")
                        {
                            query2 = araTablo.Where(q => q.ozellikId == Convert.ToInt32(objTest["ozellikId"])).Where(q => Convert.ToInt32(q.deger) >= Convert.ToInt32(objTest["minDeger"]) && Convert.ToInt32(q.deger) <= Convert.ToInt32(objTest["maxDeger"])).ToList();
                        }
                        else if (objTest["minDeger"].ToString() != "-1" && objTest["maxDeger"].ToString() == "-1")
                        {
                            query2 = araTablo.Where(q => q.ozellikId == Convert.ToInt32(objTest["ozellikId"])).Where(q => Convert.ToInt32(q.deger) >= Convert.ToInt32(objTest["minDeger"])).ToList();
                        }
                        else if (objTest["minDeger"].ToString() == "-1" && objTest["maxDeger"].ToString() != "-1")
                        {
                            query2 = araTablo.Where(q => q.ozellikId == Convert.ToInt32(objTest["ozellikId"])).Where(q => Convert.ToInt32(q.deger) <= Convert.ToInt32(objTest["maxDeger"])).ToList();
                        }

                        var swap = araTablo.Where(sio => sio.ozellikDegerId == -1).ToList();
                        ArrayList silinecekler = new ArrayList();
                        for (int k = 1; k < girilebilirDizi.Count; k++)
                        {
                            objTest = JObject.FromObject(girilebilirDizi[k]);
                            for (int l = 0; l < query2.Count; l++)
                            {
                                if (objTest["minDeger"].ToString() != "-1" && objTest["maxDeger"].ToString() != "-1")
                                {
                                    swap = araTablo.Where(q => q.ilanId == Convert.ToInt32(query2.ElementAt(l).ilanId) && q.ozellikId == Convert.ToInt32(objTest["ozellikId"])).Where(q => Convert.ToInt32(q.deger) >= Convert.ToInt32(objTest["minDeger"]) && Convert.ToInt32(q.deger) <= Convert.ToInt32(objTest["maxDeger"])).ToList();
                                }
                                else if (objTest["minDeger"].ToString() != "-1" && objTest["maxDeger"].ToString() == "-1")
                                {
                                    swap = araTablo.Where(q => q.ilanId == Convert.ToInt32(query2.ElementAt(l).ilanId) && q.ozellikId == Convert.ToInt32(objTest["ozellikId"])).Where(q => Convert.ToInt32(q.deger) >= Convert.ToInt32(objTest["minDeger"])).ToList();
                                }
                                else if (objTest["minDeger"].ToString() == "-1" && objTest["maxDeger"].ToString() != "-1")
                                {
                                    swap = araTablo.Where(q => q.ilanId == Convert.ToInt32(query2.ElementAt(l).ilanId) && q.ozellikId == Convert.ToInt32(objTest["ozellikId"])).Where(q => Convert.ToInt32(q.deger) <= Convert.ToInt32(objTest["maxDeger"])).ToList();
                                }

                                if (swap.Count != 0)
                                {
                                    var allItem = new
                                    {
                                        ilanId = swap.ElementAt(0).ilanId,
                                        baslik = swap.ElementAt(0).baslik,
                                        fiyat = swap.ElementAt(0).fiyat,
                                        resim = swap.ElementAt(0).resim,
                                        baslangicTarihi = swap.ElementAt(0).baslangicTarihi,
                                        ilanTurId = swap.ElementAt(0).ilanTurId,
                                        ilAdi = swap.ElementAt(0).ilAdi,
                                        ilceAdi = swap.ElementAt(0).ilceAdi,
                                        mahalleAdi = swap.ElementAt(0).mahalleAdi,
                                        ozellikDegerId = swap.ElementAt(0).ozellikDegerId,
                                        ilId = swap.ElementAt(0).ilId,
                                        ilceId = swap.ElementAt(0).ilceId,
                                        mahalleId = swap.ElementAt(0).mahalleId,
                                        magazaId = swap.ElementAt(0).magazaId,
                                        turId = swap.ElementAt(0).turId,
                                        ozellikId = query2.ElementAt(0).ozellikId,
                                        deger = query2.ElementAt(0).deger

                                    };
                                    var kontrol = girilebilirSonuc.Where(q => q.ilanId == Convert.ToInt32(swap.ElementAt(0).ilanId)).ToList();
                                    if (kontrol.Count == 0)
                                    {
                                        girilebilirSonuc.Add(allItem);
                                    }
                                }
                                else // eğer o ilan ıd ye ait koşu sağlanmadıysa o ilan tablodan silinecek.
                                {
                                    silinecekler.Add(query2.ElementAt(l).ilanId);
                                }
                            }
                        }

                        for (int m = 0; m < silinecekler.Count; m++)
                        {
                            secilebilirSonuc.RemoveAll(q => q.ilanId == Convert.ToInt32(silinecekler[m]));
                        }
                        silinecekler.Clear();
                    }
                }
                else // hiç bir aralıklı değer girilmemişse
                {
                    girilebilirSonuc = araTablo.ToList();
                }



                ArrayList dondur = new ArrayList();

                if (girilebilirSonuc.Count > 0)
                {
                    if (_income[10].ToString() != "")
                    {
                        int ilanNo;

                        try
                        {
                            ilanNo = Convert.ToInt32(_income[10]);
                        }
                        catch
                        {
                            ilanNo = 0;
                        }
                        if (ilanNo != 0)
                        {
                            var sonucIlanNo = girilebilirSonuc.Where(q => q.ilanId == ilanNo).First();
                            if (sonucIlanNo != null)
                            {
                                string ilan = @"{
                                                'ilanId':'" + sonucIlanNo.ilanId.ToString() + "'," +
                                                    "'baslik':'" + sonucIlanNo.baslik.ToString() + "'," +
                                                    "'fiyat':'" + sonucIlanNo.fiyat.ToString() + "'," +
                                                    "'baslangicTarihi':'" + sonucIlanNo.baslangicTarihi.ToString() + "'," +
                                                    "'ilanTurId':'" + sonucIlanNo.ilanTurId.ToString() + "'," +
                                                    "'kimden':'" + sonucIlanNo.turId.ToString() + "'," +
                                                    "'resim':'" + sonucIlanNo.resim.ToString() + "'," +
                                                    "'ilAdi':'" + sonucIlanNo.ilAdi.ToString() + "'," +
                                                    "'ilceAdi':'" + sonucIlanNo.ilceAdi.ToString() + "'," +
                                                    "'mahalleAdi':'" + sonucIlanNo.mahalleAdi.ToString() + "'," +
                                                    "'fiyatTurId':'1'," +
                                                    "'metreKare':'" + girilebilirSonuc.Where(q => q.ozellikId == 78 & q.ilanId == sonucIlanNo.ilanId).ElementAt(0).deger.ToString() + "'";
                                if (sonucIlanNo.magazaId != null)
                                {
                                    ilan += ",'magazaId':'" + sonucIlanNo.magazaId.ToString() + "'";

                                }
                                else
                                {
                                    ilan += ",'magazaId':'-1'";
                                }

                                if (girilebilirSonuc.Where(q => q.ozellikId == 71 & q.ilanId == sonucIlanNo.ilanId).ToList().Count > 0)
                                {
                                    ilan += ",'koordinat':" + girilebilirSonuc.Where(q => q.ozellikId == 71 & q.ilanId == sonucIlanNo.ilanId).ElementAt(0).deger;
                                }
                                else
                                {
                                    ilan += ",'koordinat':'-1'";
                                }
                                ilan += "}";
                                JObject obj = JObject.Parse(ilan);
                                dondur.Add(obj);
                            }
                            else
                            {
                                var sonuc = girilebilirSonuc.Where(q => q.baslik == _income[10].ToString()).GroupBy(a => a.ilanId).Select(grp => grp.First()).ToList();

                                if (sonuc.Count > 0)
                                {
                                    for (int i = 0; i < sonuc.Count; i++)
                                    {
                                        string ilan = @"{
                                                'ilanId':'" + sonuc.ElementAt(i).ilanId.ToString() + "'," +
                                                            "'baslik':'" + sonuc.ElementAt(i).baslik.ToString() + "'," +
                                                            "'fiyat':'" + sonuc.ElementAt(i).fiyat.ToString() + "'," +
                                                            "'baslangicTarihi':'" + sonuc.ElementAt(i).baslangicTarihi.ToString() + "'," +
                                                            "'ilanTurId':'" + sonuc.ElementAt(i).ilanTurId.ToString() + "'," +
                                                            "'kimden':'" + sonuc.ElementAt(i).turId.ToString() + "'," +
                                                            "'resim':'" + sonuc.ElementAt(i).resim.ToString() + "'," +
                                                            "'ilAdi':'" + sonuc.ElementAt(i).ilAdi.ToString() + "'," +
                                                            "'ilceAdi':'" + sonuc.ElementAt(i).ilceAdi.ToString() + "'," +
                                                            "'mahalleAdi':'" + sonuc.ElementAt(i).mahalleAdi.ToString() + "'," +
                                                            "'fiyatTurId':'1'," +
                                                            "'metreKare':'" + girilebilirSonuc.Where(q => q.ozellikId == 78 & q.ilanId == sonuc.ElementAt(i).ilanId).ElementAt(0).deger.ToString() + "'";
                                        if (sonuc.ElementAt(i).magazaId != null)
                                        {
                                            ilan += ",'magazaId':'" + sonuc.ElementAt(i).magazaId.ToString() + "'";

                                        }
                                        else
                                        {
                                            ilan += ",'magazaId':'-1'";
                                        }
                                        if (girilebilirSonuc.Where(q => q.ozellikId == 71 & q.ilanId == sonuc.ElementAt(i).ilanId).ToList().Count > 0)
                                        {
                                            ilan += ",'koordinat':" + girilebilirSonuc.Where(q => q.ozellikId == 71 & q.ilanId == sonuc.ElementAt(i).ilanId).ElementAt(0).deger;
                                        }
                                        else
                                        {
                                            ilan += ",'koordinat':'-1'";
                                        }
                                        ilan += "}";
                                        JObject obj = JObject.Parse(ilan);
                                        dondur.Add(obj);
                                    }
                                }
                            }
                        }
                        else
                        {
                            var sonuc = girilebilirSonuc.Where(q => q.baslik.Contains(_income[10].ToString())).GroupBy(a => a.ilanId).Select(grp => grp.First()).ToList();

                            if (sonuc.Count > 0)
                            {

                                for (int i = 0; i < sonuc.Count; i++)
                                {
                                    string ilan = @"{
                                                'ilanId':'" + sonuc.ElementAt(i).ilanId.ToString() + "'," +
                                                        "'baslik':'" + sonuc.ElementAt(i).baslik.ToString() + "'," +
                                                        "'fiyat':'" + sonuc.ElementAt(i).fiyat.ToString() + "'," +
                                                        "'baslangicTarihi':'" + sonuc.ElementAt(i).baslangicTarihi.ToString() + "'," +
                                                        "'ilanTurId':'" + sonuc.ElementAt(i).ilanTurId.ToString() + "'," +
                                                        "'kimden':'" + sonuc.ElementAt(i).turId.ToString() + "'," +
                                                        "'resim':'" + sonuc.ElementAt(i).resim.ToString() + "'," +
                                                        "'ilAdi':'" + sonuc.ElementAt(i).ilAdi.ToString() + "'," +
                                                        "'ilceAdi':'" + sonuc.ElementAt(i).ilceAdi.ToString() + "'," +
                                                        "'mahalleAdi':'" + sonuc.ElementAt(i).mahalleAdi.ToString() + "'," +
                                                        "'fiyatTurId':'1'," +
                                                        "'metreKare':'" + girilebilirSonuc.Where(q => q.ozellikId == 78 & q.ilanId == sonuc.ElementAt(i).ilanId).ElementAt(0).deger.ToString() + "'";
                                    if (sonuc.ElementAt(i).magazaId != null)
                                    {
                                        ilan += ",'magazaId':'" + sonuc.ElementAt(i).magazaId.ToString() + "'";
                                    }
                                    else
                                    {
                                        ilan += ",'magazaId':'-1'";
                                    }
                                    if (girilebilirSonuc.Where(q => q.ozellikId == 71 & q.ilanId == sonuc.ElementAt(i).ilanId).ToList().Count > 0)
                                    {
                                        ilan += ",'koordinat':" + girilebilirSonuc.Where(q => q.ozellikId == 71 & q.ilanId == sonuc.ElementAt(i).ilanId).ElementAt(0).deger;
                                    }
                                    else
                                    {
                                        ilan += ",'koordinat':'-1'";
                                    }
                                    ilan += "}";
                                    JObject obj = JObject.Parse(ilan);
                                    dondur.Add(obj);
                                }
                            }
                        }
                    }
                    else
                    {
                        var sonuc = girilebilirSonuc.GroupBy(q => q.ilanId).Select(A => A.First()).ToList();

                        for (int i = 0; i < sonuc.Count; i++)
                        {
                            string ilan = @"{
                                            'ilanId':'" + sonuc.ElementAt(i).ilanId.ToString() + "'," +
                                                "'baslik':'" + sonuc.ElementAt(i).baslik.ToString() + "'," +
                                                "'fiyat':'" + sonuc.ElementAt(i).fiyat.ToString() + "'," +
                                                "'baslangicTarihi':'" + sonuc.ElementAt(i).baslangicTarihi.ToString() + "'," +
                                                "'ilanTurId':'" + sonuc.ElementAt(i).ilanTurId.ToString() + "'," +
                                                "'kimden':'" + sonuc.ElementAt(i).turId.ToString() + "'," +
                                                "'resim':'" + sonuc.ElementAt(i).resim.ToString() + "'," +
                                                "'ilAdi':'" + sonuc.ElementAt(i).ilAdi.ToString() + "'," +
                                                "'ilceAdi':'" + sonuc.ElementAt(i).ilceAdi.ToString() + "'," +
                                                "'mahalleAdi':'" + sonuc.ElementAt(i).mahalleAdi.ToString() + "'," +
                                                "'fiyatTurId':'1'," +
                                                "'metreKare':'" + girilebilirSonuc.Where(q => q.ozellikId == 78 & q.ilanId == sonuc.ElementAt(i).ilanId).ElementAt(0).deger.ToString() + "'";

                            if (sonuc.ElementAt(i).magazaId != null)
                            {
                                ilan += ",'magazaId':'" + sonuc.ElementAt(i).magazaId.ToString() + "'";
                            }
                            else
                            {
                                ilan += ",'magazaId':'-1'";
                            }
                            if (girilebilirSonuc.Where(q => q.ozellikId == 71 & q.ilanId == sonuc.ElementAt(i).ilanId).ToList().Count > 0)
                            {
                                ilan += ",'koordinat':" + girilebilirSonuc.Where(q => q.ozellikId == 71 & q.ilanId == sonuc.ElementAt(i).ilanId).ElementAt(0).deger;
                            }
                            else
                            {
                                ilan += ",'koordinat':'-1'";
                            }
                            ilan += "}";



                            JObject obj = JObject.Parse(ilan);
                            dondur.Add(obj);
                        }
                    }
                }
                return dondur;
            }
            else
            {
                ArrayList bosDondur = new ArrayList();
                return bosDondur;
            }
        }
    }
}
