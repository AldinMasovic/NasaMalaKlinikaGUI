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
    public partial class crtanjeForm6 : Form
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
           
        }
        public crtanjeForm6()
        {
            InitializeComponent();
        }

        private void crtanjeForm6_Load(object sender, EventArgs e)
        {

        }
    }
}
