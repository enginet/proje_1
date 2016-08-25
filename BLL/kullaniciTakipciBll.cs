using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class kullaniciTakipciBll : sablon
    {
        ilanDataContext idc = new ilanDataContext();
        public void delete(int _id)
        {
            throw new NotImplementedException();
        }

        public void delete(params object[] _income)
        {

            var _value = idc.kullaniciTakips.Where(q => q.kullaniciId == Convert.ToInt32(_income[0]) & q.takipciId == Convert.ToInt32(_income[1])).FirstOrDefault();

            if (_value != null)
            {
                idc.kullaniciTakips.DeleteOnSubmit(_value);
                idc.SubmitChanges();
            }
        }

        public void insert(params object[] _income)
        {
            kullaniciTakip kullaniciTakipd = new kullaniciTakip();
            kullaniciTakipd.kullaniciId = Convert.ToInt32(_income[0]);
            kullaniciTakipd.takipciId = Convert.ToInt32(_income[1]);
            idc.kullaniciTakips.InsertOnSubmit(kullaniciTakipd);
            idc.SubmitChanges();
        }

        public void update(params object[] _income)
        {
            throw new NotImplementedException();
        }

        public kullaniciTakip search(params object[] _income)
        {
            return idc.kullaniciTakips.Where(f => f.kullaniciId == Convert.ToInt32(_income[0]) & f.takipciId == Convert.ToInt32(_income[1])).FirstOrDefault();
        }

        public IQueryable list(params object[] _income)
        {
            if (Convert.ToInt32(_income[0]) == 1)
            {
                var query = from k in idc.kullanicis
                            join t in idc.kullaniciTakips
                            on k.kullaniciId equals t.kullaniciId
                            where t.takipciId == Convert.ToInt32(_income[1]) & t.kullanici.silindiMi == false 
                            select new
                            {
                                t.kullanici.kullaniciId,
                                t.kullanici.kullaniciAdSoyad,
                                t.kullanici.iller.ilAdi,
                                t.kullanici.profilResim
                            };
                return query;

            }
            else
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
        }
    }
}
