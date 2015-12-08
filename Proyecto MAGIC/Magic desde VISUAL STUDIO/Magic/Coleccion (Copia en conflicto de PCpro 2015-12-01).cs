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
    public partial class Coleccion : Form
    {
        readonly String CURRENT_USER;
        String colorActual = "";
        ListView mLvOrigen;
        ListViewItem mLvItemClickDerecho;
        static Image img;

        public Coleccion(String user)
        {
            InitializeComponent();
            //Usuario logueado
            CURRENT_USER = user;
            cargarCartasBDD(); //Llena los listView con las cartas que le devuelve la select.
            btnSalir.Location = new Point(Width-300,btnSalir.Location.Y); //Localización flotante.
        }
        
        private void cargarCartasBDD()
        {
            ListView lv = lvMiColeccion;
            ArrayList resultado = Bdd.getCartasUsuario(CURRENT_USER, colorActual); //Obtiene las rutas de todas las imagenes del usuario.
            ImageList imgList = imgListMiColeccion;
            ListViewItem item;

            for (int i = 0; i < 2; i++)
            {
                //Se limpia los listviews por si se utiliza algún filtro.
                imgList.Images.Clear();
                lv.Clear();

                for (int j = 0; j < resultado.Count; j++)
                {
                    
                    //Actualiza el imageList con las cartas de la BDD.
                    imgList.Images.Add(Image.FromFile(resultado[j].ToString()));
                    //Se cargan los Items en el ListView
                    item = new ListViewItem();
                    item.ImageIndex = j;
                    item.Tag = resultado[j].ToString(); //Se guarda la ruta de la imágen como identificador para futuros inserts y deletes. (Nos ahorramos sacar mas información)
                    lv.Items.Add(item);
                }
                //Turno del ListViewTienda
                resultado = Bdd.getCartasTienda(CURRENT_USER, colorActual);
                imgList = imgListTienda;
                lv = lvTienda;
            }
        }



        //                    -- DRAG AND DROP --
        private void itemDragCarta(object sender, ItemDragEventArgs e)
        {
            //Se guarda en una variable del formulario el ListView de donde salen los items porque en los demás métodos de drag and drop
            //no se puede conseguir el origen de los datos pasados.
            mLvOrigen = (ListView)sender;
            
            /*//Se crea un Bitmap con la imagen del item que se está moviendo.
            Bitmap bmp = new Bitmap(Image.FromFile(((ListViewItem)e.Item).Tag.ToString()), new Size(150, 190));
           
            //El cursor actual se cambia por uno nuevo que contiene el bitmap creado anteriormente.
            Cursor cur = new Cursor(bmp.GetHicon());
            Cursor = cur;*/
            
            //DoDragDrop(((ListView)sender).SelectedItems, DragDropEffects.All);
            
            


        }

        private void listViewDragEnter(object sender, DragEventArgs e)
        {
            
            e.Effect = DragDropEffects.All;
            
        }

        private void dragoDrop(object sender, DragEventArgs e)
        {
            ImageList imgListDestino;
            ListView.SelectedListViewItemCollection items; 
            
            if (!mLvOrigen.Equals((ListView)sender)) //Comprueba que no se haga dragdrop sobre el mismo listView
            {
                //Items arrastrados a este listView
                items = (ListView.SelectedListViewItemCollection)e.Data.GetData(typeof(ListView.SelectedListViewItemCollection));

                foreach (ListViewItem item in items)
                {
                    //Ejecuta las sql correspondientes según que listview sea el sender
                    //*Item.tag contiene el Path de la imagen de la carta.
                    if (sender.Equals(lvTienda))
                        Bdd.venderCarta(CURRENT_USER, (String)item.Tag);
                    else if (sender.Equals(lvMiColeccion))
                        Bdd.comprarCarta(CURRENT_USER, (String)item.Tag);

                    //Se OPTA por MOVER LOS ITEMS localmente antes que pedir los datos de la BDD 
                    //para no sobrecargarla.

                    //Se añade la imagen del tag del item a la imageList destino.
                    imgListDestino = ((ListView)sender).LargeImageList;
                    imgListDestino.Images.Add(Image.FromFile((string)item.Tag)); 
                    item.ImageIndex = imgListDestino.Images.Count - 1;
                    
                    //Borra el item/s arrastrados del listView origen.
                    foreach (ListViewItem itemOrigen in mLvOrigen.Items)
                        if (item.Tag.Equals((string)itemOrigen.Tag))
                            mLvOrigen.Items.Remove(itemOrigen);
                    
                    //añade el item de la listView origen a la destino.
                   ((ListView)sender).Items.Add(item);
                    //Se deselecciona para que no permanezca seleccionado en el otro listView.
                    item.Selected = false;
                }
            }
            

        }

        private void filtrarPorColor(object sender, EventArgs e)
        {
            if (sender.Equals(pbRojo))
                colorActual = Bdd.COLOR_ROJO;
            else if (sender.Equals(pbAzul))
                colorActual = Bdd.COLOR_AZUL;
            else if (sender.Equals(pbVerde))
                colorActual = Bdd.COLOR_VERDE;
            else if (sender.Equals(pbNegro))
                colorActual = Bdd.COLOR_NEGRO;
            else if (sender.Equals(pbBlanco))
                colorActual = Bdd.COLOR_BLANCO;
            else if (sender.Equals(pbColorGeneral))
                colorActual = Bdd.COLOR_GENERAL;

            cargarCartasBDD();


        }

        private void cerrarFormulario(object sender, EventArgs e)
        {
            Close();
        }

        private void abrirDetalles(object sender, EventArgs e)
        {
            //Para cuando hace dobleClick entre cartas.
            if (((ListView)sender).SelectedItems.Count > 0)
            {
                //El tag del item contiene la ruta de su imagen.
                String rutaImagen = (String)((ListView)sender).SelectedItems[0].Tag;

                Detalles detallesForm = new Detalles(rutaImagen);
                //Descelecciona los items que se habían seleccionado.
                for (int i = 0; i < ((ListView)sender).SelectedItems.Count; i++)
                    ((ListView)sender).SelectedItems[i].Selected = false;
                //Se abre el formulario de detalles.
                detallesForm.Show();
            }       

        }

        private void clickContextMenu(object sender, ToolStripItemClickedEventArgs e)
        {
            //Si el contextMenuItem seleccionado es menuItemSeleccionado
            if (e.ClickedItem.Equals(menuItemDetalles))
                //Abre una ventana con los detalles de la carta seleccionada.
                new Detalles((string)mLvItemClickDerecho.Tag).Show();
            
        }

        private void clickDerechoEnItem(object sender, MouseEventArgs e)
        {
            

            if (e.Button == System.Windows.Forms.MouseButtons.Right) //Si se ha pulsado con el botón derecho del ratón.
            {
                //Se comprueba que ha pinchado sobre un item.
                ListViewItem item = ((ListView)sender).GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    item.Selected = true;
                    mLvItemClickDerecho = item;
                    cmDetalles.Show((ListView)sender, e.Location);
                }
            }
        }

        private void cursorNormal(object sender, EventArgs e)
        {
           //Cursor = Cursors.Default;
        }

        private void cursorMano(object sender, EventArgs e)
        {
           //Cursor = Cursors.Hand;
        }

        

        private void llevarseImagen(object sender, MouseEventArgs e)
        {
            //Se guarda en una variable del formulario el ListView de donde salen los items porque en los demás métodos de drag and drop
            //no se puede conseguir el origen de los datos pasados.
            mLvOrigen = (ListView)sender;
            
            int x = e.X+((ListView)sender).Location.X - pbCartaMoviendose.Width/2;
            int y = e.Y+ ((ListView)sender).Location.Y - pbCartaMoviendose.Height/2;
            
            pbCartaMoviendose.Location=new Point(x , y );
            ListViewItem item = ((ListView)sender).GetItemAt(e.X, e.Y);
            if (item != null)
            {
                pbCartaMoviendose.BackgroundImage = Image.FromFile(item.Tag.ToString());
                pbCartaMoviendose.Visible = true;
            }
            
            
        }
        private void moverCartaConRaton(object sender, MouseEventArgs e)
        {
            //Si el pb que se va a mover tiene imagen, se moverá junto al ratón imitando el movimiento del drag and drop.
//            if(pbCartaMoviendose.BackgroundImage!=null)
                pbCartaMoviendose.Location=new Point(e.X,e.Y);
            
        }
    }
}
