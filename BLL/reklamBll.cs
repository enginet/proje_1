using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class reklamBll : sablon
    {
        ilanDataContext idc = new ilanDataContext();

        reklam rklm = new reklam();

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


        //public IQueryable list(params object[] _income)
        //{

        //}

        public reklam search(params object[] _income)
        {
            // verilen ve güncellenen bilginin tür bilgilerine göre reklamın türünü (id değerini) bulur
            if((int)_income[0]==1) // reklam türü site içi reklam ise
            {
                return idc.reklams.Where(
                    q => q.reklamTurId == Convert.ToInt32(_income[0]) &&
                    q.reklamKonumuId == Convert.ToInt32(_income[1])
                    ).FirstOrDefault();
            }
            else // reklam türü harita çevresi reklam ise
            {
                return idc.reklams.Where(q => q.reklamTurId == (int)_income[0]).FirstOrDefault();
            }
        }

        public reklam searchId(int _income)
        {
            // gelen id değerine göre verilen reklamın tür bilgilerini geri döndürür

            return idc.reklams.Where(q => q.reklamId == _income).FirstOrDefault();
        }
    }
}
