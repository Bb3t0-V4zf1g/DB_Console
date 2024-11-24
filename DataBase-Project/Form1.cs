﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            String servidor = TxtServidor.Text;
            String puerto = TxtPuerto.Text;
            String usuario = TxtUsuario.Text;
            String password = TxtPassword.Text;
            String BD = TxtBD.Text;

            String cadenaConexion = "Server=" + servidor + ";Port=" + puerto + ";User Id=" + usuario + ";Password=" + password + ";Database=" + BD + ";";

            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;
            String data = null;

            try
            {
                String consulta = "SHOW DATABASES";
                MySqlCommand comando = new MySqlCommand(consulta);
                comando.Connection = conexion;
                conexion.Open();
                reader = comando.ExecuteReader();

                while(reader.Read())
                {
                    data += reader.GetString(0) + "\n";
                }

                MessageBox.Show("Conexión Correcta");
                MessageBox.Show(data);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

        }

        private void TxtPuerto_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            TxtUsuario.Text = "";
            TxtPassword.Text = "";
            TxtServidor.Text = "";
            TxtPuerto.Text = "";
            TxtBD.Text = "";
        }
    }
}
