using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magic
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void salir(object sender, EventArgs e)
        {
            Close();
        }

        private void isSamePassword(object sender, EventArgs e)
        {
            TextBox txtAComparar;
            //Selecciona el txt con el que comparar el texto.
            if (sender.Equals(txtPassword))
                txtAComparar = txtRepeatPassword;
            else
                txtAComparar = txtPassword;

            if (!((TextBox)sender).Text.Equals(txtAComparar.Text))
                lblPassError.Visible = true;
            else
                lblPassError.Visible = false;
        }

        private void comprobarUsuario(object sender, EventArgs e)
        {
            if (Bdd.existeUsuario(txtUsuario.Text))
                lblUsuarioExistente.Visible = true;
            else
                lblUsuarioExistente.Visible = false;
        }

        private void confirmarUsuario()
        {   //Si no hay ningun campo vacio.
            if (txtUsuario.Text != "" && txtPassword.Text != "" && txtRepeatPassword.Text != "")
            {
                //Si el usuario no existe aun y las contraseñas son iguales, crea el usuario.
                if (!lblUsuarioExistente.Visible && !lblPassError.Visible)
                {
                    Bdd.crearUsuario(txtUsuario.Text, txtPassword.Text);
                    Close();
                }
            }
            else
                lblCamposSinRellenar.Visible = true;
        }

        private void teclaEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                confirmarUsuario();
            else if (e.KeyChar == (char)Keys.Escape)
                Close();
        }
        private void btnConfirmar(object sender, EventArgs e)
        {
            confirmarUsuario();
        }

        private void cursorMano(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void cursorNormal(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
    }
}
