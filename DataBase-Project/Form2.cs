using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DataBase_Project
{
    public partial class Form2 : Form
    {
        private string cadenaConexion;
        private MySqlConnection conexion;
        private int currentPage = 1;
        private int pageSize = 50; // Número de registros por página
        private int totalRecords = 0;
        private Label lblPagination;

        public Form2(string cadenaConexion)
        {
            InitializeComponent();
            this.cadenaConexion = cadenaConexion;
            ConfigureListView();
            LoadDatabases();
            lblPagination = new Label();
            lblPagination.Location = new Point(10, 10); // Ajusta la ubicación según sea necesario
            lblPagination.Size = new Size(200, 20); // Ajusta el tamaño según sea necesario
            this.Controls.Add(lblPagination);
            UpdatePaginationLabel(); // Actualizar la etiqueta de paginación
        }

        private void ConfigureListView()
        {
            LvBD.View = View.Details;
            LvBD.FullRowSelect = true;
            LvBD.GridLines = true;
            LvBD.MultiSelect = false;
            LvBD.HideSelection = false;
            LvBD.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            LvBD.Font = new Font("Arial", 10, FontStyle.Regular);
            LvBD.ForeColor = Color.Black;
            LvBD.BackColor = Color.White;
            LvBD.OwnerDraw = true;
            LvBD.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(LvBD_DrawColumnHeader);
            LvBD.DrawItem += new DrawListViewItemEventHandler(LvBD_DrawItem);
            LvBD.DrawSubItem += new DrawListViewSubItemEventHandler(LvBD_DrawSubItem);
            LvBD.SelectedIndexChanged += new EventHandler(LvBD_SelectedIndexChanged);
        }

        private void LvBD_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
            e.Graphics.DrawRectangle(Pens.Black, e.Bounds);
            e.Graphics.DrawString(e.Header.Text, e.Font, Brushes.Black, e.Bounds);
        }

        private void LvBD_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void LvBD_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ItemIndex % 2 == 0)
            {
                e.Graphics.FillRectangle(Brushes.LightBlue, e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            }
            e.Graphics.DrawString(e.SubItem.Text, e.SubItem.Font, Brushes.Black, e.Bounds);
        }

        private void LvBD_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isItemSelected = LvBD.SelectedItems.Count > 0;
            BtnModificar.Enabled = isItemSelected;
            BtnEliminar.Enabled = isItemSelected;
        }

        private void LoadDatabases()
        {
            try
            {
                if (conexion == null)
                {
                    conexion = new MySqlConnection(cadenaConexion);
                }

                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                String consulta = "SHOW DATABASES";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    CmbDataBases.Items.Add(reader.GetString(0));
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
        }

        private void CmbDataBases_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbDataBases.SelectedItem != null)
            {
                string selectedDatabase = CmbDataBases.SelectedItem.ToString();
                string nuevaCadenaConexion = $"{cadenaConexion};Database={selectedDatabase};";
                conexion = new MySqlConnection(nuevaCadenaConexion);

                LoadTables(selectedDatabase);
                totalRecords = ObtenerNumeroDeRegistros(); // Actualizar el número total de registros
                currentPage = 1; // Reiniciar a la primera página
                UpdatePaginationLabel(); // Actualizar la etiqueta de paginación
            }
        }

        private void LoadTables(string selectedDatabase)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                String consulta = $"SHOW TABLES FROM {selectedDatabase}";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                MySqlDataReader reader = comando.ExecuteReader();

                CmbTablas.Items.Clear();

                while (reader.Read())
                {
                    CmbTablas.Items.Add(reader.GetString(0));
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
        }

        private void CmbTablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbTablas.SelectedItem != null)
            {
                currentPage = 1; // Reiniciar a la primera página al cambiar de tabla
                LoadTableData($"SELECT * FROM {CmbTablas.SelectedItem.ToString()} LIMIT {pageSize} OFFSET {(currentPage - 1) * pageSize}");
                totalRecords = ObtenerNumeroDeRegistros(); // Actualizar el número total de registros
                UpdatePaginationLabel(); // Actualizar la etiqueta de paginación
            }
        }

        private void LoadTableData(string query)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                MySqlCommand comando = new MySqlCommand(query, conexion);
                MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                LvBD.Clear();
                LvBD.View = View.Details;

                foreach (DataColumn column in dataTable.Columns)
                {
                    LvBD.Columns.Add(column.ColumnName);
                }

                foreach (DataRow row in dataTable.Rows)
                {
                    ListViewItem item = new ListViewItem(row.ItemArray.Select(x => x.ToString()).ToArray());
                    LvBD.Items.Add(item);
                }

                LvBD.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                LvBD.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
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

        private void ExecuteNonQuery(string query)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                MySqlCommand comando = new MySqlCommand(query, conexion);
                int affectedRows = comando.ExecuteNonQuery();
                MessageBox.Show($"Consulta ejecutada correctamente. Filas afectadas: {affectedRows}");
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

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string query = TxtQuerys.Text.Trim();
            if (string.IsNullOrEmpty(query))
            {
                MessageBox.Show("Por favor, ingrese una consulta.");
                return;
            }

            string upperQuery = query.ToUpper();
            if (upperQuery.StartsWith("SELECT"))
            {
                LoadTableData(query);
            }
            else if (upperQuery.StartsWith("INSERT") || upperQuery.StartsWith("UPDATE") || upperQuery.StartsWith("DELETE"))
            {
                ExecuteNonQuery(query);
            }
            else
            {
                MessageBox.Show("Solo se permiten consultas SELECT, INSERT, UPDATE y DELETE.");
            }
        }

        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadTableData($"SELECT * FROM {CmbTablas.SelectedItem.ToString()} LIMIT {pageSize} OFFSET {(currentPage - 1) * pageSize}");
                UpdatePaginationLabel(); // Actualizar la etiqueta de paginación
            }
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            // Obtener el número total de registros
            totalRecords = ObtenerNumeroDeRegistros();
            int maxPage = (int)Math.Ceiling((double)totalRecords / pageSize);

            if (currentPage < maxPage)
            {
                currentPage++;
                LoadTableData($"SELECT * FROM {CmbTablas.SelectedItem.ToString()} LIMIT {pageSize} OFFSET {(currentPage - 1) * pageSize}");
            }
            else
            {
                MessageBox.Show("Has alcanzado el límite de registros.");
            }
            UpdatePaginationLabel(); // Actualizar la etiqueta de paginación
        }

        private int ObtenerNumeroDeRegistros()
        {
            int totalRecords = 0;
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                if (CmbTablas.SelectedItem != null)
                {
                    String consulta = $"SELECT COUNT(*) FROM {CmbTablas.SelectedItem}";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    totalRecords = Convert.ToInt32(comando.ExecuteScalar());
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
            return totalRecords;
        }

        // Nueva función para actualizar la etiqueta de paginación
        private void UpdatePaginationLabel()
        {
            int maxPage = (int)Math.Ceiling((double)totalRecords / pageSize);
            lblPagination.Text = $"Página {currentPage} de {maxPage}";
        }

        // Actualizar el evento Form2_Load para incluir la configuración inicial del lblPagination
        private void Form2_Load(object sender, EventArgs e)
        {
            CmbTablas.SelectedIndexChanged += new EventHandler(CmbTablas_SelectedIndexChanged);
            CmbDataBases.SelectedIndexChanged += new EventHandler(CmbDataBases_SelectedIndexChanged);
            BtnAnterior.Click += new EventHandler(BtnAnterior_Click);
            BtnSiguiente.Click += new EventHandler(BtnSiguiente_Click);
            BtnBuscar.Click += new EventHandler(BtnBuscar_Click);
            BtnCerrasSesion.Click += new EventHandler(BtnCerrarSesion_Click);
            BtnModificar.Click += new EventHandler(BtnModificar_Click);
            BtnEliminar.Click += new EventHandler(BtnEliminar_Click);
            BtnAgregar.Click += new EventHandler(BtnAgregar_Click);

            // Configurar lblPagination inicialmente
            UpdatePaginationLabel();
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            conexion.Close();
            this.Close();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (LvBD.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = LvBD.SelectedItems[0];
                string tableName = CmbTablas.SelectedItem.ToString();
                string primaryKeyColumn = LvBD.Columns[0].Text;
                string primaryKeyValue = selectedItem.SubItems[0].Text;

                // Abrir el formulario de modificación
                FormModificar formModificar = new FormModificar(tableName, primaryKeyColumn, primaryKeyValue, CmbDataBases.SelectedItem.ToString(), this.cadenaConexion);
                formModificar.ShowDialog();
                LoadTableData($"SELECT * FROM {tableName} LIMIT {pageSize} OFFSET {(currentPage - 1) * pageSize}");
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (LvBD.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = LvBD.SelectedItems[0];
                string tableName = CmbTablas.SelectedItem.ToString();
                string primaryKeyColumn = LvBD.Columns[0].Text;
                string primaryKeyValue = selectedItem.SubItems[0].Text;

                string query = $"DELETE FROM {tableName} WHERE {primaryKeyColumn} = '{primaryKeyValue}'";
                ExecuteNonQuery(query);
                LoadTableData($"SELECT * FROM {tableName} LIMIT {pageSize} OFFSET {(currentPage - 1) * pageSize}");
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            string tableName = CmbTablas.SelectedItem.ToString();

            // Abrir el formulario de agregar
            FormAgregar formAgregar = new FormAgregar(tableName, CmbDataBases.SelectedItem.ToString(), this.cadenaConexion);
            formAgregar.ShowDialog();
            LoadTableData($"SELECT * FROM {tableName} LIMIT {pageSize} OFFSET {(currentPage - 1) * pageSize}");
        }
    }
}
