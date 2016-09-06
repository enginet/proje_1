using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class acilIlanBll : sablon
    {
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

        ilanDataContext idc = new ilanDataContext();
        ilanBll ilanb = new ilanBll();
        public IQueryable ilanGetir(params object[] _income)
        {

            var query = from i in idc.ilans.Where(i => i.onay == 1 & i.silindiMi == false & i.pasifMi == false)
                        join d in idc.seciliDopings.Where(d => d.dopingKategori.doping.dopingId == 5 & d.pasifMi == false & d.onay == true)
                        on i.ilanId equals d.ilanId
                        join r in idc.ilanResims.Where(r => r.seciliMi == true)
                        on i.ilanId equals r.ilanId
                        select new
                        {
                            i.ilanId,
                            i.baslik,
                            i.fiyat,
                            r.resim,
                            i.iller.ilAdi,
                            i.ilceler.ilceAdi,
                            i.mahalleler.mahalleAdi,
                            i.baslangicTarihi,
                            i.magazaId,
                            i.ilanTurId,
                            i.ilId,
                            i.magaza.magazaTur.turId
                        };

            if(_income[0].ToString()!="")
            {
                query = query.Where(q => q.ilId == Convert.ToInt32(_income[0]));
            }

            return query;
        }
    }
}
