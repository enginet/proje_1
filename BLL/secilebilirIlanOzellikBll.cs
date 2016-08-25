using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class secilebilirIlanOzellikBll : sablon
    {
        ilanDataContext idc = new ilanDataContext();
        public void delete(int _id)
        {
            throw new NotImplementedException();
        }

        public secilebilirIlanOzellik search(int ilanId, int ozellikDegerId)
        {
            return idc.secilebilirIlanOzelliks.Where(q => q.ilanId == ilanId & q.secilebilirOzellikDeger.ozellikId == ozellikDegerId).FirstOrDefault();
        }

        public IEnumerable<secilebilirIlanOzellik> searchCheckBox(int ilanId)
        {
            return idc.secilebilirIlanOzelliks.Where(q => q.ilanId == ilanId).ToList();
        }

        public bool checkBoxKontrol(int ilanId, int ozellikId)
        {
            var value = idc.secilebilirIlanOzelliks.Where(q => q.ilanId == ilanId & q.ozellikDegerId == ozellikId).FirstOrDefault();

            if (value != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void deleteGroupCheckBox(params object[] _income)
        {
            // 1. parametre ilan ID
            // 2. parametre secilebilir ozellik ID

            var _value = idc.secilebilirIlanOzelliks.Where(q => q.ilanId == Convert.ToInt32(_income[0]) & q.ozellikDegerId == Convert.ToInt32(_income[1])).FirstOrDefault();

            if (_value != null)
            {
                idc.secilebilirIlanOzelliks.DeleteOnSubmit(_value);
                idc.SubmitChanges();
            }
        }

        public void insert(params object[] _income)
        {
            secilebilirIlanOzellik so = new secilebilirIlanOzellik();

            so.ilanId           = Convert.ToInt32(_income[0]);
            so.ozellikDegerId   = Convert.ToInt32(_income[1]);

            idc.secilebilirIlanOzelliks.InsertOnSubmit(so);
            idc.SubmitChanges();
        }

        public void update(params object[] _income)
        {
            throw new NotImplementedException();
        }

        public IQueryable list(params object[] _income)
        {
            if (Convert.ToInt32(_income[0]) == 1)
            {
                var query = from g in idc.secilebilirIlanOzelliks.Where(g => g.ilanId == Convert.ToInt32(_income[1]) & g.secilebilirOzellikDeger.ozellik.secilebilirMi == 1)
                            select new
                            {
                                g.secilebilirOzellikDeger.ozellik.ozellikAdi,
                                g.secilebilirOzellikDeger.deger
                            };

                return query;
            }
            else
            {
                var query = from g in idc.secilebilirIlanOzelliks.Where(g => g.ilanId == Convert.ToInt32(_income[1]) & g.secilebilirOzellikDeger.ozellik.secilebilirMi == 1)
                            select new
                            {
                                g.secilebilirOzellikDeger.ozellik.ozellikAdi,
                                g.secilebilirOzellikDeger.deger
                            };

                return query;

            }
        }


        public IQueryable searchAll(int _income)
        {
            var query = from si in idc.secilebilirIlanOzelliks
                        join sod in idc.secilebilirOzellikDegers on si.ozellikDegerId equals sod.secilebilirOzellikDegerId
                        where
                        si.ozellikDegerId == _income
                        select new
                        {
                            sod.ozellikId,
                            si.ozellikDegerId
                        };
            return query;
        }
    }
}
