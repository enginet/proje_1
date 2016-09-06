using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class seciliDopingBll : sablon
    {
        ilanDataContext idc = new ilanDataContext();
        public void delete(int _id)
        {
            throw new NotImplementedException();
        }

        public void insert(params object[] _income)
        {
            throw new NotImplementedException();
        }

        public void update(params object[] _income)
        {
            throw new NotImplementedException();
        }

        public seciliDoping search(params object[] _income)
        {
            return idc.seciliDopings.Where(q => q.ilanId == Convert.ToInt32(_income[0]) & q.pasifMi == false & q.onay == true & q.dopingKategori.doping.dopingId == Convert.ToInt32(_income[1])).FirstOrDefault();
        }

        public IQueryable list(params object[] _income)
        {
            if (Convert.ToInt32(_income[0]) == 1)
            {   //Anasayfa Dopingi
                var query = from s in idc.seciliDopings.Where(s => s.pasifMi == false & s.onay == true & s.ilan.onay == 1 & s.ilan.pasifMi == false & s.ilan.silindiMi == false)
                            join k in idc.dopingKategoris.Where(k => k.doping.dopingId == 12)
                            on s.dopingKategoriId equals k.dopingKategoriId
                            //join r in idc.ilanResims.Where(r => r.seciliMi == true)
                            //on s.ilan.ilanId equals r.ilanId
                            select new
                            {
                                s.ilan.ilanId,
                                s.ilan.baslik,
                                s.baslangicTarihi,
                                //r.resim
                            };
                return query.OrderByDescending(q=>q.baslangicTarihi).Take(1000);
            }
            else if (Convert.ToInt32(_income[0]) == 2)
            {   //Acil Acil Dopingi
                var query = from s in idc.seciliDopings.Where(s => s.pasifMi == false & s.onay == true & s.ilan.onay == 1 & s.ilan.pasifMi == false & s.ilan.silindiMi == false)
                            join k in idc.dopingKategoris.Where(k => k.doping.dopingId == 13)
                            on s.dopingKategoriId equals k.dopingKategoriId
                            //join r in idc.ilanResims.Where(r => r.seciliMi == true)
                            //on s.ilan.ilanId equals r.ilanId
                            select new
                            {
                                s.ilan.ilanId,
                                s.ilan.baslik,
                                //r.resim,
                                s.ilan.fiyat,
                                s.ilan.fiyatTurId,
                                s.baslangicTarihi
                            };
                return query.OrderByDescending(q => q.baslangicTarihi).Take(1000);
            }
            else if (Convert.ToInt32(_income[0]) == 3)
            {   //Kategori Dopingi
                var query = from s in idc.seciliDopings.Where(s => s.pasifMi == false & s.onay == true & s.ilan.onay == 1 & s.ilan.pasifMi == false & s.ilan.silindiMi == false & s.ilan.kategori.kategoriId == Convert.ToInt32(_income[1]))
                            join k in idc.dopingKategoris.Where(k => k.doping.dopingId == 15)
                            on s.dopingKategoriId equals k.dopingKategoriId
                            //join r in idc.ilanResims.Where(r => r.seciliMi == true)
                            //on s.ilan.ilanId equals r.ilanId
                            select new
                            {
                                s.ilan.ilanId,
                                s.ilan.baslik,
                                s.baslangicTarihi
                                //r.resim
                            };
                return query.OrderByDescending(q => q.baslangicTarihi).Take(1000);
            }

            else if (Convert.ToInt32(_income[0]) == 4)
            {
                var query = from i in idc.ilans.Where(i => i.onay == 1 & i.pasifMi == false & i.silindiMi == false & i.baslangicTarihi >= DateTime.Now.Subtract(new TimeSpan(2, 0, 0, 0, 0)))
                            //join r in idc.ilanResims.Where(r => r.seciliMi == true)
                            //on i.ilanId equals r.ilanId
                            select new
                            {
                                i.baslik,
                                //r.resim,
                                i.fiyat,
                                i.ilanId,
                                i.fiyatTurId,
                                i.magazaId,
                                i.baslangicTarihi
                                

                            };

                return query.OrderByDescending(q => q.baslangicTarihi).Take(1000);
            }
            else
            {
                var query = from i in idc.ilans
                            join k in idc.kategoris
                            on i.kategoriId equals k.kategoriId
                            where k.ustKategoriId == Convert.ToInt32(_income[1]) & i.onay == 1 & i.pasifMi == false & i.silindiMi == false
                            join s in idc.seciliDopings
                            on i.ilanId equals s.ilanId
                            where s.onay == true & s.pasifMi == false & s.bitisTarihi >= DateTime.Now & s.baslangicTarihi <= DateTime.Now
                            join dk in idc.dopingKategoris
                            on s.dopingKategoriId equals dk.dopingKategoriId
                            join d in idc.dopings
                            on dk.dopingId equals d.dopingId
                            where d.dopingId == 5
                            join r in idc.ilanResims
                            on i.ilanId equals r.ilanId
                            select new
                            {
                                i.baslik,
                                r.resim
                            };

                return query;
            }
        }
    }
}
