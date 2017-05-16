using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDR2.Model
{
    public class SobeAdmin:Admin
    {
        List<Soba> sobe;

        public SobeAdmin(string us, string pass, string ime, string prezime, string adresa, string drzava, string email, string grad, string telefon, DateTime dat_rodjenja) : base(us, pass, ime, prezime, adresa, drzava, email, grad, telefon, dat_rodjenja)
        {
            Sobe = new List<Soba>();
        }

        public void ObrisiSobu(Soba s)
        {
            Sobe.Remove(s);
        }

        public void DodajSobu(Soba s)
        {
            Sobe.Add(s);
        }

        public void EditujSobu(Soba s, Soba editovana)
        {
            for(int i=0; i<Sobe.Count; i++)
            {
                if (Sobe[i] == s) s = editovana;
            }
        }

        public List<Soba> Sobe
        {
            get
            {
                return sobe;
            }

            set
            {
                sobe = value;
            }
        }
    }
}
