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

namespace Magic
{
    public partial class Detalles : Form
    {
        ArrayList datosCarta;
        readonly string resources = "..\\..\\Resources\\";

        public Detalles(String imagePath)
        {
            InitializeComponent();
            pbCarta.BackgroundImage = Image.FromFile(imagePath);
            //Se consigue la información de la carta sacando la carta que tenga el imagePath pasado.
            datosCarta=Bdd.datosCarta(imagePath);

            lblNombre.Text =(string) datosCarta[0];
            lblDescripcion.Text = (string)datosCarta[1];
            pbColor.BackgroundImage = Image.FromFile(resources + datosCarta[3].ToString() + ".png");
            

        }

        private void cerrarFormulario(object sender, EventArgs e)
        {
            Close();
        }

        private void teclasPulsadas(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Enter)
                Close();
        }
    }
}
