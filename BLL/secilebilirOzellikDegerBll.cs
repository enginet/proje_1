using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class secilebilirOzellikDegerBll : sablon
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

        public secilebilirOzellikDeger search(int id)
        {
            return idc.secilebilirOzellikDegers.Where(q => q.secilebilirOzellikDegerId == id).First();
        }
    }
}
