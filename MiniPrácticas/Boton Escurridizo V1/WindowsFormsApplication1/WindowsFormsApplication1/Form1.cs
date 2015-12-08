using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Point RATON = new Point(0,0);
        public Form1()
        {
            InitializeComponent();
        }

      

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int mov=10;
            double dist;
            Point boton = new Point(button1.Location.X, button1.Location.Y),
                 raton = new Point(e.Location.X, e.Location.Y);
            
            if (!raton.Equals(RATON) /*&& seAcerca(RATON,raton,boton)*/)
            {
                dist = distancia(boton, raton);
                if (dist > 100)
                    mov = 1;
                else if (dist > 50)
                    mov = 5;
                else if (dist > 25)
                    mov = 7;
                

                if (boton.X > raton.X && boton.X + button1.Width + 1 <= this.Width)
                    boton.X += mov;
                else if (boton.X < raton.X && boton.X > 0)
                    boton.X -= mov;

                if (boton.Y > raton.Y && boton.Y + button1.Height + 1 <= this.Height)
                    boton.Y += mov;
                else if (boton.Y < raton.Y && boton.Y > 0)
                    boton.Y -= mov;

                button1.Location = boton;
                
            }
            RATON = raton;
        }
        public Boolean seAcerca(Point ultimaPos, Point nuevaPos, Point boton)
        {
            Boolean seAcerca = false;
            if (boton.X - nuevaPos.X < boton.X - ultimaPos.X && boton.Y - nuevaPos.Y < boton.Y - ultimaPos.Y)         
                seAcerca = true;


            return seAcerca;
        }
        public double distancia(Point puntoA, Point puntoB)
        {
            double a, b;
            a = Math.Pow(puntoA.X - puntoB.X,2);
            b = Math.Pow( puntoA.Y - puntoB.Y,2);

            return Math.Sqrt(a + b);
        }
    }
}
