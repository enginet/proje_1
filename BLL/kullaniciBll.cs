using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Web;


namespace BLL
{
    public class kullaniciBll : sablon
    {
        ilanDataContext idc = new ilanDataContext();
        kullanici kullanicid = new kullanici();

        public void delete(int _id)
        {
            //olmayacak
        }

        public void insert(params object[] _income)
        {
            kullanicid.kullaniciAdSoyad = (string)_income[0];
            kullanicid.sifre = (string)_income[1];
            kullanicid.email = (string)_income[2];
            kullanicid.rol = Convert.ToInt32(_income[3]);
            kullanicid.silindiMi = false;
            idc.kullanicis.InsertOnSubmit(kullanicid);
            idc.SubmitChanges();
        }

        public void update(params object[] _income)
        {
            // birinci parametre işlem türünü belirler.
            // birinci parametre 1 ise tüm bilgilerini günceller.
            // birinci parametre 2 ise silindi bilgisini günceller.
            // 2. parametre kullanıcı id değerini tutar.
            // 3 ve üzeri parametreler güncellencek bilgileri tutar

            var _value = idc.kullanicis.Where(q => q.kullaniciId == Convert.ToInt32(_income[1])).FirstOrDefault();
            if (_value != null)
            {
                if (Convert.ToInt32(_income[0]) == 1)
                {
                    // ad+soyad,şifre,email,il,ilçe,mahalle,krediSayısı,kimlikNo,egitimDurumu,Cinsiyet,rol(yetki)
                    _value.kullaniciAdSoyad = (string)_income[2];
                    //_value.sifre = (string)_income[3];
                    //_value.email = (string)_income[4];
                    _value.ilId = (int)_income[3];
                    _value.ilceId = (int)_income[4];
                    _value.mahalleId = (int)_income[5];
                    //_value.kredi = (int)_income[8];
                    _value.tckimlikNo = (string)_income[6];
                    _value.egitimDurumuId = (int)_income[7];
                    _value.meslekId = (int)_income[8];
                    _value.cinsiyetId = (bool)_income[9];
                    _value.rol = (int)_income[10];

                    idc.SubmitChanges();
                }
                else if (Convert.ToInt32(_income[0]) == 2)
                {
                    _value.silindiMi = (bool)_income[2];
                    idc.SubmitChanges();
                }
                else if (Convert.ToInt32(_income[0]) == 3)
                {
                    _value.kredi = Convert.ToInt32(_income[2]);
                    idc.SubmitChanges();
                }
                else if (Convert.ToInt32(_income[0]) == 4)
                {
                    _value.sifre = (string)_income[2];
                    idc.SubmitChanges();
                }
                else if (Convert.ToInt32(_income[0]) == 5)
                {
                    _value.tarayici = _income[2].ToString();
                    _value.sonGirisTarihi = DateTime.Now;
                    _value.ipAdres = _income[3].ToString();
                    idc.SubmitChanges();
                }

                else if (Convert.ToInt32(_income[0]) == 6)
                {
                    _value.online = DateTime.Now.AddMinutes(10);
                    idc.SubmitChanges();
                }
                else if (Convert.ToInt32(_income[0]) == 7)
                {
                    _value.online = DateTime.Now.AddMinutes(-10);
                    idc.SubmitChanges();
                }
            }

        }

        public IQueryable list(params object[] _income)
        {
            if (Convert.ToInt32(_income[0]) == 1)
            {
                var query = from k in idc.kullanicis.Where(k => k.silindiMi == false)
                            select new
                            {
                                k.profilResim,
                                k.kullaniciId,
                                k.kullaniciAdSoyad,
                                k.sonGirisTarihi

                            };
                return query;
            }
            else if (Convert.ToInt32(_income[0]) == 2)
            {
                var query = from k in idc.kullanicis.Where(k => k.silindiMi == false)
                            select new
                            {
                                k.profilResim,
                                k.kullaniciId,
                                k.kullaniciAdSoyad,
                                k.sonGirisTarihi

                            };
                return query;

            }
            else if (Convert.ToInt32(_income[0]) == 3)
            {
                var query = from k in idc.kullanicis.Where(k => k.silindiMi == false & k.rol==Convert.ToInt32(_income[1]))
                            select new
                            {
                               k.kullaniciId,
                               k.kullaniciAdSoyad,
                               k.email,
                               k.sonGirisTarihi
                            };
                return query;

            }
            else
            {
                var query = from k in idc.kullanicis.Where(k => k.silindiMi == false & (k.rol==1 | k.rol == 2| k.rol == 3) & DateTime.Compare(Convert.ToDateTime(k.online),DateTime.Now)>0)
                            select new
                            {

                                k.kullaniciId,
                                k.kullaniciAdSoyad,
                            };
                return query;
            }
       }


        //public IEnumerable<kullanici> list(int _income)
        //{
        //    // Role göre kullanıcı listeleme
        //    return idc.kullanicis.Where(q => q.rol == _income && q.silindiMi == false);
        //}

        public IEnumerable<kullanici> receiveList()
        {
            // düzeltilecek
            return idc.kullanicis.ToList();
        }

        public kullanici search(int _income)
        {
            // gelen kullanıcı id değerine göre tüm bilgileri getiriliyor.
            return idc.kullanicis.Where(q => q.kullaniciId == _income && q.silindiMi == false).FirstOrDefault();
        }

        public kullanici mail_search(string _income)
        {
            // gelen kullanıcı id değerine göre tüm bilgileri getiriliyor.
            return idc.kullanicis.Where(q => q.email == _income && q.silindiMi == false).FirstOrDefault();
        }


        public bool loginOn(string inusername, string inpassword)
        {
            // kullanıcı girişleri kontrolü
            var _control = idc.kullanicis.Where(q => q.email == inusername && q.sifre == inpassword && (q.rol == 1 | q.rol == 2 | q.rol == 3)).FirstOrDefault();
            if (_control != null)
            {


                    HttpContext.Current.Session["unique-user"] = _control;
                    HttpContext.Current.Session["unique-user-name"] = _control.kullaniciAdSoyad;
                return true;
            }

            else
            {
                return false;
            }
        }

        public bool userLoginOn(string inusername, string inpassword)
        {
            var _control = idc.kullanicis.Where(q => (q.email == inusername | q.telefonlars.Where(t=>t.telefonTur==1).FirstOrDefault().telefon.ToString()==inusername) & q.sifre == inpassword & (q.rol == 1 | q.rol == 2 | q.rol == 3 | q.rol==4)).FirstOrDefault();
            if (_control != null)
            {
                HttpContext.Current.Session["unique-site-user"] = _control;
                HttpContext.Current.Session["unique-site-user-name"] = _control.kullaniciAdSoyad;
                return true;
            }

            else
            {
                return false;
            }
        }

        public bool kullanici_varmi(string eposta, string cepTelefonu)
        {
            telefonlar tlf = idc.telefonlars.Where(q => q.telefon == cepTelefonu).FirstOrDefault();
            kullanici kll = idc.kullanicis.Where(q => q.email == eposta).FirstOrDefault();

            if (tlf != null || kll != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
