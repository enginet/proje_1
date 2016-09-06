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
            go.deger        = _income[2].ToString();

            idc.girilenIlanOzelliks.InsertOnSubmit(go);
            idc.SubmitChanges();
        }

        public void update(params object[] _income)
        {
            var _value = idc.girilenIlanOzelliks.Where(q => q.ilanId == Convert.ToInt32(_income[0]) & q.ozellikId == Convert.ToInt32(_income[1])).FirstOrDefault();

            if(_value!=null)
            {
                if(_income[2].ToString()=="")
                {
                    idc.girilenIlanOzelliks.DeleteOnSubmit(_value);
                }
                else
                {
                    _value.deger = _income[2].ToString();
                }

                idc.SubmitChanges();
            }
            else
            {
                girilenIlanOzellik go = new girilenIlanOzellik();
                go.ilanId = Convert.ToInt32(_income[0]);
                go.ozellikId = Convert.ToInt32(_income[1]);
                go.deger = _income[2].ToString();

                idc.girilenIlanOzelliks.InsertOnSubmit(go);
                idc.SubmitChanges();
            }
        }

        public girilenIlanOzellik search(int ilanId,int ozellikId)
        {
            var value= idc.girilenIlanOzelliks.Where(q => q.ilanId == ilanId & q.ozellikId == ozellikId).FirstOrDefault();
            return value;
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
