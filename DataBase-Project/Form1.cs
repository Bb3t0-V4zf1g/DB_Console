using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace DataBase_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            String servidor = TxtServidor.Text;
            String puerto = TxtPuerto.Text;
            String usuario = TxtUsuario.Text;
            String password = TxtPassword.Text;

            String cadenaConexion = $"Server={servidor};Port={puerto};User Id={usuario};Password={password};";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                MessageBox.Show("Conexión Correcta");

                // Abrir el formulario 2 para seleccionar la base de datos
                Form2 form2 = new Form2(cadenaConexion);
                form2.Show();
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

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            TxtUsuario.Text = "";
            TxtPassword.Text = "";
            TxtServidor.Text = "";
            TxtPuerto.Text = "";
        }
    }
}
