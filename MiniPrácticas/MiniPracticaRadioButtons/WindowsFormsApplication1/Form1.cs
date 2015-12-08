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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }

        
        
        private void clickRB(object sender, EventArgs e)
        {
            int index= ((RadioButton)sender).TabIndex;
            foreach (Panel pa in ((RadioButton)sender).Parent.Parent.Controls)
                foreach (RadioButton rb in pa.Controls)
                    if (rb.TabIndex <= index)
                         rb.Checked = true;
                    else
                         rb.Checked = false;
        }

       
    }
}
