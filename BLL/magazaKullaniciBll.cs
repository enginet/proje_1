using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class magazaKullaniciBll : sablon
    {
        ilanDataContext idc = new ilanDataContext();
        magazaKullanici magazaKlld = new magazaKullanici();
        public void delete(int _id)
        {
            throw new NotImplementedException();
        }

        public void delete(params object[] _income)
        {
            var _value = idc.magazaKullanicis.Where(q => q.magazaId == Convert.ToInt32(_income[0]) & q.kullaniciId == Convert.ToInt32(_income[1])).FirstOrDefault();

            if (_value != null)
            {
                idc.magazaKullanicis.DeleteOnSubmit(_value);
                idc.SubmitChanges();
            }
        }

        public void insert(params object[] _income)
        {
            magazaKlld.magazaId = Convert.ToInt32(_income[0]);
            magazaKlld.kullaniciId = Convert.ToInt32(_income[1]);
            magazaKlld.rol = Convert.ToInt32(_income[2]);
            idc.magazaKullanicis.InsertOnSubmit(magazaKlld);
            idc.SubmitChanges();
        }

        public void update(params object[] _income)
        {
            throw new NotImplementedException();
        }

        public magazaKullanici search(params object[] _income)
        {
            if (Convert.ToInt32(_income[0]) == 1)
            {
                return idc.magazaKullanicis.Where(q => q.magazaId ==Convert.ToInt32(_income[1]) & q.rol == 0).FirstOrDefault();
            }
            else
            {
                return idc.magazaKullanicis.Where(q => q.kullaniciId == Convert.ToInt32(_income[1]) & q.rol==0).FirstOrDefault();
            }
        }

        public IQueryable list(params object[] _income)
        {
            if (Convert.ToInt32(_income[0]) == 1)
            {
                var query = from k in idc.kullanicis.Where(k=>k.silindiMi==false)
                            join mk in idc.magazaKullanicis.Where(mk => mk.magazaId == Convert.ToInt32(_income[1]) & mk.rol==2)
                            on k.kullaniciId equals mk.kullaniciId
                            select new
                            {
                                k.kullaniciId,
                                k.profilResim,
                                k.iller.ilAdi,
                                k.kullaniciAdSoyad,
                                k.email,
                                k.sonGirisTarihi
                            };
                return query;

            }
            else
            {
                var query = from k in idc.kullanicis  //silinecek
                            join mk in idc.magazaTakips
                            on k.kullaniciId equals mk.kullaniciId
                            join m in idc.magazas
                            on mk.magazaId equals m.magazaId
                            where k.silindiMi == false & m.magazaId == Convert.ToInt32(_income[1])
                            select new
                            {
                                k.kullaniciId,
                                k.kullaniciAdSoyad,
                                k.email,
                                k.sonGirisTarihi
                            };

                return query;
            }
        }
    }
}
