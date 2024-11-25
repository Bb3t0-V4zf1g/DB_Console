using System;

namespace DataBase_Project
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.TxtServidor = new System.Windows.Forms.TextBox();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.LblServidor = new System.Windows.Forms.Label();
            this.LblPuerto = new System.Windows.Forms.Label();
            this.LblUsuario = new System.Windows.Forms.Label();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.LblBD = new System.Windows.Forms.Label();
            this.LblPassword = new System.Windows.Forms.Label();
            this.TxtPuerto = new System.Windows.Forms.TextBox();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Font = new System.Drawing.Font("Mongolian Baiti", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenido.Location = new System.Drawing.Point(217, 11);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(241, 50);
            this.lblBienvenido.TabIndex = 0;
            this.lblBienvenido.Text = "Bienvenido";
            // 
            // TxtServidor
            // 
            this.TxtServidor.Location = new System.Drawing.Point(276, 75);
            this.TxtServidor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtServidor.Name = "TxtServidor";
            this.TxtServidor.Size = new System.Drawing.Size(197, 22);
            this.TxtServidor.TabIndex = 1;
            // 
            // BtnLogin
            // 
            this.BtnLogin.Location = new System.Drawing.Point(192, 313);
            this.BtnLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(109, 33);
            this.BtnLogin.TabIndex = 6;
            this.BtnLogin.Text = "Conectar";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(375, 313);
            this.BtnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(81, 33);
            this.BtnCancelar.TabIndex = 7;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // LblServidor
            // 
            this.LblServidor.AutoSize = true;
            this.LblServidor.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblServidor.Location = new System.Drawing.Point(157, 75);
            this.LblServidor.Name = "LblServidor";
            this.LblServidor.Size = new System.Drawing.Size(86, 21);
            this.LblServidor.TabIndex = 5;
            this.LblServidor.Text = "Servidor:";
            // 
            // LblPuerto
            // 
            this.LblPuerto.AutoSize = true;
            this.LblPuerto.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPuerto.Location = new System.Drawing.Point(157, 129);
            this.LblPuerto.Name = "LblPuerto";
            this.LblPuerto.Size = new System.Drawing.Size(69, 21);
            this.LblPuerto.TabIndex = 6;
            this.LblPuerto.Text = "Puerto:";
            // 
            // LblUsuario
            // 
            this.LblUsuario.AutoSize = true;
            this.LblUsuario.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUsuario.Location = new System.Drawing.Point(157, 171);
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Size = new System.Drawing.Size(80, 21);
            this.LblUsuario.TabIndex = 7;
            this.LblUsuario.Text = "Usuario:";
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(276, 217);
            this.TxtPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(197, 22);
            this.TxtPassword.TabIndex = 4;
            this.TxtPassword.UseSystemPasswordChar = true;
            // 
            // LblBD
            // 
            this.LblBD.AutoSize = true;
            this.LblBD.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBD.Location = new System.Drawing.Point(97, 268);
            this.LblBD.Name = "LblBD";
            this.LblBD.Size = new System.Drawing.Size(0, 21);
            this.LblBD.TabIndex = 9;
            // 
            // LblPassword
            // 
            this.LblPassword.AutoSize = true;
            this.LblPassword.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPassword.Location = new System.Drawing.Point(135, 222);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.Size = new System.Drawing.Size(107, 21);
            this.LblPassword.TabIndex = 12;
            this.LblPassword.Text = "Contraseña:";
            // 
            // TxtPuerto
            // 
            this.TxtPuerto.Location = new System.Drawing.Point(276, 124);
            this.TxtPuerto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtPuerto.Name = "TxtPuerto";
            this.TxtPuerto.Size = new System.Drawing.Size(197, 22);
            this.TxtPuerto.TabIndex = 2;
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.Location = new System.Drawing.Point(276, 166);
            this.TxtUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(197, 22);
            this.TxtUsuario.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 359);
            this.Controls.Add(this.TxtUsuario);
            this.Controls.Add(this.TxtPuerto);
            this.Controls.Add(this.LblPassword);
            this.Controls.Add(this.LblBD);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.LblUsuario);
            this.Controls.Add(this.LblPuerto);
            this.Controls.Add(this.LblServidor);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnLogin);
            this.Controls.Add(this.TxtServidor);
            this.Controls.Add(this.lblBienvenido);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        #endregion

        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.TextBox TxtServidor;
        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Label LblServidor;
        private System.Windows.Forms.Label LblPuerto;
        private System.Windows.Forms.Label LblUsuario;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Label LblBD;
        private System.Windows.Forms.Label LblPassword;
        private System.Windows.Forms.TextBox TxtPuerto;
        private System.Windows.Forms.TextBox TxtUsuario;
    }
}

