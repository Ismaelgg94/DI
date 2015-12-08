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
        private int x, y;

        public Coleccion(String user)
        {
            InitializeComponent();
            //Usuario logueado
            CURRENT_USER = user;
            cargarCartasBDD(); //Llena los listView con las cartas que le devuelve la select.
            btnSalir.Location = new Point(SystemInformation.PrimaryMonitorSize.Width - 100,btnSalir.Location.Y); //Localización flotante.
        }
        //Actualiza las cartas de los ListViews
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
                    imgList.Images.Add(Image.FromFile(System.IO.Path.GetFullPath(resultado[j].ToString())));
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

        
        private void filtrarPorColor(object sender, EventArgs e)
        {
            //Se usará para filtrar por color las cartas que aparecerán
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
            //Actualiza las cartas con los datos de la BDD
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

        private void clickDerechoEnItem(object sender, MouseEventArgs e)
        {
            

            if (e.Button ==  MouseButtons.Right) //Si se ha pulsado con el botón derecho del ratón.
            {
                //Se comprueba que ha pinchado sobre un item.
                ListViewItem item = ((ListView)sender).GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    item.Selected = true;
                    mLvItemClickDerecho = item; //Se guarda en una var auxiliar para cuando se pulse en el contextMenu.
                    //Se muestra el contextMenu
                    cmDetalles.Show((ListView)sender, e.Location);
                }
            }
        }

        private void clickContextMenu(object sender, ToolStripItemClickedEventArgs e)
        {
            //Si el contextMenuItem seleccionado es menuItemSeleccionado
            if (e.ClickedItem.Equals(menuItemDetalles))
                //Abre una ventana con los detalles de la carta seleccionada.
                new Detalles((string)mLvItemClickDerecho.Tag).Show();

        }

        private void cursorNormal(object sender, EventArgs e)
        {
           Cursor = Cursors.Default;
        }

        private void cursorMano(object sender, EventArgs e)
        { 
           Cursor = Cursors.Hand;
        }
        //    --------------    DRAG AND DROP SIMULADO     ---------------------
        private void llevarseImagen(object sender, ItemDragEventArgs e)
        {
            //Posición del ratón
            x = Cursor.Position.X;
            y = Cursor.Position.Y;

            pbCartaMoviendose.Location = new Point(x - pbCartaMoviendose.Width / 2, y - pbCartaMoviendose.Height / 2);
            //Variable auxiliar para cuando despues el metodos soltarCarta necesita diferenciar entre ListView, no tiene 
            //Forma de saber de donde proviene la carta.
            mLvOrigen = (ListView)sender;
            //Si los items que se van a transportar son solo 1, se mostrará esa carta moviendose
            if(mLvOrigen.SelectedItems.Count<=1)
                pbCartaMoviendose.BackgroundImage = Image.FromFile(((ListViewItem)e.Item).Tag.ToString());
            //sino se mostrará el dorso de las cartas Magic.
            else
                pbCartaMoviendose.BackgroundImage = Properties.Resources.cartaTrasera;
            pbCartaMoviendose.Visible = true;
            
        }


        private void moverCarta(object sender, MouseEventArgs e)
        {
            //Si este pb tiene background es porque se ha agarrado del listView
            //El pictureBox se moverá junto al ratón.
            if (pbCartaMoviendose.BackgroundImage != null)
                pbCartaMoviendose.Location = new Point(e.X + pbCartaMoviendose.Location.X - pbCartaMoviendose.Width / 2, e.Y + pbCartaMoviendose.Location.Y - pbCartaMoviendose.Height / 2);
        }

        private void soltarCarta(object sender, MouseEventArgs e)
        {
            ListView lvDestino = null;
            //Selecciona el ListView destino.
            if (mLvOrigen.Equals(lvMiColeccion))
                lvDestino = lvTienda;
            else if (mLvOrigen.Equals(lvTienda))
                lvDestino = lvMiColeccion;

            //Comprueba que el ratón está dentro del listView destino cuando se suelta la carta.
            if (Cursor.Position.X >= lvDestino.Location.X && Cursor.Position.X <= lvDestino.Location.X + lvDestino.Width)
                if (Cursor.Position.Y >= lvDestino.Location.Y && Cursor.Position.Y <= lvDestino.Location.Y + lvDestino.Width)
                    soltarCartaEnListView(lvDestino);
            //Una vez se ha soltado la carta, se oculta y se mueve a un lugar que no moleste, el picturebox
            //que imita el efecto de drag.
            pbCartaMoviendose.Visible = false;
            pbCartaMoviendose.Location = new Point(0, 0);
            pbCartaMoviendose.BackgroundImage = null;

        }

        private void soltarCartaEnListView(ListView lvDestino)
        {

            if (pbCartaMoviendose.BackgroundImage != null)
                //Si este listView (sender) no es igual al listView de origen(mLvOrigen)
                if (!lvDestino.Equals(mLvOrigen))
                {
                    foreach (ListViewItem item in mLvOrigen.SelectedItems)
                    {
                        //Ejecuta las sql correspondientes según que listview sea el sender
                        //*Item.tag contiene el Path de la imagen de la carta.
                        if (lvDestino.Equals(lvTienda))
                            Bdd.venderCarta(CURRENT_USER, (String)item.Tag);
                        else if (lvDestino.Equals(lvMiColeccion))
                            Bdd.comprarCarta(CURRENT_USER, (String)item.Tag);
                        
                    }
                    //Actualiza las cartas con los datos de la BDD
                    cargarCartasBDD();
                    
                }
        }

        

        private void teletransportarCarta(object sender, EventArgs e)
        {
            //Cuando el ratón se sale muy rapido de la carta
            if (pbCartaMoviendose.BackgroundImage != null)
                pbCartaMoviendose.Location = new Point(Cursor.Position.X - pbCartaMoviendose.Width / 2, Cursor.Position.Y - pbCartaMoviendose.Height / 2);

        }
    }
}
