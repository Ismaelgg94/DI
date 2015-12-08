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

namespace CheckBoxAleatorio
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void timerCreador(object sender, EventArgs e)
        {


            CheckBox ch = new CheckBox();
            //  Crea una posición aleatoria donde se controla que no se salga por abajo y 
            //que el Text del CheckBox no se sale por pantalla.
            Point pos= new Point(rnd.Next(0,this.Width-ch.Width-ch.Text.Length),rnd.Next(0,this.Height-ch.Height));
            
            ch.Location = pos;
            //Introduce en el Text del CheckBox la hora exacta cuando se creó
            ch.Text = DateTime.Now.Hour+":"+DateTime.Now.Minute+":"+DateTime.Now.Second;

            this.Controls.Add(ch);



        }

        private void timerEliminador(object sender, EventArgs e)
        {
            //Elimina del formulario, los controles que son CheckBox
            foreach (Object item in Controls)
                if (item is CheckBox)
                    ((CheckBox)item).Checked = false;

            
        }
    }
}
