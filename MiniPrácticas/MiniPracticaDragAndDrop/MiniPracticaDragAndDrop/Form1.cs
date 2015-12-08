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

namespace MiniPracticaDragAndDrop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.AllowDrop = true;
            textBox3.AllowDrop = true;
        }

       


        private void textBoxMouseDown(object sender, MouseEventArgs e)
        {
            if(sender is TextBox)
                DoDragDrop(((TextBox)sender).Text, DragDropEffects.All);
            else if( sender is ListBox)
                DoDragDrop(((ListBox)sender).Text, DragDropEffects.All);
        }


        private void textBoxDragDrop(object sender, DragEventArgs e)
        {
            if(sender is TextBox)
                ((TextBox)sender).Text = e.Data.GetData(DataFormats.Text).ToString();
            else if (sender is ListBox)
                ((ListBox)sender).Items.Add(e.Data.GetData(DataFormats.Text).ToString());

        }

        private void textBoxDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
            
        }

        private void listViewDragDrop(object sender, DragEventArgs e)
        {
            ListViewItem lvItem = new ListViewItem();
            lvItem.Text = e.Data.GetData(DataFormats.Text).ToString();
            lvItem.SubItems.Add("pepe");
            ((ListView)sender).Items.Add(lvItem);
           

        }

        private void listView2_DragDrop(object sender, DragEventArgs e)
        {
            ListView.SelectedListViewItemCollection items = (ListView.SelectedListViewItemCollection)e.Data.GetData(typeof(ListView.SelectedListViewItemCollection));

            foreach (var item in items)
            {

                ((ListView)sender).Items.Add((ListViewItem)((ListViewItem)item).Clone());
            }
            
        }

        private void selectedItemsDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            //Todos los seleccionados
            DoDragDrop(((ListView)sender).SelectedItems, DragDropEffects.All); 
            
        }
    }
}
