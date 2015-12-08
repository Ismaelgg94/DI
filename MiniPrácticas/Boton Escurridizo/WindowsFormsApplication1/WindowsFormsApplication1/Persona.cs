using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Persona
    {
        private Point posicion;
        private Image img= Properties.Resources.diana;
        private int velocidad;
        private Size tamano;
        private int areaVision;
        private int muroFobia;
        private Random rnd = new Random();
       
        public Persona(int velocidad,int areaVision, Size tamano,int muroFobia, Point tamanoForm)
        {
            this.velocidad = velocidad;
            this.tamano = tamano;
            this.areaVision = areaVision;
            this.muroFobia = muroFobia;
            posicion = new Point(rnd.Next(tamanoForm.X), rnd.Next(tamanoForm.Y));
        }
        public void mirar(Form1 form, MouseEventArgs e)
        {   //Calcula la distancia entre la persona y el monstruo mediante el teorema de Pitágoras.
            double a, b;
            a = Math.Pow(posicion.X + tamano.Width/2 - e.X, 2);
            b = Math.Pow(posicion.Y + tamano.Height/2 - e.Y, 2);
            if (Math.Sqrt(a + b) <= areaVision)
                huir(form, e);
        }
        public void huir(Form1 form, MouseEventArgs e)
        {
                //Se controla que no se salga de la ventana y respeten la muroFobia(Distancia mínima, la cual no se acercarán a la pared)
                if (posicion.X+tamano.Width/2 > e.X && posicion.X + tamano.Width + 1 < form.Width-muroFobia)
                {
                     posicion.X+=velocidad;
                }
                
                else if (posicion.X + tamano.Width/2 < e.X && posicion.X > 0 + muroFobia)
                {
                     posicion.X-=velocidad;
                }
                
                if (posicion.Y +tamano.Height/2 > e.Y && posicion.Y + tamano.Height + 1 <= form.Height-muroFobia)
                {
                    posicion.Y+=velocidad;
                 }
                
                else if (posicion.Y+tamano.Height/2 < e.Y && posicion.Y > muroFobia)
                {
                    posicion.Y-=velocidad;
                }
                
        }
        public void crecer()
        {
            tamano.Height+=2;
            tamano.Width += 2;
            areaVision += 2;
        }
        public void morir(Button btn)
        {
            btn.Dispose();
        }
        
        //Getters
        public Point getPosicion()
        {
            return posicion;
        }
        public int getVelocidad()
        {
            return velocidad;
        }
        public Size getTamano()
        {
            return tamano;
        }
        public Image getImg()
        {
            return img;
        }
    }
}
