using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
namespace Tienda
{
    public partial class frmMain : Form
    {
        frmAgregarProducto frmAgregarProd;
        public List<Producto> listaProductos = new List<Producto>();
        public frmMain()
        {
            InitializeComponent();
            frmAgregarProd = new frmAgregarProducto(this);
        }
        public void refrescarDataGrid() 
        {
            if (listaProductos == null)
            {
                return;
            }
            // Si la lista de personas guarda valores menores a 0 sigue con el código
            if (listaProductos.Count <= 0)
            {
                return;
            }
            // Limpia si había algo previamente en el data grid view
            dgvProductos.Rows.Clear();
            foreach (Producto p in listaProductos)
            {
                dgvProductos.Rows.Add(p.IdProducto,p.Nombre, p.Descripcion, p.Tipo, p.Precio);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            frmAgregarProd.Show();
            this.Hide();
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            Conexion con = new Conexion(this);
            con.lista();
            //string de conexion que indica el nombre de la base de datos
            string strConexion = "Data Source = tienda.db"; //direccion relativa 
            SqliteConnection conexion = new SqliteConnection(strConexion);
            //abre la conexion
            conexion.Open();
            SqliteCommand comando = new SqliteCommand("SELECT * FROM Productos", conexion);
            SqliteDataReader lector = comando.ExecuteReader();
            lector.Read();
            conexion.Close();
            lector.Close();
            refrescarDataGrid();
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            lblPrueba.Text = dgvProductos.SelectedRows[0].Cells[0].Value.ToString();
            Conexion con = new Conexion(this);
            con.lista();
            string strConexion = "Data Source = tienda.db"; //direccion relativa 
            SqliteConnection conexion = new SqliteConnection(strConexion);
            conexion.Open();
            SqliteCommand comando = new SqliteCommand("SELECT * FROM Productos", conexion);
            SqliteDataReader lector = comando.ExecuteReader();
            lector.Read();
            conexion.Close();
            lector.Close();
            refrescarDataGrid();
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {

        }
    }
}
