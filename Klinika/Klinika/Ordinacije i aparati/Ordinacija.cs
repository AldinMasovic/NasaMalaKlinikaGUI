using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika
{
    class Ordinacija
    {
        string naziv;
        int cijena;
        Doktor doktor;
        Aparat aparat;
        List<Karton> pacijenti;
        int protok;
        int redcekanja;

        public string NazivOrdinacije { get => naziv; set => naziv = value; }
        internal Doktor Doktor { get => doktor; set => doktor = value; }
        internal Aparat Aparat { get => aparat; set => aparat = value; }
        public int Protok { get => protok; set => protok = value; }
        internal List<Karton> Pacijenti { get => pacijenti; set => pacijenti = value; }

        public Ordinacija()
        {
            cijena = 0; doktor = null;  aparat = null; Pacijenti=new List<Karton>(); protok= 0;redcekanja = 0;
        }
        public void DodajDoktora(ref Doktor l) { doktor = l; }
        public void dodajAparat(ref Aparat l) { aparat = l; }
        public void dodajPacijenta(Karton l){
            protok++;
            redcekanja++;
            Pacijenti.Add(l);//mozda da dodamo preko jmbg ili sam ga veæ alocirao vidjet æu
        }
        public void CijenaUsluga(int x) { cijena = x; }
        public int CijenaUsluga() { return cijena; }
        public void PregledanPacijent(String misljenje,String terapija)
        {
            if (Pacijenti.Count == 0)
            {
                Console.WriteLine("Nema pacijenata!");
                return;
            }
            /*
            string misljenje;
            Console.WriteLine("Vase misljenje: ");
            misljenje=Console.ReadLine();
            Console.WriteLine("Terapija: ");
            string terapija = Console.ReadLine();
            //Console.WriteLine("Datum: ");
            //string datum = Console.ReadLine();
            DateTime datum = new DateTime();
                bool datumIspravan = false;
                while (!datumIspravan)
                {
                    Console.WriteLine("Unesite datum pregleda pacijenta: dd/mm/yyyy");
                    string datum_rodjenja = Console.ReadLine();

                    datumIspravan = DateTime.TryParseExact(datum_rodjenja, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out datum);
                    if (!datumIspravan) Console.WriteLine("Neispravan unos");
                }
                */
            pacijenti[0].MisljenjeDoktora(misljenje,terapija, Doktor.Ime +" "+ Doktor.Prezime, naziv,DateTime.Now);
            pacijenti[0].Racun = pacijenti[0].Racun + cijena;
            pacijenti[0].IzbrisiPregled(this.naziv);
            Pacijenti.Remove(Pacijenti[0]);
            redcekanja--;
            for (int i = 0; i < Pacijenti.Count; i++) pacijenti[i].DajPregled(this.naziv).Broj_u_redu--;
        }
        public int Broj_U_Redu() { return redcekanja; }
        public void IspisiSvePacijenteIzOrdinacije()
        {
            //for (int i = 0; i < Pacijenti.Count; i++) Pacijenti[i].Karton.Ispisi();
        }
}
}
