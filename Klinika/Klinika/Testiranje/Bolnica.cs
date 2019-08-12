using Klinika.Help;
using Klinika.Osoblje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika
{
    class Bolnica
    {
        static Kartoteka kartoteka;
        static List<Pacijent> pacijenti;
        static List<Doktor> doktori_17580_1;
        static List<Ordinacija> ordinacije_17580_1;
        static List<Zaposelni> osoblje;
        static List<Administracija> administracija;
        internal static List<Zaposelni> Osoblje { get => osoblje; set => osoblje = value; }
        internal static List<Administracija> Administracija { get => administracija; set => administracija = value; }

        public Bolnica()
        {
            kartoteka = new Kartoteka();
            pacijenti =  new List<Pacijent>();
            doktori_17580_1 = new List<Doktor>();
            Osoblje = new List<Zaposelni>();
            administracija = new List<Administracija>();
            Doktor doktor_17580_1 = new Doktor("Ahmed", "Arap", "2902996175023", 2000, true);
            doktor_17580_1.Username = "doktor1"; doktor_17580_1.Passwrod = Validacije.CalculateHash("sifra1");
            Doktor doktor_17580_2 = new Doktor("Suada", "Sljivo", "2902996175023", 2100, true);
            doktor_17580_2.Username = "doktor2"; doktor_17580_2.Passwrod = Validacije.CalculateHash("sifra2");
            Doktor doktor_17580_3 = new Doktor("Jasmin", "Prezimenko", "2902996175023", 1800, true);
            doktor_17580_3.Username = "doktor3"; doktor_17580_3.Passwrod = Validacije.CalculateHash("sifra3");
            Doktor doktor_17580_4 = new Doktor("Faruk", "Arapovic", "2902996175023", 1900, true);
            doktor_17580_4.Username = "doktor4"; doktor_17580_4.Passwrod = Validacije.CalculateHash("sifra4");
            Doktor doktor_17580_5 = new Doktor("Bakir", "Izedbegovic", "2902996175023", 2500, true);
            Doktor doktor_17580_6 = new Doktor("Sebljia", "Izedbegovic", "2902996175023", 1920, true);
            Doktor doktor_17580_7 = new Doktor("Fahrduin", "Radoncic", "2902996175023", 2050, true);
            Doktor doktor_17580_8 = new Doktor("Milorad", "Dodik", "2902996175023", 2100, true);
            doktori_17580_1.Add(doktor_17580_1);
            doktori_17580_1.Add(doktor_17580_2);
            doktori_17580_1.Add(doktor_17580_3);
            doktori_17580_1.Add(doktor_17580_4);
            Aparat aparat_17580_1 = new Aparat("EKG", true);
            Aparat aparat_17580_2 = new Aparat("Guglaj", true);
            Aparat aparat_17580_3 = new Aparat("Guglaj opet", true);
            Aparat aparat_17580_4 = new Aparat("Nemam ideju", true);
            Aparat aparat_17580_5 = new Aparat("Ne znam", true);
            Aparat aparat_17580_6 = new Aparat("Valjda nije bitno", true);
            Aparat aparat_17580_7 = new Aparat("Testiranje", true);
            Aparat aparat_17580_8 = new Aparat("No idea", true);
            ordinacije_17580_1 = new List<Ordinacija>();
            Ordinacija hirurgija_17580_1 = new Ordinacija();
            hirurgija_17580_1.dodajAparat(ref aparat_17580_1);
            hirurgija_17580_1.DodajDoktora(ref doktor_17580_1);
            hirurgija_17580_1.CijenaUsluga(100);
            hirurgija_17580_1.NazivOrdinacije = "Opsta medicina";
            ordinacije_17580_1.Add(hirurgija_17580_1);
            Ordinacija hirurgija_17580_2 = new Ordinacija();
            hirurgija_17580_2.dodajAparat(ref aparat_17580_2);
            hirurgija_17580_2.DodajDoktora(ref doktor_17580_2);
            hirurgija_17580_2.CijenaUsluga(80);
            hirurgija_17580_2.NazivOrdinacije = "Ortopedska medicina";
            Ordinacija hirurgija_17580_3 = new Ordinacija();
            hirurgija_17580_3.dodajAparat(ref aparat_17580_3);
            hirurgija_17580_3.DodajDoktora(ref doktor_17580_3);
            hirurgija_17580_3.CijenaUsluga(20);
            hirurgija_17580_3.NazivOrdinacije = "Kardiološka medicina";
            Ordinacija hirurgija_17580_4 = new Ordinacija();
            hirurgija_17580_4.DodajDoktora(ref doktor_17580_4);
            hirurgija_17580_4.CijenaUsluga(30);
            hirurgija_17580_4.NazivOrdinacije = "Dermatološka";
            Ordinacija hirurgija_17580_5 = new Ordinacija();
            hirurgija_17580_5.dodajAparat(ref aparat_17580_5);
            hirurgija_17580_5.DodajDoktora(ref doktor_17580_5);
            hirurgija_17580_5.CijenaUsluga(100);
            hirurgija_17580_5.NazivOrdinacije = "Internisticka medicina";
            //ordinacije_17580_1.Add(hirurgija_17580_5);
            Ordinacija hirurgija_17580_6 = new Ordinacija();
            hirurgija_17580_6.dodajAparat(ref aparat_17580_6);
            hirurgija_17580_6.DodajDoktora(ref doktor_17580_6);
            hirurgija_17580_6.CijenaUsluga(30);
            hirurgija_17580_6.NazivOrdinacije = "Otoriolaringologija";
            //ordinacije_17580_1.Add(hirurgija_17580_6);
            Ordinacija hirurgija_17580_7 = new Ordinacija();
            hirurgija_17580_7.dodajAparat(ref aparat_17580_7);
            hirurgija_17580_7.DodajDoktora(ref doktor_17580_7);
            hirurgija_17580_7.CijenaUsluga(40);
            hirurgija_17580_7.NazivOrdinacije = "Ortamoloska medicina";
            //ordinacije_17580_1.Add(hirurgija_17580_7);
            Ordinacija hirurgija_17580_8 = new Ordinacija();
            hirurgija_17580_8.dodajAparat(ref aparat_17580_8);
            hirurgija_17580_8.DodajDoktora(ref doktor_17580_8);
            hirurgija_17580_8.CijenaUsluga(60);
            hirurgija_17580_8.NazivOrdinacije = "Labaratorijska medicina";
            //ordinacije_17580_1.Add(hirurgija_17580_8);
            ordinacije_17580_1.Add(hirurgija_17580_2);
            ordinacije_17580_1.Add(hirurgija_17580_3);
            ordinacije_17580_1.Add(hirurgija_17580_4);
            ordinacije_17580_1.Add(hirurgija_17580_5);
            ordinacije_17580_1.Add(hirurgija_17580_6);
            ordinacije_17580_1.Add(hirurgija_17580_7);
            ordinacije_17580_1.Add(hirurgija_17580_8);
            //osoblje
            Zaposelni s = new Zaposelni("John", "Semic", "2902996175023");
            s.Username = "zaposleni";s.Passwrod = Validacije.CalculateHash("zaposleni");
            Osoblje.Add(s);
            Administracija a = new Administracija("ee", "Kavazovic", "2902996175023");
            a.Username = "admin";a.Passwrod = Validacije.CalculateHash("admin1");
            Administracija.Add(a);
            Karton k = new Karton("John", "Hehe", DateTime.Now, "2902996175023", Spol.Musko, "Neka adresa", Bracnostanje.Razveden, DateTime.Now,
                "proliv", "polen", "nista", "radi");
            k.Username = "pacijent"; k.Password = Validacije.CalculateHash("pacijent");
            k.DodajPregled(new Pregled("Opsta medicina"));
            ordinacije_17580_1[0].dodajPacijenta(k);
            kartoteka.DodajKarton(ref k);
            
        }
        public static Kartoteka PristupKartoteci()
        {
            return kartoteka;
        }
        public static void ispisidoktore()
        {
            for(int i = 0; i < doktori_17580_1.Count; i++) Console.WriteLine("{0}",doktori_17580_1[i].Ime);
        }
        public static void DodajDoktora(Doktor dok)
        {
            doktori_17580_1.Add(dok);
        }
        public static List<Pacijent> PristumPacijentima() { return pacijenti; }
        public static List<Doktor> PristupDoktorima() { return doktori_17580_1; }
        public static List<Ordinacija> PristupOrdinacijama() { return ordinacije_17580_1; }
    }
}
