using Klinika.Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika
{
    abstract class Osoba
    {
        String ime;
        String prezime;
        String jmbg;
        String username;
        String passwrod;
        //Validacije v = new Validacije();
        public Osoba(string ime, string prezime, String jmbg)
        {
            Ime= ime;
            Prezime = prezime;
            Jmbg = jmbg;
            
        }
        
        public string Ime
        {
            get => ime;
            set
            {
                if (Validacije.validateNaziv(value)) ime = value;
                else throw new ArgumentException("Pogrešan unos imena");
            }
        }
        public string Prezime { get => prezime;
                set
                {
                if (Validacije.validateNaziv(value)) prezime = value;
                else throw new ArgumentException("Pogrešno ste unijeli prezime");
                }
            }
        public string Jmbg { get => jmbg;
            set 
                {
                if (Validacije.validnostJMBG(value))
                    jmbg = value;
                else throw new ArgumentException("Pogrešno ste unijeli JMBG");
            }
        }
        //doradi
        public override string ToString()
        {
            return Ime + " " + Prezime;
        }

        public string Username { get => username; set => username = value; }
        public string Passwrod { get => passwrod; set => passwrod = value; }
        
    }
}
