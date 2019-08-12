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
    public partial class Analiza : Form
    {
        public Analiza()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            float suma = 0;
            for (int i = 0; i < 4; i++) suma += Bolnica.PristupDoktorima()[i].Plata;
            base.OnPaint(e); // Poziv OnPaint metode bazne klase
            System.Drawing.Graphics mojGrafickiObjekat; // Kreiranje vlastitog Graphics objekta
            mojGrafickiObjekat = this.CreateGraphics();
            SolidBrush b = new SolidBrush(Color.YellowGreen);
            List<SolidBrush> olovke = new List<SolidBrush>();
            olovke.Add(new SolidBrush(Color.Green));
            olovke.Add(new SolidBrush(Color.DimGray));
            olovke.Add(new SolidBrush(Color.Yellow));
            olovke.Add(new SolidBrush(Color.Red));
            olovke.Add(new SolidBrush(Color.Gold));
            olovke.Add(new SolidBrush(Color.Green));
            List<Pen> crtaj = new List<Pen>();
            for (int i = 0; i < 4; i++) crtaj.Add(new Pen(olovke[i], 3));
            Pen p = new Pen(b, 5);
            Rectangle rt = new Rectangle(410, 210, 80, 80);
            Rectangle rt2 = new Rectangle(200, 100, 200, 200);
            // Font f4 = new Font("Algerian", 100);
            float trenutni = 0;
            for (int i = 0; i <4; i++)
            {
                mojGrafickiObjekat.DrawPie(crtaj[i], rt2, trenutni,360*Bolnica.PristupDoktorima()[i].Plata/suma);
                trenutni += 360*Bolnica.PristupDoktorima()[i].Plata/suma;
            }
            label1.BackColor = olovke[0].Color;
            label1.Text = Bolnica.PristupDoktorima()[0].ToString();
            label2.BackColor = olovke[1].Color;
            label2.Text = Bolnica.PristupDoktorima()[1].ToString();
            label3.BackColor = olovke[2].Color;
            label3.Text = Bolnica.PristupDoktorima()[2].ToString();
            label4.BackColor = olovke[3].Color;
            label4.Text = Bolnica.PristupDoktorima()[3].ToString();

            // mojGrafickiObjekat.DrawPie(crtaj[1], rt2, 50, 100);
            //m/ojGrafickiObjekat.DrawPie(crtaj[2], rt2, 150, 30);
            /*e.Graphics.DrawString("H", f4, new SolidBrush(Color.DarkRed), 300, 100);
            mojGrafickiObjekat.DrawRectangle(p, 300, 100, 150, 150);
            mojGrafickiObjekat.DrawArc(p, rt, 180, 90);
            Font f1 = new Font("Arial", 5);
            e.Graphics.DrawString("Since '08", f1, new SolidBrush(Color.DarkRed), 413, 240);*/

        }
        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
