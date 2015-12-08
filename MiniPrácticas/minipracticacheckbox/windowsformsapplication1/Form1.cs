using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        String[] rangos = { "1-5", "5-10", "10-15" };
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(rangos);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*ComboBox cb = (ComboBox)sender;
            String[] subNum=new String[5];
            comboBox2.Items.Clear();

            Array.ConstrainedCopy(num, (cb.SelectedIndex)*5, subNum, 0, 5);
            comboBox2.Items.AddRange(subNum);*/
           
        }
    }
}
