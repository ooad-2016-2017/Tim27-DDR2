using DDR2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDR2.ViewModel
{
    class OsobljeVM
    {
        public string Posao(Uposlenik u)
        {
            return u.GetType().ToString();
        }
    }
}
