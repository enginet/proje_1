using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface sablon
    {   
        void insert(params object[] _income);

        void update(params object[] _income);

        void delete(int _id);

        //IEnumerable<Kategori> select();

    }
}
