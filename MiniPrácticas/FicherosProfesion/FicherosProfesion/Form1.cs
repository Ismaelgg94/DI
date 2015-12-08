using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FicherosProfesion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cambioDeRaza(object sender, EventArgs e)
        {
            string[] SEPARADOR = { "|*|"};
            StreamReader lector = new StreamReader("C:\\Users\\Usuario\\Dropbox\\Ciclo\\2\\DI\\FicherosProfesion\\FicherosProfesion\\Files\\Raza.pro");
            cbProfesion.Items.Clear(); //Se limpia el comboBox por si se ha usado anteriormente.
            cbProfesion.Text = ""; //Se limpia la profesión escogida anteriormente.

            string[] profesiones=null;
            string aux;
            
            while ((aux = lector.ReadLine()) != null)
            {
                
               profesiones=  aux.Split(SEPARADOR,StringSplitOptions.RemoveEmptyEntries);
                if (profesiones[0] == cbRaza.Text)
                    cbProfesion.Items.AddRange(profesiones[1].Split('|'));
                
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader lector;
            string[] cadena;
            
            String ruta = Application.StartupPath;
            openFileDialog1.InitialDirectory = ruta.Remove(ruta.Length-9,9);

            DialogResult resultado = openFileDialog1.ShowDialog();
            openFileDialog1.RestoreDirectory = true;
            

            if (resultado == DialogResult.OK) //Comprueba que se haya hecho bien.
            {
                lector = new StreamReader(saveFileDialog1.FileName);
                cadena = lector.ReadLine().Split('|');
                cbRaza.Text = cadena[0];
                cbProfesion.Text = cadena[1];
                lector.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter escritor;
             
            //Se define en el Diseño para no tener que crearse cada vez que le das al botón.
            saveFileDialog1.Filter ="Pro files (*.pro)|*.pro|All files (*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                escritor = new StreamWriter(saveFileDialog1.FileName);
                escritor.Write(cbRaza.Text+"|");
                escritor.Write(cbProfesion.Text);
                escritor.Close();

               
            }
            
        }
    }
}
