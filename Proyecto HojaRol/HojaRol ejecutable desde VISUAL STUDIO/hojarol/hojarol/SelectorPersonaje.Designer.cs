namespace HojaRol
{
    partial class SelectorPersonaje
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectorPersonaje));
            this.btnSalir = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.pbTituloFF = new System.Windows.Forms.PictureBox();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.panelSelectorPersonaje = new System.Windows.Forms.Panel();
            this.panelPersonaje = new System.Windows.Forms.Panel();
            this.lblRaza = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.pbGenero = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblProfesion = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblAttSuerte = new System.Windows.Forms.Label();
            this.lblAttEspiritu = new System.Windows.Forms.Label();
            this.lblAttMente = new System.Windows.Forms.Label();
            this.lblAttVitalidad = new System.Windows.Forms.Label();
            this.lblAttAgilidad = new System.Windows.Forms.Label();
            this.lblAttFuerza = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.pbAvatar = new System.Windows.Forms.PictureBox();
            this.panelNoHayPersonaje = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.panelAlbum = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.btnImportar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.pbOrdenInvertido = new System.Windows.Forms.PictureBox();
            this.pbOrden = new System.Windows.Forms.PictureBox();
            this.btnSalir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTituloFF)).BeginInit();
            this.panelContenedor.SuspendLayout();
            this.panelSelectorPersonaje.SuspendLayout();
            this.panelPersonaje.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGenero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).BeginInit();
            this.panelNoHayPersonaje.SuspendLayout();
            this.panelAlbum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOrdenInvertido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOrden)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Transparent;
            this.btnSalir.BackgroundImage = global::HojaRol.Properties.Resources.Menu;
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSalir.Controls.Add(this.label18);
            this.btnSalir.Location = new System.Drawing.Point(1179, 25);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(65, 35);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Click += new System.EventHandler(this.cerrarFormulario);
            this.btnSalir.MouseEnter += new System.EventHandler(this.cursorMano);
            this.btnSalir.MouseLeave += new System.EventHandler(this.cursorDefault);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Final Fantasy", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(22, 10);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(23, 17);
            this.label18.TabIndex = 120;
            this.label18.Text = "X";
            this.label18.Click += new System.EventHandler(this.cerrarFormulario);
            this.label18.MouseEnter += new System.EventHandler(this.cursorMano);
            // 
            // pbTituloFF
            // 
            this.pbTituloFF.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbTituloFF.BackgroundImage")));
            this.pbTituloFF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbTituloFF.Location = new System.Drawing.Point(418, 652);
            this.pbTituloFF.Name = "pbTituloFF";
            this.pbTituloFF.Size = new System.Drawing.Size(290, 66);
            this.pbTituloFF.TabIndex = 7;
            this.pbTituloFF.TabStop = false;
            // 
            // panelContenedor
            // 
            this.panelContenedor.Controls.Add(this.panelSelectorPersonaje);
            this.panelContenedor.Controls.Add(this.panelAlbum);
            this.panelContenedor.Controls.Add(this.pbOrdenInvertido);
            this.panelContenedor.Controls.Add(this.pbTituloFF);
            this.panelContenedor.Controls.Add(this.pbOrden);
            this.panelContenedor.Location = new System.Drawing.Point(26, 12);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(1134, 721);
            this.panelContenedor.TabIndex = 8;
            // 
            // panelSelectorPersonaje
            // 
            this.panelSelectorPersonaje.BackColor = System.Drawing.Color.Transparent;
            this.panelSelectorPersonaje.BackgroundImage = global::HojaRol.Properties.Resources.Menu;
            this.panelSelectorPersonaje.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSelectorPersonaje.Controls.Add(this.panelPersonaje);
            this.panelSelectorPersonaje.Controls.Add(this.panelNoHayPersonaje);
            this.panelSelectorPersonaje.Controls.Add(this.btnSiguiente);
            this.panelSelectorPersonaje.Controls.Add(this.btnAnterior);
            this.panelSelectorPersonaje.Controls.Add(this.btnModificar);
            this.panelSelectorPersonaje.Controls.Add(this.btnBorrar);
            this.panelSelectorPersonaje.Controls.Add(this.btnCrear);
            this.panelSelectorPersonaje.Location = new System.Drawing.Point(372, 179);
            this.panelSelectorPersonaje.Name = "panelSelectorPersonaje";
            this.panelSelectorPersonaje.Size = new System.Drawing.Size(389, 473);
            this.panelSelectorPersonaje.TabIndex = 8;
            // 
            // panelPersonaje
            // 
            this.panelPersonaje.BackColor = System.Drawing.Color.Transparent;
            this.panelPersonaje.Controls.Add(this.lblRaza);
            this.panelPersonaje.Controls.Add(this.label15);
            this.panelPersonaje.Controls.Add(this.pbGenero);
            this.panelPersonaje.Controls.Add(this.label14);
            this.panelPersonaje.Controls.Add(this.label13);
            this.panelPersonaje.Controls.Add(this.label12);
            this.panelPersonaje.Controls.Add(this.label11);
            this.panelPersonaje.Controls.Add(this.label10);
            this.panelPersonaje.Controls.Add(this.lblProfesion);
            this.panelPersonaje.Controls.Add(this.lblNombre);
            this.panelPersonaje.Controls.Add(this.lblAttSuerte);
            this.panelPersonaje.Controls.Add(this.lblAttEspiritu);
            this.panelPersonaje.Controls.Add(this.lblAttMente);
            this.panelPersonaje.Controls.Add(this.lblAttVitalidad);
            this.panelPersonaje.Controls.Add(this.lblAttAgilidad);
            this.panelPersonaje.Controls.Add(this.lblAttFuerza);
            this.panelPersonaje.Controls.Add(this.label9);
            this.panelPersonaje.Controls.Add(this.label8);
            this.panelPersonaje.Controls.Add(this.label7);
            this.panelPersonaje.Controls.Add(this.label6);
            this.panelPersonaje.Controls.Add(this.label5);
            this.panelPersonaje.Controls.Add(this.label4);
            this.panelPersonaje.Controls.Add(this.label3);
            this.panelPersonaje.Controls.Add(this.label2);
            this.panelPersonaje.Controls.Add(this.label1);
            this.panelPersonaje.Controls.Add(this.label20);
            this.panelPersonaje.Controls.Add(this.pbAvatar);
            this.panelPersonaje.Location = new System.Drawing.Point(28, 37);
            this.panelPersonaje.Name = "panelPersonaje";
            this.panelPersonaje.Size = new System.Drawing.Size(331, 290);
            this.panelPersonaje.TabIndex = 117;
            this.panelPersonaje.Visible = false;
            // 
            // lblRaza
            // 
            this.lblRaza.AutoSize = true;
            this.lblRaza.BackColor = System.Drawing.Color.Transparent;
            this.lblRaza.Font = new System.Drawing.Font("Final Fantasy", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRaza.ForeColor = System.Drawing.Color.Gold;
            this.lblRaza.Location = new System.Drawing.Point(226, 44);
            this.lblRaza.Name = "lblRaza";
            this.lblRaza.Size = new System.Drawing.Size(11, 14);
            this.lblRaza.TabIndex = 133;
            this.lblRaza.Text = ".";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Final Fantasy", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(275, 240);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 14);
            this.label15.TabIndex = 140;
            this.label15.Text = "-";
            // 
            // pbGenero
            // 
            this.pbGenero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbGenero.Location = new System.Drawing.Point(311, 34);
            this.pbGenero.Name = "pbGenero";
            this.pbGenero.Size = new System.Drawing.Size(21, 26);
            this.pbGenero.TabIndex = 141;
            this.pbGenero.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Final Fantasy", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(275, 203);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 14);
            this.label14.TabIndex = 139;
            this.label14.Text = "-";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Final Fantasy", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(275, 165);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 14);
            this.label13.TabIndex = 138;
            this.label13.Text = "-";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Final Fantasy", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(105, 240);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 14);
            this.label12.TabIndex = 137;
            this.label12.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Final Fantasy", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(105, 203);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 14);
            this.label11.TabIndex = 136;
            this.label11.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Final Fantasy", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(105, 165);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 14);
            this.label10.TabIndex = 135;
            this.label10.Text = "-";
            // 
            // lblProfesion
            // 
            this.lblProfesion.AutoSize = true;
            this.lblProfesion.BackColor = System.Drawing.Color.Transparent;
            this.lblProfesion.Font = new System.Drawing.Font("Final Fantasy", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfesion.ForeColor = System.Drawing.Color.Gold;
            this.lblProfesion.Location = new System.Drawing.Point(226, 70);
            this.lblProfesion.Name = "lblProfesion";
            this.lblProfesion.Size = new System.Drawing.Size(11, 14);
            this.lblProfesion.TabIndex = 134;
            this.lblProfesion.Text = ".";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.Color.Transparent;
            this.lblNombre.Font = new System.Drawing.Font("Final Fantasy", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.Gold;
            this.lblNombre.Location = new System.Drawing.Point(226, 17);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(82, 14);
            this.lblNombre.TabIndex = 132;
            this.lblNombre.Text = "Clavate";
            // 
            // lblAttSuerte
            // 
            this.lblAttSuerte.AutoSize = true;
            this.lblAttSuerte.BackColor = System.Drawing.Color.Transparent;
            this.lblAttSuerte.Font = new System.Drawing.Font("Final Fantasy", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttSuerte.ForeColor = System.Drawing.Color.Gold;
            this.lblAttSuerte.Location = new System.Drawing.Point(298, 240);
            this.lblAttSuerte.Name = "lblAttSuerte";
            this.lblAttSuerte.Size = new System.Drawing.Size(20, 14);
            this.lblAttSuerte.TabIndex = 131;
            this.lblAttSuerte.Text = "0";
            // 
            // lblAttEspiritu
            // 
            this.lblAttEspiritu.AutoSize = true;
            this.lblAttEspiritu.BackColor = System.Drawing.Color.Transparent;
            this.lblAttEspiritu.Font = new System.Drawing.Font("Final Fantasy", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttEspiritu.ForeColor = System.Drawing.Color.Gold;
            this.lblAttEspiritu.Location = new System.Drawing.Point(298, 203);
            this.lblAttEspiritu.Name = "lblAttEspiritu";
            this.lblAttEspiritu.Size = new System.Drawing.Size(20, 14);
            this.lblAttEspiritu.TabIndex = 130;
            this.lblAttEspiritu.Text = "0";
            // 
            // lblAttMente
            // 
            this.lblAttMente.AutoSize = true;
            this.lblAttMente.BackColor = System.Drawing.Color.Transparent;
            this.lblAttMente.Font = new System.Drawing.Font("Final Fantasy", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttMente.ForeColor = System.Drawing.Color.Gold;
            this.lblAttMente.Location = new System.Drawing.Point(298, 165);
            this.lblAttMente.Name = "lblAttMente";
            this.lblAttMente.Size = new System.Drawing.Size(20, 14);
            this.lblAttMente.TabIndex = 129;
            this.lblAttMente.Text = "0";
            // 
            // lblAttVitalidad
            // 
            this.lblAttVitalidad.AutoSize = true;
            this.lblAttVitalidad.BackColor = System.Drawing.Color.Transparent;
            this.lblAttVitalidad.Font = new System.Drawing.Font("Final Fantasy", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttVitalidad.ForeColor = System.Drawing.Color.Gold;
            this.lblAttVitalidad.Location = new System.Drawing.Point(128, 240);
            this.lblAttVitalidad.Name = "lblAttVitalidad";
            this.lblAttVitalidad.Size = new System.Drawing.Size(20, 14);
            this.lblAttVitalidad.TabIndex = 128;
            this.lblAttVitalidad.Text = "0";
            // 
            // lblAttAgilidad
            // 
            this.lblAttAgilidad.AutoSize = true;
            this.lblAttAgilidad.BackColor = System.Drawing.Color.Transparent;
            this.lblAttAgilidad.Font = new System.Drawing.Font("Final Fantasy", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttAgilidad.ForeColor = System.Drawing.Color.Gold;
            this.lblAttAgilidad.Location = new System.Drawing.Point(128, 203);
            this.lblAttAgilidad.Name = "lblAttAgilidad";
            this.lblAttAgilidad.Size = new System.Drawing.Size(20, 14);
            this.lblAttAgilidad.TabIndex = 127;
            this.lblAttAgilidad.Text = "0";
            // 
            // lblAttFuerza
            // 
            this.lblAttFuerza.AutoSize = true;
            this.lblAttFuerza.BackColor = System.Drawing.Color.Transparent;
            this.lblAttFuerza.Font = new System.Drawing.Font("Final Fantasy", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttFuerza.ForeColor = System.Drawing.Color.Gold;
            this.lblAttFuerza.Location = new System.Drawing.Point(128, 165);
            this.lblAttFuerza.Name = "lblAttFuerza";
            this.lblAttFuerza.Size = new System.Drawing.Size(20, 14);
            this.lblAttFuerza.TabIndex = 126;
            this.lblAttFuerza.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Final Fantasy", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(184, 240);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 14);
            this.label9.TabIndex = 125;
            this.label9.Text = "Suerte";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Final Fantasy", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(184, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 14);
            this.label8.TabIndex = 124;
            this.label8.Text = "Espiritu ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Final Fantasy", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(184, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 14);
            this.label7.TabIndex = 123;
            this.label7.Text = "Mente";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Final Fantasy", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(11, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 14);
            this.label6.TabIndex = 122;
            this.label6.Text = "Vitalidad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Final Fantasy", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(11, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 14);
            this.label5.TabIndex = 121;
            this.label5.Text = "Agilidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Final Fantasy", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(11, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 14);
            this.label4.TabIndex = 120;
            this.label4.Text = "Fuerza";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Final Fantasy", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(11, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 14);
            this.label3.TabIndex = 119;
            this.label3.Text = "Atributos:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Final Fantasy", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(115, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 14);
            this.label2.TabIndex = 118;
            this.label2.Text = "Profesion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Final Fantasy", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(115, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 117;
            this.label1.Text = "Raza";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Final Fantasy", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(115, 17);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(75, 14);
            this.label20.TabIndex = 116;
            this.label20.Text = "Nombre";
            // 
            // pbAvatar
            // 
            this.pbAvatar.BackColor = System.Drawing.Color.White;
            this.pbAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAvatar.Location = new System.Drawing.Point(14, 3);
            this.pbAvatar.Name = "pbAvatar";
            this.pbAvatar.Size = new System.Drawing.Size(79, 91);
            this.pbAvatar.TabIndex = 115;
            this.pbAvatar.TabStop = false;
            // 
            // panelNoHayPersonaje
            // 
            this.panelNoHayPersonaje.BackColor = System.Drawing.Color.Transparent;
            this.panelNoHayPersonaje.Controls.Add(this.label16);
            this.panelNoHayPersonaje.Location = new System.Drawing.Point(40, 63);
            this.panelNoHayPersonaje.Name = "panelNoHayPersonaje";
            this.panelNoHayPersonaje.Size = new System.Drawing.Size(309, 221);
            this.panelNoHayPersonaje.TabIndex = 123;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Final Fantasy", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(43, 104);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(229, 14);
            this.label16.TabIndex = 121;
            this.label16.Text = "No hay ningun personaje";
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.AutoSize = true;
            this.btnSiguiente.Font = new System.Drawing.Font("Final Fantasy", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiguiente.Location = new System.Drawing.Point(277, 356);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(52, 32);
            this.btnSiguiente.TabIndex = 2;
            this.btnSiguiente.Text = "->";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Visible = false;
            this.btnSiguiente.Click += new System.EventHandler(this.siguientePersonaje);
            this.btnSiguiente.MouseEnter += new System.EventHandler(this.cursorMano);
            this.btnSiguiente.MouseLeave += new System.EventHandler(this.cursorDefault);
            // 
            // btnAnterior
            // 
            this.btnAnterior.AutoSize = true;
            this.btnAnterior.Font = new System.Drawing.Font("Final Fantasy", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnterior.Location = new System.Drawing.Point(71, 356);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(52, 32);
            this.btnAnterior.TabIndex = 1;
            this.btnAnterior.Text = "<-";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Visible = false;
            this.btnAnterior.Click += new System.EventHandler(this.anteriorPersonaje);
            this.btnAnterior.MouseEnter += new System.EventHandler(this.cursorMano);
            this.btnAnterior.MouseLeave += new System.EventHandler(this.cursorDefault);
            // 
            // btnModificar
            // 
            this.btnModificar.AutoSize = true;
            this.btnModificar.Font = new System.Drawing.Font("Final Fantasy", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(40, 408);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(102, 23);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Visible = false;
            this.btnModificar.Click += new System.EventHandler(this.modificarPersonaje);
            this.btnModificar.MouseEnter += new System.EventHandler(this.cursorMano);
            this.btnModificar.MouseLeave += new System.EventHandler(this.cursorDefault);
            // 
            // btnBorrar
            // 
            this.btnBorrar.AutoSize = true;
            this.btnBorrar.Font = new System.Drawing.Font("Final Fantasy", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrar.Location = new System.Drawing.Point(148, 408);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(103, 23);
            this.btnBorrar.TabIndex = 4;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Visible = false;
            this.btnBorrar.Click += new System.EventHandler(this.borrarPersonaje);
            this.btnBorrar.MouseEnter += new System.EventHandler(this.cursorMano);
            this.btnBorrar.MouseLeave += new System.EventHandler(this.cursorDefault);
            // 
            // btnCrear
            // 
            this.btnCrear.AutoSize = true;
            this.btnCrear.Font = new System.Drawing.Font("Final Fantasy", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrear.Location = new System.Drawing.Point(257, 408);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(102, 23);
            this.btnCrear.TabIndex = 5;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.crearPersonaje);
            this.btnCrear.MouseEnter += new System.EventHandler(this.cursorMano);
            this.btnCrear.MouseLeave += new System.EventHandler(this.cursorDefault);
            // 
            // panelAlbum
            // 
            this.panelAlbum.BackColor = System.Drawing.Color.Transparent;
            this.panelAlbum.BackgroundImage = global::HojaRol.Properties.Resources.Menu;
            this.panelAlbum.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelAlbum.Controls.Add(this.label17);
            this.panelAlbum.Controls.Add(this.btnImportar);
            this.panelAlbum.Controls.Add(this.btnExportar);
            this.panelAlbum.Location = new System.Drawing.Point(778, 456);
            this.panelAlbum.Name = "panelAlbum";
            this.panelAlbum.Size = new System.Drawing.Size(149, 141);
            this.panelAlbum.TabIndex = 9;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Final Fantasy", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(39, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(68, 17);
            this.label17.TabIndex = 120;
            this.label17.Text = "Album";
            // 
            // btnImportar
            // 
            this.btnImportar.AutoSize = true;
            this.btnImportar.Font = new System.Drawing.Font("Final Fantasy", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportar.Location = new System.Drawing.Point(25, 89);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(102, 23);
            this.btnImportar.TabIndex = 7;
            this.btnImportar.Text = "Importar";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.importarAlbum);
            this.btnImportar.MouseEnter += new System.EventHandler(this.cursorMano);
            this.btnImportar.MouseLeave += new System.EventHandler(this.cursorDefault);
            // 
            // btnExportar
            // 
            this.btnExportar.AutoSize = true;
            this.btnExportar.Font = new System.Drawing.Font("Final Fantasy", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.Location = new System.Drawing.Point(25, 47);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(102, 23);
            this.btnExportar.TabIndex = 6;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.exportarAlbum);
            this.btnExportar.MouseEnter += new System.EventHandler(this.cursorMano);
            this.btnExportar.MouseLeave += new System.EventHandler(this.cursorDefault);
            // 
            // pbOrdenInvertido
            // 
            this.pbOrdenInvertido.BackColor = System.Drawing.Color.Transparent;
            this.pbOrdenInvertido.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbOrdenInvertido.BackgroundImage")));
            this.pbOrdenInvertido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbOrdenInvertido.Location = new System.Drawing.Point(746, 0);
            this.pbOrdenInvertido.Name = "pbOrdenInvertido";
            this.pbOrdenInvertido.Size = new System.Drawing.Size(386, 444);
            this.pbOrdenInvertido.TabIndex = 11;
            this.pbOrdenInvertido.TabStop = false;
            // 
            // pbOrden
            // 
            this.pbOrden.BackColor = System.Drawing.Color.Transparent;
            this.pbOrden.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbOrden.BackgroundImage")));
            this.pbOrden.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbOrden.Location = new System.Drawing.Point(3, 0);
            this.pbOrden.Name = "pbOrden";
            this.pbOrden.Size = new System.Drawing.Size(386, 444);
            this.pbOrden.TabIndex = 10;
            this.pbOrden.TabStop = false;
            // 
            // SelectorPersonaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1604, 818);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.btnSalir);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SelectorPersonaje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.guardarAlbum);
            this.Shown += new System.EventHandler(this.cargarAlbum);
            this.btnSalir.ResumeLayout(false);
            this.btnSalir.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTituloFF)).EndInit();
            this.panelContenedor.ResumeLayout(false);
            this.panelSelectorPersonaje.ResumeLayout(false);
            this.panelSelectorPersonaje.PerformLayout();
            this.panelPersonaje.ResumeLayout(false);
            this.panelPersonaje.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGenero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).EndInit();
            this.panelNoHayPersonaje.ResumeLayout(false);
            this.panelNoHayPersonaje.PerformLayout();
            this.panelAlbum.ResumeLayout(false);
            this.panelAlbum.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOrdenInvertido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOrden)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel btnSalir;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.PictureBox pbTituloFF;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Panel panelSelectorPersonaje;
        private System.Windows.Forms.Panel panelPersonaje;
        private System.Windows.Forms.Label lblRaza;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox pbGenero;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblProfesion;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblAttSuerte;
        private System.Windows.Forms.Label lblAttEspiritu;
        private System.Windows.Forms.Label lblAttMente;
        private System.Windows.Forms.Label lblAttVitalidad;
        private System.Windows.Forms.Label lblAttAgilidad;
        private System.Windows.Forms.Label lblAttFuerza;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.PictureBox pbAvatar;
        private System.Windows.Forms.Panel panelNoHayPersonaje;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Panel panelAlbum;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.PictureBox pbOrdenInvertido;
        private System.Windows.Forms.PictureBox pbOrden;
    }
}