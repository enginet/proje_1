using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.Objects;

namespace BLL
{
    public class ziyaretciBll
    {
        ilanDataContext idc = new ilanDataContext();
        ziyaretci ziyaretcid = new ziyaretci();

        public void AddVisitorCounter(params object[] _income)
        {
            DateTime today = DateTime.Now.Date;
            var query = idc.ziyaretcis.Where(z => z.ipAdres.Equals(_income[0]) & DateTime.Equals(today, z.sonGirisTarihi) & z.ilanId == Convert.ToInt32(_income[1])).FirstOrDefault();
            if (query == null)
            {
                ziyaretcid.ipAdres = _income[0].ToString();
                ziyaretcid.ilanId = Convert.ToInt32(_income[1]);
                ziyaretcid.sonGirisTarihi = DateTime.Now.Date;
                idc.ziyaretcis.InsertOnSubmit(ziyaretcid);

                idc.SubmitChanges();
            }
        }

        public int GetCount(int ilanId)
        {
            int sayac = 0;

            var sonuc = (from p in idc.ziyaretcis where p.ilanId == ilanId select new { }).Count();
            sayac = sonuc;

            return sayac;
        }

    }
}
