using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tienda
{
    public partial class frmMain : Form
    {
        frmAgregarProducto frmAgregarProd;
        public List<Producto> listaProducto = new List<Producto>();
        public frmMain()
        {
            InitializeComponent();
            frmAgregarProd = new frmAgregarProducto(this);
        }
        public void refrescarDataGrid()
        {
            // Los primeros dos ifs son cortafuegos para que no haya inconvenientes en el código siguiente

            // Si la lista de personas no guarda nada sigue con la funcion
            if (listaProducto == null)
            {
                return;
            }
            // Si la lista de personas guarda valores menores a 0 sigue con el código
            if (listaProducto.Count <= 0)
            {
                return;
            }
            // Limpia si había algo previamente en el data grid view
            dgvProductos.Rows.Clear();
            // Recorre la lista de personas y le pasa por parametro los valores que requiere el dgv
            foreach (Producto p in listaProducto)
            {
                dgvProductos.Rows.Add(p.Nombre, p.Descripcion, p.Tipo, p.Precio);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frmAgregarProd.Show();
            this.Hide();
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            refrescarDataGrid();
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
