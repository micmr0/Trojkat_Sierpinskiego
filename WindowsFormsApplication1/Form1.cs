using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



public class Punkt
{
    public int x;
    public int y;

    public Punkt()
    {
        this.x = 0;
        this.y = 0;
    }

    public Punkt(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

}

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(650, 600);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            // duży czerwony mazak
            Pen p = new Pen(Color.Red, 5);

            Brush aBrush = (Brush)Brushes.Red;

            // punkty będące wierchołkami trójkąta
            Punkt a = new Punkt(0, 500);
            Punkt b = new Punkt(300, 80);
            Punkt c = new Punkt(600, 500);

            Punkt[] points = new Punkt[]{a, b, c};

            Punkt wybrany;
            Punkt game_point;
            Punkt srodek = new Punkt();
            Random rand;

            // rysowanie trójkąta
            g.DrawLine(p, a.x, a.y, b.x, b.y); //prawe
            g.DrawLine(p, b.x, b.y, c.x, c.y); //lewe
            g.DrawLine(p, c.x, c.y, a.x, a.y); //dol

            
            int x,y,z;

            // losowanie wierzchołka
            rand = new Random();
            x = rand.Next(2);
            wybrany = points[x];

            // losowanie współrzędnych punktu gry
            y = rand.Next(650);
            z = rand.Next(600);


            game_point = new Punkt(y, z);

            // tablica współrzędnych punktów wynikowych
            Punkt[] calculatedPoints = new Punkt[100000];

            int n = 0;
            while(n<100000)
            {
                calculatedPoints[n] = new Punkt();
                n++;
            }
    

            // ------pętla losująca "środki"------
            n = 0;
            while(n<100000)
            {
                if(n>0)
                {
                    x = rand.Next(3);
                    wybrany = points[x];

                    game_point.x = srodek.x;
                    game_point.y = srodek.y;
                }

                srodek.x = (wybrany.x + game_point.x)/2;
                srodek.y = (wybrany.y + game_point.y)/2;

                calculatedPoints[n].x = srodek.x;
                calculatedPoints[n].y = srodek.y;

                n++;
            }
            // -----------------------------------


            // pętla rysująca "środki"
            n = 0;
            while(n<100000)
            {
                g.FillRectangle(aBrush, calculatedPoints[n].x, calculatedPoints[n].y, 2, 2);
                n++;
            }

        }
    }
}
