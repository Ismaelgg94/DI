using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// la misma práctica incorporando múltiples personas huyendo del mismo monstruo
namespace BotonEscapista
{
    public partial class Form1 : Form
    {

        Point oldpunto = new Point(0, 0);
        int contador = 0; // para generar nuevas personas cada cierto número de ticks
        ArrayList lista = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized; // maximizo la ventana
        }

        // función pitagórica que devuelve la distancia entre dos puntos
        private int fDistancia(Point p1, Point p2) { return (int) Math.Pow(Math.Pow(p1.X - p2.X , 2) + Math.Pow(p1.Y - p2.Y , 2) , 0.5); }
        
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (oldpunto != e.Location) // el evento mouse move se lanza múltiples veces por cada movimiento de ratón, por lo que debo controlarlo
            {
                Point p = e.Location;
                oldpunto = new Point(e.Location.X, e.Location.Y);

                foreach (PersonaCompleta ejPersona in lista) // el monstruo se mueve -> todos los personajes miran y huyen
                {
                    ejPersona.Pers.mirar(e.Location, this.Size);
                    ejPersona.Pers.mostrar(ejPersona.Bot);
                }
            }                        
        }
        
        private void tePille(object Sender, System.EventArgs e)
        {
            int i = 0;
            foreach (PersonaCompleta ejPersona in lista)
            {
                if (ejPersona.Bot == Sender) // busco que sea el mismo boton -> que muera!
                {                
                    ejPersona.Pers.morir(ejPersona.Bot);
                    break;
                }
            }
            lista.RemoveAt(i); // borro de la colección toda la información de la persona (persona y boton)

            if (lista.Count == 0) // si no hay nada en la lista -> ha ganado la partida
            {
                timer1.Enabled = false;
                MessageBox.Show("¡FELICIDADES! ¡HAS GANADO!");
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {            
            if (contador % 20 == 0) // crea una persona nueva cada 20 ticks
            {                
                PersonaCompleta nuevaPersona = new PersonaCompleta(new Persona(this.Size), fNuevoBoton());
                lista.Add(nuevaPersona);
            }

            // y crece en cada tick
            foreach (PersonaCompleta ejPersona in lista)
            {
                ejPersona.Pers.crece();
                ejPersona.Pers.mostrar(ejPersona.Bot);
            }
            ++contador;
        }

        public Button fNuevoBoton() // función que crea un botón con el aspecto base
        {
            Button elBoton = new Button();
            elBoton.Size = new Size(0, 0); // esto se pondrá con los valores de la persona
            elBoton.Location = new Point(0,0); // esto se pondrá con los valores de la persona
            elBoton.BackgroundImage = Properties.Resources.persona;
            elBoton.AutoSizeMode = AutoSizeMode.GrowOnly;
            elBoton.BackColor = Color.DarkGreen;
            elBoton.BackgroundImageLayout = ImageLayout.Zoom;
            elBoton.Cursor = Cursors.Cross;
            elBoton.FlatAppearance.BorderSize = 0;
            elBoton.FlatStyle = FlatStyle.Flat;
            this.Controls.Add(elBoton);

            // linkar su click al método "tePille"
            elBoton.Click += new EventHandler(this.tePille);

            return elBoton;
        }
    }
    
}
