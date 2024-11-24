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
        private MySqlConnection conexion;
        private string database;
        private int currentPage = 1;
        private int pageSize = 100; // Número de registros por página

        public Form2(MySqlConnection conexion, string database)
        {
            InitializeComponent();
            this.conexion = conexion;
            this.database = database;
            ConfigureListView();
            LoadTables();
        }

        public Form2()
        {
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

        private void LoadTables()
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                String consulta = "SHOW TABLES";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    CmbTablas.Items.Add(reader.GetString(0));
                }

                reader.Close(); // Cerrar el DataReader después de cargar las tablas
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

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbTablas.SelectedItem != null)
            {
                currentPage = 1; // Reiniciar a la primera página al cambiar de tabla
                LoadTableData(CmbTablas.SelectedItem.ToString(), currentPage, pageSize);
            }
        }

        private void LoadTableData(string tableName, int page, int pageSize)
        {
            try
            {
                conexion.Open();
                int offset = (page - 1) * pageSize;
                String consulta = $"SELECT * FROM {tableName} LIMIT {pageSize} OFFSET {offset}";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
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
                conexion.Close();
            }
        }

        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadTableData(CmbTablas.SelectedItem.ToString(), currentPage, pageSize);
            }
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            currentPage++;
            LoadTableData(CmbTablas.SelectedItem.ToString(), currentPage, pageSize);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            CmbTablas.SelectedIndexChanged += new EventHandler(cmbTables_SelectedIndexChanged);
            BtnAnterior.Click += new EventHandler(BtnAnterior_Click);
            BtnSiguiente.Click += new EventHandler(BtnSiguiente_Click);
        }
    }
}

