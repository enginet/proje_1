using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DAL;

namespace BLL
{
    public class telefonBll:sablon
    {
        ilanDataContext idc = new ilanDataContext();

        telefonlar tlf = new telefonlar();

        public void delete(int _id)
        {
            throw new NotImplementedException();
        }

        public void deleteTlf(params object[] _income)
        {
            // 1. parametre kullanici Id
            // 2. parametre telefon tur Id

            var _value = idc.telefonlars.Where(q => q.kullaniciId == Convert.ToInt32(_income[0]) && q.telefonTur == Convert.ToInt32(_income[1])).FirstOrDefault();

            if (_value != null)
            {
                idc.telefonlars.DeleteOnSubmit(_value);
                idc.SubmitChanges();
            }
        }

        public void insert(params object[] _income)
        {
            // 1. parametre ( _income[0] ) kullanıcı id değerini tutuyor
            // 2. parametre ( _income[1] ) telefon numarası değerini tutuyor

            tlf.kullaniciId = (int)_income[0];
            tlf.telefon = (string)_income[1];

            idc.telefonlars.InsertOnSubmit(tlf);
            idc.SubmitChanges();

        }

        public void update(params object[] _income)
        {
            // 1. parametre kullanici Id değerini tutar
            // 2. parametre telefon numarasını tutar
            // 3.parametre telefon türünü tutar


            var _value = idc.telefonlars.Where(q => q.kullaniciId == Convert.ToInt32(_income[0]) && q.telefonTur == Convert.ToInt32(_income[2])).FirstOrDefault();

            if (_value != null)
            {
                _value.telefon = (string)_income[1];
                idc.SubmitChanges();
            }
            else
            {
                telefonlar tlf = new telefonlar();

                tlf.telefon = (string)_income[1];
                tlf.telefonTur = Convert.ToInt32(_income[2]);
                tlf.kullaniciId = Convert.ToInt32(_income[0]);

                idc.telefonlars.InsertOnSubmit(tlf);
                idc.SubmitChanges();
            }
        }

        public telefonlar search(params object[] _income)
        {
            // gelen kullanıcı id ye göre telefonlar geri gönderiliyor.
            return idc.telefonlars.Where(q => q.kullaniciId ==(int)_income[0] & q.telefonTur==(int)_income[1]).FirstOrDefault();
        }

        public IEnumerable<telefonlar> list(params object[] _income)
        {
            if (_income[0].ToString() == "1")
            {
                return idc.telefonlars.Where(q => q.kullaniciId == Convert.ToInt32(_income[1]) & q.telefonTur == Convert.ToInt32(_income[2])).ToList();
            }
            else
            {
                return idc.telefonlars.Where(q => q.kullaniciId == Convert.ToInt32(_income[1])).ToList();
            }
        }
    }
}
