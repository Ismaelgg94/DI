using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boton_Aleatorio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random aleatorio = new Random();

            button1.Location = new Point(aleatorio.Next(this.Width - button1.Width),
                                aleatorio.Next(this.Height - button1.Height));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            MessageBox.Show("Has Ganado");
            
        }

        
    }
}
