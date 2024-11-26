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
        private int pageSize = 100; // Número de registros por página

        public Form2(string cadenaConexion)
        {
            InitializeComponent();
            this.cadenaConexion = cadenaConexion;
            ConfigureListView();
            LoadDatabases();
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
            }
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            currentPage++;
            LoadTableData($"SELECT * FROM {CmbTablas.SelectedItem.ToString()} LIMIT {pageSize} OFFSET {(currentPage - 1) * pageSize}");
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            CmbTablas.SelectedIndexChanged += new EventHandler(CmbTablas_SelectedIndexChanged);
            CmbDataBases.SelectedIndexChanged += new EventHandler(CmbDataBases_SelectedIndexChanged);
            BtnAnterior.Click += new EventHandler(BtnAnterior_Click);
            BtnSiguiente.Click += new EventHandler(BtnSiguiente_Click);
            BtnBuscar.Click += new EventHandler(BtnBuscar_Click);
            BtnCerrasSesion.Click += new EventHandler(BtnCerrarSesion_Click);
        }

        private void TxtQuerys_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnAnterior_Click_1(object sender, EventArgs e)
        {

        }
    }
}
