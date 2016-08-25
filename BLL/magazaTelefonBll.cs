using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class magazaTelefonBll : sablon
    {
        ilanDataContext idc = new ilanDataContext();

        public void delete(int _id)
        {
            var _value = idc.magazaTelefons.Where(q => q.magazaTelefonId == _id).FirstOrDefault();

            if (_value != null)
            {
                idc.magazaTelefons.DeleteOnSubmit(_value);
                idc.SubmitChanges();
            }
        }

        public void insert(params object[] _income)
        {
            magazaTelefon magazaTlf = new magazaTelefon();
            magazaTlf.magazaId = Convert.ToInt32( _income[0]);
            magazaTlf.telefon = _income[1].ToString();
            magazaTlf.telefonTur = Convert.ToInt32(_income[2]);
            idc.magazaTelefons.InsertOnSubmit(magazaTlf);
            idc.SubmitChanges();
  
        }

        public void update(params object[] _income)
        {
            var _value = idc.magazaTelefons.Where(q => q.magazaId == Convert.ToInt32(_income[0]) & q.telefonTur == Convert.ToInt32(_income[1])).FirstOrDefault();
            if (_value != null)
            {
                _value.telefon = _income[2].ToString();
                idc.SubmitChanges();
            }
            else
            {
                magazaTelefon tlf = new magazaTelefon();

                tlf.telefon = (string)_income[2];
                tlf.telefonTur = Convert.ToInt32(_income[1]);
                tlf.magazaId = Convert.ToInt32(_income[0]);

                idc.magazaTelefons.InsertOnSubmit(tlf);
                idc.SubmitChanges();
            }
            
        }
        public magazaTelefon search(int _income,int _value)
        {
            return idc.magazaTelefons.Where(q => q.magazaId == _income & q.telefonTur == _value).FirstOrDefault();
        }

        public IEnumerable<magazaTelefon> list(params object[] _income)
        {

            if (_income[0].ToString() == "1")
            {
                return idc.magazaTelefons.Where(q => q.magazaId == Convert.ToInt32(_income[1])).ToList();
            }
            else
            {
                return idc.magazaTelefons.Where(q => q.magazaId == Convert.ToInt32(_income[1])).ToList();

            }
        }
    }
}
