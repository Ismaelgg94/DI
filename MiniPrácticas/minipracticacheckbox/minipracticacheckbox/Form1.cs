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

namespace MiniPracticaCheckbox
{
    public partial class Form1 : Form
    {
        ArrayList lista = new ArrayList();
        public Form1()
        {
            InitializeComponent();
            checkBox1.Checked = true;
            checkBox3.Checked = true;
            lista.Add(checkBox1);
            lista.Add(checkBox2);
            lista.Add(checkBox3);
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            //Si este checkbox está activado y alguno de los demás, también lo está, entonces
            //no se podrá deseleccionar este checkbox
            if (!checkBox1.Checked && (checkBox2.Checked || checkBox3.Checked))
                checkBox1.Checked = true; 

            if (checkBox1.Checked)
                if (checkBox2.Checked)
                    checkBox3.Checked = false;
                else if (checkBox3.Checked)
                    checkBox2.Checked = false;
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            if (!checkBox2.Checked && (checkBox1.Checked || checkBox3.Checked))
                checkBox2.Checked = true;

            if (checkBox2.Checked)
                if (checkBox1.Checked)
                    checkBox3.Checked = false;
                else if (checkBox3.Checked)
                    checkBox1.Checked = false;
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            if (!checkBox3.Checked && (checkBox1.Checked || checkBox2.Checked))
                checkBox3.Checked = true;

            if (checkBox3.Checked)
                if (checkBox2.Checked)
                    checkBox1.Checked = false;
                else if (checkBox1.Checked)
                    checkBox2.Checked = false;
        }


        
        

    }
}
