using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lucrarea8_cs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public struct tranz_bursa
        {
            public int data, val_min, val_max, val_open, val_close;
        };

        System.Drawing.Graphics Desen;
        System.Drawing.Pen Pen_Black, Pen_Green, Pen_Red;
        System.Drawing.SolidBrush Brush_Green, Brush_Red, Radiera;
        System.Random n;
        tranz_bursa[] zi;
        int nr_zile;

        private void Form1_Load(object sender, EventArgs e)
        {

            Desen = CreateGraphics();
            Pen_Black = new System.Drawing.Pen(System.Drawing.Color.Black);
            Pen_Green = new System.Drawing.Pen(System.Drawing.Color.Green, 3);
            Pen_Red = new System.Drawing.Pen(System.Drawing.Color.Red, 3);
            Brush_Green = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
            Brush_Red = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            Radiera = new System.Drawing.SolidBrush(this.BackColor);
            n = new Random();
            nr_zile = 31;
            zi = new tranz_bursa[nr_zile];
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            zi[1].val_close = 90;
            for (int i = 2; i <= 30; i++)
            {
                zi[i].data = i;
                zi[i].val_min = n.Next(0, 20);////////////// dar atentie ca in realitate sunt inversate
                 zi[i].val_max = n.Next(80, 90);///////////// din cauza originii de sus
                int nr = n.Next(100);
                zi[i].val_open = nr;
                if (nr % 2 == 0) zi[i].val_close = nr + n.Next(40);
                else zi[i].val_close = nr - n.Next(40);

                if (zi[i].val_close < 0)
                    zi[i].val_close *= -1;
                if (zi[i].val_open < 0)
                    zi[i].val_open *= -1;
                Desen.DrawLine(Pen_Black, (i - 1) * 20, (zi[i - 1].val_close + zi[i - 1].val_open) / 2,
               (i) * 20, (zi[i].val_close + zi[i].val_open) / 2);////linie grafic
                                                                 /////////////// PT CANDLE
                if (zi[i].val_open < zi[i].val_close)
                {
                    Desen.DrawLine(Pen_Red, i * 20, zi[i].val_open, i * 20, zi[i].val_close);
                }
                else
                {
                    Desen.DrawLine(Pen_Green, i * 20, zi[i].val_open, i * 20, zi[i].val_close);
                }
                Desen.DrawLine(Pen_Black, i * 20, zi[i].val_max, i * 20, zi[i].val_min);///linie  subtire
            }
        }
    }
}
