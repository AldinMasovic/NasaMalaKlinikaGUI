using Klinika.Osoblje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aldin;

namespace Klinika
{
    partial class Doktor:Osoba, IIspisiIme
    {
        int plata;
        int brojpacijenata;
        bool prisutan;

        public Doktor(string ime, string prezime, string jmbg, int plata, bool prisutan):base(ime,prezime,jmbg)
        {
            //this.ime = ime;
            //this.prezime = prezime;
            //this.jmbg = jmbg;
            this.plata = plata;
            this.prisutan = prisutan;
            brojpacijenata = 0;
        }

        //public string Ime { get => ime; set => ime = value; }
        //public string Prezime { get => prezime; set => prezime = value; }
        //public int Jmbg { get => jmbg; set => jmbg = value; }
        public int Plata
        {
            get => plata;
            set
            {
                if (value > 0)
                    plata = value;
                else
                    Console.WriteLine("Greksa plate treba biti pozitivna");
            }
        }
        public int Brojpacijenata { get => brojpacijenata; set => brojpacijenata = value; }
        public bool Prisutan { get => prisutan; set => prisutan = value; }
        public void PromjeniPrisustvo()
        {
            if (prisutan) prisutan = false;
            else prisutan = true;
        }
        public override string ToString()
        {
            return Ime+" "+Prezime;
        }

        public void ispisiIme()
        {
            Console.WriteLine(Ime);
            Aldin.Class1.funkcija();
        }

    }
}
