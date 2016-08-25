using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ozellikBll : sablon
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

        public IEnumerable<ozellik> list()
        {
            return idc.ozelliks.ToList();
        }

        public IEnumerable<ozellik> selectList(int _income)
        {
            return idc.ozelliks.Where(q => Convert.ToInt32(q.secilebilirMi) == _income).ToList();
        }

        public IEnumerable<secilebilirOzellikDeger> selectFieldList(int _income)
        {
            return idc.secilebilirOzellikDegers.Where(q => q.ozellikId == _income).ToList();
        }
    }
}
