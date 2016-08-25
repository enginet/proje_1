using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class girilebilirIlanOzellikBll : sablon
    {
        ilanDataContext idc = new ilanDataContext();
        public void delete(int _id)
        {
            throw new NotImplementedException();
        }

        public void insert(params object[] _income)
        {
            girilenIlanOzellik go = new girilenIlanOzellik();
            go.ilanId       = Convert.ToInt32(_income[0]);
            go.ozellikId    = Convert.ToInt32(_income[1]);
            go.deger        = (string)_income[2];

            idc.girilenIlanOzelliks.InsertOnSubmit(go);
            idc.SubmitChanges();
        }

        public void update(params object[] _income)
        {
            throw new NotImplementedException();
        }

        public girilenIlanOzellik search(params object[] _income)
        {
            return idc.girilenIlanOzelliks.Where(g => g.ilanId == Convert.ToInt32(_income[0]) & g.ozellikId == Convert.ToInt32(_income[1])).FirstOrDefault();
        }

        public IQueryable list(params object[] _income)
        {
            if (Convert.ToInt32(_income[0]) == 1)
            {
                var query = from g in idc.girilenIlanOzelliks.Where(g => g.ilanId == Convert.ToInt32(_income[1]) & g.ozellik.secilebilirMi == 0)
                            select new
                            {
                                g.ozellik.ozellikAdi,
                                g.deger
                            };

                return query;
            }
            else
            {
                var query = from g in idc.girilenIlanOzelliks.Where(g => g.ilanId == Convert.ToInt32(_income[1]) & g.ozellik.secilebilirMi == 0)
                            select new
                            {
                                g.ozellik.ozellikAdi,
                                g.deger
                            };
                return query;

            }
        }
    }
}
