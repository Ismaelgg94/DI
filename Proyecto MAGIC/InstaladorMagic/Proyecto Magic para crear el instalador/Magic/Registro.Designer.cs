namespace Magic
{
    partial class Registro
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRepeatPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPassError = new System.Windows.Forms.Label();
            this.lblUsuarioExistente = new System.Windows.Forms.Label();
            this.pbConfirmar = new System.Windows.Forms.PictureBox();
            this.lblCamposSinRellenar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbConfirmar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Marlett", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(298, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(74)))), ((int)(((byte)(75)))));
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.ForeColor = System.Drawing.SystemColors.Window;
            this.txtUsuario.Location = new System.Drawing.Point(250, 74);
            this.txtUsuario.MaxLength = 15;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(167, 23);
            this.txtUsuario.TabIndex = 2;
            this.txtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.teclaEnter);
            this.txtUsuario.Leave += new System.EventHandler(this.comprobarUsuario);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(74)))), ((int)(((byte)(75)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.SystemColors.Window;
            this.txtPassword.Location = new System.Drawing.Point(250, 153);
            this.txtPassword.MaxLength = 15;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(167, 23);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.isSamePassword);
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.teclaEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Marlett", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(284, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña";
            // 
            // txtRepeatPassword
            // 
            this.txtRepeatPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(74)))), ((int)(((byte)(75)))));
            this.txtRepeatPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRepeatPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRepeatPassword.ForeColor = System.Drawing.SystemColors.Window;
            this.txtRepeatPassword.Location = new System.Drawing.Point(250, 225);
            this.txtRepeatPassword.MaxLength = 15;
            this.txtRepeatPassword.Name = "txtRepeatPassword";
            this.txtRepeatPassword.PasswordChar = '*';
            this.txtRepeatPassword.Size = new System.Drawing.Size(167, 23);
            this.txtRepeatPassword.TabIndex = 6;
            this.txtRepeatPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRepeatPassword.UseSystemPasswordChar = true;
            this.txtRepeatPassword.TextChanged += new System.EventHandler(this.isSamePassword);
            this.txtRepeatPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.teclaEnter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Marlett", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(255, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Repetir Contraseña";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Magic.Properties.Resources.btnAtras;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(234, 371);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 30);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.salir);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.cursorMano);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.cursorNormal);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Marlett", 19F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(266, 371);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 30);
            this.label4.TabIndex = 8;
            this.label4.Text = "Volver";
            this.label4.Click += new System.EventHandler(this.salir);
            this.label4.MouseEnter += new System.EventHandler(this.cursorMano);
            this.label4.MouseLeave += new System.EventHandler(this.cursorNormal);
            // 
            // lblPassError
            // 
            this.lblPassError.AutoSize = true;
            this.lblPassError.BackColor = System.Drawing.Color.Transparent;
            this.lblPassError.Font = new System.Drawing.Font("Marlett", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassError.ForeColor = System.Drawing.Color.Red;
            this.lblPassError.Location = new System.Drawing.Point(225, 267);
            this.lblPassError.Name = "lblPassError";
            this.lblPassError.Size = new System.Drawing.Size(218, 16);
            this.lblPassError.TabIndex = 9;
            this.lblPassError.Text = "Las contraseñas no coinciden";
            this.lblPassError.Visible = false;
            // 
            // lblUsuarioExistente
            // 
            this.lblUsuarioExistente.AutoSize = true;
            this.lblUsuarioExistente.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuarioExistente.Font = new System.Drawing.Font("Marlett", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioExistente.ForeColor = System.Drawing.Color.Red;
            this.lblUsuarioExistente.Location = new System.Drawing.Point(225, 292);
            this.lblUsuarioExistente.Name = "lblUsuarioExistente";
            this.lblUsuarioExistente.Size = new System.Drawing.Size(162, 16);
            this.lblUsuarioExistente.TabIndex = 10;
            this.lblUsuarioExistente.Text = "Este usuario ya existe";
            this.lblUsuarioExistente.Visible = false;
            // 
            // pbConfirmar
            // 
            this.pbConfirmar.BackColor = System.Drawing.Color.Transparent;
            this.pbConfirmar.BackgroundImage = global::Magic.Properties.Resources.Log;
            this.pbConfirmar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbConfirmar.Location = new System.Drawing.Point(377, 365);
            this.pbConfirmar.Name = "pbConfirmar";
            this.pbConfirmar.Size = new System.Drawing.Size(44, 42);
            this.pbConfirmar.TabIndex = 11;
            this.pbConfirmar.TabStop = false;
            this.pbConfirmar.Click += new System.EventHandler(this.btnConfirmar);
            this.pbConfirmar.MouseEnter += new System.EventHandler(this.cursorMano);
            this.pbConfirmar.MouseLeave += new System.EventHandler(this.cursorNormal);
            // 
            // lblCamposSinRellenar
            // 
            this.lblCamposSinRellenar.AutoSize = true;
            this.lblCamposSinRellenar.BackColor = System.Drawing.Color.Transparent;
            this.lblCamposSinRellenar.Font = new System.Drawing.Font("Marlett", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCamposSinRellenar.ForeColor = System.Drawing.Color.Red;
            this.lblCamposSinRellenar.Location = new System.Drawing.Point(225, 317);
            this.lblCamposSinRellenar.Name = "lblCamposSinRellenar";
            this.lblCamposSinRellenar.Size = new System.Drawing.Size(175, 16);
            this.lblCamposSinRellenar.TabIndex = 12;
            this.lblCamposSinRellenar.Text = "Hay campos sin rellenar";
            this.lblCamposSinRellenar.Visible = false;
            // 
            // Registro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Magic.Properties.Resources.registro;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(455, 546);
            this.Controls.Add(this.lblCamposSinRellenar);
            this.Controls.Add(this.pbConfirmar);
            this.Controls.Add(this.lblUsuarioExistente);
            this.Controls.Add(this.lblPassError);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtRepeatPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Registro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbConfirmar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRepeatPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPassError;
        private System.Windows.Forms.Label lblUsuarioExistente;
        private System.Windows.Forms.PictureBox pbConfirmar;
        private System.Windows.Forms.Label lblCamposSinRellenar;
    }
}