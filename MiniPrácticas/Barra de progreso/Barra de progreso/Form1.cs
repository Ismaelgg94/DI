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

namespace Barra_de_progreso
{
    public partial class Form1 : Form
    {
        ArrayList listaCheck = new ArrayList();
        public Form1()
        {
            InitializeComponent();
            listaCheck.Add(checkBox1);
            listaCheck.Add(checkBox2);
            listaCheck.Add(checkBox3);
            listaCheck.Add(checkBox4);
            listaCheck.Add(checkBox5);
        }

        private void limpiar()
        {
            //Desmarca cada Checkbox de los que contiene el array
            foreach (CheckBox ch in listaCheck)
                ch.Checked = false;
        }
        

        private void checkBox_Click(object sender, EventArgs e)
        {
            int index;
            limpiar();
            //Marca el Checkbox que llama al evento y todos los anteriores.
            ((CheckBox)sender).Checked = true;
            index=listaCheck.IndexOf(sender);

            for (int i = index; i >= 0; i--)
               ((CheckBox) listaCheck[i]).Checked=true;
            
        }


    }
}
