using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ilBll : sablon
    {
        ilanDataContext idc = new ilanDataContext();
        iller il = new iller();

        public void delete(int _id)
        {
            var _value = idc.illers.Where(q => q.ilId == _id).FirstOrDefault();

            if (_value != null)
            {
                idc.illers.DeleteOnSubmit(_value);
                idc.SubmitChanges();
            }
        }

        public void insert(params object[] _income)
        {
            il.ilAdi = (string)_income[0];
            idc.illers.InsertOnSubmit(il);
            idc.SubmitChanges();
        }

        public void update(params object[] _income)
        {
            var _value = idc.illers.Where(q => q.ilId == Convert.ToInt32(_income[0])).FirstOrDefault();

            if (_value != null)
            {
                _value.ilAdi = (string)_income[1];
                idc.SubmitChanges();
            }
        }

        public IEnumerable<iller> list()
        {
            return idc.illers.ToList();
        }

        public iller search(int _income)
        {
            return idc.illers.Where(q => q.ilId == _income).FirstOrDefault();
        }

        public IQueryable qlist(params object[] _income)
        {
            if (Convert.ToInt32(_income[0]) == 1)
            {
                var query = from i in idc.ilans
                            join il in idc.illers
                            on i.ilId equals il.ilId
                            orderby il.ilans.Count() descending
                            select new
                            {
                                il.ilId,
                                il.ilAdi
                            };

                return query.Take(10);
            } 
            else
            {
                var query = from i in idc.ilans
                            join il in idc.illers
                            on i.ilId equals il.ilId
                            orderby il.ilans.Count() descending
                            select new
                            {
                                il.ilId,
                                il.ilAdi
                            };

                return query.Take(20);

            }

        }
    }
}
