﻿namespace DataBase_Project
{
    partial class Form2
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
            this.LblTablas = new System.Windows.Forms.Label();
            this.CmbTablas = new System.Windows.Forms.ComboBox();
            this.LvBD = new System.Windows.Forms.ListView();
            this.BtnSiguiente = new System.Windows.Forms.Button();
            this.BtnAnterior = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblTablas
            // 
            this.LblTablas.AutoSize = true;
            this.LblTablas.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTablas.Location = new System.Drawing.Point(11, 9);
            this.LblTablas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblTablas.Name = "LblTablas";
            this.LblTablas.Size = new System.Drawing.Size(57, 16);
            this.LblTablas.TabIndex = 6;
            this.LblTablas.Text = "Tablas: ";
            // 
            // CmbTablas
            // 
            this.CmbTablas.FormattingEnabled = true;
            this.CmbTablas.Location = new System.Drawing.Point(74, 3);
            this.CmbTablas.Name = "CmbTablas";
            this.CmbTablas.Size = new System.Drawing.Size(176, 21);
            this.CmbTablas.TabIndex = 7;
            // 
            // LvBD
            // 
            this.LvBD.HideSelection = false;
            this.LvBD.Location = new System.Drawing.Point(14, 41);
            this.LvBD.Name = "LvBD";
            this.LvBD.Size = new System.Drawing.Size(759, 397);
            this.LvBD.TabIndex = 8;
            this.LvBD.UseCompatibleStateImageBehavior = false;
            // 
            // BtnSiguiente
            // 
            this.BtnSiguiente.Location = new System.Drawing.Point(647, 462);
            this.BtnSiguiente.Name = "BtnSiguiente";
            this.BtnSiguiente.Size = new System.Drawing.Size(126, 23);
            this.BtnSiguiente.TabIndex = 11;
            this.BtnSiguiente.Text = "Siguiente";
            this.BtnSiguiente.UseVisualStyleBackColor = true;
            // 
            // BtnAnterior
            // 
            this.BtnAnterior.Location = new System.Drawing.Point(14, 462);
            this.BtnAnterior.Name = "BtnAnterior";
            this.BtnAnterior.Size = new System.Drawing.Size(126, 23);
            this.BtnAnterior.TabIndex = 12;
            this.BtnAnterior.Text = "Anterior";
            this.BtnAnterior.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 497);
            this.Controls.Add(this.BtnAnterior);
            this.Controls.Add(this.BtnSiguiente);
            this.Controls.Add(this.LvBD);
            this.Controls.Add(this.CmbTablas);
            this.Controls.Add(this.LblTablas);
            this.Name = "Form2";
            this.Text = "GestorBD";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTablas;
        private System.Windows.Forms.ComboBox CmbTablas;
        private System.Windows.Forms.ListView LvBD;
        private System.Windows.Forms.Button BtnSiguiente;
        private System.Windows.Forms.Button BtnAnterior;
    }
}