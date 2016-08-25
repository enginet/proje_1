using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace BLL
{
    public class araBll
    {
        ilanDataContext idc = new ilanDataContext();
        public IQueryable list(object _income)
        {
            var query = from i in idc.ilans.Where(i => i.silindiMi == false & i.onay == 1 & i.pasifMi == false)
                        where i.baslik.Contains(_income.ToString()) || i.ilanId.ToString().Contains(_income.ToString())
                        select new
                        {
                            i
                        };

            return query;
        }

    }
}
