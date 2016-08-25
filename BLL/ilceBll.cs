using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ilceBll : sablon
    {
        ilanDataContext idc = new ilanDataContext();
        ilceler ilce = new ilceler();
        public void delete(int _id)
        {
            var _value = idc.ilcelers.Where(q => q.ilceId == _id).FirstOrDefault();

            if (_value != null)
            {
                idc.ilcelers.DeleteOnSubmit(_value);
                idc.SubmitChanges();
            }
        }

        public void insert(params object[] _income)
        {
            ilce.ilceAdi = (string)_income[0];
            ilce.ilId = Convert.ToInt32(_income[1]);
            idc.ilcelers.InsertOnSubmit(ilce);
            idc.SubmitChanges();
        }

        public void update(params object[] _income)
        {
            var _value = idc.ilcelers.Where(q => q.ilceId == Convert.ToInt32(_income[0])).FirstOrDefault();

            if (_value != null)
            {
                _value.ilceAdi = (string)_income[1];
                _value.ilId = Convert.ToInt32(_income[2]);
                idc.SubmitChanges();
            }
        }

        public IEnumerable<ilceler> list(int _income)
        {
            return idc.ilcelers.Where(q => q.ilId == _income).ToList();
        }

        public IEnumerable<ilceler> listim()
        {
            return idc.ilcelers.ToList();
        }

        public ilceler search(int _income)
        {
            return idc.ilcelers.Where(q => q.ilceId == _income).FirstOrDefault();
        }
    }
}
