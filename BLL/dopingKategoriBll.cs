using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class dopingKategoriBll : sablon
    {
        ilanDataContext idc = new ilanDataContext();
        dopingKategori dopingKtg = new dopingKategori();

        public void delete(int _id)
        {
            throw new NotImplementedException();
        }

        public void insert(params object[] _income)
        {
            dopingKtg.kategoriId = Convert.ToInt32(_income[0]);
            dopingKtg.dopingId = Convert.ToInt32(_income[1]);
            dopingKtg.dopingSureId = Convert.ToInt32(_income[2]);
            dopingKtg.fiyat = Convert.ToDouble(_income[3]);
            idc.dopingKategoris.InsertOnSubmit(dopingKtg);
            idc.SubmitChanges();
        }

        public void update(params object[] _income)
        {
            throw new NotImplementedException();
        }

        public IQueryable list(params object[] _income)
        {
            if (Convert.ToInt32(_income[0] ) == 1)
            {
                var query = from dk in idc.dopingKategoris
                            join k in idc.kategoris
                            on dk.kategoriId equals k.kategoriId
                            join d in idc.dopings
                            on dk.dopingId equals d.dopingId
                            select new
                            {
                                k.kategoriAdi,
                                d.dopingAdi,
                                dk.dopingSureId,
                                dk.fiyat

                            };

                return query;
            }
            else
            {
                var query = from dk in idc.dopingKategoris.Where(d => d.kategoriId == Convert.ToInt32(_income[1]) & d.dopingId == Convert.ToInt32(_income[2]))
                            select new
                            {
                                deneme = String.Format("{0} Hafta ( {1} TL)", dk.dopingSureId, dk.fiyat),
                                dk.dopingKategoriId
                            };

                return query;
            }
        }

        public dopingKategori search(int id)
        {

            var query = idc.dopingKategoris.Where(q => q.dopingKategoriId == id).First();

            return query;
        }
    }
}
