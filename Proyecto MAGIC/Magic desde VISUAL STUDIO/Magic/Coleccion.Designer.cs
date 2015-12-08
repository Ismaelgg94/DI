namespace Magic
{
    partial class Coleccion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbRojo = new System.Windows.Forms.PictureBox();
            this.pbAzul = new System.Windows.Forms.PictureBox();
            this.pbVerde = new System.Windows.Forms.PictureBox();
            this.pbNegro = new System.Windows.Forms.PictureBox();
            this.pbBlanco = new System.Windows.Forms.PictureBox();
            this.lvMiColeccion = new System.Windows.Forms.ListView();
            this.imgListMiColeccion = new System.Windows.Forms.ImageList(this.components);
            this.lvTienda = new System.Windows.Forms.ListView();
            this.imgListTienda = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbColorGeneral = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmDetalles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemDetalles = new System.Windows.Forms.ToolStripMenuItem();
            this.pbCartaMoviendose = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbRojo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAzul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVerde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNegro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBlanco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColorGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            this.cmDetalles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCartaMoviendose)).BeginInit();
            this.SuspendLayout();
            // 
            // pbRojo
            // 
            this.pbRojo.BackColor = System.Drawing.Color.Transparent;
            this.pbRojo.BackgroundImage = global::Magic.Properties.Resources.colorRojo;
            this.pbRojo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbRojo.Location = new System.Drawing.Point(9, 116);
            this.pbRojo.Name = "pbRojo";
            this.pbRojo.Size = new System.Drawing.Size(112, 131);
            this.pbRojo.TabIndex = 0;
            this.pbRojo.TabStop = false;
            this.pbRojo.Click += new System.EventHandler(this.filtrarPorColor);
            this.pbRojo.MouseEnter += new System.EventHandler(this.cursorMano);
            this.pbRojo.MouseLeave += new System.EventHandler(this.cursorNormal);
            // 
            // pbAzul
            // 
            this.pbAzul.BackColor = System.Drawing.Color.Transparent;
            this.pbAzul.BackgroundImage = global::Magic.Properties.Resources.colorAzul;
            this.pbAzul.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbAzul.Location = new System.Drawing.Point(127, 305);
            this.pbAzul.Name = "pbAzul";
            this.pbAzul.Size = new System.Drawing.Size(112, 131);
            this.pbAzul.TabIndex = 1;
            this.pbAzul.TabStop = false;
            this.pbAzul.Click += new System.EventHandler(this.filtrarPorColor);
            this.pbAzul.MouseEnter += new System.EventHandler(this.cursorMano);
            this.pbAzul.MouseLeave += new System.EventHandler(this.cursorNormal);
            // 
            // pbVerde
            // 
            this.pbVerde.BackColor = System.Drawing.Color.Transparent;
            this.pbVerde.BackgroundImage = global::Magic.Properties.Resources.colorVerde;
            this.pbVerde.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbVerde.Location = new System.Drawing.Point(9, 305);
            this.pbVerde.Name = "pbVerde";
            this.pbVerde.Size = new System.Drawing.Size(112, 131);
            this.pbVerde.TabIndex = 2;
            this.pbVerde.TabStop = false;
            this.pbVerde.Click += new System.EventHandler(this.filtrarPorColor);
            this.pbVerde.MouseEnter += new System.EventHandler(this.cursorMano);
            this.pbVerde.MouseLeave += new System.EventHandler(this.cursorNormal);
            // 
            // pbNegro
            // 
            this.pbNegro.BackColor = System.Drawing.Color.Transparent;
            this.pbNegro.BackgroundImage = global::Magic.Properties.Resources.colorNegro;
            this.pbNegro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbNegro.Location = new System.Drawing.Point(127, 489);
            this.pbNegro.Name = "pbNegro";
            this.pbNegro.Size = new System.Drawing.Size(112, 131);
            this.pbNegro.TabIndex = 3;
            this.pbNegro.TabStop = false;
            this.pbNegro.Click += new System.EventHandler(this.filtrarPorColor);
            this.pbNegro.MouseEnter += new System.EventHandler(this.cursorMano);
            this.pbNegro.MouseLeave += new System.EventHandler(this.cursorNormal);
            // 
            // pbBlanco
            // 
            this.pbBlanco.BackColor = System.Drawing.Color.Transparent;
            this.pbBlanco.BackgroundImage = global::Magic.Properties.Resources.colorBlanco;
            this.pbBlanco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbBlanco.Location = new System.Drawing.Point(9, 489);
            this.pbBlanco.Name = "pbBlanco";
            this.pbBlanco.Size = new System.Drawing.Size(112, 131);
            this.pbBlanco.TabIndex = 4;
            this.pbBlanco.TabStop = false;
            this.pbBlanco.Click += new System.EventHandler(this.filtrarPorColor);
            this.pbBlanco.MouseEnter += new System.EventHandler(this.cursorMano);
            this.pbBlanco.MouseLeave += new System.EventHandler(this.cursorNormal);
            // 
            // lvMiColeccion
            // 
            this.lvMiColeccion.AllowDrop = true;
            this.lvMiColeccion.BackColor = System.Drawing.Color.Silver;
            this.lvMiColeccion.BackgroundImage = global::Magic.Properties.Resources.fondoNube;
            this.lvMiColeccion.BackgroundImageTiled = true;
            this.lvMiColeccion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvMiColeccion.GridLines = true;
            this.lvMiColeccion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lvMiColeccion.LargeImageList = this.imgListMiColeccion;
            this.lvMiColeccion.Location = new System.Drawing.Point(302, 85);
            this.lvMiColeccion.Name = "lvMiColeccion";
            this.lvMiColeccion.Size = new System.Drawing.Size(488, 611);
            this.lvMiColeccion.TabIndex = 5;
            this.lvMiColeccion.TileSize = new System.Drawing.Size(155, 195);
            this.lvMiColeccion.UseCompatibleStateImageBehavior = false;
            this.lvMiColeccion.View = System.Windows.Forms.View.Tile;
            this.lvMiColeccion.ItemActivate += new System.EventHandler(this.abrirDetalles);
            this.lvMiColeccion.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.llevarseImagen);
            this.lvMiColeccion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clickDerechoEnItem);
            this.lvMiColeccion.MouseEnter += new System.EventHandler(this.cursorMano);
            this.lvMiColeccion.MouseLeave += new System.EventHandler(this.cursorNormal);
            // 
            // imgListMiColeccion
            // 
            this.imgListMiColeccion.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgListMiColeccion.ImageSize = new System.Drawing.Size(150, 190);
            this.imgListMiColeccion.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lvTienda
            // 
            this.lvTienda.AllowDrop = true;
            this.lvTienda.BackgroundImage = global::Magic.Properties.Resources.fondoDolar;
            this.lvTienda.BackgroundImageTiled = true;
            this.lvTienda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvTienda.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvTienda.LargeImageList = this.imgListTienda;
            this.lvTienda.Location = new System.Drawing.Point(829, 85);
            this.lvTienda.Name = "lvTienda";
            this.lvTienda.Size = new System.Drawing.Size(495, 611);
            this.lvTienda.TabIndex = 6;
            this.lvTienda.TileSize = new System.Drawing.Size(155, 195);
            this.lvTienda.UseCompatibleStateImageBehavior = false;
            this.lvTienda.View = System.Windows.Forms.View.Tile;
            this.lvTienda.ItemActivate += new System.EventHandler(this.abrirDetalles);
            this.lvTienda.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.llevarseImagen);
            this.lvTienda.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clickDerechoEnItem);
            this.lvTienda.MouseEnter += new System.EventHandler(this.cursorMano);
            this.lvTienda.MouseLeave += new System.EventHandler(this.cursorNormal);
            // 
            // imgListTienda
            // 
            this.imgListTienda.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgListTienda.ImageSize = new System.Drawing.Size(150, 190);
            this.imgListTienda.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(473, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 22);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mi colección";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1049, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 22);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tienda";
            // 
            // pbColorGeneral
            // 
            this.pbColorGeneral.BackColor = System.Drawing.Color.Transparent;
            this.pbColorGeneral.BackgroundImage = global::Magic.Properties.Resources.colorGeneral;
            this.pbColorGeneral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbColorGeneral.Location = new System.Drawing.Point(127, 116);
            this.pbColorGeneral.Name = "pbColorGeneral";
            this.pbColorGeneral.Size = new System.Drawing.Size(112, 131);
            this.pbColorGeneral.TabIndex = 9;
            this.pbColorGeneral.TabStop = false;
            this.pbColorGeneral.Click += new System.EventHandler(this.filtrarPorColor);
            this.pbColorGeneral.MouseEnter += new System.EventHandler(this.cursorMano);
            this.pbColorGeneral.MouseLeave += new System.EventHandler(this.cursorNormal);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Transparent;
            this.btnSalir.BackgroundImage = global::Magic.Properties.Resources.btnSalir;
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSalir.Location = new System.Drawing.Point(1431, 12);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(47, 48);
            this.btnSalir.TabIndex = 10;
            this.btnSalir.TabStop = false;
            this.btnSalir.Click += new System.EventHandler(this.cerrarFormulario);
            this.btnSalir.MouseEnter += new System.EventHandler(this.cursorMano);
            this.btnSalir.MouseLeave += new System.EventHandler(this.cursorNormal);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::Magic.Properties.Resources.Marco;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(821, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(515, 640);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::Magic.Properties.Resources.Marco;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(295, 70);
            this.panel2.Name = "panel2";
            this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel2.Size = new System.Drawing.Size(506, 638);
            this.panel2.TabIndex = 12;
            // 
            // cmDetalles
            // 
            this.cmDetalles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemDetalles});
            this.cmDetalles.Name = "cmDetalles";
            this.cmDetalles.Size = new System.Drawing.Size(116, 26);
            this.cmDetalles.Text = "Detalles";
            this.cmDetalles.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.clickContextMenu);
            // 
            // menuItemDetalles
            // 
            this.menuItemDetalles.Name = "menuItemDetalles";
            this.menuItemDetalles.Size = new System.Drawing.Size(115, 22);
            this.menuItemDetalles.Text = "Detalles";
            // 
            // pbCartaMoviendose
            // 
            this.pbCartaMoviendose.BackColor = System.Drawing.Color.Black;
            this.pbCartaMoviendose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCartaMoviendose.Location = new System.Drawing.Point(52, -80);
            this.pbCartaMoviendose.Name = "pbCartaMoviendose";
            this.pbCartaMoviendose.Size = new System.Drawing.Size(150, 190);
            this.pbCartaMoviendose.TabIndex = 13;
            this.pbCartaMoviendose.TabStop = false;
            this.pbCartaMoviendose.Visible = false;
            this.pbCartaMoviendose.MouseLeave += new System.EventHandler(this.teletransportarCarta);
            this.pbCartaMoviendose.MouseMove += new System.Windows.Forms.MouseEventHandler(this.moverCarta);
            this.pbCartaMoviendose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.soltarCarta);
            // 
            // Coleccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Magic.Properties.Resources.fondoLeon;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.Controls.Add(this.pbCartaMoviendose);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvTienda);
            this.Controls.Add(this.lvMiColeccion);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pbColorGeneral);
            this.Controls.Add(this.pbBlanco);
            this.Controls.Add(this.pbNegro);
            this.Controls.Add(this.pbVerde);
            this.Controls.Add(this.pbAzul);
            this.Controls.Add(this.pbRojo);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Coleccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Coleccion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pbRojo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAzul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVerde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNegro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBlanco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColorGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            this.cmDetalles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCartaMoviendose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbRojo;
        private System.Windows.Forms.PictureBox pbAzul;
        private System.Windows.Forms.PictureBox pbVerde;
        private System.Windows.Forms.PictureBox pbNegro;
        private System.Windows.Forms.PictureBox pbBlanco;
        private System.Windows.Forms.ListView lvMiColeccion;
        private System.Windows.Forms.ImageList imgListMiColeccion;
        private System.Windows.Forms.ListView lvTienda;
        private System.Windows.Forms.ImageList imgListTienda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbColorGeneral;
        private System.Windows.Forms.PictureBox btnSalir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ContextMenuStrip cmDetalles;
        private System.Windows.Forms.ToolStripMenuItem menuItemDetalles;
        private System.Windows.Forms.PictureBox pbCartaMoviendose;
    }
}