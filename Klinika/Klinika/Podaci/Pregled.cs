using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika
{
   sealed class Pregled
    {
        String pregled;
        String misljenje;
        String potpis;
        String terapija;
        int broj_u_redu;
        int cijena;
        public string Preglede { get => pregled; set => pregled = value; }
        public int Broj_u_redu { get => broj_u_redu; set => broj_u_redu = value; }
        public int Cijena { get => cijena; set => cijena = value; }

        //Ordinacija pregledi;
        public Pregled(string pregled)
        {
            for(int i = 0; i < Bolnica.PristupOrdinacijama().Count; i++)
            {
                if (pregled == Bolnica.PristupOrdinacijama()[i].NazivOrdinacije)
                {
                    this.cijena = Bolnica.PristupOrdinacijama()[i].CijenaUsluga();
                    broj_u_redu = Bolnica.PristupOrdinacijama()[i].Broj_U_Redu();
                    potpis = Bolnica.PristupOrdinacijama()[i].Doktor.ToString();
                    this.pregled = pregled;
                    return;
                }
            }
            Console.WriteLine("ne moe pregled dodati");
            //this.cijena = cijena;
            //broj_u_redu = 0;
            //this.pregled = pregled;
            //this.misljenje = misljenje;
        }
        public string NazivPregleda()
        {
            return pregled;
        }
        
    }
}
