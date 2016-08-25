using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ilanUcretBll : sablon
    {
        ilanDataContext idc = new ilanDataContext();
        ilanUcret ilanUcret = new ilanUcret();
        public void delete(int _id)
        {
            throw new NotImplementedException();
        }

        public void insert(params object[] _income)
        {
            ilanUcret.kategoriId = Convert.ToInt32(_income[0]);
            ilanUcret.ucret = Convert.ToDouble(_income[1]);
            idc.ilanUcrets.InsertOnSubmit(ilanUcret);
            idc.SubmitChanges();
        }

        public void update(params object[] _income)
        {
            var _value = idc.ilanUcrets.Where(q => q.kategoriId == Convert.ToInt32(_income[0])).FirstOrDefault();

            if (_value != null)
            {
                _value.ucret = Convert.ToDouble(_income[1]);
                idc.SubmitChanges();
            }
        }

        public IQueryable list()
        {
            var query = from i in idc.ilanUcrets
                        join k in idc.kategoris
                        on i.kategoriId equals k.kategoriId
                        select new
                        {
                            k.kategoriAdi,
                            i.ucret
                        };

            return query;
        }
    }
}
