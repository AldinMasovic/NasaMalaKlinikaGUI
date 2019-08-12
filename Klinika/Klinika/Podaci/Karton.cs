using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika
{
    sealed class Karton
    {
        Image slika;
        string ime;
        string prezime;
        DateTime datum_rodjenja;
        string jmbg;
        Spol spol;
        string adresa;
        Bracnostanje bracno_stanje;
        DateTime datum_prijema;
        List<string> misljenja;
        List<string> potpisi;
        List<string> ordinacije;
        List<string> terapije;
        List<Pregled> pregledi;
        List<Pregled> pregledano;
        Oboljenja oboljenja;
        double dug;
        int broj_dolazaka;
        int racun;
        int rate;
        String username;
        String password;
        //int brojac;
        List<DateTime> datumi;
        List<Prva_pomoc> hitne;
        public override string ToString()
        {
            return ime + " " + Prezime;
        }
        public Karton(string ime, string prezime, DateTime datum, string jmbg, Spol musko, string adresa, Bracnostanje bracno_stanje, DateTime datumprijema
            ,string bolesti,string alergije,string bolesti1,string alergije1)
        {
            hitne = new List<Prva_pomoc>();
            Terapije = new List<string>();
            pregledano = new List<Pregled>();
            rate = 0;
            Oboljenja = new Oboljenja(bolesti, alergije, bolesti1, alergije1);
            broj_dolazaka = 0;
            racun = 0;
            dug = 0;
            this.ime = ime;
            this.prezime = prezime;
            Datum_rodjenja = datum;
            this.jmbg = jmbg;
            this.Spol = musko;
            this.adresa = adresa;
            this.Bracno_stanje = bracno_stanje;
            Datum_prijema = datumprijema;
            Misljenja = new List<string>();
            Potpisi = new List<string>();
            Ordinacije = new List<string>();
            Pregledi = new List<Pregled>();
            Datumi = new List<DateTime>();
        }
        public void DodajHitniPregled(Prva_pomoc l)
        {
            hitne.Add(l);
        }
        public void IspisiHitnepreglede()
        {
            for(int i = 0; i < hitne.Count; i++)
            {
                Console.WriteLine("Opis: {0}",hitne[i].Opis);
                Console.WriteLine("Razlog: {0}",hitne[i].Razlog);
                Console.WriteLine("Datum: {0}",hitne[i].Datum);
            }
        }
        public Karton() { }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Jmbg { get => jmbg; set => jmbg = value; }
        public string Adresa { get => adresa; set => adresa = value; }
        public double Dug { get => dug; set => dug = value; }
        public int Broj_dolazaka { get => broj_dolazaka; set => broj_dolazaka = value; }
        public int Broj_dolazaka1 { get => broj_dolazaka; set => broj_dolazaka = value; }
        public int Racun { get => racun; set => racun = value; }
        public int Rate { get => rate; set => rate = value; }
        internal Bracnostanje Bracno_stanje { get => bracno_stanje; set => bracno_stanje = value; }
        internal Spol Spol { get => spol; set => spol = value; }
        public DateTime Datum_rodjenja { get => datum_rodjenja; set => datum_rodjenja = value; }
        public DateTime Datum_prijema { get => datum_prijema; set => datum_prijema = value; }
        internal Oboljenja Oboljenja { get => oboljenja; set => oboljenja = value; }
        internal List<Pregled> Pregledi { get => pregledi; set => pregledi = value; }
        public List<string> Misljenja { get => misljenja; set => misljenja = value; }
        public List<string> Potpisi { get => potpisi; set => potpisi = value; }
        public List<string> Ordinacije { get => ordinacije; set => ordinacije = value; }
        public List<string> Terapije { get => terapije; set => terapije = value; }
        public List<DateTime> Datumi { get => datumi; set => datumi = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public Image Slika { get => slika; set => slika = value; }

        public void MisljenjeDoktora(string misljenje,string terapija,string potpis,string ordinacija,DateTime datum)
        {
            //pregledano.Zavrseno(misljenje,terapija,)
            Misljenja.Add(misljenje);Potpisi.Add(potpis);Ordinacije.Add(ordinacija);Terapije.Add(terapija);
            Datumi.Add(datum);
        }
        public void Ispisi_misljenja_doktora()
        {
            Console.WriteLine();
            for(int i = 0; i < Misljenja.Count; i++)
            {
                Console.WriteLine("Ordinacija: {0}", Ordinacije[i]);
                Console.WriteLine("Misljenje: {0}", Misljenja[i]);
                Console.WriteLine("Terapija: {0}", Terapije[i]);
                Console.WriteLine("Datum: {0}", Datumi[i]);
                Console.WriteLine("Potpis: {0}", Potpisi[i]);
                Console.WriteLine();
            }
        }
        public void SortirajPreglede()
        {
            Pregledi.Sort(delegate (Pregled x, Pregled y)
            {
                if (x.Broj_u_redu <= y.Broj_u_redu) return 0;
                else return 1;
            });
        }
        public void Ispisi()
        {
            Console.WriteLine("Ime: {0}", this.Ime);
            Console.WriteLine("Prezime: {0}", this.Prezime);
            Console.WriteLine("Godina rodjenja: {0}", Datum_rodjenja);
            Console.WriteLine("JMBG: {0}", this.Jmbg);
            string s;if ((int)Spol==1) s = "Musko"; else s = "Zensko";
            Console.WriteLine("Spol: {0}",s );
            Console.WriteLine("Adresa: {0}", this.Adresa);
            if ((int)Bracno_stanje == 1) s = "Slobodan"; else if ((int)Bracno_stanje == 2) s = "Razveden"; else s = "U braku";
            Console.WriteLine("Bracno stanje: {0}", s);
            Console.WriteLine("Datum prijema: {0}", Datum_prijema);
            Ispisi_misljenja_doktora();
        }
        public void DodajPregled(Pregled l) { pregledi.Add(l); }
        public bool Postoji_Li_Pregled(string naziv)
        {
            for(int i = 0; i < Pregledi.Count; i++)
            {
                if (Pregledi[i].Preglede == naziv) return true;
            }
            return false;
        }
        public  Pregled DajPregled(string naziv)
        {
            for (int i = 0; i < Pregledi.Count; i++)
            {
                if (Pregledi[i].Preglede == naziv) return Pregledi[i];
            }
            return null;
        }
        public void IspisiPreglede()
        {
            if (Pregledi.Count == 0) Console.WriteLine("Nema zakazanih pregleda.");
            for (int i = 0; i < Pregledi.Count; i++)
            {
                Console.WriteLine("{0}. pregled je: {1}, a vi ste {2}. u redu cekanja",
                    i + 1, Pregledi[i].Preglede, Pregledi[i].Broj_u_redu);
            }
            Console.WriteLine();
        }
        public void IspisiPregledeZaRacun()
        {
            for(int i = 0; i < pregledano.Count; i++)
            {
                Console.WriteLine("Pregled: {0} - cijena: {1}", pregledano[i].Preglede, pregledano[i].Cijena);
            }
            if (broj_dolazaka > 3)
            {
                Console.WriteLine("Ukupno za gotovinsko placanje: {0}", racun - 0.1 * racun);
                Console.WriteLine("Ukupno za placanje na 3 rate: {0}", racun);
            }
            else
            {
                Console.WriteLine("Ukupno za gotovinsko placanje: {0}", racun);
                Console.WriteLine("Ukupno za placanje na 3 rate: {0}", racun+0.15*racun);
            }
            Console.WriteLine();
            if (dug != 0) Console.WriteLine("Podsjecamo vas na dug od: {0}", dug);
            Console.WriteLine();
            for (int i = 0; i < pregledano.Count; i++)
            {
                pregledano.Remove(pregledano[i]);
                i--;
            }
            
        }
        public void IspisiSve()
        {
            this.Ispisi();
            this.IspisiPreglede();
            this.IspisiHitnepreglede();
            this.IspisiPregledeZaRacun();
            this.Ispisi_misljenja_doktora();

        }
        public void IzbrisiPregled(string s)
        {
            for(int i = 0; i < Pregledi.Count; i++)
            {
                if (Pregledi[i].Preglede == s)
                {
                    pregledano.Add(Pregledi[i]);
                    Pregledi.Remove(Pregledi[i]);
                    break;
                }
            }
        }
    }
}
