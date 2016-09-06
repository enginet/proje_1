using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class magazaBll : sablon
    {
        ilanDataContext idc = new ilanDataContext();
        magaza magazad = new magaza();
        magazaKullanici magazaKlld = new magazaKullanici();
        public void delete(int _id)
        {
            throw new NotImplementedException();
        }

        public void insert(params object[] _income)
        {
            magazad.magazaAdi = (string)_income[0];
            magazad.kurumsalMi = bool.Parse(_income[1].ToString());
            magazad.ilId = Convert.ToInt32(_income[2]);
            magazad.ilceId = Convert.ToInt32(_income[3]);
            magazad.mahalleId = Convert.ToInt32(_income[4]);
            magazad.vergiNo = _income[5].ToString();
            magazad.vergiDaireId = Convert.ToInt32(_income[6]);
            magazad.onay = true;
            idc.magazas.InsertOnSubmit(magazad);
            idc.SubmitChanges();
        }

        public void update(params object[] _income)
        {
            var _value = idc.magazas.Where(q => q.magazaId == Convert.ToInt32(_income[1])).FirstOrDefault();
            if (_value != null)
            {
                if (Convert.ToInt32(_income[0]) == 1)
                {

                    _value.silindiMi = true;
                    idc.SubmitChanges();

                }
                if (Convert.ToInt32(_income[0]) == 2)
                {
                    _value.magazaKategoriId = Convert.ToInt32(_income[2]);
                    _value.magazaTurId = Convert.ToInt32(_income[3]);
                    _value.magazaAdi = _income[4].ToString();
                    _value.magazaLogo = _income[5].ToString();
                    _value.bitisTarihi = Convert.ToDateTime(_income[6]);
                    _value.aciklama = _income[7].ToString();
                    _value.onay = false;
                    idc.SubmitChanges();

                }
                if (_income[0].ToString() == "3")
                {
                    _value.onay = (bool)_income[2];
                    _value.silindiMi = (bool)_income[3];
                    _value.pasifMi = (bool)_income[4];
                }
                if (_income[0].ToString() == "4")
                {
                    _value.magazaAdi = _income[2].ToString();
                    _value.kurumsalMi = bool.Parse(_income[3].ToString());
                    _value.ilId = Convert.ToInt32(_income[4]);
                    _value.ilceId = Convert.ToInt32(_income[5]);
                    _value.mahalleId = Convert.ToInt32(_income[6]);
                    _value.vergiNo = _income[7].ToString();
                    _value.vergiDaireId = Convert.ToInt32(_income[8]);
                }
                idc.SubmitChanges();

            }
        }

        public IQueryable list(params object[] _income)
        {

            if (Convert.ToInt32(_income[0]) == 1)
            {
                var query = from m in idc.magazas.Where(m => m.silindiMi == (bool)_income[1] & m.pasifMi == (bool)_income[2] & m.onay == (bool)_income[3])
                            select new
                            {
                                m.magazaTur.kategori.kategoriAdi,
                                m.magazaId,
                                m.magazaAdi,
                                m.magazaKategori.magazaPaketId
                            };

                return query;
            }
             else if  (Convert.ToInt32(_income[0]) == 2)
            {
                var query = from m in idc.magazas.Where(m => m.silindiMi == false & m.pasifMi == false & m.onay == true)
                            select new
                            {
                                m.magazaTur.kategori.kategoriAdi,
                                m.magazaId,
                                m.magazaAdi,
                                m.magazaKategori.magazaPaketId
                            };

                return query;
            }
            else
            {
                var query = from m in idc.magazas.Where(m => m.silindiMi == false & m.pasifMi == false & m.onay == true & m.magazaKategoriId==null & m.vergiDaireId==null & m.vergiNo==null)
                            select new
                            {
                                m.magazaId,
                                m.magazaAdi,
                            };

                return query;
            }

        }

        public IEnumerable<magaza> ielist()
        {
            return idc.magazas.ToList();
        }

        public magaza search(int _income)
        {
            return idc.magazas.Where(q => q.magazaId == _income).FirstOrDefault();
        }
    }
}
