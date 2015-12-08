using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        ArrayList listaPersonas = new ArrayList();
        int contador= 0;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            nacimiento(); //Crea una persona inicial
            
        }
        

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //Cada vez que el ratón se mueve, cada persona ejecuta su método mirar() y se mueven si el ratón se dirige a ellos.
            foreach (UnionPersonaBoton p in listaPersonas)
            {
                p.getPersona().mirar(this, e);
                p.getB().Location = p.getPersona().getPosicion();
            }  
        }

        private void timer(object sender, EventArgs e)
        {
            //Comprueba si ha finalizado la partida
            if (listaPersonas.Count == 0)
            {
                
                timer1.Enabled = false;
                MessageBox.Show("Has ganado");
                this.Close();
                
            }
            else
            {
                //Aumenta el tamaño de las personas
                foreach (UnionPersonaBoton p in listaPersonas)
                {
                    p.getPersona().crecer();
                    p.getB().Width = p.getPersona().getTamano().Width;
                    p.getB().Height = p.getPersona().getTamano().Height;
                }

                if (contador % 2 == 0) //Añade mas tiempo para que nacimiento tarde mas
                    nacimiento();


                contador++;
            }
            
                
        }

        private void nacimiento()
        {
            UnionPersonaBoton p = new UnionPersonaBoton(new Point(this.Width, this.Height));
            this.Controls.Add(p.getB());    // Añade la imagen del botón al formulario
            p.getB().Click+= new EventHandler(matar); //Cuando un botón es clickado ejecuta el evento matar()
            listaPersonas.Add(p);

        }

        public void matar(Object sender, EventArgs e)
        {
            int i = 0;
            foreach (UnionPersonaBoton p in listaPersonas)
            {
                if(p.getB() == sender)
                {
                    p.getPersona().morir(p.getB());
                    break;
                }
                i++;

            }
            listaPersonas.RemoveAt(i);
           
            
        }
      
    }
}
