using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HojaRol
{
    public partial class Form1 : Form, IPasoDeDatos
    {
        private readonly string PUNTOS_EQUIPO_DEFAULT = "00";
        private readonly int PUNTOS_RESTANTES = 10, PUNTOS_A_REPARTIR=1;
        
        private int fuerzaMin, agilidadMin, vitalidadMin, menteMin, espirituMin, suerteMin;
        private Color COLOR_DEFAULT = Color.White;
        private readonly int FACTOR_ALEATORIO_ATRIBUTOS = 10;
        private readonly int PUNTOS_POR_HAB = 5;
        private readonly int PUNTOS_RESTANTES_HAB = 5;
        
        private Personaje personaje = new Personaje();

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            //Se selecciona la raza y profesión por defecto.
            cbRaza.SelectedItem = cbRaza.Items[0]; 
            rbGuerrero.Checked = true;
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

            
            cambiarImagen(cbRaza);
            //Depende del RadioButton activado, se mostrará su equipo permitido.
            if (profesion.Equals(rbGuerrero))
            {
                personaje.getProfesion().setProfesion(Profesion.GUERRERO);
                dedoEspada.Visible = true;
                dedoEscudo.Visible = true;
                dedoPesada.Visible = true;
                dedoLigera.Visible = true;  
            }
            else if (profesion.Equals(rbMago))
            {
                personaje.getProfesion().setProfesion(Profesion.MAGO);
                dedoVara.Visible = true;
                dedoLigera.Visible = true;
            }
            else if (profesion.Equals(rbPicaro))
            {
                personaje.getProfesion().setProfesion(Profesion.PICARO);
                dedoDaga.Visible = true;
                dedoLigera.Visible = true;

            }
            else if (profesion.Equals(rbCazador))
            {
                personaje.getProfesion().setProfesion(Profesion.CAZADOR);
                dedoArco.Visible = true;
                dedoLigera.Visible = true;         
            }
            reiniciarBarraHabilidades(); // Se devuelven las habilidades a 0.
            reiniciarDesplegables(profesion);// Se establecen los desplegables a su forma por defecto.
            resetearAtributos(profesion); // Se establecen los atributos mínimos según la profesión escogida.

        }
        private void cambiarImagen(ComboBox cbRaza)
        {
            pbAvatar.BackgroundImage = personaje.getImagen().establecerImagen(cbRaza, rbMasculino, panelProfesion);
        }

        private void rbMasculino_CheckedChanged(object sender, EventArgs e)
        {
            //Se cambia la imagen cada vez que se cambia el género.
            cambiarImagen(cbRaza);
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

            cambiarImagen((ComboBox)sender);

        }
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
                if (barra.Value + barra.Maximum / PUNTOS_POR_HAB > barra.Maximum)
                    barra.Value = barra.Maximum;
                else
                    barra.Value += barra.Maximum / PUNTOS_POR_HAB;
                lblPHPuntosRestantes.Text = (puntosRestantes - 1).ToString(); //Se resta 1 a los puntos restantes
            }
            else if (e.X < barra.Value && puntosRestantes < PUNTOS_RESTANTES_HAB)
            {
                barra.Value -= barra.Maximum / PUNTOS_POR_HAB;
                lblPHPuntosRestantes.Text = (puntosRestantes + 1).ToString();
            }


            foreach (Control lbl in barra.Parent.Controls)
                if (lbl is Label)
                {
                    lbl.Text = (barra.Value / (barra.Maximum / PUNTOS_POR_HAB)).ToString(); //Cambia el número del label de la barra.
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
                            hab.Text = 0.ToString();
                    }
            lblPHPuntosRestantes.Text = PUNTOS_RESTANTES_HAB.ToString();
            lblPHPuntosRestantes.ForeColor = Color.White;
        }

        //-------------------------------------------------------------------------------------------------------------
        // ---------------------------------------        ATRIBUTOS         -------------------------------------------
        //-------------------------------------------------------------------------------------------------------------
        private void resetearAtributos(RadioButton profesion)
        {
            Random rnd = new Random();
            lblAttPuntosRestantes.Text = PUNTOS_RESTANTES.ToString();//Se devuelve los puntos restantes al valor por defecto.

            //Establece los atributos con la suma del atributo mínimo de la profesión + un aleatorio.
            if (profesion.TabIndex == rbGuerrero.TabIndex)
            {
                lblAttFuerza.Text = (Profesion.FUERZA_G_DEFAULT+rnd.Next(FACTOR_ALEATORIO_ATRIBUTOS)).ToString();
                lblAttAgilidad.Text = (Profesion.AGILIDAD_G_DEFAULT + rnd.Next(FACTOR_ALEATORIO_ATRIBUTOS)).ToString();
                lblAttVitalidad.Text = (Profesion.VITALIDAD_G_DEFAULT + rnd.Next(FACTOR_ALEATORIO_ATRIBUTOS)).ToString();
                lblAttEspiritu.Text = (Profesion.ESPIRITU_G_DEFAULT + rnd.Next(FACTOR_ALEATORIO_ATRIBUTOS)).ToString();
                lblAttMente.Text = (Profesion.MENTE_G_DEFAULT + rnd.Next(FACTOR_ALEATORIO_ATRIBUTOS)).ToString();
                lblAttSuerte.Text = (Profesion.SUERTE_G_DEFAULT + rnd.Next(FACTOR_ALEATORIO_ATRIBUTOS)).ToString();
            }
            else if (profesion.TabIndex == rbMago.TabIndex)
            {
                lblAttFuerza.Text = (Profesion.FUERZA_M_DEFAULT + rnd.Next(FACTOR_ALEATORIO_ATRIBUTOS)).ToString(); 
                lblAttAgilidad.Text = (Profesion.AGILIDAD_M_DEFAULT + rnd.Next(FACTOR_ALEATORIO_ATRIBUTOS)).ToString();
                lblAttVitalidad.Text = (Profesion.VITALIDAD_M_DEFAULT + rnd.Next(FACTOR_ALEATORIO_ATRIBUTOS)).ToString();
                lblAttEspiritu.Text = (Profesion.ESPIRITU_M_DEFAULT + rnd.Next(FACTOR_ALEATORIO_ATRIBUTOS)).ToString();
                lblAttMente.Text = (Profesion.MENTE_M_DEFAULT + rnd.Next(FACTOR_ALEATORIO_ATRIBUTOS)).ToString();
                lblAttSuerte.Text = (Profesion.SUERTE_M_DEFAULT + rnd.Next(FACTOR_ALEATORIO_ATRIBUTOS)).ToString();
            }
            else if (profesion.TabIndex == rbPicaro.TabIndex)
            {
                lblAttFuerza.Text = (Profesion.FUERZA_P_DEFAULT + rnd.Next(FACTOR_ALEATORIO_ATRIBUTOS)).ToString();
                lblAttAgilidad.Text = (Profesion.AGILIDAD_P_DEFAULT + rnd.Next(FACTOR_ALEATORIO_ATRIBUTOS)).ToString();
                lblAttVitalidad.Text = (Profesion.VITALIDAD_P_DEFAULT + rnd.Next(FACTOR_ALEATORIO_ATRIBUTOS)).ToString();
                lblAttEspiritu.Text = (Profesion.ESPIRITU_P_DEFAULT + rnd.Next(FACTOR_ALEATORIO_ATRIBUTOS)).ToString();
                lblAttMente.Text = (Profesion.MENTE_P_DEFAULT + rnd.Next(FACTOR_ALEATORIO_ATRIBUTOS)).ToString();
                lblAttSuerte.Text = (Profesion.SUERTE_P_DEFAULT + rnd.Next(FACTOR_ALEATORIO_ATRIBUTOS)).ToString();
            }
            else if (profesion.TabIndex == rbCazador.TabIndex)
            {
                lblAttFuerza.Text = (Profesion.FUERZA_C_DEFAULT + rnd.Next(FACTOR_ALEATORIO_ATRIBUTOS)).ToString();
                lblAttAgilidad.Text = (Profesion.AGILIDAD_C_DEFAULT + rnd.Next(FACTOR_ALEATORIO_ATRIBUTOS)).ToString();
                lblAttVitalidad.Text = (Profesion.VITALIDAD_C_DEFAULT + rnd.Next(FACTOR_ALEATORIO_ATRIBUTOS)).ToString();
                lblAttEspiritu.Text = (Profesion.ESPIRITU_C + rnd.Next(FACTOR_ALEATORIO_ATRIBUTOS)).ToString();
                lblAttMente.Text = (Profesion.MENTE_C_DEFAULT + rnd.Next(FACTOR_ALEATORIO_ATRIBUTOS)).ToString();
                lblAttSuerte.Text = (Profesion.SUERTE_C_DEFAULT + rnd.Next(FACTOR_ALEATORIO_ATRIBUTOS)).ToString();
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
            lblAttFuerza.ForeColor = COLOR_DEFAULT;
            lblAttAgilidad.ForeColor = COLOR_DEFAULT;
            lblAttVitalidad.ForeColor = COLOR_DEFAULT;
            lblAttMente.ForeColor = COLOR_DEFAULT;
            lblAttEspiritu.ForeColor = COLOR_DEFAULT;
            lblAttSuerte.ForeColor = COLOR_DEFAULT;
            lblAttPuntosRestantes.ForeColor = COLOR_DEFAULT;
        }


        private void sumarAtt(object sender, EventArgs e)
        {
            Label lblASumar = null;
            int atributoMin = 0;

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
                lblASumar.Text = (int.Parse(lblASumar.Text) + PUNTOS_A_REPARTIR).ToString(); //Incrementa en X el atributo seleccionado
                lblAttPuntosRestantes.Text = (int.Parse(lblAttPuntosRestantes.Text) - PUNTOS_A_REPARTIR).ToString(); //Decrementa en X los Puntos Restantes 
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
            if (int.Parse(lblAttPuntosRestantes.Text) < PUNTOS_RESTANTES && int.Parse(lblARestar.Text) > atributoMin) // Si los Puntos restantes es menor que PUNTOS_RESTANTES y mayor que el atributo mínimo, se podrá restar puntos.
            {
                lblARestar.Text = (int.Parse(lblARestar.Text) - PUNTOS_A_REPARTIR).ToString(); //Decrementa en X el atributo seleccionado
                lblAttPuntosRestantes.Text = (int.Parse(lblAttPuntosRestantes.Text) + PUNTOS_A_REPARTIR).ToString(); //Incrementa en X Puntos Restantes
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
            foreach (Control panelDesplegable in panelDesplegables.Controls)
                foreach (Control panelesEquipo in panelDesplegable.Controls)
                    foreach (Control control in panelesEquipo.Controls)
                        if (control is Button)
                            control.BackgroundImage = Properties.Resources.cuadroVacio;
                        else if (control is PictureBox)
                            control.Enabled = true; //Reactiva los PictureBox que han podido ser desactivado al cambiar de profesión.

            reiniciarNumTxtEquipo(); // Se vuelven a desactivar todos los txtEquipo

            huecoProteccion1.BackgroundImage = Properties.Resources.cuadroArmaduraLigera;
            huecoAccesorio1_1.BackgroundImage = Properties.Resources.cuadroAccesorio;
            huecoAccesorio2_1.BackgroundImage = Properties.Resources.cuadroAccesorio;
            if (profesion.Equals(rbGuerrero))
            { 
                //Se actualizan las imagenes de los desplegables.
                huecoArmaIzquierda1.BackgroundImage = Properties.Resources.cuadroEspada;
                huecoArmaDerecha1.BackgroundImage = Properties.Resources.cuadroEscudo;
                huecoProteccion2.BackgroundImage = Properties.Resources.cuadroArmaduraPesada;
            }
            else if (profesion.Equals(rbMago))
            {
                //Se actualizan las imagenes de los desplegables.
                huecoArmaIzquierda1.BackgroundImage = Properties.Resources.cuadroVara;
                huecoArmaDerecha1.Enabled = false;
                huecoProteccion2.Enabled = false;
            }
            else if (profesion.Equals(rbPicaro))
            {
                //Se actualizan las imagenes de los desplegables.
                huecoArmaIzquierda1.BackgroundImage = Properties.Resources.cuadroDaga;
                huecoArmaDerecha1.BackgroundImage = Properties.Resources.cuadroDaga;
                huecoProteccion2.Enabled = false;
            }
            else if (profesion.Equals(rbCazador))
            {
                //Se actualizan las imagenes de los desplegables.
                huecoArmaIzquierda1.BackgroundImage = Properties.Resources.cuadroArco;
                huecoArmaDerecha1.Enabled = false;
                huecoProteccion2.Enabled = false;
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
            cambiarDesplegables((PictureBox)sender);   
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

                    //Si es cuadroVacio desactiva toda la linea de atributos del equipo y si no lo es, activa los TextBox correspondiente al equipo seleccionado.
                    if (compararImagenes((Bitmap)btn.BackgroundImage, Properties.Resources.cuadroVacio))
                        desasctivarTxtEquipo(pb);
                    else
                        activarTxtEquipo(pb);

                }
        }

        
        private bool compararImagenes(Bitmap primeraImagen, Bitmap segundaImagen)
        {
            string primerPixel, segundoPixel;

            if (primeraImagen.Width == segundaImagen.Width && primeraImagen.Height == segundaImagen.Height) //Se comprueba que tengan el mismo tamaño.
            {
                //Se divide entre 2 para optimizar la busqueda.
                for (int i = 0; i < primeraImagen.Height/2; i++)
                    for (int j = 0; j < primeraImagen.Width/2; j++)
                    {
                        primerPixel = primeraImagen.GetPixel(j, i).ToString();
                        segundoPixel = segundaImagen.GetPixel(j, i).ToString();
                        if (!primerPixel.Equals(segundoPixel)) // Si los píxeles no son iguales, se sale del método devolviendo un false.
                            return false;
                    }
                return true; // Si no salió con el anterior return, es que las imágenes son iguales.                 
            }
            else //No tienen el mismo tamaño.
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
                    //Desactivación por Profesión personalizado
                    if (compararImagenes((Bitmap)btn.BackgroundImage, Properties.Resources.cuadroEspada))
                        txtPMArmaIzquierda.Enabled = false;
                    else if (compararImagenes((Bitmap)btn.BackgroundImage, Properties.Resources.cuadroVara))
                        txtAtqArmaIzquierda.Enabled = false;
                    else if (compararImagenes((Bitmap)btn.BackgroundImage, Properties.Resources.cuadroEscudo))
                        txtAtqArmaDerecha.Enabled = false;
                    else if (compararImagenes((Bitmap)btn.BackgroundImage, Properties.Resources.cuadroDaga))
                    {
                        txtPMArmaIzquierda.Enabled = false;
                        if (btn.Parent == panelDesplegableArmaDerecha)
                        {
                            txtDefArmaDerecha.Enabled = false;
                            txtDefMagArmaDerecha.Enabled = false;
                        }
                        else if (btn.Parent == panelDesplegableArmaIzquierda)
                        {
                            txtDefArmaIzquierda.Enabled = false;
                            txtDefMagArmaIzquierda.Enabled = false;
                        }
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


        private void crearPersonaje(object sender, EventArgs e)
        {

            IPasoDeDatos pasoDeDatos = this.Owner as IPasoDeDatos;
            
            personaje.setNombre(txtNombre.Text);
            personaje.setRaza(cbRaza.SelectedItem.ToString());
            if (rbMasculino.Checked)
                personaje.setGenero('M');
            else
                personaje.setGenero('F');
            //Atributos
            //Fuerza - Agilidad - Vitalidad - Mente - Espiritu - Suerte
            personaje.setAtributos(new Atributos(int.Parse(lblAttFuerza.Text), int.Parse(lblAttAgilidad.Text), int.Parse(lblAttVitalidad.Text), int.Parse(lblAttMente.Text), int.Parse(lblAttEspiritu.Text), int.Parse(lblAttSuerte.Text)));
            //Habilidades
            //Correr - Saltar - Nadar - Sigilo - Cocinar - Negociar - Hurtar - Rastrear
            personaje.setHabilidades(new Habilidades(int.Parse(lblNumCorrer.Text), int.Parse(lblNumSaltar.Text), int.Parse(lblNumNadar.Text), int.Parse(lblNumSigilo.Text), int.Parse(lblNumCocinar.Text), int.Parse(lblNumNegociar.Text), int.Parse(lblNumHurtar.Text), int.Parse(lblNumRastrear.Text)));

            //Equipo 
            personaje.setArmaIzquierda(new Equipo(btnArmaIzquierda.BackgroundImage, int.Parse(txtAtqArmaIzquierda.Text), int.Parse(txtPMArmaIzquierda.Text),int.Parse(txtDefArmaIzquierda.Text),int.Parse(txtDefMagArmaIzquierda.Text)));
            personaje.setArmaDerecha(new Equipo(btnArmaDerecha.BackgroundImage, int.Parse(txtAtqArmaDerecha.Text), int.Parse(txtPMArmaDerecha.Text), int.Parse(txtDefArmaDerecha.Text), int.Parse(txtDefMagArmaDerecha.Text)));
            personaje.setProteccion(new Equipo(btnProteccion.BackgroundImage, int.Parse(txtAtqProteccion.Text), int.Parse(txtPMProteccion.Text), int.Parse(txtDefProteccion.Text), int.Parse(txtDefMagProteccion.Text)));
            personaje.setAccesorio1(new Equipo(btnAccesorio1.BackgroundImage, int.Parse(txtDefMagAccesorio1.Text), int.Parse(txtPMAccesorio1.Text), int.Parse(txtDefAccesorio1.Text), int.Parse(txtDefMagAccesorio1.Text)));
            personaje.setAccesorio2(new Equipo(btnAccesorio2.BackgroundImage, int.Parse(txtDefMagAccesorio2.Text), int.Parse(txtPMAccesorio2.Text), int.Parse(txtDefAccesorio2.Text), int.Parse(txtDefMagAccesorio2.Text)));

            pasoDeDatos.pasarPersonaje(personaje); //Se utiliza el método del SelectorPersonaje a través de la interfaz que implementa.
            Close(); //Se cierra el formulario de creación de personaje.
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

        //-------------------------------------------------------------------------------------------------------
        //----------------------------------  ENTRADA DE DATOS EXTERNOS  ----------------------------------------
        //-------------------------------------------------------------------------------------------------------
        //Puede ser llamado desde cualquier formulario que implemente la interfaz, sin acoplar formularios entre si.
        public void pasarPersonaje(Personaje personaje)
        {
            recuperarPersonajeExistente(personaje);
        }
        private void recuperarPersonajeExistente(Personaje personaje)
        {
            txtNombre.Text = personaje.getNombre();
            //Género
            if (personaje.getGenero() == 'M')
                rbMasculino.Checked = true;
            else if(personaje.getGenero() == 'F')
                rbMasculino.Checked = true;
            //Profesión
            if (personaje.getProfesion().getProfesion() == Profesion.GUERRERO)
                rbGuerrero.Checked = true;
            else if (personaje.getProfesion().getProfesion() == Profesion.MAGO)
                rbMago.Checked = true;
            else if (personaje.getProfesion().getProfesion() == Profesion.PICARO)
                rbPicaro.Checked = true;
            else if (personaje.getProfesion().getProfesion() == Profesion.CAZADOR)
                rbCazador.Checked = true;
            panelProfesion.Enabled = false;
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
                //No se podrá modificar los puntos de habilidades.
            panelHabilidades.Enabled = false;
            //Atributos
            lblAttFuerza.Text = personaje.getAtributos().getFuerza().ToString();
            lblAttAgilidad.Text = personaje.getAtributos().getAgilidad().ToString();
            lblAttVitalidad.Text = personaje.getAtributos().getVitalidad().ToString();
            lblAttMente.Text = personaje.getAtributos().getMente().ToString();
            lblAttEspiritu.Text = personaje.getAtributos().getEspiritu().ToString();
            lblAttSuerte.Text = personaje.getAtributos().getSuerte().ToString();
                //No se podrá modificar los atributos.
            lblAttPuntosRestantes.Text = "0";
            lblAttPuntosRestantes.ForeColor = Color.Red;
            panelAtributos.Enabled = false;
            foreach (Control pb in panelAtributos.Controls)
                if (pb is PictureBox)
                    pb.Visible = false;
            //Equipo
                //Imagenes
            recuperarImagenesEquipo(panelDesplegableArmaIzquierda,personaje.getArmaIzquierda());
            recuperarImagenesEquipo(panelDesplegableArmaDerecha,personaje.getArmaDerecha());
            recuperarImagenesEquipo(panelDesplegableProteccion, personaje.getProteccion());
            recuperarImagenesEquipo(panelDesplegableAccesorio1, personaje.getAccesorio1());
            recuperarImagenesEquipo(panelDesplegableAccesorio2, personaje.getAccesorio2());
        }
        private void recuperarBarraHabilidades(ProgressBar barra, int numPuntos)
        {
            lblPHPuntosRestantes.Text = (int.Parse(lblPHPuntosRestantes.Text) - numPuntos).ToString();
            barra.Value = barra.Maximum / PUNTOS_POR_HAB * numPuntos;
            foreach (Control lbl in barra.Parent.Controls)
                if (lbl is Label)
                    lbl.Text = numPuntos.ToString();
           
        }
        private void recuperarImagenesEquipo(Panel panelEquipo,Equipo piezaEquipo)
        {
            foreach (Control c in panelEquipo.Controls)
                if (c is PictureBox && compararImagenes((Bitmap)c.BackgroundImage, (Bitmap)piezaEquipo.getImg()))
                    cambiarDesplegables((PictureBox)c);
        }
    }
}
