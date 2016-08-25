using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class magazaTakipciBll : sablon
    {
        ilanDataContext idc = new ilanDataContext();
        public void delete(int _id)
        {
            throw new NotImplementedException();
        }

        public void delete(params object[] _income)
        {

            var _value = idc.magazaTakips.Where(q => q.magazaId == Convert.ToInt32(_income[0]) & q.kullaniciId == Convert.ToInt32(_income[1])).FirstOrDefault();

            if (_value != null)
            {
                idc.magazaTakips.DeleteOnSubmit(_value);
                idc.SubmitChanges();
            }
        }

        public void insert(params object[] _income)
        {
            magazaTakip magazaTakipd = new magazaTakip();
            magazaTakipd.kullaniciId = Convert.ToInt32(_income[0]);
            magazaTakipd.magazaId = Convert.ToInt32(_income[1]);
            idc.magazaTakips.InsertOnSubmit(magazaTakipd);
            idc.SubmitChanges();
        }

        public void update(params object[] _income)
        {
            throw new NotImplementedException();
        }

        public magazaTakip search(params object[] _income)
        {
            return idc.magazaTakips.Where(f => f.kullaniciId == Convert.ToInt32(_income[0]) & f.magazaId == Convert.ToInt32(_income[1])).FirstOrDefault();
        }

        public IQueryable list(params object[] _income)
        {
            if (Convert.ToInt32(_income[0]) == 1)
            {
                var query = from k in idc.kullanicis
                            join t in idc.magazaTakips
                            on k.kullaniciId equals t.kullaniciId
                            where t.kullaniciId == Convert.ToInt32(_income[1]) & t.magaza.pasifMi == false & t.magaza.onay == true & t.magaza.silindiMi == false
                            select new
                            {
                                t.magazaId,
                                t.magaza.magazaAdi,
                                t.magaza.magazaKategori.kategori.kategoriAdi,
                                t.magaza.baslangicTarihi,
                                t.magaza.iller.ilAdi,
                                t.magaza.magazaLogo,

                            };
                return query;

            }

            else if (Convert.ToInt32(_income[0]) == 2)
            {
                var query = from k in idc.kullanicis
                            join t in idc.magazaTakips
                            on k.kullaniciId equals t.kullaniciId
                            where k.kullaniciId == Convert.ToInt32(_income[1]) & t.magaza.pasifMi == false & t.magaza.onay == true & t.magaza.silindiMi == false & t.magaza.baslangicTarihi <= DateTime.Now & t.magaza.bitisTarihi >= DateTime.Now
                            select new
                            {
                                t.magaza.magazaAdi,
                                t.magaza.magazaTur.kategori.kategoriAdi,
                                t.magaza.baslangicTarihi,
                                t.magaza.iller.ilAdi,
                                t.magaza.magazaLogo,

                            };
                return query;
            }
            else
            {
                var query = from t in idc.magazaTakips.Where(t => t.kullanici.silindiMi == false & t.magaza.magazaId == Convert.ToInt32(_income[1]))
                            select new
                            {
                                t.kullanici.kullaniciId,
                                t.kullanici.kullaniciAdSoyad,
                                t.kullanici.email,
                                t.kullanici.sonGirisTarihi
                            };

                return query;

            }
        }

        public IQueryable list_Follow(int _income)
        {
            var query = from m in idc.magazas.Where(m=>m.magazaId == _income & m.pasifMi == false & m.onay == true & m.silindiMi == false )
                        join t in idc.magazaTakips
                        on m.magazaId equals t.magazaId
                        join k in idc.kullanicis
                        on t.kullaniciId equals k.kullaniciId
                        where k.silindiMi == false
                        select new
                        {
                            k.profilResim,
                            k.kullaniciId                         
                        };
            return query;


        }
    }
}
