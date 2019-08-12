using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klinika
{
    public partial class Form4 : Form
    {
        private  Ordinacija ordinacija;
        public Form4()
        {
            InitializeComponent();
            for(int i = 0; i < Bolnica.PristupOrdinacijama().Count; i++)
            {
                checkedListBox1.Items.Add(Bolnica.PristupOrdinacijama()[i].NazivOrdinacije, false);
            }
            zauzetost();
        }
        public void Pohrani(int i)
        {
            ordinacija = Bolnica.PristupOrdinacijama()[i];
            popuni();
        }
        private void popuni()
        {
            label7.Text = ordinacija.NazivOrdinacije;
            label13.Text = DateTime.Now.ToString();
            label12.Text = ordinacija.Doktor.ToString();
            for(int i = 0; i < ordinacija.Broj_U_Redu(); i++)
            {
                listView7.Items.Add(ordinacija.Pacijenti[i].ToString());
            }
            reflesh();
            //popuni prvi đavo
            prvidio();
        }
        private void zauzetost()
        {
            listView1.Clear();
            for (int i = 0; i < Bolnica.PristupOrdinacijama().Count; i++)
            {
                listView1.Items.Add(Bolnica.PristupOrdinacijama()[i].Broj_U_Redu() + "    " + Bolnica.PristupOrdinacijama()[i].NazivOrdinacije);
            }

        }
        private void prvidio()
        {
            if (ordinacija.Pacijenti.Count == 0) return;
            label14.Text = ordinacija.Pacijenti[0].Ime;
            label15.Text = ordinacija.Pacijenti[0].Prezime;
            label16.Text = ordinacija.Pacijenti[0].Spol.ToString();
            label17.Text = ordinacija.Pacijenti[0].Adresa;
            label18.Text = ordinacija.Pacijenti[0].Bracno_stanje.ToString();
            label19.Text = ordinacija.Pacijenti[0].Jmbg;
            label20.Text = ordinacija.Pacijenti[0].Datum_rodjenja.ToString();
            label21.Text = ordinacija.Pacijenti[0].Datum_prijema.ToString();
            label23.Text = ordinacija.Pacijenti[0].ToString();
            listView3.Items.Add(ordinacija.Pacijenti[0].Oboljenja.Aktivnebolesti);
            listView4.Items.Add(ordinacija.Pacijenti[0].Oboljenja.Aktivnealergije);
            listView5.Items.Add(ordinacija.Pacijenti[0].Oboljenja.Pasivnealergije);
            listView6.Items.Add(ordinacija.Pacijenti[0].Oboljenja.Pasivnebolesti);
            for(int i = ordinacija.Pacijenti[0].Misljenja.Count - 1; i >= 0; i--)
            {
                treeView1.Nodes.Add(ordinacija.Pacijenti[0].Ordinacije[i]);
                treeView1.Nodes[ordinacija.Pacijenti[0].Misljenja.Count - i - 1].Nodes.Add("Misljenje");
                treeView1.Nodes[ordinacija.Pacijenti[0].Misljenja.Count-i-1].Nodes[0].Nodes.Add(ordinacija.Pacijenti[0].Misljenja[i]);
                treeView1.Nodes[ordinacija.Pacijenti[0].Misljenja.Count - i - 1].Nodes.Add("Terapija");
                treeView1.Nodes[ordinacija.Pacijenti[0].Misljenja.Count - i - 1].Nodes[1].Nodes.Add(ordinacija.Pacijenti[0].Terapije[i]);
                treeView1.Nodes[ordinacija.Pacijenti[0].Misljenja.Count - i - 1].Nodes.Add("Datum");
                treeView1.Nodes[ordinacija.Pacijenti[0].Misljenja.Count - i - 1].Nodes[2].Nodes.Add(ordinacija.Pacijenti[0].Datumi[i].ToString());
                treeView1.Nodes[ordinacija.Pacijenti[0].Misljenja.Count - i - 1].Nodes.Add("Potpis");
                treeView1.Nodes[ordinacija.Pacijenti[0].Misljenja.Count - i - 1].Nodes[3].Nodes.Add(ordinacija.Pacijenti[0].Potpisi[i]);
            }
            treeView1.EndUpdate();
        }
        private void reflesh()
        {
            if (ordinacija.Pacijenti.Count == 0) return;
            for (int i = 0; i < ordinacija.Pacijenti[0].Pregledi.Count; i++)
            {
                listView2.Items.Add(ordinacija.Pacijenti[0].Pregledi[i].Broj_u_redu+1+"    "+
                    ordinacija.Pacijenti[0].Pregledi[i].NazivPregleda());
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (ordinacija.Pacijenti.Count != 0)
            {
                int n = ordinacija.Pacijenti[0].Pregledi.Count;
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i) == true) {
                        ordinacija.Pacijenti[0].DodajPregled(new Pregled(checkedListBox1.Items[i].ToString()));
                        Bolnica.PristupOrdinacijama()[i].dodajPacijenta(ordinacija.Pacijenti[0]);
                        listView2.Items.Add(ordinacija.Pacijenti[0].Pregledi[n++].NazivPregleda());
                    }
                }
                zauzetost();
                MessageBox.Show("Uspjesno ste zakazali preglede");
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }
           // reflesh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ordinacija.Pacijenti.Count != 0)
            {
                String misljenje = textBox5.Text;
                String terapija = textBox6.Text;
                ordinacija.PregledanPacijent(misljenje, terapija);
                MessageBox.Show("Pregledan pacijent");
                textBox5.Text = "";
                textBox6.Text = "";
                sljedeciPacijent();
                //DORADI OVOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO//
                //listView2.Items.RemoveAt(0);
                //listView7.Items.RemoveAt(0);
            }
            else MessageBox.Show("Nema zakazanih pacijenata");
        }
        private void sljedeciPacijent()
        {
            if (ordinacija.Pacijenti.Count != 0)
            {
                prvidio();
            }
            else
            {
                label14.Text = "Nema pacijenta";
                label15.Text = "Nema pacijenta";
                label16.Text = "Nema pacijenta";
                label17.Text = "Nema pacijenta";
                label18.Text = "Nema pacijenta";
                label19.Text = "Nema pacijenta";
                label20.Text = "Nema pacijenta";
                label21.Text = "Nema pacijenta";
                label23.Text = "Nema pacijenta";
                listView3.Items.Clear();
                listView4.Items.Clear();
                listView5.Items.Clear();
                listView6.Items.Clear();
                listView2.Items.Clear();
                treeView1.Nodes.Clear();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
