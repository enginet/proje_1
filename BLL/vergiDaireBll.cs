using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class vergiDaireBll : sablon
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

        public IEnumerable<vergiDaire> list(int _income)
        {
            return idc.vergiDaires.Where(q => q.ilId == _income).ToList();
        }
    }
}
