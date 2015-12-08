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

namespace MiniPracticaSelector
{
    public partial class Form1 : Form
    {
        ArrayList listaNombres = new ArrayList();
        Button botonAccionado;
        public Form1()
        {
            InitializeComponent();
        }

        private void nuevoNombre(object sender, EventArgs e)
        {
            btnGuardar.Text = "Crear";
            transcicionBotonera();
            txtNombre.Focus();
            botonAccionado = (Button)sender; //Se guarda el botón que ha sido accionado para diferenciar la acción posterior.
        }
        private void confirmar(object sender, EventArgs e)
        {
            string nombre=txtNombre.Text;
            int nombreAModificar;

            //Si el txtNombre no tiene ningun caracter introducido, muestra el mensaje de error.
            if (txtNombre.Text.Equals(""))
                lblErrorNombre.Visible = true;
            else
            {
                lblErrorNombre.Visible = false; // Desactiva el mensaje de error si estuviera activado.
                if (botonAccionado.Equals(btnNuevo))
                {
                    listaNombres.Add(nombre);
                    mostrarNombre(listaNombres.Count - 1);
                    lblNum.Text = listaNombres.Count + "/" + listaNombres.Count; //Se muestra el valor de la última posición.
                }
                else if (botonAccionado.Equals(btnModificar))
                {
                    nombreAModificar = int.Parse(lblNum.Text.Substring(0, 1)) - 1; //Consigue el índice del nombre seleccionado.
                    listaNombres[nombreAModificar] = txtNombre.Text;
                    lblResultado.Text = (String)listaNombres[nombreAModificar]; //Se muestra el nombre modificado
                }
                transcicionBotonera();
            }
            txtNombre.Text = "";
        }
        private void cancelar(object sender, EventArgs e)
        {
            transcicionBotonera();
            txtNombre.Text = "";
            
        }
        private void transcicionBotonera()
        {
            if (btnGuardar.Visible)
            {
                //Se escuende los botones de confirmación y cancelación.
                panelEditar.Visible = false;
                //Se reactiva la botonera inferior.
                panelBotonera.Enabled = true;
                //Se escuende el txtNombre
                panelNombre.Visible = false;
            }
            else
            {
                //Se desactiva la botonera inferior.
                panelBotonera.Enabled = false;

                //Se pone visible los botones de confirmacion y cancelación.
                panelEditar.Visible = true;
                panelNombre.Visible = true;
               
            }

        }
       
        private void mostrarNombre(int posicion)
        {
            //Muestra el nombre en pantalla.
            lblResultado.Text = (String) listaNombres[posicion];
            lblNum.Text = (posicion+1)+"/"+listaNombres.Count;
        }

        private void modificarNombre(object sender, EventArgs e)
        {
            if (listaNombres.Count > 0)
            {
                btnGuardar.Text = "Modificar";
                transcicionBotonera();
                txtNombre.Focus();
                botonAccionado = (Button)sender;
            }

        }

        private void borrarNombre(object sender, EventArgs e)
        {           
            int nombreAEliminar = int.Parse(lblNum.Text.Substring(0, 1)) - 1; //Indice del elemento en pantalla

            if (listaNombres.Count > 0)
            {               
                listaNombres.RemoveAt(nombreAEliminar);
                if (listaNombres.Count == 0)// Si no quedan elementos tras el borrado.
                { 
                    lblNum.Text = "0/0";
                    lblResultado.Text = "";
                }
                else
                {
                    //Muestra en pantalla el elemento anterior al borrado.
                    lblResultado.Text = (String) listaNombres[nombreAEliminar];
                    lblNum.Text = (nombreAEliminar+1).ToString()+"/"+listaNombres.Count;
                }
                

            }
               

        }

        private void pasarAdelante(object sender, EventArgs e)
        {
            int nombreActual = int.Parse(lblNum.Text.Substring(0, 1)) - 1;

            if (nombreActual < listaNombres.Count-1)
                mostrarNombre(nombreActual+1);
        }

        private void pasarAtras(object sender, EventArgs e)
        {
            int nombreActual = int.Parse(lblNum.Text.Substring(0, 1)) - 1;

            if (nombreActual > 0)
                mostrarNombre(nombreActual - 1);
        }

        private void pasarFinal(object sender, EventArgs e)
        {
            mostrarNombre(listaNombres.Count - 1);
        }

        private void pasarInicio(object sender, EventArgs e)
        {
            mostrarNombre(0);
        }

        
    }
}
