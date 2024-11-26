using System;

namespace DataBase_Project
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
            this.TxtQuerys = new System.Windows.Forms.TextBox();
            this.LblInfo = new System.Windows.Forms.Label();
            this.BtnCerrasSesion = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.lblDB = new System.Windows.Forms.Label();
            this.CmbDataBases = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblPagination = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblTablas
            // 
            this.LblTablas.AutoSize = true;
            this.LblTablas.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTablas.Location = new System.Drawing.Point(553, 14);
            this.LblTablas.Name = "LblTablas";
            this.LblTablas.Size = new System.Drawing.Size(75, 21);
            this.LblTablas.TabIndex = 6;
            this.LblTablas.Text = "Tablas: ";
            // 
            // CmbTablas
            // 
            this.CmbTablas.FormattingEnabled = true;
            this.CmbTablas.Location = new System.Drawing.Point(624, 11);
            this.CmbTablas.Margin = new System.Windows.Forms.Padding(4);
            this.CmbTablas.Name = "CmbTablas";
            this.CmbTablas.Size = new System.Drawing.Size(221, 24);
            this.CmbTablas.TabIndex = 7;
            this.CmbTablas.SelectedIndexChanged += new System.EventHandler(this.CmbTablas_SelectedIndexChanged);
            // 
            // LvBD
            // 
            this.LvBD.HideSelection = false;
            this.LvBD.Location = new System.Drawing.Point(19, 325);
            this.LvBD.Margin = new System.Windows.Forms.Padding(4);
            this.LvBD.Name = "LvBD";
            this.LvBD.Size = new System.Drawing.Size(1011, 213);
            this.LvBD.TabIndex = 8;
            this.LvBD.UseCompatibleStateImageBehavior = false;
            // 
            // BtnSiguiente
            // 
            this.BtnSiguiente.Location = new System.Drawing.Point(913, 569);
            this.BtnSiguiente.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSiguiente.Name = "BtnSiguiente";
            this.BtnSiguiente.Size = new System.Drawing.Size(117, 28);
            this.BtnSiguiente.TabIndex = 11;
            this.BtnSiguiente.Text = "Siguiente";
            this.BtnSiguiente.UseVisualStyleBackColor = true;
            // 
            // BtnAnterior
            // 
            this.BtnAnterior.Location = new System.Drawing.Point(19, 569);
            this.BtnAnterior.Margin = new System.Windows.Forms.Padding(4);
            this.BtnAnterior.Name = "BtnAnterior";
            this.BtnAnterior.Size = new System.Drawing.Size(121, 28);
            this.BtnAnterior.TabIndex = 12;
            this.BtnAnterior.Text = "Anterior";
            this.BtnAnterior.UseVisualStyleBackColor = true;
            // 
            // TxtQuerys
            // 
            this.TxtQuerys.Location = new System.Drawing.Point(19, 89);
            this.TxtQuerys.Margin = new System.Windows.Forms.Padding(4);
            this.TxtQuerys.Multiline = true;
            this.TxtQuerys.Name = "TxtQuerys";
            this.TxtQuerys.Size = new System.Drawing.Size(1011, 212);
            this.TxtQuerys.TabIndex = 13;
            // 
            // LblInfo
            // 
            this.LblInfo.AutoSize = true;
            this.LblInfo.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInfo.Location = new System.Drawing.Point(505, 65);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(73, 21);
            this.LblInfo.TabIndex = 14;
            this.LblInfo.Text = "Querys ";
            // 
            // BtnCerrasSesion
            // 
            this.BtnCerrasSesion.BackColor = System.Drawing.Color.Red;
            this.BtnCerrasSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCerrasSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCerrasSesion.ForeColor = System.Drawing.SystemColors.Control;
            this.BtnCerrasSesion.Location = new System.Drawing.Point(865, 1);
            this.BtnCerrasSesion.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCerrasSesion.Name = "BtnCerrasSesion";
            this.BtnCerrasSesion.Size = new System.Drawing.Size(168, 28);
            this.BtnCerrasSesion.TabIndex = 15;
            this.BtnCerrasSesion.Text = "Cerrar Sesion";
            this.BtnCerrasSesion.UseVisualStyleBackColor = false;
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(863, 53);
            this.BtnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(168, 28);
            this.BtnBuscar.TabIndex = 16;
            this.BtnBuscar.Text = "Ejecutar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            // 
            // lblDB
            // 
            this.lblDB.AutoSize = true;
            this.lblDB.Font = new System.Drawing.Font("Mongolian Baiti", 12F);
            this.lblDB.Location = new System.Drawing.Point(150, 14);
            this.lblDB.Name = "lblDB";
            this.lblDB.Size = new System.Drawing.Size(139, 21);
            this.lblDB.TabIndex = 17;
            this.lblDB.Text = "Bases de Datos:";
            this.lblDB.Click += new System.EventHandler(this.label1_Click);
            // 
            // CmbDataBases
            // 
            this.CmbDataBases.FormattingEnabled = true;
            this.CmbDataBases.Location = new System.Drawing.Point(295, 11);
            this.CmbDataBases.Name = "CmbDataBases";
            this.CmbDataBases.Size = new System.Drawing.Size(241, 24);
            this.CmbDataBases.TabIndex = 18;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(249, 569);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(125, 28);
            this.btnAgregar.TabIndex = 19;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(475, 569);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(125, 28);
            this.btnModificar.TabIndex = 20;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(696, 569);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(125, 28);
            this.btnEliminar.TabIndex = 21;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // lblPagination
            // 
            this.lblPagination.AutoSize = true;
            this.lblPagination.Location = new System.Drawing.Point(300, 400);
            this.lblPagination.Name = "lblPagination";
            this.lblPagination.Size = new System.Drawing.Size(89, 16);
            this.lblPagination.TabIndex = 0;
            this.lblPagination.Text = "Página 1 de 1";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 612);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.CmbDataBases);
            this.Controls.Add(this.lblDB);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.BtnCerrasSesion);
            this.Controls.Add(this.LblInfo);
            this.Controls.Add(this.TxtQuerys);
            this.Controls.Add(this.BtnAnterior);
            this.Controls.Add(this.BtnSiguiente);
            this.Controls.Add(this.LvBD);
            this.Controls.Add(this.CmbTablas);
            this.Controls.Add(this.LblTablas);
            this.Controls.Add(this.lblPagination);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GestorBD";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label LblTablas;
        private System.Windows.Forms.ComboBox CmbTablas;
        private System.Windows.Forms.ListView LvBD;
        private System.Windows.Forms.Button BtnSiguiente;
        private System.Windows.Forms.Button BtnAnterior;
        private System.Windows.Forms.TextBox TxtQuerys;
        private System.Windows.Forms.Label LblInfo;
        private System.Windows.Forms.Button BtnCerrasSesion;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Label lblDB;
        private System.Windows.Forms.ComboBox CmbDataBases;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
    }
}