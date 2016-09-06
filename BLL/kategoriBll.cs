using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class kategoriBll : sablon
    {
        ilanDataContext idc = new ilanDataContext();
        kategori kategorid = new kategori();

        public void delete(int _id)
        {
            throw new NotImplementedException(); //olmayacak
        }

        public void insert(params object[] _income)
        {
            kategorid.kategoriAdi = (string)_income[0];
            kategorid.ustKategoriId = Convert.ToInt32(_income[1]);
            idc.kategoris.InsertOnSubmit(kategorid);
            idc.SubmitChanges();
        }

        public void update(params object[] _income)
        {
            var _value = idc.kategoris.Where(q => q.kategoriId == Convert.ToInt32(_income[0])).FirstOrDefault();

            if (_value != null)
            {
                _value.kategoriAdi = (string)_income[1];
                idc.SubmitChanges();
            }
        }

        public IEnumerable<kategori> list(int _income)
        {
            return idc.kategoris.Where(q => q.ustKategoriId == _income).ToList();

        }

        public kategori search(int _income)
        {
            return idc.kategoris.Where(q => q.kategoriId == _income).FirstOrDefault();
        }

        public kategori ustKategoriSearch(int id)
        {
            return idc.kategoris.Where(q => q.ustKategoriId == id).FirstOrDefault();
        }
        
        public IQueryable qlist(params object[] _income)
        {
            if (Convert.ToInt32(_income[0]) == 1)
            {
                var query = from i in idc.ilans
                            join k in idc.kategoris
                            on i.kategoriId equals k.kategoriId
                            orderby k.ilans.Count() descending
                            select new
                            {
                                k.kategoriId,
                                k.kategoriAdi
                            };

                return query.Take(20);
            }
            else
            {
                var query = from i in idc.ilans
                            join k in idc.kategoris
                            on i.kategoriId equals k.kategoriId
                            orderby k.ilans.Count() descending
                            select new
                            {
                                k.kategoriAdi
                            };

                return query.Take(10).Distinct();

            }
        }
    }
}
