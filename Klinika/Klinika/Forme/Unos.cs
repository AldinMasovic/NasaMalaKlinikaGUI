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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            comboBoxBracno.SelectedIndex = 0;
            kontrole = new List<Control>() { textBoxIme, textBoxPrezime,textBoxJMBG,textBoxAdresa,
            textBox2,maskedTextBox1,maskedTextBox2};
            statusStrip1.Visible = false;
            zauzetost();
        }
        private List<Control> kontrole;
        private void zauzetost()
        {
            listView1.Clear();
            for (int i = 0; i < Bolnica.PristupOrdinacijama().Count; i++)
            {
                listView1.Items.Add(Bolnica.PristupOrdinacijama()[i].Broj_U_Redu() + "    " + Bolnica.PristupOrdinacijama()[i].NazivOrdinacije);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
                Spol spol;
                if (radioButton3.Checked == true) spol = Spol.Musko;
                else spol = Spol.Zensko;
                String user = textBox2.Text;
            String pass = maskedTextBox1.Text;
                DateTime t = dateTimePickerprijema.Value.Date;
                Bracnostanje bracnostanje = (Bracnostanje)1;
                if (comboBoxBracno.SelectedItem.ToString() == "Slobodan/na") { bracnostanje = (Bracnostanje)1; }
                else if (comboBoxBracno.SelectedItem.ToString() == "Razveden/na") { bracnostanje = (Bracnostanje)2; }
                else if (comboBoxBracno.SelectedItem.ToString() == "Ozenjen/Udata") { bracnostanje = (Bracnostanje)3; }
                String ime = textBoxIme.Text;
                String prezime = textBoxPrezime.Text;
            validatepass();
                Validacije.check_and_set_message(ime, Validacije.validateNaziv, textBoxIme, errorProvider1, "Naziv nije validan");
                Validacije.check_and_set_message(prezime, Validacije.validateNaziv, textBoxPrezime, errorProvider1, "Naziv nije validan");
            Validacije.check_and_set_message(user, Validacije.validateUsername, textBox2, errorProvider1, "Minimalno 6 karaktera");
            Validacije.check_and_set_message(textBoxAdresa.Text, Validacije.validateNaziv, textBoxAdresa, errorProvider1, "Naziv nije validan");
            Validacije.check_and_set_message(textBoxJMBG.Text, Validacije.validnostJMBG, textBoxJMBG, errorProvider1, "Neispravan JMBG");
            //Validacije.check_and_set_message(textBoxJMBG.Text, Validacije.validnostJMBG, textBoxJMBG, errorProvider1, "JMBG nije validan");
            if (!Validacije.any_has_error(kontrole, errorProvider1))

                {
                    
                    toolStripStatusLabel1.Visible = false;
                    MessageBox.Show("uspjesno registrovan pacijent");
                    Karton k = new Karton(ime, prezime,
                    dateTimePickerRodjenje.Value.Date, textBoxJMBG.Text, spol, textBoxAdresa.Text,
                    bracnostanje, t, richTextBox1.Text, richTextBox3.Text, richTextBox2.Text, richTextBox4.Text);
                    Bolnica.PristupKartoteci().DodajKarton(ref k);
                k.Username = user;
                k.Password = Validacije.CalculateHash(pass);
                
                }
            else
            {
                statusStrip1.Visible = true;
            }
                
                /*
                Karton k = new Karton(textBoxIme.ToString(), textBoxPrezime.ToString(),
                    dateTimePickerRodjenje.Value.Date, textBoxJMBG.Text, spol, textBoxAdresa.Text,
                    bracnostanje, t, richTextBox1.Text, richTextBox3.Text, richTextBox2.Text, richTextBox4.Text);*/
           
        }


        private void textBoxIme_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
        private void tabPage3_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            foreach (Karton k in Bolnica.PristupKartoteci().Pok)
            {
                if ((k.Ime + " " + k.Prezime).Contains(textBox1.Text))
                {
                    listBox1.Items.Add(k);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            String pass = maskedTextBox1.Text;
            String pass2 = maskedTextBox2.Text;
            if (pass != pass2)
            {
                errorProvider1.SetError(maskedTextBox1, "Ne poklapaju se sifre");
            }
            else
            {
                errorProvider1.SetError(maskedTextBox1, "");
                errorProvider1.SetError(maskedTextBox2, "");
            }
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            String pass = maskedTextBox1.Text;
            String pass2 = maskedTextBox2.Text;
            if (pass != pass2)
            {
                errorProvider1.SetError(maskedTextBox1, "Ne poklapaju se sifre");
            }
            else
            {
                errorProvider1.SetError(maskedTextBox1, "");
                errorProvider1.SetError(maskedTextBox2, "");
            }
        }

        private void maskedTextBox1_Validated(object sender, EventArgs e)
        {

        }
        private bool validatepass()
        {
            String pass = maskedTextBox1.Text;
            String pass2 = maskedTextBox2.Text;
            if (pass == pass2 && pass!=null && pass.Length>5)
            {
                errorProvider1.SetError(maskedTextBox1, "");
                errorProvider1.SetError(maskedTextBox2, "");
                return true;
            }
            else
            {
                errorProvider1.SetError(maskedTextBox1, "Ne poklapaju se sifre i minimalno sest karaktera");
                return false;
            }
        }
        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            validatepass();
        }

        private void maskedTextBox2_Leave_1(object sender, EventArgs e)
        {
            validatepass();
        }
    }
}
