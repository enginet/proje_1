using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class bildirimBll : sablon
    {
        ilanDataContext idc = new ilanDataContext();
        bildirimler bildirimd = new bildirimler();

        public void delete(int _id)
        {
            throw new NotImplementedException(); //boş kalacak
        }

        public void insert(params object[] _income)
        {
            bildirimd.kimeId = Convert.ToInt32(_income[0]);
            bildirimd.konu = (string)_income[1];
            bildirimd.mesaj = (string)_income[2];
            idc.bildirimlers.InsertOnSubmit(bildirimd);
            idc.SubmitChanges();
        }

        public void update(params object[] _income)
        {
            var _value = idc.bildirimlers.Where(q => q.bildirimId == Convert.ToInt32(_income[1])).FirstOrDefault();
            if (_value != null)
            {
                if (Convert.ToInt32(_income[0]) == 1)
                {

                    _value.aliciSildiMi = true;
                    idc.SubmitChanges();
                }

                else if (Convert.ToInt32(_income[0]) == 3)
                {
                    _value.okunduMu = true;
                    idc.SubmitChanges();
                }
            }
        }

        public bildirimler search(int _income)
        {
            return idc.bildirimlers.Where(q => q.bildirimId == _income).FirstOrDefault();
        }

        public IQueryable list(params object[] _income)
        {
            if (Convert.ToInt32(_income[1]) == 1)
            {
                var query = from k in idc.kullanicis
                            join b in idc.bildirimlers
                            on k.kullaniciId equals b.kimeId
                            where b.kimeId ==Convert.ToInt32(_income[0]) & b.aliciSildiMi == false
                            select new
                            {
                                b.bildirimId,
                                b.konu,
                                b.tarih
                            };
                return query;
            }
            else if (Convert.ToInt32(_income[1]) == 2)
            {
                var query = from k in idc.kullanicis
                            join b in idc.bildirimlers
                            on k.kullaniciId equals b.kimeId
                            where b.kimeId == Convert.ToInt32(_income[0]) & b.aliciSildiMi == false
                            select new
                            {
                                b.bildirimId,
                                b.konu,
                                b.tarih
                            };
                return query;
            }
            else
            {
                var query = from k in idc.kullanicis
                            join b in idc.bildirimlers.Where(b=> b.kimeId == Convert.ToInt32(_income[0]) & b.aliciSildiMi == false & b.okunduMu==false)
                            on k.kullaniciId equals b.kimeId
                            select new
                            {
                                b.bildirimId,
                                b.konu,
                                b.tarih,
                            };
                return query;
            }

        }

        public int count(params object[] _income)
        {
            if(Convert.ToInt32(_income[0])==1)
            {
                var query = from k in idc.kullanicis
                            join b in idc.bildirimlers.Where(b => b.kimeId == Convert.ToInt32(_income[0]) & b.aliciSildiMi == false & b.okunduMu == false)
                            on k.kullaniciId equals b.kimeId
                            select new
                            {
                                b.bildirimId,

                            };
                return query.Count();

            }
            else
            {
                var query = from k in idc.kullanicis
                            join b in idc.bildirimlers.Where(b => b.kimeId == Convert.ToInt32(_income[0]) & b.aliciSildiMi == false & b.okunduMu == false)
                            on k.kullaniciId equals b.kimeId
                            select new
                            {
                                b.bildirimId,

                            };
                return query.Count();

            }

        }
    }
}
