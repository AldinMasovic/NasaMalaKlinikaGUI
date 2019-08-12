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
    public partial class Form2 : Form
    {
        private Karton karton;
        public Form2()
        {
            InitializeComponent();
        }
        public void pohrani(int i)
        {
            karton=Bolnica.PristupKartoteci().DajKartonNaPoziciji(i);
            popuni();
        }
        private void popuni()
        {
            label7.Text = karton.Ime;
            label10.Text = karton.Prezime;
            label11.Text = karton.Bracno_stanje.ToString();
            label12.Text = karton.Adresa;
            label13.Text = karton.Spol.ToString();
            label14.Text = karton.Jmbg;
            label15.Text = karton.Datum_rodjenja.ToString();
            label16.Text = karton.Datum_prijema.ToString();
            label18.Text = karton.Racun.ToString();
            listView3.Items.Add(karton.Oboljenja.Aktivnebolesti);
            listView4.Items.Add(karton.Oboljenja.Aktivnealergije);
            listView5.Items.Add(karton.Oboljenja.Pasivnealergije);
            listView6.Items.Add(karton.Oboljenja.Pasivnebolesti);
            for (int i = karton.Misljenja.Count - 1; i >= 0; i--)
            {
                treeView1.Nodes.Add(karton.Ordinacije[i]);
                treeView1.Nodes[karton.Misljenja.Count - i - 1].Nodes.Add("Misljenje");
                treeView1.Nodes[karton.Misljenja.Count - i - 1].Nodes[0].Nodes.Add(karton.Misljenja[i]);
                treeView1.Nodes[karton.Misljenja.Count - i - 1].Nodes.Add("Terapija");
                treeView1.Nodes[karton.Misljenja.Count - i - 1].Nodes[1].Nodes.Add(karton.Terapije[i]);
                treeView1.Nodes[karton.Misljenja.Count - i - 1].Nodes.Add("Datum");
                treeView1.Nodes[karton.Misljenja.Count - i - 1].Nodes[2].Nodes.Add(karton.Datumi[i].ToString());
                treeView1.Nodes[karton.Misljenja.Count - i - 1].Nodes.Add("Potpis");
                treeView1.Nodes[karton.Misljenja.Count - i - 1].Nodes[3].Nodes.Add(karton.Potpisi[i]);
            }
            treeView1.EndUpdate();
            karton.SortirajPreglede();
            for (int i = 0; i < karton.Pregledi.Count; i++)
            {
                listView2.Items.Add(karton.Pregledi[i].Broj_u_redu+1+"    "+karton.Pregledi[i].NazivPregleda());
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
