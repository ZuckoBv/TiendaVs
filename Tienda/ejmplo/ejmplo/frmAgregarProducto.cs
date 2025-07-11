﻿using System;
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
    public partial class frmAgregarProducto : Form
    {
        frmMain formularioPadre;
        Producto productoAModificar;
        public frmAgregarProducto(frmMain formPadre)
        {
            formularioPadre = formPadre;
            InitializeComponent();
        }

        private void grpDatos_Enter(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
			lblNombre.Text = " ";
			lblDescripcion.Text = " ";
			lblPrecio.Text = " ";
			ResetearForm();
			formularioPadre.Show();
            this.Hide();
        }
        private void frmAgregarProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cancela el cerrado del programa, oculta el form agregar producto y muestra el frmMain
            e.Cancel = true;
            this.Hide();
            formularioPadre.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto productoNuevo;
            Categoria catProducto;
                
            switch (cmbCategoria.Text)
            {
                case "Electronico":
                    catProducto = Categoria.Electronico;
                    break;
                case "Ropa":
                    catProducto = Categoria.Ropa;
                    break;
                case "Libreria":
                    catProducto = Categoria.Libreria;
                    break;
                case "Accesorios":
                    catProducto = Categoria.Accesorios;
                    break;
                case "Muebles":
                    catProducto = Categoria.Muebles;
                    break;
                default:
                    catProducto = Categoria.Ropa;
                    break;
            }

            // Crear producto
            productoNuevo = new Producto(
                nombr: txtNombre.Text,
                descr: txtDescripcion.Text,
                prec: float.Parse(txtPrecio.Text),
                cat: catProducto
            );
            productoNuevo.AgregarABaseDeDatos();
            formularioPadre.ActualizarLista();
            ResetearForm();
            this.Hide();
            formularioPadre.Show();
        }
        private void ResetearForm()
        {
            btnModificar.Visible = false;
			btnAgregar.Visible = true;
			cmbCategoria.Visible = true;
			lblCategoria.Visible = true;
			txtNombre.Clear();
			txtDescripcion.Clear();
			txtPrecio.Clear();
		}
	public void MostrarModificar(Producto pro)
        {
            productoAModificar = pro;
            txtNombre.Text = productoAModificar.Nombre;
			txtDescripcion.Text = productoAModificar.Descripcion;
			txtPrecio.Text = productoAModificar.Precio.ToString();
			cmbCategoria.Text = productoAModificar.Tipo;
			txtNombre.Text = productoAModificar.Nombre;
			this.Show();
			cmbCategoria.Visible = false;
			lblCategoria.Visible = false;
			btnModificar.Visible = true;
            btnAgregar.Visible = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
			productoAModificar.Nombre = txtNombre.Text;
			productoAModificar.Descripcion = txtDescripcion.Text;
			productoAModificar.Precio = float.Parse(txtPrecio.Text);
            Producto.ModificarProducto(productoAModificar);
            ResetearForm();
			formularioPadre.ActualizarLista();
			this.Hide();
			formularioPadre.Show();
		}
    }
}
