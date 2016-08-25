using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class guvenlikKodlariBll : sablon
    {
        ilanDataContext idc = new ilanDataContext();
        guvenlikKodlari guvenlikb = new guvenlikKodlari();
        public void delete(int _id)
        {
            throw new NotImplementedException();
        }

        public void insert(params object[] _income)
        {
            guvenlikb.cepTelefonu = _income[0].ToString();
            guvenlikb.guvenlikKodu = _income[1].ToString();
            idc.guvenlikKodlaris.InsertOnSubmit(guvenlikb);
            idc.SubmitChanges();
        }

        public void update(params object[] _income)
        {
            var _value = idc.guvenlikKodlaris.Where(q => q.cepTelefonu == _income[0].ToString()).FirstOrDefault();

            if (_value != null)
            {
                _value.guvenlikKodu = (string)_income[1];
                idc.SubmitChanges();
            }
        }

        public guvenlikKodlari search(string _income)
        {
            return idc.guvenlikKodlaris.Where(q => q.guvenlikKodu == _income).FirstOrDefault();
        }

        public guvenlikKodlari sec_search(string _income)
        {
            return idc.guvenlikKodlaris.Where(q => q.cepTelefonu == _income).FirstOrDefault();
        }
    }
}
