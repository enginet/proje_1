using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ilanFavoriBll : sablon
    {
        ilanDataContext idc = new ilanDataContext();
        ilanFavori favorid = new ilanFavori();
        public void delete(int _id)
        {

        }

        public void delete(params object[] _income)
        {
            var _value = idc.ilanFavoris.Where(q => q.ilanId == Convert.ToInt32(_income[0]) & q.kullaniciId == Convert.ToInt32(_income[1])).FirstOrDefault();

            if (_value != null)
            {
                idc.ilanFavoris.DeleteOnSubmit(_value);
                idc.SubmitChanges();
            }
        }

        public void insert(params object[] _income)
        {
            favorid.ilanId = Convert.ToInt32(_income[0]);
            favorid.kullaniciId = Convert.ToInt32(_income[1]);
            idc.ilanFavoris.InsertOnSubmit(favorid);
            idc.SubmitChanges();
        }

        public void update(params object[] _income)
        {
            throw new NotImplementedException();
        }

        public ilanFavori search(params object[] _income)
        {
            return idc.ilanFavoris.Where(f => f.ilanId == Convert.ToInt32(_income[0]) & f.kullaniciId == Convert.ToInt32(_income[1])).FirstOrDefault();
        }

        public IQueryable list(params object[] _income)
        {
            if (Convert.ToInt32(_income[0]) == 1)
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
            else
            {
                //düzeltilecek
                var query = from k in idc.kullanicis
                            join f in idc.ilanFavoris
                            on k.kullaniciId equals f.kullaniciId
                            where f.kullaniciId == Convert.ToInt32(_income[1])
                            join i in idc.ilans
                            on f.ilanId equals i.ilanId
                            join r in idc.ilanResims
                            on i.ilanId equals r.ilanId
                            join ka in idc.kategoris
                            on i.kategoriId equals ka.kategoriId
                            select new
                            {
                                i.baslik,
                                i.baslangicTarihi,
                                ka.kategoriAdi,
                                i.iller.ilAdi,
                                i.fiyat

                            };
                return query;
            }

        }
    }
}
