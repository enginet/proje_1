using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class mahalleBll : sablon
    {
        ilanDataContext idc = new ilanDataContext();
        mahalleler mahalle = new mahalleler();
        public void delete(int _id)
        {
            throw new NotImplementedException();
        }

        public void insert(params object[] _income)
        {
            mahalle.mahalleAdi = (string)_income[0];
            mahalle.ilceId = Convert.ToInt32(_income[1]);
            idc.mahallelers.InsertOnSubmit(mahalle);
            idc.SubmitChanges();
        }

        public void update(params object[] _income)
        {
            var _value = idc.mahallelers.Where(q => q.mahalleId == Convert.ToInt32(_income[0])).FirstOrDefault();

            if (_value != null)
            {
                _value.mahalleAdi = (string)_income[1];
                _value.ilceId = Convert.ToInt32(_income[2]);
                idc.SubmitChanges();
            }
        }
        public IEnumerable<mahalleler> list(int _income)
        {
            return idc.mahallelers.Where(q => q.ilceId == _income).ToList();
        }

        public mahalleler search(int _income)
        {
            return idc.mahallelers.Where(q => q.mahalleId == _income).FirstOrDefault();
        }
    }
}
