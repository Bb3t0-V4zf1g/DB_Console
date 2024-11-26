using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DataBase_Project
{
    public partial class FormAgregar : Form
    {
        private string tableName;
        private string dataBaseName;
        private string cadenaConexion;
        private MySqlConnection conexion;
        private DataTable tableSchema;

        public FormAgregar(string tableName, string dataBName, string cadenaConexion)
        {
            InitializeComponent();
            this.tableName = tableName;
            this.dataBaseName = dataBName;
            this.cadenaConexion = cadenaConexion;
        }

        private void FormAgregar_Load(object sender, EventArgs e)
        {
            LoadTableSchema();
        }

        private void LoadTableSchema()
        {
            try
            {
                conexion = new MySqlConnection(cadenaConexion);
                conexion.Open();

                // Obtener el esquema de la tabla
                string schemaQuery = $"SELECT * FROM {dataBaseName}.{tableName} LIMIT 1";
                MySqlCommand schemaCommand = new MySqlCommand(schemaQuery, conexion);
                MySqlDataAdapter adapter = new MySqlDataAdapter(schemaCommand);
                tableSchema = new DataTable();
                adapter.Fill(tableSchema);

                int y = 10;
                foreach (DataColumn column in tableSchema.Columns)
                {
                    Label label = new Label
                    {
                        Text = column.ColumnName,
                        Location = new System.Drawing.Point(10, y),
                        AutoSize = true
                    };
                    TextBox textBox = new TextBox
                    {
                        Name = "txt" + column.ColumnName,
                        Location = new System.Drawing.Point(150, y),
                        Width = 200
                    };
                    this.Controls.Add(label);
                    this.Controls.Add(textBox);
                    y += 30;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            if (tableSchema != null && tableSchema.Columns.Count > 0)
            {
                Button btnGuardar = new Button
                {
                    Text = "Guardar",
                    Location = new System.Drawing.Point(150, tableSchema.Columns.Count * 30 + 20)
                };
                btnGuardar.Click += new EventHandler(BtnGuardar_Click);
                this.Controls.Add(btnGuardar);
            }
            else
            {
                MessageBox.Show("Error: No se pudo obtener el esquema de la tabla.");
            }
        }


        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();

                // Construir la consulta de inserción
                string columns = string.Join(", ", tableSchema.Columns.Cast<DataColumn>().Select(column => column.ColumnName));
                string values = string.Join(", ", tableSchema.Columns.Cast<DataColumn>().Select(column => $"'{this.Controls["txt" + column.ColumnName].Text}'"));
                string query = $"INSERT INTO {dataBaseName}.{tableName} ({columns}) VALUES ({values})";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.ExecuteNonQuery();

                MessageBox.Show("Registro agregado correctamente.");
                this.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }
    }
}
