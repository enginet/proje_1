using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class odemeBll : sablon
    {
        ilanDataContext idc = new ilanDataContext();
        public void delete(int _id)
        {
            var _value = idc.odemes.Where(q => q.odemeId == _id).FirstOrDefault();

            if(_value!=null)
            {
                idc.odemes.DeleteOnSubmit(_value);
                idc.SubmitChanges();
            }
        }

        public void insert(params object[] _income)
        {
            odeme odm = new odeme();

            odm.kullaniciId = Convert.ToInt32(_income[0]);
            odm.odemeTutar = Convert.ToDouble(_income[1]);
            odm.islemId = Convert.ToInt32(_income[2]);
            odm.odemeTipId = Convert.ToInt32(_income[3]);
            if(_income[4].ToString()!="")
            {
                odm.kartNo = _income[4].ToString();
            }
            odm.basariliMi = Convert.ToBoolean(_income[5]);

            idc.odemes.InsertOnSubmit(odm);
            idc.SubmitChanges();
        }

        public void update(params object[] _income)
        {
            throw new NotImplementedException();
        }
        

        public IEnumerable<odeme> list(int kullaniciId)
        {
            return idc.odemes.Where(q => q.kullaniciId == kullaniciId).ToList();
        }
    }
}
