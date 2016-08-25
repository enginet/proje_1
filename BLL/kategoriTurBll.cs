using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class kategoriTurBll : sablon
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

        public kategoriTur search(int _income)
        {
            return idc.kategoriTurs.Where(q => q.kategoriId == _income).FirstOrDefault();
        }

        public IQueryable list(params object[] _income)
        {

            // İlk paramatre ( _income[0] ) sorgu tipini belirler.
            // 1 ise kategoriye ait türleri getirir. (kategori > satılık | kiralık | Devren | Günlük Kiralık)
            // 2 ise o kategoriye ait türlerin kategorilerini getirir. ( kategori > Satılık > altkategori )

            // ikinci parametre ( _income[1] ) ise gelen kategorinin id değeridir.

            // Üçüncü parametre ( _income[2] ) ise ilan türünü parametre alır.
            IQueryable query;
            if (Convert.ToInt32(_income[0]) == 1)
            {
                query = from kt in idc.kategoriTurs
                            join k in idc.kategoris
                            on kt.kategoriId equals k.kategoriId
                            where kt.kategoriId == Convert.ToInt32(_income[1])
                            select new
                            {
                                kt.turId
                            };
                return query;
            }
            else
            {
                 query = from kt in idc.kategoriTurs
                            join k in idc.kategoris
                            on kt.kategoriId equals k.kategoriId
                            where k.ustKategoriId == Convert.ToInt32(_income[1]) &&
                            kt.turId==Convert.ToInt32(_income[2])
                            select new
                            {
                                k.kategoriAdi,
                                k.kategoriId,
                               
                            };
                return query;
            }

      

        }
    }
}
