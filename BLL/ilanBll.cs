﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ilanBll : sablon
    {
        ilanDataContext idc = new ilanDataContext();
        ilan iln = new ilan();
        public void delete(int _id)
        {
            throw new NotImplementedException();
        }

        public void insert(params object[] _income)
        {
            //ilanId,ilanTurId,/kategoriId,fiyat,fiyatTurId,kimdenId,kullaniciId,ilId,/ilceId,mahalleId,baslik,aciklama,
            //baslangicTarihi,bitisTarihi,ilanSahibiId,ziyaretci,onay,numaraYayinlansinMi,pasifMi,silindiMi,fiyatiDustu

            iln.ilanTurId = Convert.ToInt32(_income[0]);
            iln.kategoriId = Convert.ToInt32(_income[1]);
            iln.fiyat = Convert.ToDouble(_income[2]);
            iln.fiyatTurId = Convert.ToInt32(_income[3]);
            iln.kullaniciId = Convert.ToInt32(_income[4]);

            if (_income[5].ToString() != "")
            {
                iln.magazaId = Convert.ToInt32(_income[5]);
            }

            iln.ilId = Convert.ToInt32(_income[6]);
            iln.ilceId = Convert.ToInt32(_income[7]);
            iln.mahalleId = Convert.ToInt32(_income[8]);
            iln.baslik = (string)_income[9];
            iln.aciklama = (string)_income[10];
            iln.baslangicTarihi = DateTime.Now;
            iln.bitisTarihi = (DateTime.Now.AddYears(1));
            iln.onay = Convert.ToInt32(_income[11]);
            //iln.numaraYayinlansinMi = Convert.ToBoolean(_income[12]);
            iln.pasifMi = false;
            iln.silindiMi = false;


            idc.ilans.InsertOnSubmit(iln);
            idc.SubmitChanges();
        }

        public void update(params object[] _income)
        {

            if (Convert.ToInt32(_income[0]) == 1)
            {
                var _value = idc.ilans.Where(q => q.ilanId == Convert.ToInt32(_income[1])).FirstOrDefault();

                if (_value != null)
                {
                    _value.fiyat = Convert.ToDouble(_income[2]);
                    _value.fiyatTurId = Convert.ToInt32(_income[3]);
                    if (_income[4].ToString() != "NULL")
                    {
                        _value.magazaId = Convert.ToInt32(_income[4]);
                    }
                    _value.ilId = Convert.ToInt32(_income[5]);
                    _value.ilceId = Convert.ToInt32(_income[6]);
                    _value.mahalleId = Convert.ToInt32(_income[7]);
                    _value.baslik = (string)_income[8];
                    _value.aciklama = (string)_income[9];
                    _value.onay = Convert.ToInt32(_income[10]);
                    _value.numaraYayinlansinMi = Convert.ToBoolean(_income[11]);
                    idc.SubmitChanges();

                }
            }
            else if (Convert.ToInt32(_income[0]) == 2)
            {
                var _value = idc.ilans.Where(q => q.ilanId == Convert.ToInt32(_income[2])).FirstOrDefault();
                if (Convert.ToInt32(_income[1]) == 1) // onay durumu aktif yap
                {

                    if (_value != null)
                    {
                        _value.onay = 1;
                    }
                }

                if (Convert.ToInt32(_income[1]) == 2) // pasif true yap
                {

                    if (_value != null)
                    {
                        _value.pasifMi = true;
                    }
                }

                if (Convert.ToInt32(_income[1]) == 3) // pasif false yap
                {

                    if (_value != null)
                    {
                        _value.pasifMi = false;
                    }
                }

                if (Convert.ToInt32(_income[1]) == 4) //şikayetleri kaldır
                {
                    //idc.ilanSikayets.Where(q => q.ilanId == Convert.ToInt32(_income[2])).ToList().ForEach(idc.ilanSikayets);
                    //if (_value != null)
                    //{
                    //    idc.ilanSikayets.DeleteOnSubmit(value_sikayet);
                    //}
                }

                idc.SubmitChanges();
            }
            else
            {
                var _value = idc.ilans.Where(q => q.ilanId == Convert.ToInt32(_income[1])).FirstOrDefault();

                if (_value != null)
                {
                    _value.silindiMi = true;
                    idc.SubmitChanges();
                }
            }
        }
        public IQueryable list_admin(params object[] _income)
        {
            // 1.parametre sorgu türünü belirler
            // Eğer 1 ise onay bekleyen ilanlar
            // Eğer 2 ise yayındaki ilanlar
            // Eğer 3 ise pasif ilanlar
            // Eğer 4 ise Şikayet edilen ilanlar
            // Eğer 5 ise fiyatı düşen ilanlar
            // Eğer 6 ise dopingli ilanlar
            // Eğer 7 ise editörlerin girmiş olduğu ilanlar

            if (Convert.ToInt32(_income[0]) == 1)
            {
                var query = from i in idc.ilans
                            where
                                i.onay == 2 &&
                                i.pasifMi == false &&
                                i.silindiMi == false
                            join il in idc.illers on i.ilId equals il.ilId
                            select new
                            {
                                i.ilanId,
                                il.ilAdi,
                                i.fiyat,
                                i.baslangicTarihi,
                                i.baslik
                            };

                return query.OrderByDescending(q => q.baslangicTarihi).Take(1000);
            }
            else if (Convert.ToInt16(_income[0]) == 2)
            {
                var query = from i in idc.ilans
                            where
                                i.onay == 1 &&
                                i.pasifMi == false &&
                                i.silindiMi == false
                            join il in idc.illers on i.ilId equals il.ilId
                            select new
                            {
                                i.ilanId,
                                il.ilAdi,
                                i.fiyat,
                                i.baslangicTarihi,
                                i.baslik

                            };

                return query.OrderByDescending(q => q.baslangicTarihi).Take(1000);
            }
            else if (Convert.ToInt16(_income[0]) == 3)
            {

                var query = from i in idc.ilans
                            where
                                i.pasifMi == true &&
                                i.silindiMi == false
                            join il in idc.illers on i.ilId equals il.ilId
                            select new
                            {
                                i.ilanId,
                                il.ilAdi,
                                i.fiyat,
                                i.baslangicTarihi,
                                i.baslik

                            };

                return query.OrderByDescending(q => q.baslangicTarihi).Take(1000);
            }

            else if (Convert.ToInt16(_income[0]) == 4)
            {

                var query = from i in idc.ilans
                            where
                                i.onay == 1 &&
                                i.silindiMi == false
                            join il in idc.illers on i.ilId equals il.ilId
                            join isk in idc.ilanSikayets on i.ilanId equals isk.ilanId
                            select new
                            {
                                i.ilanId,
                                il.ilAdi,
                                i.fiyat,
                                i.baslangicTarihi,
                                i.baslik

                            };

                return query.OrderByDescending(q => q.baslangicTarihi).Take(1000);
            }
            else if (Convert.ToInt16(_income[0]) == 5)
            {

                var query = from i in idc.ilans
                            where
                                i.fiyatiDustu == true &&
                                i.silindiMi == false
                            join il in idc.illers on i.ilId equals il.ilId
                            select new
                            {
                                i.ilanId,
                                il.ilAdi,
                                i.fiyat,
                                i.baslangicTarihi,
                                i.baslik

                            };

                return query.OrderByDescending(q => q.baslangicTarihi).Take(1000);
            }

            else if (Convert.ToInt16(_income[0]) == 6)
            {

                var query = from i in idc.ilans
                            where
                                i.onay == 1 &&
                                i.pasifMi == false &&
                                i.silindiMi == false
                            join il in idc.illers on i.ilId equals il.ilId
                            join sd in idc.seciliDopings on i.ilanId equals sd.ilanId
                            select new
                            {
                                i.ilanId,
                                il.ilAdi,
                                i.fiyat,
                                i.baslangicTarihi,
                                i.baslik

                            };

                return query.OrderByDescending(q => q.baslangicTarihi).Take(1000);
            }

            else if (Convert.ToInt16(_income[0]) == 7)
            {

                var query = from i in idc.ilans
                            where
                                i.onay == 1
                            join il in idc.illers on i.ilId equals il.ilId
                            join k in idc.kullanicis on i.kullaniciId equals k.kullaniciId
                            where k.rol != 4
                            select new
                            {
                                i.ilanId,
                                il.ilAdi,
                                i.fiyat,
                                i.baslangicTarihi,
                                i.baslik

                            };

                return query.OrderByDescending(q => q.baslangicTarihi).Take(1000);
            }
            else if (Convert.ToInt16(_income[0]) == 8)
            {
                if (_income[1].ToString() == "1")
                {
                    var query = from i in idc.ilans.Where(i => i.kategoriId == Convert.ToInt32(_income[2]) & i.ilanTurId == Convert.ToInt32(_income[3]) & i.silindiMi == false & i.pasifMi == false & i.onay == 1 & i.magazaId == null)
                                    //join g in idc.girilenIlanOzelliks.Where(g => g.ozellikId == 78)
                                    //on i.ilanId equals g.ilanId
                                join r in idc.ilanResims.Where(r => r.seciliMi == true)
                                on i.ilanId equals r.ilanId
                                select new
                                {
                                    i.ilanId,
                                    i.baslik,
                                    i.iller.ilAdi,
                                    i.ilceler.ilceAdi,
                                    i.baslangicTarihi,
                                    i.fiyat,
                                    i.kategori.kategoriAdi,
                                    i.kategori.kategoriId,
                                    i.ilanTurId,
                                    r.resim,
                                    //g.deger,
                                    i.fiyatTurId,
                                    i.magazaId



                                };

                    return query.OrderByDescending(q => q.baslangicTarihi).Take(1000);
                }
                else if (_income[1].ToString() == "2")
                {

                    var query = from i in idc.ilans.Where(i => i.kategoriId == Convert.ToInt32(_income[2]) & i.ilanTurId == Convert.ToInt32(_income[3]) & i.silindiMi == false & i.pasifMi == false & i.onay == 1 & i.magaza.magazaTur.turId == Convert.ToInt32(_income[4]))
                                    //join g in idc.girilenIlanOzelliks.Where(g => g.ozellikId == 78)
                                    //on i.ilanId equals g.ilanId
                                join r in idc.ilanResims.Where(r => r.seciliMi == true)
                                on i.ilanId equals r.ilanId
                                select new
                                {
                                    i.ilanId,
                                    i.baslik,
                                    i.iller.ilAdi,
                                    i.ilceler.ilceAdi,
                                    i.baslangicTarihi,
                                    i.fiyat,
                                    i.kategori.kategoriAdi,
                                    i.kategori.kategoriId,
                                    i.ilanTurId,
                                    r.resim,
                                    //g.deger,
                                    i.fiyatTurId,
                                    i.magazaId

                                };

                    return query.OrderByDescending(q => q.baslangicTarihi).Take(1000);
                }

                else if (_income[1].ToString() == "3")
                {
                    var query = from i in idc.ilans.Where(i => i.kategoriId == Convert.ToInt32(_income[2]) & i.ilanTurId == Convert.ToInt32(_income[3]) & i.silindiMi == false & i.pasifMi == false & i.onay == 1)
                                    //join g in idc.girilenIlanOzelliks.Where(g => g.ozellikId == 78)
                                    //on i.ilanId equals g.ilanId
                                join r in idc.ilanResims.Where(r => r.seciliMi == true)
                                on i.ilanId equals r.ilanId
                                select new
                                {
                                    i.ilanId,
                                    i.baslik,
                                    i.iller.ilAdi,
                                    i.ilceler.ilceAdi,
                                    i.baslangicTarihi,
                                    i.fiyat,
                                    i.kategori.kategoriAdi,
                                    i.kategori.kategoriId,
                                    i.ilanTurId,
                                    r.resim,
                                    //g.deger,
                                    i.fiyatTurId,
                                    i.magazaId
                                };

                    return query.OrderByDescending(q => q.baslangicTarihi).Take(1000);
                }

                else
                {   //turu olmayanlar için 
                    var query = from i in idc.ilans.Where(i => i.kategoriId == Convert.ToInt32(_income[2]) & i.silindiMi == false & i.pasifMi == false & i.onay == 1)
                                    //join g in idc.girilenIlanOzelliks.Where(g => g.ozellikId == 78)
                                    //on i.ilanId equals g.ilanId
                                join r in idc.ilanResims.Where(r => r.seciliMi == true)
                                on i.ilanId equals r.ilanId
                                select new
                                {
                                    i.ilanId,
                                    i.baslik,
                                    i.iller.ilAdi,
                                    i.ilceler.ilceAdi,
                                    i.baslangicTarihi,
                                    i.fiyat,
                                    i.kategori.kategoriAdi,
                                    i.kategori.kategoriId,
                                    i.ilanTurId,
                                    r.resim,
                                    //g.deger,
                                    i.fiyatTurId,
                                    i.magazaId


                                };

                    return query.OrderByDescending(q => q.baslangicTarihi).Take(1000);
                }
            }
            else if (Convert.ToInt16(_income[0]) == 9)
            {
                if (_income[1].ToString() == "1")
                {   //sahibinden
                    var query = from i in idc.ilans.Where(i => i.kategori.ustKategoriId == Convert.ToInt32(_income[2]) & i.ilanTurId == Convert.ToInt32(_income[3]) & i.silindiMi == false & i.pasifMi == false & i.onay == 1 & i.magazaId == null)
                                    //join g in idc.girilenIlanOzelliks.Where(g => g.ozellikId == 78)
                                    //on i.ilanId equals g.ilanId
                                join r in idc.ilanResims.Where(r => r.seciliMi == true)
                                on i.ilanId equals r.ilanId
                                select new
                                {
                                    i.ilanId,
                                    i.baslik,
                                    i.iller.ilAdi,
                                    i.ilceler.ilceAdi,
                                    i.baslangicTarihi,
                                    i.fiyat,
                                    i.kategori.kategoriAdi,
                                    i.kategori.kategoriId,
                                    i.ilanTurId,
                                    r.resim,
                                    //g.deger,
                                    i.fiyatTurId,
                                    i.magazaId



                                };

                    return query.OrderByDescending(q => q.baslangicTarihi).Take(1000);
                }
                else if (_income[1].ToString() == "2")
                {   //kimden
                    var query = from i in idc.ilans.Where(i => i.kategori.ustKategoriId == Convert.ToInt32(_income[2]) & i.ilanTurId == Convert.ToInt32(_income[3]) & i.silindiMi == false & i.pasifMi == false & i.onay == 1 & i.magaza.magazaTur.turId == Convert.ToInt32(_income[4]))
                                    //join g in idc.girilenIlanOzelliks.Where(g => g.ozellikId == 78)
                                    //on i.ilanId equals g.ilanId
                                join r in idc.ilanResims.Where(r => r.seciliMi == true)
                                on i.ilanId equals r.ilanId
                                select new
                                {
                                    i.ilanId,
                                    i.baslik,
                                    i.iller.ilAdi,
                                    i.ilceler.ilceAdi,
                                    i.baslangicTarihi,
                                    i.fiyat,
                                    i.kategori.kategoriAdi,
                                    i.kategori.kategoriId,
                                    i.ilanTurId,
                                    r.resim,
                                    //g.deger,
                                    i.fiyatTurId,
                                    i.magazaId
                                };

                    return query.OrderByDescending(q => q.baslangicTarihi).Take(1000);

                }
                else
                {  //tüm
                    var query = from i in idc.ilans.Where(i => i.kategori.ustKategoriId == Convert.ToInt32(_income[2]) & i.ilanTurId == Convert.ToInt32(_income[3]) & i.silindiMi == false & i.pasifMi == false & i.onay == 1)
                                    //join g in idc.girilenIlanOzelliks.Where(g => g.ozellikId == 78)
                                    //on i.ilanId equals g.ilanId
                                join r in idc.ilanResims.Where(r => r.seciliMi == true)
                                on i.ilanId equals r.ilanId
                                select new
                                {
                                    i.ilanId,
                                    i.baslik,
                                    i.iller.ilAdi,
                                    i.ilceler.ilceAdi,
                                    i.baslangicTarihi,
                                    i.fiyat,
                                    i.kategori.kategoriAdi,
                                    i.kategori.kategoriId,
                                    i.ilanTurId,
                                    r.resim,
                                    i.fiyatTurId,
                                    i.magazaId


                                };

                    return query.OrderByDescending(q => q.baslangicTarihi).Take(1000);

                }

            }

            else if (Convert.ToInt32(_income[0]) == 10)
            {
                var query = from i in idc.ilans.Where(i => i.onay == 3 && i.pasifMi == false && i.silindiMi == false)
                            select new
                            {
                                i.ilanId,
                                i.iller.ilAdi,
                                i.fiyat,
                                i.baslangicTarihi,
                                i.baslik

                            };

                return query.OrderByDescending(q => q.baslangicTarihi).Take(1000);

            }

            else
            {
                var query = from i in idc.ilans
                            where
                                i.onay == 1 &&
                                i.pasifMi == false &&
                                i.silindiMi == false
                            join il in idc.illers on i.ilId equals il.ilId
                            select new
                            {
                                i.ilanId,
                                il.ilAdi,
                                i.fiyat,
                                i.baslangicTarihi,
                                i.baslik

                            };

                return query.OrderByDescending(q => q.baslangicTarihi).Take(1000);

            }
        }



        public IQueryable list(params object[] _income)
        {
            if (Convert.ToInt32(_income[0]) == 1)
            {
                var query = from i in idc.ilans
                            join k in idc.kategoris
                            on i.kategoriId equals k.kategoriId
                            where i.onay == Convert.ToInt32(_income[1])
                            select new
                            {
                                i.ilanId,
                                i.baslik,
                                k.kategoriAdi,
                                i.fiyat
                            };

                return query;
            }
            else if (Convert.ToInt32(_income[0]) == 2)
            {
                var query = from i in idc.ilans.Where(i => i.onay == Convert.ToInt32(_income[2]) & i.silindiMi == bool.Parse(_income[3].ToString()) & i.pasifMi == bool.Parse(_income[4].ToString()))
                            join k in idc.kullanicis.Where(k => k.kullaniciId == Convert.ToInt32(_income[1]))
                            on i.kullaniciId equals k.kullaniciId
                            join r in idc.ilanResims.Where(r => r.seciliMi == true)
                            on i.ilanId equals r.ilanId
                            select new
                            {
                                i.ilanId,
                                i.baslik,
                                i.baslangicTarihi,
                                r.resim,
                                i.fiyat,
                                i.iller.ilAdi,
                                i.kategori.kategoriAdi,
                                i.ziyaretci

                            };

                return query;

            }
            else if (Convert.ToInt32(_income[0]) == 3)
            {
                var query = from f in idc.ilanFavoris.Where(i => i.ilan.onay == 1 & i.ilan.silindiMi == false & i.ilan.pasifMi == false)
                            join k in idc.kullanicis.Where(k => k.kullaniciId == Convert.ToInt32(_income[1]))
                            on f.kullaniciId equals k.kullaniciId
                            join r in idc.ilanResims.Where(r => r.seciliMi == true)
                            on f.ilan.ilanId equals r.ilanId
                            select new
                            {
                                f.ilanId,
                                f.ilan.baslik,
                                f.ilan.baslangicTarihi,
                                r.resim,
                                f.ilan.fiyat,
                                f.ilan.iller.ilAdi,
                                f.ilan.kategori.kategoriAdi

                            };

                return query;

            }

            else if (Convert.ToInt32(_income[0]) == 4)
            {
                var query = from k in idc.kullanicis.Where(k => k.kullaniciId == Convert.ToInt32(_income[1]))
                            join i in idc.ilans.Where(i => i.silindiMi == false & i.pasifMi == false & i.onay == 1)
                            on k.kullaniciId equals i.kullaniciId
                            join r in idc.ilanResims.Where(r => r.seciliMi == true)
                            on i.ilanId equals r.ilanId
                            select new
                            {
                                i.ilanId,
                                i.baslik,
                                i.baslangicTarihi,
                                i.ziyaretci,
                                i.iller.ilAdi,
                                i.fiyat,
                                i.kategori.kategoriAdi,
                                r.resim,
                                i.fiyatTurId
                            };

                return query;

            }
            else
            {
                var query = from i in idc.ilans.Where(i => i.silindiMi == false & i.pasifMi == false & i.onay == 1 & i.magazaId == Convert.ToInt32(_income[1]))
                            join r in idc.ilanResims.Where(r => r.seciliMi == true)
                            on i.ilanId equals r.ilanId
                            select new
                            {
                                i.ilanId,
                                i.baslik,
                                i.baslangicTarihi,
                                i.ziyaretci,
                                i.iller.ilAdi,
                                i.fiyat,
                                i.kategori.kategoriAdi,
                                r.resim,
                                i.fiyatTurId

                            };
                return query;
            }
        }

        public ilan search(params object[] _income)
        {
            if (_income[0].ToString() == "1")
            {
                return idc.ilans.Where(i => i.kullaniciId == Convert.ToInt32(_income[1]) & i.silindiMi == false & i.pasifMi == false & i.onay == 1).ToList().LastOrDefault();

            }
            else if (_income[0].ToString() == "2")
            {
                return idc.ilans.Where(i => i.ilanId == Convert.ToInt32(_income[1]) & i.silindiMi == false).ToList().FirstOrDefault();

            }
            else if (_income[0].ToString() == "3")
            {
                return idc.ilans.Where(i => i.kullaniciId == Convert.ToInt32(_income[1]) && i.ilanId == Convert.ToInt32(_income[2])).FirstOrDefault();
            }
            else
            {
                return idc.ilans.Where(i => i.ilanId == Convert.ToInt32(_income[1]) & i.silindiMi == false).ToList().FirstOrDefault();
            }
        }

        public IEnumerable<ilan> list()
        {
            return idc.ilans.ToList();
        }

        public int ilanSayisi(int id)
        {
            return idc.ilans.Where(q => q.kullaniciId == id & q.pasifMi == false & q.silindiMi == false & (q.onay == 1 || q.onay == 2)).ToList().Count;
        }


        public int countIlanListe(params object[] _income)
        {

            if (Convert.ToInt32(_income[0])==1) // Tüm ilanların sayısı
            {
                return idc.ilans.Where(q => q.silindiMi == false && q.pasifMi == false && q.onay == 1 && q.kategoriId == Convert.ToInt32(_income[1]) && q.ilanTurId == Convert.ToInt32(_income[2])).ToList().Count;
            }
            if (Convert.ToInt32(_income[0]) ==2) // sahibinden ilanların sayısı
            {
                return idc.ilans.Where(q => q.magazaId==null && q.silindiMi == false && q.pasifMi == false && q.onay == 1 && q.kategoriId == Convert.ToInt32(_income[1]) && q.ilanTurId == Convert.ToInt32(_income[2])).ToList().Count;
            }
            if (Convert.ToInt32(_income[0]) == 3) // emlakçıdan ilanların sayısı
            {
                return idc.ilans.Where(q => q.magaza.magazaTur.turId == 7 && q.silindiMi == false && q.pasifMi == false && q.onay == 1 && q.kategoriId == Convert.ToInt32(_income[1]) && q.ilanTurId == Convert.ToInt32(_income[2])).ToList().Count;
            }
            if (Convert.ToInt32(_income[0]) == 4) // bankadan ilanların sayısı
            {
                return idc.ilans.Where(q => q.magaza.magazaTur.turId == 5 && q.silindiMi == false && q.pasifMi == false && q.onay == 1 && q.kategoriId == Convert.ToInt32(_income[1]) && q.ilanTurId == Convert.ToInt32(_income[2])).ToList().Count;
            }
            if (Convert.ToInt32(_income[0]) == 5) // beldiyeden ilanların sayısı
            {
                return idc.ilans.Where(q => q.magaza.magazaTur.turId == 1 && q.silindiMi == false && q.pasifMi == false && q.onay == 1 && q.kategoriId == Convert.ToInt32(_income[1]) && q.ilanTurId == Convert.ToInt32(_income[2])).ToList().Count;
            }
            if (Convert.ToInt32(_income[0]) == 6) // İcradan ilanların sayısı
            {
                return idc.ilans.Where(q => q.magaza.magazaTur.turId == 2 && q.silindiMi == false && q.pasifMi == false && q.onay == 1 && q.kategoriId == Convert.ToInt32(_income[1]) && q.ilanTurId == Convert.ToInt32(_income[2])).ToList().Count;
            }
            if (Convert.ToInt32(_income[0]) == 7) // izaleyi şuyu ilanların sayısı
            {
                return idc.ilans.Where(q => q.magaza.magazaTur.turId == 3 && q.silindiMi == false && q.pasifMi == false && q.onay == 1 && q.kategoriId == Convert.ToInt32(_income[1]) && q.ilanTurId == Convert.ToInt32(_income[2])).ToList().Count;
            }
            if (Convert.ToInt32(_income[0]) == 8) // milli hazineden ilanların sayısı
            {
                return idc.ilans.Where(q => q.magaza.magazaTur.turId == 4 && q.silindiMi == false && q.pasifMi == false && q.onay == 1 && q.kategoriId == Convert.ToInt32(_income[1]) && q.ilanTurId == Convert.ToInt32(_income[2])).ToList().Count;
            }
            if (Convert.ToInt32(_income[0]) == 9) // özelleştrime ilanların sayısı
            {
                return idc.ilans.Where(q => q.magaza.magazaTur.turId == 9 && q.silindiMi == false && q.pasifMi == false && q.onay == 1 && q.kategoriId == Convert.ToInt32(_income[1]) && q.ilanTurId == Convert.ToInt32(_income[2])).ToList().Count;
            }
            if (Convert.ToInt32(_income[0]) == 10) // kamu kurumlarından ilanların sayısı
            {
                return idc.ilans.Where(q => q.magaza.magazaTur.turId == 6 && q.silindiMi == false && q.pasifMi == false && q.onay == 1 && q.kategoriId == Convert.ToInt32(_income[1]) && q.ilanTurId == Convert.ToInt32(_income[2])).ToList().Count;
            }
            else // inşaat firmasından ilanların sayısı
            {
                return idc.ilans.Where(q => q.magaza.magazaTur.turId == 8 && q.silindiMi == false && q.pasifMi == false && q.onay == 1 && q.kategoriId == Convert.ToInt32(_income[1]) && q.ilanTurId == Convert.ToInt32(_income[2])).ToList().Count;
            }
        }
    }
}
