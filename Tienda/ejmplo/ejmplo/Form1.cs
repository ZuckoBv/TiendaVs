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
        public List<Producto> listaProductos;
        public frmMain()
        {
            InitializeComponent();
            frmAgregarProd = new frmAgregarProducto(this);
        }

        public void ActualizarLista()
        {
            listaProductos = Producto.ObtenerTodosLosProductos();
            refrescarDataGrid();
        }

        public void refrescarDataGrid() 
        {
            dgvProductos.Rows.Clear();
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
            ActualizarLista();
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idProducto = (int)dgvProductos.SelectedRows[0].Cells[0].Value;
            Producto.EliminarProducto(idProducto);
            ActualizarLista();
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {

        }
        
    }
}
