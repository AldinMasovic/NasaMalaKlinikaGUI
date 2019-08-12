using Klinika.Help;
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
    public partial class Login : Form
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); // Poziv OnPaint metode bazne klase
            System.Drawing.Graphics mojGrafickiObjekat; // Kreiranje vlastitog Graphics objekta
            mojGrafickiObjekat = this.CreateGraphics();
            SolidBrush b = new SolidBrush(Color.YellowGreen);
            Pen p = new Pen(b, 5);
            Rectangle rt = new Rectangle(410, 210, 80, 80);
            Font f4 = new Font("Algerian", 100);
            e.Graphics.DrawString("H", f4, new SolidBrush(Color.DarkRed), 300, 100);
            mojGrafickiObjekat.DrawRectangle(p, 300, 100, 150, 150);
            mojGrafickiObjekat.DrawArc(p, rt, 180, 90);
            Font f1 = new Font("Arial", 5);
            e.Graphics.DrawString("Since '08", f1, new SolidBrush(Color.DarkRed), 413, 240);

        }
        public Login()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool jeste = false;
            String ime = textBox1.Text;
            if (comboBox1.SelectedItem == null)
            {
                toolStripStatusLabel2.Text = "Niste nista izabrali";
                return;
            }
            if (comboBox1.SelectedItem.ToString() == "Doktor")
            {
                for (int i = 0; i < Bolnica.PristupDoktorima().Count; i++)
                {

                    if (textBox1.Text == Bolnica.PristupDoktorima()[i].Username &&
                        Validacije.CalculateHash(textBox2.Text)==Bolnica.PristupDoktorima()[i].Passwrod)
                    {
                        //MessageBox.Show(Bolnica.PristupDoktorima()[i].Ime, "Otvori formu za doktore");
                        Form4 f4 = new Form4();
                        for (int j = 0; j < Bolnica.PristupOrdinacijama().Count; j++)
                        {
                            if (Bolnica.PristupOrdinacijama()[j].Doktor == Bolnica.PristupDoktorima()[i])
                            {
                                f4.Pohrani(j);
                                break;
                            }
                        }
                        jeste = true;
                        reset();
                        f4.Show();
                    }
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Zaposleni") {
                for(int i = 0; i < Bolnica.Osoblje.Count; i++)
                {
                    if (textBox1.Text == Bolnica.Osoblje[i].Username &&
                         Validacije.CalculateHash(textBox2.Text) == Bolnica.Osoblje[i].Passwrod)
                    {
                        Form3 f3 = new Form3();
                        reset();
                        f3.Show();
                    }
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Administracija") {
                for(int i = 0; i < Bolnica.Administracija.Count; i++)
                {
                    if (textBox1.Text == Bolnica.Administracija[i].Username &&
                         Validacije.CalculateHash(textBox2.Text) == Bolnica.Administracija[i].Passwrod)
                    {
                        Analiza f6 = new Analiza();
                        reset();
                        f6.Show();
                    }
                }


            }
            else if (comboBox1.SelectedItem.ToString() == "Pacijent")
            {
                for (int i = 0; i < Bolnica.PristupKartoteci().duzina(); i++)
                {
                    if (textBox1.Text == Bolnica.PristupKartoteci().DajKartonNaPoziciji(i).Username &&
                         Validacije.CalculateHash(textBox2.Text) == Bolnica.PristupKartoteci().DajKartonNaPoziciji(i).Password)
                    {
                        Form2 f2 = new Form2();
                        f2.pohrani(i);
                        reset();
                        f2.Show();
                        //this.Hide();
                        jeste = true;
                    }
                }
            }
            if (!jeste)
            {
                toolStripStatusLabel2.Visible = true;
                toolStripStatusLabel2.Text = "Neispravni podaci";
            }
        }
        private void reset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            toolStripStatusLabel2.Text = "";
            toolStripStatusLabel2.Visible = false;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void izlazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void oNamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nasa mala klinika hehe :D", "O nama");
        }
    }
}
