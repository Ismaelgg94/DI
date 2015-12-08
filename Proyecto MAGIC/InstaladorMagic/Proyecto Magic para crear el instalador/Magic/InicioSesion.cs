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
    public partial class InicioSesion : Form
    {
        
        public InicioSesion()
        {
            InitializeComponent();
            //Localización flotante.
            btnSalir.Location = new Point(SystemInformation.PrimaryMonitorSize.Width - 100, btnSalir.Location.Y);
        }

        private void iniciarSesion(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (Bdd.identificarUsuario(txtUser.Text, txtPass.Text))
                {
                    //Oculta el mensaje de error si el login ha tenido exito.
                    lblError.Visible = false;
                    //Oculta este formulario.
                    this.Hide();

                    Coleccion coleccion = new Coleccion(txtUser.Text);
                    coleccion.Show();
                    //Cuando el formulario coleccion se cierra, se vuelve a mostrar este.
                    coleccion.FormClosed += (s, args) => { this.Show(); };
                }                    
                else
                    lblError.Visible = true;
                       
            }
                
        }

        private void salirFormulario(object sender, EventArgs e)
        {
            Close();
        }

        private void registrarse(object sender, EventArgs e)
        {
            new Registro().ShowDialog();
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
