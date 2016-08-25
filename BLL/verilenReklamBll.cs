using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class verilenReklamBll : sablon
    {
        ilanDataContext idc = new ilanDataContext();
        verilenReklam verReklam = new verilenReklam();
        public void delete(int _id)
        {
            throw new NotImplementedException();
        }

        public void insert(params object[] _income)
        {
            // reklamId, kullaniciId,reklamAdi,reklamResim,ilId,baslangicTarih,bitisTarih,reklamLinkonay

            verReklam.reklamId          = (int)_income[0];
            verReklam.kullaniciId       = (int)_income[1];
            verReklam.reklamAdi         = (string)_income[2];
            verReklam.reklamResim       = (string)_income[3];

            if(_income[4].ToString()!="null")
            {
                verReklam.ilId          = Convert.ToInt32(_income[4]);
            }

            verReklam.baslangicTarihi   = (DateTime)_income[5];
            verReklam.bitisTarihi       = (DateTime)_income[6];
            verReklam.reklamLink        = (string)_income[7];
            verReklam.pasifMi           = (bool)_income[8];
            verReklam.onay              = (bool)_income[9];

            idc.verilenReklams.InsertOnSubmit(verReklam);
            idc.SubmitChanges();
        }

        public void update(params object[] _income)
        {
            // 1. parametre 1 ise onay update eder
            // 1. parametre 2 ise pasif update eder
            // 1. parametre 3 ise diğer bilgileri update eder
            // 2. parametre verilen reklam id değerini tutar.
            // 3 ve üzeri parametre güncellencek bilgileri tutar.

            var _value = idc.verilenReklams.Where(q => q.verilenReklamId == Convert.ToInt32(_income[1])).FirstOrDefault();
            if(_value!=null)
            {
                if (_income[0].ToString() == "1")
                {
                    _value.onay = (bool)_income[2];
                }
                if (_income[0].ToString() == "2")
                {
                    _value.pasifMi = (bool)_income[2];
                    _value.onay = (bool)_income[3];
                }
                if (_income[0].ToString() == "3")
                {
                    // vReklamId, kullaniciId, reklamAdi, reklamId, il, baslangicTar.ToShortDateString(), bitisTar.ToShortDateString(), false, true
                    _value.kullaniciId = Convert.ToInt32(_income[2]);
                    _value.reklamAdi = _income[3].ToString();
                    _value.reklamId = Convert.ToInt32(_income[4]);
                    if(_income[5].ToString()!="null")
                    {
                        _value.ilId = Convert.ToInt32(_income[5]);
                    }
                    _value.baslangicTarihi = Convert.ToDateTime(_income[6]);
                    _value.bitisTarihi = Convert.ToDateTime(_income[7]);
                    _value.pasifMi = Convert.ToBoolean(_income[8]);
                    _value.onay = Convert.ToBoolean(_income[9]);
                }
                if (Convert.ToInt32(_income[0]) == 4)
                {
                    _value.reklamResim = (string)_income[2];
                }

                idc.SubmitChanges();
            }
        }

        public IEnumerable<verilenReklam> receiveList(bool pasif,bool onay)
        {
            //gelen parametrelere göre tüm reklamları getirdik
            return idc.verilenReklams.Where(q=>q.pasifMi==pasif && q.onay==onay).ToList();
        }

        public verilenReklam search(int _income)
        {
            return idc.verilenReklams.Where(q => q.verilenReklamId == _income).FirstOrDefault();
        }

        public IQueryable list(params object[] _income)
        {
            // gelen parametrelere bağlı olarak veri döndürülür.
            if (Convert.ToInt32(_income[0]) == 1)
            {
                var query = 
                            from v in idc.verilenReklams.Where(v => v.kullanici.kullaniciId == v.kullaniciId & v.reklam.reklamId == v.reklamId)
                        where
                                v.pasifMi == (bool)_income[1] &&
                                v.onay == (bool)_income[2]
                            select new
                            {
                                v.kullanici.kullaniciAdSoyad,
                                v.verilenReklamId,
                                v.reklamAdi,
                                v.baslangicTarihi,
                                v.bitisTarihi,
                                v.ilId,
                                v.reklam.reklamId,
                                v.reklam.reklamTurId,
                                v.reklam.reklamKonumuId
                            };

                return query;
            }

            else 
            {
                var query = 
                            from v in idc.verilenReklams.Where(v => v.kullaniciId==Convert.ToInt32(_income[3]) & v.pasifMi == (bool)_income[1] & v.onay == (bool)_income[2])
                            join k in idc.kullanicis
                            on v.kullaniciId equals k.kullaniciId
                            select new
                            {
                                v.verilenReklamId,
                                v.reklamAdi,
                                v.baslangicTarihi,
                                v.bitisTarihi,
                                v.reklam.fiyat,
                                v.reklamResim,
                                v.iller.ilAdi,
                                v.reklam.reklamId,
                                v.reklam.reklamTurId,
                                v.reklam.reklamKonumuId
                            };
                return query;
            }
        }
        
    }
}
