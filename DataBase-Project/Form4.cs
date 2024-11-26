using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DataBase_Project
{
    public partial class FormModificar : Form
    {
        private string tableName;
        private string primaryKeyColumn;
        private string primaryKeyValue;
        private string cadenaConexion;
        private string dataBaseName;
        private MySqlConnection conexion;
        private DataTable tableSchema;

        public FormModificar(string tableName, string primaryKeyColumn, string primaryKeyValue, string dataBName, string cadenaConexion)
        {
            InitializeComponent();
            this.tableName = tableName;
            this.primaryKeyColumn = primaryKeyColumn;
            this.primaryKeyValue = primaryKeyValue;
            this.dataBaseName = dataBName;
            this.cadenaConexion = cadenaConexion;
        }

        private void FormModificar_Load(object sender, EventArgs e)
        {
            LoadRecordData();
        }

        private void LoadRecordData()
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

                // Obtener los datos del registro
                string query = $"SELECT * FROM {dataBaseName}.{tableName} WHERE {primaryKeyColumn} = '{primaryKeyValue}'";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                MySqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
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
                            Text = reader[column.ColumnName].ToString(),
                            Location = new System.Drawing.Point(150, y),
                            Width = 200
                        };
                        this.Controls.Add(label);
                        this.Controls.Add(textBox);
                        y += 30;
                    }
                }

                reader.Close();
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

                // Construir la consulta de actualización
                string setClause = string.Join(", ", tableSchema.Columns.Cast<DataColumn>().Select(column => $"{column.ColumnName} = '{this.Controls["txt" + column.ColumnName].Text}'"));
                string query = $"UPDATE {dataBaseName}.{tableName} SET {setClause} WHERE {primaryKeyColumn} = '{primaryKeyValue}'";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.ExecuteNonQuery();

                MessageBox.Show("Registro actualizado correctamente.");
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
