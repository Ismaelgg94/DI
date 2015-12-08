using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HojaRol
{
    public partial class SelectorPersonaje : Form
    {
        AlbumPersonajes album= new AlbumPersonajes();
        

        public SelectorPersonaje()
        {
            InitializeComponent();
            //Se ocultara el botón de exportar si no existe ningun personaje
            if (album.numPersonajes() == 0)
                btnExportar.Visible = false;
            //Se colocan los controles centrados relativamente.
            panelContenedor.Left = (Screen.PrimaryScreen.Bounds.Width - panelContenedor.Width) / 2;
            panelContenedor.Top = (Screen.PrimaryScreen.Bounds.Height - panelContenedor.Height) / 2;
            //Arriba a la derecha
            btnSalir.Top = 0;
            btnSalir.Left = Screen.PrimaryScreen.Bounds.Width - btnSalir.Width;


        }

        private void crearPersonaje(object sender, EventArgs e)
        {
            //Se oculta el botón de salir y las imagenes antes de abrir el nuevo formulario
            ocultarAtrezzo();
            Form1 creador = new Form1(album,Constantes.MODO_CREACION);
            
            //Se inicia el creador de personaje, y se pausa este código hasta que se cierre el formulario Creador.
            creador.ShowDialog();
            //Se vuelve a mostrar el selectorDeCampeones 
            mostrarAtrezzo();
            if (album.getPersonajeActual() != null) //Se comprueba que haya personajes en el album, por si el usuario le da a cancelar.
            {
                visualizarPersonaje(album.getPersonajeActual());
                btnImportar.Visible = true;
                btnExportar.Visible = true;
                if (album.numPersonajes() > 1)
                    btnAnterior.Visible = true;
            }
            
        }
        private void visualizarPersonaje(Personaje personaje)
        {
            string genero="";

            //Se infla los controles con los datos del personaje.
            lblNombre.Text = personaje.getNombre();
            lblRaza.Text = personaje.getRaza();
            lblProfesion.Text = personaje.getProfesion();
            lblAttFuerza.Text = personaje.getAtributos().getFuerza().ToString();
            lblAttAgilidad.Text = personaje.getAtributos().getAgilidad().ToString();
            lblAttVitalidad.Text = personaje.getAtributos().getVitalidad().ToString();
            lblAttMente.Text = personaje.getAtributos().getMente().ToString();
            lblAttEspiritu.Text = personaje.getAtributos().getEspiritu().ToString();
            lblAttSuerte.Text = personaje.getAtributos().getSuerte().ToString();
            pbGenero.Location= new Point( lblRaza.Location.X + lblRaza.Width,pbGenero.Location.Y); //Hace que el simbolo del género flote a la derecha de la raza.
            if (personaje.getGenero() == 'M')
            {
                pbGenero.BackgroundImage = Properties.Resources.SimboloMasculino;
                genero = "Masculino";
            }                
            else if (personaje.getGenero() == 'F')
            {
                pbGenero.BackgroundImage = Properties.Resources.SimboloFemenino;
                genero = "Femenino";
            }
                
            //Al existir mínimo 1 personaje, se permite que se vea sus datos y los respectivos botones para modificarlos.
            panelNoHayPersonaje.Visible = false;
            panelPersonaje.Visible = true;

            btnModificar.Visible = true;
            btnBorrar.Visible = true;
            //Carga la imagén del personaje en el selector.
            pbAvatar.BackgroundImage = Image.FromFile(Constantes.PATH_RESOURCES+personaje.getRaza()+personaje.getProfesion()+genero+".png");
            if (album.existeSiguientePersonaje())
                btnSiguiente.Visible = true;
            if (album.existeAnteriorPersonaje())
                btnAnterior.Visible = true;
        }
      

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
                btnSiguiente.Visible = true;
            else
                btnSiguiente.Visible = false;
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
                btnExportar.Visible = false;
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
            ocultarAtrezzo();
            Form1 form1 = new Form1(album,Constantes.MODO_MODIFICACION);

            form1.ShowDialog();
            
            mostrarAtrezzo();
            //Se refresca el selector de personajes.
            visualizarPersonaje(album.getPersonajeActual());
        }
        private void ocultarAtrezzo()
        {
            //Oculta los controles que puedan verse cuando se abra el creadorDePersonajes
            btnSalir.Visible = false;
            panelContenedor.Visible = false;
        }
        private void mostrarAtrezzo()
        {
            btnSalir.Visible = true;
            panelContenedor.Visible = true;
        }
        private void exportarAlbum(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.DefaultExt = "txt";
            dialog.Filter ="Archivo de texto (*.txt)|*.txt|All files (*.*)|*.*";
            string ruta;
            DialogResult resultado = dialog.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                ruta = dialog.FileName;
                if ((Regex.Match(dialog.FileName, ".txt")).Length == 0)
                    ruta += ".txt";

                album.exportarAlbum(ruta);
            }
        }

        private void importarAlbum(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            DialogResult resultado = dialogo.ShowDialog();
            if (resultado == DialogResult.OK)
                if ((Regex.Match(dialogo.FileName, ".txt")).Length > 0)
                {
                    // Si el archivo tiene extensión se importa.
                    album.importarAlbum(dialogo.FileName);
                    if (album.numPersonajes() > 0)
                    {
                        visualizarPersonaje(album.getPersonajeActual());
                        btnExportar.Visible = true;
                    }
                        
                   
                }
                
        }

        

        private void guardarAlbum(object sender, FormClosingEventArgs e)
        {
            //Guarda el album en una ruta por defecto , para guardar el trabajo realizado automaticamente cuando se cierra.
            album.exportarAlbum(Constantes.DEFAULT_ALBUM_PATH);
        }

        private void cargarAlbum(object sender, EventArgs e)
        {
            //Carga el album guardado anteriormente guardado, para recargar el trabajo realizado anteriormente.
            album.importarAlbum(Constantes.DEFAULT_ALBUM_PATH);
            if (album.numPersonajes() > 0)
                visualizarPersonaje(album.getPersonajeActual());
        }

        private void cerrarFormulario(object sender, EventArgs e)
        {
            Close();
        }

        private void cursorMano(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void cursorDefault(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
    }
}
