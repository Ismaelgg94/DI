using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HojaRol
{
    public partial class Form1 : Form
    {
        private AlbumPersonajes album;
        private readonly string PUNTOS_EQUIPO_DEFAULT = "00";
        private string[] equipoSeleccionado = new string[5];
            

        private int fuerzaMin, agilidadMin, vitalidadMin, menteMin, espirituMin, suerteMin;
        

        private Personaje personaje;

        public Form1(AlbumPersonajes album,string modo)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.album = album;
            if (modo.Equals(Constantes.MODO_CREACION))
            {
                
                personaje = new Personaje();
                
                //Se selecciona la raza y profesión por defecto.
                cbRaza.SelectedItem = cbRaza.Items[0];
                rbGuerrero.Checked = true;
                btnConfirmar.Text = "Crear";
                

            }
            else if (modo.Equals(Constantes.MODO_MODIFICACION))
            {
                //Se recupera el personaje que se quiere modificar.
                personaje = album.getPersonajeActual(); 
                recuperarPersonajeExistente(); //Recupera los datos de los controles con los datos del personaje.
                btnConfirmar.Text = "Modificar";
            }
            
            
        }
        
        //---------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------- CUADRO PERSONAJE ----------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------

        private void rbProfesion_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton profesion = (RadioButton)sender;

            //Vuelve a poner Enable=true a los cuadrosVacios que pudieran haber sido puestos a Enabled=false porque estaban vacíos.
            foreach (Control panel in panelDesplegables.Controls)
                if(panel is Panel)
                    foreach (Control pb in panel.Controls)
                        if (pb is PictureBox)
                            pb.Enabled = true;
            
            //Establece el atributo Visible de todos los dedos a "false" para que no se queden visibles las anteriores
            foreach (PictureBox pB in panelEquipoPermitido.Controls)
                pB.Visible = false;

            
            cambiarImagen();
            //Depende del RadioButton activado, se mostrará su equipo permitido.
            if (profesion.Equals(rbGuerrero))
            {
                dedoEspada.Visible = true;
                dedoEscudo.Visible = true;
                dedoPesada.Visible = true;
                dedoLigera.Visible = true;  
            }
            else if (profesion.Equals(rbMago))
            {
                dedoVara.Visible = true;
                dedoLigera.Visible = true;
            }
            else if (profesion.Equals(rbPicaro))
            {
                dedoDaga.Visible = true;
                dedoLigera.Visible = true;

            }
            else if (profesion.Equals(rbCazador))
            {
                dedoArco.Visible = true;
                dedoLigera.Visible = true;         
            }
            reiniciarBarraHabilidades(); // Se devuelven las habilidades a 0.
            reiniciarDesplegables(profesion);// Se establecen los desplegables a su forma por defecto.
            resetearAtributos(profesion); // Se establecen los atributos mínimos según la profesión escogida.

        }
        private void cambiarImagen()
        {
            String profesion="", genero="";
            //Se guarda en la variable profesion, el tag del RadioButton que este marcado.
            foreach (Control rb in panelProfesion.Controls)
                if (rb is RadioButton && ((RadioButton)rb).Checked)
                    profesion = rb.Tag.ToString();

            if (rbMasculino.Checked)
                genero = "Masculino";
            else
                genero = "Femenino";
            //Se forma una dirección absoluta concatenando la ruta de la carpeta Resources del proyecto + raza + profesíón + género.
            pbAvatar.BackgroundImage = Image.FromFile(Path.GetFullPath(Constantes.PATH_RESOURCES+cbRaza.SelectedItem.ToString()+profesion+genero+".png"));
            
        }

        private void rbMasculino_CheckedChanged(object sender, EventArgs e)
        {
            //Se cambia la imagen cada vez que se cambia el género.
            cambiarImagen();
        }

        private void cbRaza_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Si la raza seleccionada en el ComboBox es lilty, solo se permite género femenino.
            if (cbRaza.SelectedItem.Equals(cbRaza.Items[2]))
            {
                rbFemenino.Checked = true;
                rbMasculino.Enabled = false;
            }
            else
                rbMasculino.Enabled = true;

            cambiarImagen();

        }
        //Hace que los iconos manitas parpadeen.
        private void timerParpadeoDedos_Tick(object sender, EventArgs e)
        {
            panelEquipoPermitido.Visible = !panelEquipoPermitido.Visible;
        }
        //------------------------------------------------------------------------------------------------------------------
        //---------------------------------------      HABILIDADES       ---------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------
        private void cambiarPuntosHabilidad(object sender, MouseEventArgs e)
        {
            ProgressBar barra = (ProgressBar)sender;
            int puntosRestantes = int.Parse(lblPHPuntosRestantes.Text);
            if (e.X > barra.Value && puntosRestantes > 0)
            {
                //Si el valor actual de la barra + la cantidad añadida supera el Máximo de la barra,
                //se llena sola automaticamente sin dejar ningún hueco.
                if (barra.Value + barra.Maximum / Constantes.PUNTOS_POR_HAB > barra.Maximum)
                    barra.Value = barra.Maximum;
                else
                    barra.Value += barra.Maximum / Constantes.PUNTOS_POR_HAB;
                lblPHPuntosRestantes.Text = (puntosRestantes - 1).ToString(); //Se resta 1 a los puntos restantes
            }
            else if (e.X < barra.Value && puntosRestantes < Constantes.PUNTOS_RESTANTES_HAB)
            {
                barra.Value -= barra.Maximum / Constantes.PUNTOS_POR_HAB;
                lblPHPuntosRestantes.Text = (puntosRestantes + 1).ToString();
            }
            
            foreach (Control lbl in barra.Parent.Controls)
                if (lbl is Label)
                {
                    lbl.Text = (barra.Value / (barra.Maximum / Constantes.PUNTOS_POR_HAB)).ToString(); //Cambia el número del label de la barra.
                    if (int.Parse(lblPHPuntosRestantes.Text) == 0)
                        lblPHPuntosRestantes.ForeColor = Color.Red;
                    else
                        lblPHPuntosRestantes.ForeColor = Color.White;
                }
                    
            

        }
        
        private void reiniciarBarraHabilidades()
        {
            foreach (Control panels in panelHabilidades.Controls)
                if (panels is Panel)
                    foreach (Control hab in panels.Controls)
                    {
                        if (hab is ProgressBar)
                            ((ProgressBar)hab).Value = 0;
                        else if (hab is Label)
                            hab.Text = "0";
                    }
            lblPHPuntosRestantes.Text = Constantes.PUNTOS_RESTANTES_HAB.ToString();
            lblPHPuntosRestantes.ForeColor = Color.White;
        }

        //-------------------------------------------------------------------------------------------------------------
        // ---------------------------------------        ATRIBUTOS         -------------------------------------------
        //-------------------------------------------------------------------------------------------------------------
        private void resetearAtributos(RadioButton profesion)
        {
            Random rnd = new Random();
            lblAttPuntosRestantes.Text = Constantes.PUNTOS_RESTANTES.ToString();//Se devuelve los puntos restantes al valor por defecto.
            int a = Constantes.FACTOR_ALEATORIO_ATRIBUTOS;

            //Establece los atributos con la suma del atributo mínimo de la profesión + un aleatorio.
            if (profesion.TabIndex == rbGuerrero.TabIndex)
            {
                lblAttFuerza.Text = (Constantes.FUERZA_G_DEFAULT+rnd.Next(a)).ToString();
                lblAttAgilidad.Text = (Constantes.AGILIDAD_G_DEFAULT + rnd.Next(a)).ToString();
                lblAttVitalidad.Text = (Constantes.VITALIDAD_G_DEFAULT + rnd.Next(a)).ToString();
                lblAttEspiritu.Text = (Constantes.ESPIRITU_G_DEFAULT + rnd.Next(a)).ToString();
                lblAttMente.Text = (Constantes.MENTE_G_DEFAULT + rnd.Next(a)).ToString();
                lblAttSuerte.Text = (Constantes.SUERTE_G_DEFAULT + rnd.Next(a)).ToString();
            }
            else if (profesion.TabIndex == rbMago.TabIndex)
            {
                lblAttFuerza.Text = (Constantes.FUERZA_M_DEFAULT + rnd.Next(a)).ToString(); 
                lblAttAgilidad.Text = (Constantes.AGILIDAD_M_DEFAULT + rnd.Next(a)).ToString();
                lblAttVitalidad.Text = (Constantes.VITALIDAD_M_DEFAULT + rnd.Next(a)).ToString();
                lblAttEspiritu.Text = (Constantes.ESPIRITU_M_DEFAULT + rnd.Next(a)).ToString();
                lblAttMente.Text = (Constantes.MENTE_M_DEFAULT + rnd.Next(a)).ToString();
                lblAttSuerte.Text = (Constantes.SUERTE_M_DEFAULT + rnd.Next(a)).ToString();
            }
            else if (profesion.TabIndex == rbPicaro.TabIndex)
            {
                lblAttFuerza.Text = (Constantes.FUERZA_P_DEFAULT + rnd.Next(a)).ToString();
                lblAttAgilidad.Text = (Constantes.AGILIDAD_P_DEFAULT + rnd.Next(a)).ToString();
                lblAttVitalidad.Text = (Constantes.VITALIDAD_P_DEFAULT + rnd.Next(a)).ToString();
                lblAttEspiritu.Text = (Constantes.ESPIRITU_P_DEFAULT + rnd.Next(a)).ToString();
                lblAttMente.Text = (Constantes.MENTE_P_DEFAULT + rnd.Next(a)).ToString();
                lblAttSuerte.Text = (Constantes.SUERTE_P_DEFAULT + rnd.Next(a)).ToString();
            }
            else if (profesion.TabIndex == rbCazador.TabIndex)
            {
                lblAttFuerza.Text = (Constantes.FUERZA_C_DEFAULT + rnd.Next(a)).ToString();
                lblAttAgilidad.Text = (Constantes.AGILIDAD_C_DEFAULT + rnd.Next(a)).ToString();
                lblAttVitalidad.Text = (Constantes.VITALIDAD_C_DEFAULT + rnd.Next(a)).ToString();
                lblAttEspiritu.Text = (Constantes.ESPIRITU_C + rnd.Next(a)).ToString();
                lblAttMente.Text = (Constantes.MENTE_C_DEFAULT + rnd.Next(a)).ToString();
                lblAttSuerte.Text = (Constantes.SUERTE_C_DEFAULT + rnd.Next(a)).ToString();
            }
            //Se indican los valores de atributo mínimos para que en su posterior modificación, no puedan ser inferiores a estos.
            fuerzaMin = int.Parse(lblAttFuerza.Text);
            agilidadMin = int.Parse(lblAttAgilidad.Text);
            vitalidadMin = int.Parse(lblAttVitalidad.Text);
            espirituMin = int.Parse(lblAttEspiritu.Text);
            menteMin = int.Parse(lblAttMente.Text);
            suerteMin = int.Parse(lblAttSuerte.Text);

            //Se resetean los colores de los atributos.
            resetearColoresAtributos();

        }
        private void resetearColoresAtributos()
        {
            lblAttFuerza.ForeColor = Constantes.COLOR_DEFAULT;
            lblAttAgilidad.ForeColor = Constantes.COLOR_DEFAULT;
            lblAttVitalidad.ForeColor = Constantes.COLOR_DEFAULT;
            lblAttMente.ForeColor = Constantes.COLOR_DEFAULT;
            lblAttEspiritu.ForeColor = Constantes.COLOR_DEFAULT;
            lblAttSuerte.ForeColor = Constantes.COLOR_DEFAULT;
            lblAttPuntosRestantes.ForeColor = Constantes.COLOR_DEFAULT;
        }


        private void sumarAtt(object sender, EventArgs e)
        {
            Label lblASumar = null;

            //Se busca el botón que empezó el evento.
            if (sender.Equals(btnSumarFuerza))
                lblASumar = lblAttFuerza;
            else if (sender.Equals(btnSumarAgilidad))
                lblASumar = lblAttAgilidad;
            else if (sender.Equals(btnSumarVitalidad))
                lblASumar = lblAttVitalidad;
            else if (sender.Equals(btnSumarMente))
                lblASumar = lblAttMente;
            else if (sender.Equals(btnSumarEspiritu))
                lblASumar = lblAttEspiritu;
            else if (sender.Equals(btnSumarSuerte))
                lblASumar = lblAttSuerte;

            if (int.Parse(lblAttPuntosRestantes.Text) > 0) // Si los Puntos restantes son mayor que 0, se podrá sumar puntos.
            {
                lblASumar.Text = (int.Parse(lblASumar.Text) + Constantes.PUNTOS_A_REPARTIR).ToString(); //Incrementa en X el atributo seleccionado
                lblAttPuntosRestantes.Text = (int.Parse(lblAttPuntosRestantes.Text) - Constantes.PUNTOS_A_REPARTIR).ToString(); //Decrementa en X los Puntos Restantes 
                lblASumar.ForeColor = Color.Lime; // Cuando se sume a algún atributo, será mas grande que el mínimo, por lo tanto su color será verde para saber que se ha modificado.
            }
            //Si los Puntos Restantes llegan a 0, se le cambiara el color de fuente a Rojo.
            if (int.Parse(lblAttPuntosRestantes.Text) == 0)
                lblAttPuntosRestantes.ForeColor = Color.Red;
        }
        private void restarAtt(object sender, EventArgs e)
        {
            Label lblARestar = null;
            int atributoMin = 0;

            //Se busca el botón que inició el evento.
            if (sender.Equals(btnRestarFuerza))
            {
                lblARestar = lblAttFuerza;
                atributoMin = fuerzaMin;
            }
            else if (sender.Equals(btnRestarAgilidad))
            {
                lblARestar = lblAttAgilidad;
                atributoMin = agilidadMin;
            }
            else if (sender.Equals(btnRestarVitalidad))
            {
                lblARestar = lblAttVitalidad;
                atributoMin = vitalidadMin;
            }
            else if (sender.Equals(btnRestarMente))
            {
                lblARestar = lblAttMente;
                atributoMin = menteMin;
            }
            else if (sender.Equals(btnRestarEspiritu))
            {
                lblARestar = lblAttEspiritu;
                atributoMin = espirituMin;
            }
            else if (sender.Equals(btnRestarSuerte))
            {
                lblARestar = lblAttSuerte;
                atributoMin = suerteMin;
            }
            if (int.Parse(lblAttPuntosRestantes.Text) < Constantes.PUNTOS_RESTANTES && int.Parse(lblARestar.Text) > atributoMin) // Si los Puntos restantes es menor que PUNTOS_RESTANTES y mayor que el atributo mínimo, se podrá restar puntos.
            {
                //Decrementa en X el atributo seleccionado
                lblARestar.Text = (int.Parse(lblARestar.Text) - Constantes.PUNTOS_A_REPARTIR).ToString();
                //Incrementa en X Puntos Restantes
                lblAttPuntosRestantes.Text = (int.Parse(lblAttPuntosRestantes.Text) + Constantes.PUNTOS_A_REPARTIR).ToString(); 
                //Si el atributo es el mínimo de su profesión, su color será blanco.
                if (int.Parse(lblARestar.Text) == atributoMin)
                    lblARestar.ForeColor = Color.White;
            }
            //Si los Puntos Restantes son mayores que 0 , el número aparecerá en color blanco.
            if (int.Parse(lblAttPuntosRestantes.Text) > 0)
                lblAttPuntosRestantes.ForeColor = Color.White;
        }
        //-------------------------------------------------------------------------------------------------------
        // --------------------------------------------    EQUIPO    --------------------------------------------
        //-------------------------------------------------------------------------------------------------------
        private void reiniciarDesplegables(RadioButton profesion)
        {
            //Se reinician todas las imagenes de los desplegables a cuadroVacio (Imagen por defecto)
            foreach (Control panelDesplegable in panelDesplegables.Controls)
                foreach (Control panelesEquipo in panelDesplegable.Controls)
                    foreach (Control control in panelesEquipo.Controls)
                        if (control is Button)
                            control.BackgroundImage = Properties.Resources.cuadroVacio;
                        else if (control is PictureBox)
                        {
                            control.BackgroundImage = Properties.Resources.cuadroVacio;
                            control.Enabled = true; //Reactiva los PictureBox que han podido ser desactivado al cambiar de profesión.
                        }
                            

            reiniciarNumTxtEquipo(); // Se vuelven a desactivar todos los txtEquipo
            //Estos objetos los tienen todos en común.
            huecoProteccion1.BackgroundImage = Properties.Resources.cuadroArmaduraLigera;
            huecoAccesorio1_1.BackgroundImage = Properties.Resources.cuadroAccesorio;
            huecoAccesorio2_1.BackgroundImage = Properties.Resources.cuadroAccesorio;
            huecoProteccion2.Enabled = false; // Se desactiva la segunda protección, y quien la necesite que la active.
            if (profesion.Equals(rbGuerrero))
            { 
                //Se actualizan las imagenes de los desplegables.
                huecoArmaIzquierda1.BackgroundImage = Properties.Resources.cuadroEspada;
                huecoArmaDerecha1.BackgroundImage = Properties.Resources.cuadroEscudo;
                huecoProteccion1.BackgroundImage = Properties.Resources.cuadroArmaduraPesada;
                huecoProteccion2.BackgroundImage = Properties.Resources.cuadroArmaduraLigera;
                huecoProteccion2.Enabled = true;
            }
            else if (profesion.Equals(rbMago))
            {
                //Se actualizan las imagenes de los desplegables.
                huecoArmaIzquierda1.BackgroundImage = Properties.Resources.cuadroVara;
                huecoArmaDerecha1.Enabled = false;
            }
            else if (profesion.Equals(rbPicaro))
            {
                //Se actualizan las imagenes de los desplegables.
                huecoArmaIzquierda1.BackgroundImage = Properties.Resources.cuadroDaga;
                huecoArmaDerecha1.BackgroundImage = Properties.Resources.cuadroDaga;
            }
            else if (profesion.Equals(rbCazador))
            {
                //Se actualizan las imagenes de los desplegables.
                huecoArmaIzquierda1.BackgroundImage = Properties.Resources.cuadroArco;
                huecoArmaDerecha1.Enabled = false;
            }
        }   

        private void mostrarEquipo(object sender, EventArgs e)
        {
            foreach (Control pb in ((Button)sender).Parent.Controls)           
                if (pb is PictureBox && ((PictureBox)pb).Enabled) //Solo se visualizan los cuadros que no estan vacíos.
                    pb.Visible = true;
            
        }


        private void esconderEquipo(object sender, EventArgs e)
        {
            foreach (Control pb in ((Panel)sender).Controls)
                if (pb is PictureBox)
                    pb.Visible = false;
        }
        private void escogerDesplegable(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            int tipoEquipo=0;

            cambiarDesplegables(pb);
            // Dependiendo del tipo de equipo seleccionado (ArmaIzquierda,Proteccion,Accesorio,etc...) 
            if (pb.Parent.Equals(panelDesplegableArmaIzquierda)) tipoEquipo = 0;
            else if (pb.Parent.Equals(panelDesplegableArmaDerecha)) tipoEquipo = 1;
            else if (pb.Parent.Equals(panelDesplegableProteccion)) tipoEquipo = 2;
            else if (pb.Parent.Equals(panelDesplegableAccesorio1)) tipoEquipo = 3;
            else if (pb.Parent.Equals(panelDesplegableAccesorio2)) tipoEquipo = 4;
            // se guardará el nombre del pictureBox seleccionado para cuando se recupere un personaje importado,
            // sepa que equipo seleccionar sin tener que guardarlo en el personaje.
            equipoSeleccionado[tipoEquipo] = pb.Name;
        }
        private void cambiarDesplegables(PictureBox pb)
        {
            Image imagen;

            //Se busca el botón y se le cambia de imagen con la del PictureBox clickeado.
            foreach (Control btn in pb.Parent.Controls)
                if (btn is Button)
                {
                    //Se guarda en una variable aux de la imágen del botón antes de cambiarla para poder 
                    //ponersela al botón clickeado sin que se pierda.
                    imagen = btn.BackgroundImage;
                    btn.BackgroundImage = pb.BackgroundImage;
                    pb.BackgroundImage = imagen;

                    //Si es cuadroVacio desactiva toda la linea de atributos del equipo y al contrario si no lo es.
                    if (compararImagenes((Bitmap)btn.BackgroundImage, Properties.Resources.cuadroVacio))
                        desasctivarTxtEquipo(pb);
                    else
                        activarTxtEquipo(pb);

                }
        }

        
        private bool compararImagenes(Bitmap primeraImagen, Bitmap segundaImagen)
        {
            string primerPixel, segundoPixel;

            if (primeraImagen.Width == segundaImagen.Width && primeraImagen.Height == segundaImagen.Height) //Se comprueba que tengan la misma resolución.
            {
                for (int i = 20; i < primeraImagen.Height; i++)
                    for (int j = 20; j < primeraImagen.Width; j++)
                    {
                        primerPixel = primeraImagen.GetPixel(j, i).ToString();
                        segundoPixel = segundaImagen.GetPixel(j, i).ToString();
                        if (!primerPixel.Equals(segundoPixel)) // Si los píxeles no son iguales, se sale del método devolviendo un false.
                            return false;
                    }
                return true; // Si no salió con el anterior return, es que las imágenes son iguales.        
            }
            else //No tienen los mismos píxeles
                return false;
            
            
        }

        
        private void reiniciarNumTxtEquipo()
        {
            foreach (Control paneles in panelDesplegables.Controls)
                foreach (Control txt in paneles.Controls)
                    if (txt is TextBox)
                    {
                        //Se restauran los txt al valor por defecto y se desactivan.
                        txt.Text = PUNTOS_EQUIPO_DEFAULT;
                        txt.Enabled = false;
                    }

        }
        private void activarTxtEquipo(PictureBox pb)
        {
            foreach (Control txt in pb.Parent.Parent.Controls)
                if (txt is TextBox)
                    txt.Enabled = true;

            foreach (Control btn in pb.Parent.Controls)
                if (btn is Button)
                {
                    //Desactivación por Profesión personalizado
                    if (compararImagenes((Bitmap)btn.BackgroundImage, Properties.Resources.cuadroEspada))
                        txtPMArmaIzquierda.Enabled = false;
                    else if (compararImagenes((Bitmap)btn.BackgroundImage, Properties.Resources.cuadroVara))
                        txtAtqArmaIzquierda.Enabled = false;
                    else if (compararImagenes((Bitmap)btn.BackgroundImage, Properties.Resources.cuadroEscudo))
                    {
                        txtAtqArmaDerecha.Enabled = false;
                        txtPMArmaDerecha.Enabled = false;
                    }
                    else if (compararImagenes((Bitmap)btn.BackgroundImage, Properties.Resources.cuadroArco))
                        txtPMArmaIzquierda.Enabled = false;

                    else if (compararImagenes((Bitmap)btn.BackgroundImage, Properties.Resources.cuadroDaga))
                    {
                        if (btn.Parent == panelDesplegableArmaDerecha)
                        {
                            txtPMArmaDerecha.Enabled = false;
                            txtDefArmaDerecha.Enabled = false;
                            txtDefMagArmaDerecha.Enabled = false;
                        }
                        else if (btn.Parent == panelDesplegableArmaIzquierda)
                        {
                            txtPMArmaIzquierda.Enabled = false;
                            txtDefArmaIzquierda.Enabled = false;
                            txtDefMagArmaIzquierda.Enabled = false;
                        }
                    }
                    txtAtqProteccion.Enabled = false;
                    txtPMProteccion.Enabled = false;
                }
                    
        }


        private void desasctivarTxtEquipo(PictureBox pb)
        {
            foreach (Control txt in pb.Parent.Parent.Controls)
                if (txt is TextBox)
                {
                    txt.Text = PUNTOS_EQUIPO_DEFAULT;
                    txt.Enabled = false;
                }

        }

        
        private void crearPersonaje()
        {
            
            //Se CONFIGURA el personaje a CREAR.
            personaje.setNombre(txtNombre.Text);
            personaje.setRaza(cbRaza.SelectedItem.ToString());
            if (rbMasculino.Checked)
                personaje.setGenero('M');
            else
                personaje.setGenero('F');
            //Profesión
            foreach(Control rb in panelProfesion.Controls)
                if(rb is RadioButton && ((RadioButton)rb).Checked)
                    personaje.setProfesion(rb.Tag.ToString());
            //Atributos
            //Fuerza - Agilidad - Vitalidad - Mente - Espiritu - Suerte
            personaje.setAtributos(new Atributos(int.Parse(lblAttFuerza.Text), int.Parse(lblAttAgilidad.Text), int.Parse(lblAttVitalidad.Text), int.Parse(lblAttMente.Text), int.Parse(lblAttEspiritu.Text), int.Parse(lblAttSuerte.Text)));
            //Habilidades
            //Correr - Saltar - Nadar - Sigilo - Cocinar - Negociar - Hurtar - Rastrear
            personaje.setHabilidades(new Habilidades(int.Parse(lblNumCorrer.Text), int.Parse(lblNumSaltar.Text), int.Parse(lblNumNadar.Text), int.Parse(lblNumSigilo.Text), int.Parse(lblNumCocinar.Text), int.Parse(lblNumNegociar.Text), int.Parse(lblNumHurtar.Text), int.Parse(lblNumRastrear.Text)));

            //Equipo 
            personaje.setArmaIzquierda(new Equipo(equipoSeleccionado[0], int.Parse(txtAtqArmaIzquierda.Text), int.Parse(txtPMArmaIzquierda.Text),int.Parse(txtDefArmaIzquierda.Text),int.Parse(txtDefMagArmaIzquierda.Text)));
            personaje.setArmaDerecha(new Equipo(equipoSeleccionado[1], int.Parse(txtAtqArmaDerecha.Text), int.Parse(txtPMArmaDerecha.Text), int.Parse(txtDefArmaDerecha.Text), int.Parse(txtDefMagArmaDerecha.Text)));
            personaje.setProteccion(new Equipo(equipoSeleccionado[2], int.Parse(txtAtqProteccion.Text), int.Parse(txtPMProteccion.Text), int.Parse(txtDefProteccion.Text), int.Parse(txtDefMagProteccion.Text)));
            personaje.setAccesorio1(new Equipo(equipoSeleccionado[3], int.Parse(txtAtqAccesorio1.Text), int.Parse(txtPMAccesorio1.Text), int.Parse(txtDefAccesorio1.Text), int.Parse(txtDefMagAccesorio1.Text)));
            personaje.setAccesorio2(new Equipo(equipoSeleccionado[4], int.Parse(txtAtqAccesorio2.Text), int.Parse(txtPMAccesorio2.Text), int.Parse(txtDefAccesorio2.Text), int.Parse(txtDefMagAccesorio2.Text)));

            
            
        }
        
        //Selecciona según en el modo en el que se entre al Form1, si el botón de confirmación es de creación o de modificación 
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            confirmarPersonaje(); 
        }
        //Crea el personaje o lo modifica y se sale del creador.
        private void confirmarPersonaje()
        {
            if (txtNombre.Text != "") //Controla que se le haya puesto nombre al personaje.
            {
                crearPersonaje();
                if (btnConfirmar.Text == "Crear")
                    album.introducirPersonaje(personaje); //Lo introduce en la última posición del album.
                else if (btnConfirmar.Text == "Modificar")
                    album.modificarPersonaje(personaje); //Sobreescribe el personaje que se quería modificar.

                Close();
            }
            else
                lblErrorNombre.Visible = true;
        }

        private void cancelarFormulario(object sender, EventArgs e)
        {
            Close();
        }



        // ----------------------- Limitadores de TextBox ------------------------------
        private void selectAllText(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                ((TextBox)sender).SelectAll();
            });
            
        }


        private void soloNumeros(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar)) //Permite introducir números
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))//Permite introducir teclas de control (Borrar,etc)
                e.Handled = false;       
            else
                e.Handled = true; //Prohibe todo lo demás.
        }

        
        private void recuperarPersonajeExistente()
        {
            Equipo[] equipoEntero = { personaje.getArmaIzquierda(), personaje.getArmaDerecha(), personaje.getProteccion(), personaje.getAccesorio1(), personaje.getAccesorio2() };
           
            txtNombre.Text = personaje.getNombre();
            cbRaza.SelectedItem=cbRaza.Items[cbRaza.Items.IndexOf(personaje.getRaza())]; //Se establece la raza del personaje.
            //Género
            if (personaje.getGenero() == 'M')
                rbMasculino.Checked = true;
            else if(personaje.getGenero() == 'F')
                rbMasculino.Checked = true;
            //Profesión
            if (personaje.getProfesion() == Constantes.GUERRERO)
                rbGuerrero.Checked = true;
            else if (personaje.getProfesion() == Constantes.MAGO)
                rbMago.Checked = true;
            else if (personaje.getProfesion() == Constantes.PICARO)
                rbPicaro.Checked = true;
            else if (personaje.getProfesion() == Constantes.CAZADOR)
                rbCazador.Checked = true;
            panelProfesion.Enabled = false; //No se podrá cambiar la profesión una vez creado el personaje
            //Habilidades
            recuperarBarraHabilidades(barraCorrer, personaje.getHabilidades().getCorrer());
            recuperarBarraHabilidades(barraSaltar, personaje.getHabilidades().getSaltar());
            recuperarBarraHabilidades(barraNadar, personaje.getHabilidades().getNadar());
            recuperarBarraHabilidades(barraSigilo, personaje.getHabilidades().getSigilo());
            recuperarBarraHabilidades(barraCocinar, personaje.getHabilidades().getCocinar());
            recuperarBarraHabilidades(barraNegociar, personaje.getHabilidades().getNegociar());
            recuperarBarraHabilidades(barraHurtar, personaje.getHabilidades().getHurtar());
            recuperarBarraHabilidades(barraRastrear, personaje.getHabilidades().getRastrear());
            if (lblPHPuntosRestantes.Text == "0")
                lblPHPuntosRestantes.ForeColor = Color.Red;
            panelHabilidades.Enabled = false; //No se podrá cambiar las habilidades una vez creado el personaje.
            //Atributos
            lblAttFuerza.Text = personaje.getAtributos().getFuerza().ToString();
            lblAttAgilidad.Text = personaje.getAtributos().getAgilidad().ToString();
            lblAttVitalidad.Text = personaje.getAtributos().getVitalidad().ToString();
            lblAttMente.Text = personaje.getAtributos().getMente().ToString();
            lblAttEspiritu.Text = personaje.getAtributos().getEspiritu().ToString();
            lblAttSuerte.Text = personaje.getAtributos().getSuerte().ToString();
                //No se podrá modificar los atributos
            lblAttPuntosRestantes.Text = "00";
            lblAttPuntosRestantes.ForeColor = Color.Red;
            panelAtributos.Enabled = false;
            foreach (Control pb in panelAtributos.Controls)
                if (pb is PictureBox)
                    pb.Visible = false;
            //Equipo
                //Imagenes
            recuperarImagenesEquipo(panelDesplegableArmaIzquierda,personaje.getArmaIzquierda().getImg());
            recuperarImagenesEquipo(panelDesplegableArmaDerecha,personaje.getArmaDerecha().getImg());
            recuperarImagenesEquipo(panelDesplegableProteccion, personaje.getProteccion().getImg());
            recuperarImagenesEquipo(panelDesplegableAccesorio1, personaje.getAccesorio1().getImg());
            recuperarImagenesEquipo(panelDesplegableAccesorio2, personaje.getAccesorio2().getImg());
                //Atributos
            recuperarAtributosEquipo(equipoEntero);
            
            

        }
        private void recuperarAtributosEquipo(Equipo[] equipoEntero)
        {
            int[] atributos = new int[4];
            Panel panel =null;
            int contador = 0;
            //Recorre todas las partes del equipo
            for (int i = 0; i < equipoEntero.Length; i++)
            {
                //Guarda los atributos del equipo seleccionado.
                atributos[0]= equipoEntero[i].getAtq();
                atributos[1] = equipoEntero[i].getPoderMag();
                atributos[2] = equipoEntero[i].getDefFis();
                atributos[3] = equipoEntero[i].getDefMag();
                //Escoge el panel deonde se encuentran los TextBox del equipo seleccionado.
                switch (i)
                {
                    case 0:
                        panel = panelArmaIzquierda;
                        break;
                    case 1:
                        panel = panelArmaDerecha;
                        break;
                    case 2:
                        panel = panelProteccion;
                        break;
                    case 3:
                        panel = panelAccesorio1;
                        break;
                    case 4:
                        panel = panelAccesorio2;
                        break; 
                }
                //Recorre los TextBox del panel seleccionado ordenadamente por el TabIndex
                foreach (Control txt in panel.Controls.Cast<Control>().OrderBy(c => c.TabIndex))
                    if (txt is TextBox)
                    {
                        //Asigna al TextBox.text el valor del atributo guardado y si es "0" lo convierte en "00".
                        txt.Text = atributos[contador].ToString();
                        if (txt.Text.Equals("0"))
                            txt.Text = "00";
                    
                        contador++;
                    }
                
                contador = 0; //Reinicializa el contador por cada equipo que termina.
            }
        }
        private void recuperarBarraHabilidades(ProgressBar barra, int numPuntos)
        {
            //Recupera los puntos restantes que dejó el usuario a la hora de crearlo, restandole el 
            //número de puntos que tiene en la barra al número de puntos totales que se pueden
            // utilizar.
            lblPHPuntosRestantes.Text = (int.Parse(lblPHPuntosRestantes.Text) - numPuntos).ToString();
            barra.Value = barra.Maximum / Constantes.PUNTOS_POR_HAB * numPuntos;
            foreach (Control lbl in barra.Parent.Controls)
                if (lbl is Label)
                    lbl.Text = numPuntos.ToString();
           
        }
        private void recuperarImagenesEquipo(Panel panelEquipo,string nombrePb)
        {
            foreach (Control c in panelEquipo.Controls)
                //Busca las imagenes que contiene el desplegable indicado y cambia el cuadroVacio que aparece
                // al principio por el que tiene el personaje.
                if (c is PictureBox && ((PictureBox)c).Name==nombrePb)
                    cambiarDesplegables((PictureBox)c); 
        }

        //                      Control de Teclas
        private void teclaPresionada(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                Close();
            else if (e.KeyChar == (char)Keys.Enter)
                confirmarPersonaje();
        }
    }
}
