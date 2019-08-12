using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika
{
    class Oboljenja
    {
        string aktivnebolesti;
        string aktivnealergije;
        string pasivnebolesti;
        string pasivnealergije;
        public Oboljenja(string ab,string aa,string pb,string pa) {
            Aktivnebolesti = ab;
            Aktivnealergije = aa;
            Pasivnealergije = pa;
            Pasivnebolesti = pb;
        }

        public string Aktivnebolesti { get => aktivnebolesti; set => aktivnebolesti = value; }
        public string Aktivnealergije { get => aktivnealergije; set => aktivnealergije = value; }
        public string Pasivnebolesti { get => pasivnebolesti; set => pasivnebolesti = value; }
        public string Pasivnealergije { get => pasivnealergije; set => pasivnealergije = value; }
    }
}
