using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class mesajBll : sablon
    {
        ilanDataContext idc = new ilanDataContext();
        mesajlar mesajlard = new mesajlar();

        public void delete(int _id)
        {
            throw new NotImplementedException();
        }

        public void insert(params object[] _income)
        {
            mesajlard.kimeId = Convert.ToInt32(_income[0]);
            mesajlard.kullaniciId = Convert.ToInt32(_income[1]);
            if (_income[2] != null)
            {
                mesajlard.ilanId = Convert.ToInt32(_income[2]);
            }
            mesajlard.mesaj = _income[3].ToString();
            idc.mesajlars.InsertOnSubmit(mesajlard);
            idc.SubmitChanges();
        }

        public void update(params object[] _income)
        {
            //buraya bağlı olanlar düzeltilecek.
            if (_income[0].ToString() == "1")
                {
                var _value = idc.mesajlars.Where(q => q.mesajId == Convert.ToInt32(_income[2])).FirstOrDefault();
                if (_value != null)
                {
                    if (Convert.ToInt32(_income[1])== 1)
                    {
                        _value.aliciSildiMi = true;
                        idc.SubmitChanges();
                    }
                    else if (Convert.ToInt32(_income[1]) == 2)
                    {
                        _value.gonderenSildiMi = true;
                        idc.SubmitChanges();
                    }
                    else
                    {
                        _value.okunduMu = true;
                        idc.SubmitChanges();
                    }
                }
            }
            else if (_income[0].ToString() == "2")
            {
                var _value= idc.mesajlars.Where(q => q.kimeId == Convert.ToInt32(_income[1]) & q.kullaniciId == Convert.ToInt32(_income[2]) & q.ilanId == Convert.ToInt32(_income[3])).ToList();
                _value.ForEach(f => f.aliciSildiMi = true);
                idc.SubmitChanges();
            }
            else
            {
                var _value = idc.mesajlars.Where(q => q.kimeId == Convert.ToInt32(_income[1]) & q.kullaniciId == Convert.ToInt32(_income[2]) & q.ilanId == Convert.ToInt32(_income[3])).ToList();
                _value.ForEach(f => f.gonderenSildiMi = true);
                idc.SubmitChanges();
            }
        }

        public mesajlar search(int _income)
        {
            return idc.mesajlars.Where(q => q.mesajId == _income).FirstOrDefault();
        }


        public IQueryable list(params object[] _income)
        {
            if (Convert.ToInt32(_income[0]) == 1)
            {
                var query = from k in idc.kullanicis
                            join m in idc.mesajlars.Where(m => m.kimeId == Convert.ToInt32(_income[1]) & m.aliciSildiMi == false)
                            on k.kullaniciId equals m.kullaniciId
                            join r in idc.ilanResims.Where(r => r.seciliMi == true)
                            on m.ilan.ilanId equals r.ilanId
                            select new
                            {
                                m.mesajId,
                                k.kullaniciAdSoyad,
                                m.mesaj,
                                m.tarih,
                                k.profilResim,
                                m.ilan.baslik,
                                m.okunduMu
                            };
                return query;
            }
            else if (Convert.ToInt32(_income[0]) == 2)
            {
                var query = from k in idc.kullanicis
                            join m in idc.mesajlars.Where(m => m.kullaniciId == Convert.ToInt32(_income[1]) & m.aliciSildiMi == false)
                            on k.kullaniciId equals m.kullaniciId
                            join r in idc.ilanResims.Where(r => r.seciliMi == true)
                            on m.ilan.ilanId equals r.ilanId
                            select new
                            {
                                m.mesajId,
                                k.kullaniciAdSoyad,
                                m.mesaj,
                                m.tarih,
                                k.profilResim,
                                m.ilan.baslik
                                ,m.okunduMu

                            };
                return query;
            }

            else if (Convert.ToInt32(_income[0]) == 3)
            {
                var query = from k in idc.kullanicis
                            join m in idc.mesajlars.Where(m => m.kimeId == Convert.ToInt32(_income[1]) & m.aliciSildiMi==false)
                            on k.kullaniciId equals m.kullaniciId
                            join r in idc.ilanResims.Where(r => r.seciliMi == true)
                            on m.ilan.ilanId equals r.ilanId
                            group new { r, m } by new
                            {
                                m.ilan,
                                m.kullanici,
                                r.resim,                              
                            }
                            into gro
                            select new
                            {
                                gro.Key.ilan.baslik,
                                gro.Key.kullanici.kullaniciAdSoyad,
                                gro.Key.resim,
                                gro.Key.ilan.ilanId,
                                gro.First().m.tarih,
                                gro.Key.kullanici.kullaniciId

                            };
                return query;
            }
            else if (Convert.ToInt32(_income[0]) == 4)
            {
                var query = from k in idc.kullanicis
                            join m in idc.mesajlars.Where(m => m.kullaniciId == Convert.ToInt32(_income[1]) & m.gonderenSildiMi==false)
                            on k.kullaniciId equals m.kullaniciId
                            join r in idc.ilanResims.Where(r => r.seciliMi == true)
                            on m.ilan.ilanId equals r.ilanId
                            group new { r, m } by new
                            {
                                m.ilan,
                                m.kullanici,
                                r.resim,
                                m.kimeId
                            }
                            into gro
                            select new
                            {
                                gro.Key.ilan.baslik,
                                gro.Key.kullanici.kullaniciAdSoyad,
                                gro.Key.resim,
                                gro.Key.ilan.ilanId,
                                gro.Key.kimeId,
                                gro.First().m.tarih,
                                gro.Key.kullanici.kullaniciId

                            };
                return query;
            }

            else if (Convert.ToInt32(_income[0]) == 5)
            {
                var query = from m in idc.mesajlars.Where(m => (m.kullaniciId == Convert.ToInt32(_income[1]) | m.kimeId == Convert.ToInt32(_income[1])) & (m.kullaniciId == Convert.ToInt32(_income[2]) | m.kimeId == Convert.ToInt32(_income[2])) & m.ilanId==Convert.ToInt32(_income[3]))
                            select new
                            {
                                m.mesaj,
                                m.kullanici.kullaniciAdSoyad,
                                m.kullanici.profilResim,
                                m.tarih

                            };
                return query;
            }

            else if (Convert.ToInt32(_income[0]) == 6)
            {  //admin tarafında gelen kutusu
                var query = from k in idc.kullanicis
                            join m in idc.mesajlars.Where(m => m.kimeId == Convert.ToInt32(_income[1]) & m.aliciSildiMi == false)
                            on k.kullaniciId equals m.kullaniciId

                            select new
                            {
                                m.mesajId,
                                k.kullaniciAdSoyad,
                                m.mesaj,
                                m.tarih,
                                m.okunduMu
                            };
                return query;
            }

            else 
            {   //admin tarafında gonderilen kutusu
                var query = from k in idc.kullanicis
                            join m in idc.mesajlars.Where(m => m.kullaniciId == Convert.ToInt32(_income[1]) & m.gonderenSildiMi == false)
                            on k.kullaniciId equals m.kimeId

                            select new
                            {
                                m.mesajId,
                                k.kullaniciAdSoyad,
                                m.mesaj,
                                m.tarih,
                                m.okunduMu
                            };
                return query;
            }
        }

        public int count(params object[] _income)
        {
            if (Convert.ToInt32(_income[0]) == 1)
            {
                var query = from k in idc.kullanicis
                            join m in idc.mesajlars.Where(m => m.kimeId == Convert.ToInt32(_income[1]) & m.okunduMu == false & m.aliciSildiMi == false)
                            on k.kullaniciId equals m.kullaniciId
                            select new
                            {
                                m.mesajId,

                            };

                return query.Count();
            }
            else
            {
                var query = from k in idc.kullanicis
                            join m in idc.mesajlars.Where(m => m.kimeId == Convert.ToInt32(_income[1]) & m.okunduMu == false & m.aliciSildiMi == false)
                            on k.kullaniciId equals m.kullaniciId
                            select new
                            {
                                m.mesajId,

                            };

                return query.Count();
            }
        }
    }
}
