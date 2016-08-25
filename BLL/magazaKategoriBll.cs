using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class magazaKategoriBll : sablon
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

        public magazaKategori search(params object[] _income)
        {
            if (Convert.ToInt32(_income[0]) == 1)
            {
                return idc.magazaKategoris.Where(q => q.kategoriId == Convert.ToInt32(_income[1]) & q.paketSureId == Convert.ToInt32(_income[2]) & q.magazaPaketId == Convert.ToInt32(_income[3])).FirstOrDefault();
            }
            else
            {
                return idc.magazaKategoris.Where(q => q.magazaKategoriId == Convert.ToInt32(_income[1])).FirstOrDefault();
            }
        }
    }
}
