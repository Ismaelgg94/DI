using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressBar
{
    public partial class Form1 : Form
    {
        private int a = 5;
        public Form1()
        {
            InitializeComponent();
            
           
        }

        private void botonSubir(object sender, EventArgs e)
        {
            subir();
        }

        private void botonBajar(object sender, EventArgs e)
        {
            bajar();
        }

        private void clickProgress(object sender, MouseEventArgs e)
        {
            if (e.X < progressBar1.Value)
                bajar();
            else
                subir();
        }

        private void subir()
        {
            if (progressBar1.Value + a <= progressBar1.Maximum)
                progressBar1.Value += a;
        }
        private void bajar()
        {
            if (progressBar1.Value - a >= 0)
                progressBar1.Value -= a;
        }

        private void clickCoordenadas(object sender, MouseEventArgs e)
        {
            //Dependiendo del MaxValue, afinará colocandose en el punto clickado.
            progressBar2.Value = e.X*progressBar2.Maximum/progressBar2.Width;
        }
    }
}
