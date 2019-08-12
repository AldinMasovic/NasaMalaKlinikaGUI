using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika
{
    class Kartoteka
    {
        List<Karton> pok;

        internal List<Karton> Pok { get => pok; set => pok = value; }

        public Kartoteka()
        {
            Pok = new List<Karton>();
        }

        public Kartoteka(List<Karton> pok, int duzina)
        {
            this.Pok = pok;

        }
        public void DodajKarton(ref Karton x)
        {
            
            if (postojiLiKarton(x.Jmbg)) return;
            //treba pronaci karton ako postoji i samo ga dodijeliti
            Pok.Add(x);//ili ga samo povezi
            
        }
        public bool postojiLiKarton(string jmbg)
        {
            for(int i = 0; i < Pok.Count; i++)
            {
                if (Pok[i].Jmbg == jmbg) return true;
            }
            return false;
        }
        public Karton DajKartonNaPoziciji(int i)
        {
            return Pok[i];
        }
        public void IspisiSveKartone()
        {
            for(int i = 0; i < Pok.Count; i++)
            {
                Pok[i].IspisiSve();
            }
        }
        public  Karton DajKarton(string jmbg)
        {
            for(int i = 0; i < Pok.Count; i++)
            {
                if (Pok[i].Jmbg == jmbg) return  Pok[i];
            }
            return null;
        }
        public int duzina() { return Pok.Count; }
        public Karton Najposjeceniji()
        {
            int max = 0, index = 0;
            for(int i = 0; i < Pok.Count; i++)
            {
                if (Pok[i].Broj_dolazaka > max) { max = Pok[i].Broj_dolazaka;index = i; }
            }
            return Pok[index];
        }
        //dodaj metodu koja vraća karton obavezno!!!!
    }
}
