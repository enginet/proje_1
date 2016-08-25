using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class magazaTurBll : sablon
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
        public magazaTur search(int _income)
        {
            return idc.magazaTurs.Where(q => q.magazaTurId == _income).First();
        }

        public IEnumerable<magazaTur> list(int _income)
        {
            return idc.magazaTurs.Where(q => q.kategoriId == _income).ToList();

        }
    }
}
