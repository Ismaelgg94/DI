using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace BotonEscapista
{
    class Persona
    {
        private int velocidadAndar;
        private int velocidadCorrer;
        private int lejos;
        private int cerca;
        private int tamaño;
        private Point posicion;
        private int borde;
        private int capacidadCrecimiento;

        public Persona(Size jardin)
        {
            Random r = new Random();
            velocidadAndar = r.Next(1, 3);
            velocidadCorrer = r.Next(3, 6);
            lejos = r.Next(150, 250);
            cerca = r.Next(50, 150);
            tamaño = r.Next(11, 101);
            borde = r.Next(20, 50);
            capacidadCrecimiento = r.Next(1, 3);
            posicion = new Point(r.Next(jardin.Width) - tamaño, r.Next(jardin.Height) - tamaño);
        }
        
        // función pitagórica que devuelve la distancia entre dos puntos
        private int fDistancia(Point p1, Point p2) { return (int)Math.Pow(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2), 0.5); }

        public void mirar(Point posMonstruo, Size jardin) 
        {
            int velocidad = 0;
            if (fDistancia(posMonstruo, posicion) < lejos) { velocidad = velocidadAndar; }
            if (fDistancia(posMonstruo, posicion) < cerca) { velocidad = velocidadCorrer; }

            //mov Horizontal
            if (posMonstruo.X > posicion.X) //ataca por la derecha
            { if (posicion.X > borde) { posicion = new Point(posicion.X - velocidad, posicion.Y); } }
            else //ataca por la izquierda
            { if (posicion.X < jardin.Width - (tamaño + borde)) { posicion = new Point(posicion.X + velocidad, posicion.Y); } }

            //mov Vertical
            if (posMonstruo.Y > posicion.Y) //ataca por abajo
            { if (posicion.Y > borde) { posicion = new Point(posicion.X, posicion.Y - velocidad); } }
            else //ataca por arriba
            { if (posicion.Y < jardin.Height - (tamaño + borde)) { posicion = new Point(posicion.X, posicion.Y + velocidad); } }

        }

        public void mostrar(Button elBoton)
        {
            elBoton.Size = new Size(tamaño, tamaño);
            elBoton.Location = posicion;       
        }

        public void morir(Button elBtn) 
        {
            Console.Beep(200, 200); // gritar
            elBtn.Dispose();
            // el tema del recolector de basura es bastante frustrante ... se elimina de la colección, me cargo el boton y que él lo elimine cuando quiera
            // GC.SuppressFinalize(this);
            // GC.ReRegisterForFinalize(this);
            
        }
        public void crece()
        {
            tamaño += capacidadCrecimiento;
            lejos += capacidadCrecimiento;
            cerca += capacidadCrecimiento;
        }
    }
}
