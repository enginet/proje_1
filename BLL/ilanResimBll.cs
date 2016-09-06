using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ilanResimBll : sablon
    {
        ilanDataContext idc = new ilanDataContext();

        public void delete(int _id)
        {
            idc.ilanResims.Where(x => x.ilanId == _id).ToList().ForEach(idc.ilanResims.DeleteOnSubmit);
            idc.SubmitChanges();
        }

        public void insert(params object[] _income)
        {
            // 1.parametre ilan id değerini tutar
            // 2. parametre ilan resim adını tutar.
            // 3.paramatre resim türünü tutar.

            ilanResim ir = new ilanResim();

            ir.ilanId = Convert.ToInt32(_income[0]);
            ir.resim = (string)_income[1];
            ir.seciliMi = (bool)_income[2];

            idc.ilanResims.InsertOnSubmit(ir);
            idc.SubmitChanges();

        }

        public ilanResim search(object _income)
        {
            //Convert.ToInt32(r.resim.ToString().Split('_')[1].Split('.')[0]) == 1
            return idc.ilanResims.Where(r => r.ilanId == Convert.ToInt32(_income) ).FirstOrDefault();
        }

        public void update(params object[] _income)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ilanResim> list(params object[] _income)
        {
            if (Convert.ToInt32(_income[0]) == 1)
            {
                return idc.ilanResims.Where(r => r.ilanId == Convert.ToInt32(_income[1]));
            }
            else
            {
                return idc.ilanResims.Where(r => r.ilanId == Convert.ToInt32(_income[1]));
            }
        }
    }
}
