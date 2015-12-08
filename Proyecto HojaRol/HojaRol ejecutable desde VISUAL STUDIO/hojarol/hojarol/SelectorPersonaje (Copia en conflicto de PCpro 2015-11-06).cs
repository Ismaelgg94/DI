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

namespace HojaRol
{
    public partial class SelectorPersonaje : Form
    {
        AlbumPersonajes album= new AlbumPersonajes();
        Personaje personaje;

        public SelectorPersonaje()
        {
            
            InitializeComponent();
            //Se centra el panel al centro del formulario.
            panelSelectorPersonaje.Location = new Point(this.Width / 2 - panelSelectorPersonaje.Width/2, this.Height / 2- panelSelectorPersonaje.Height/2);
            panelSelectorPersonaje.Anchor = AnchorStyles.None;
        }

        private void crearPersonaje(object sender, EventArgs e)
        {
            Form1 creador = new Form1(album,Constantes.MODO_CREACION);
            
            creador.Show(this); //Se inicia el formulario de creación de personaje pasandole quien es el padre.
            //No se puede parar el método mientras se utiliza el otro formulario.
            
        }
        private void visualizarPersonaje(Personaje personaje)
        {
            lblNombre.Text = personaje.getNombre();
            lblRaza.Text = personaje.getRaza();
            lblProfesion.Text = personaje.getProfesion().getProfesion();
            pbAvatar.BackgroundImage = personaje.getImagen().getImagen();
            lblAttFuerza.Text = personaje.getAtributos().getFuerza().ToString();
            lblAttAgilidad.Text = personaje.getAtributos().getAgilidad().ToString();
            lblAttVitalidad.Text = personaje.getAtributos().getVitalidad().ToString();
            lblAttMente.Text = personaje.getAtributos().getMente().ToString();
            lblAttEspiritu.Text = personaje.getAtributos().getEspiritu().ToString();
            lblAttSuerte.Text = personaje.getAtributos().getSuerte().ToString();
            pbGenero.Location= new Point(lblRaza.Location.X + lblRaza.Width,pbGenero.Location.Y); //Hace que el simbolo del género flote a la derecha de la raza.
            if (personaje.getGenero() == 'M')
                pbGenero.BackgroundImage = Properties.Resources.SimboloMasculino;
            else if (personaje.getGenero() == 'F')
                pbGenero.BackgroundImage = Properties.Resources.SimboloFemenino;
        }
      /*  //Método usado por otras clases para pasarle a esta un personaje.
        public void pasarPersonaje(Personaje personaje)
        {
            album.introducirPersonaje(personaje);

            panelNoHayPersonaje.Visible = false;
            panelPersonaje.Visible = true;

            btnModificar.Visible = true;
            btnBorrar.Visible = true;

            if (album.numPersonajes() > 1)
                btnAnterior.Visible = true;

            visualizarPersonaje(personaje);
        }*/

        private void siguientePersonaje(object sender, EventArgs e)
        {
            //Si existe un siguiente personaje, se pasará al siguiente y se visualizará.
            if (album.existeSiguientePersonaje())
            {
                visualizarPersonaje(album.siguientePersonaje());
                btnAnterior.Visible = true;
            }
            //Si despues de haber pasado el personaje, existen mas personajes posteriormente, 
            //se activará el botón de siguiente.
            if (album.existeSiguientePersonaje())
                btnSiguiente.Visible = false;
            else
                btnSiguiente.Visible = true;
        }

        private void anteriorPersonaje(object sender, EventArgs e)
        {
            //Si existe un personaje anterior, se pasará al anterior y se visualizará.
            if (album.existeAnteriorPersonaje())
            {
                visualizarPersonaje(album.anteriorPersonaje());
                btnSiguiente.Visible = true;
            }
            //Si despues de haber pasado el personaje, existen mas personajes anteriores, 
            //se activará el botón de anterior.
            if (album.existeAnteriorPersonaje())
                btnAnterior.Visible = true;
            else
                btnAnterior.Visible = false;

            
            
        }

        private void borrarPersonaje(object sender, EventArgs e)
        {
            if(!album.eliminarPersonajeActual())
            {
                //Si no se ha podido eliminar nada, es que no quedan personajes se oculta todo y se muestra el mensaje
                //de que no quedan personajes.
                panelPersonaje.Visible = false;
                panelNoHayPersonaje.Visible = true;
                btnBorrar.Visible = false;
                btnModificar.Visible = false;
                btnAnterior.Visible = false;
                btnAnterior.Visible = false;
            }
            else
            {
                visualizarPersonaje(album.getPersonajeActual());
                //Si solo queda un personaje, no permitir que se pueda pasar al anterior o al siguiente.
                if (album.numPersonajes() == 1)
                {
                    btnSiguiente.Visible = false;
                    btnAnterior.Visible = false;
                }
                    
            }
            
                
        }

        private void modificarPersonaje(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(album,Constantes.MODO_MODIFICACION);
            form1.Show();
            visualizarPersonaje(album.getPersonajeActual());
        }
    }
}
