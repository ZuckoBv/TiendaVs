namespace Tienda
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbCategoria = new ComboBox();
            dgvProductos = new DataGridView();
            IdProducto = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Descripcion = new DataGridViewTextBoxColumn();
            Categoria = new DataGridViewTextBoxColumn();
            Precio = new DataGridViewTextBoxColumn();
            btnAgregarProducto = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            fileSystemWatcher1 = new FileSystemWatcher();
            btnFiltrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // cmbCategoria
            // 
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Items.AddRange(new object[] { "Electronico", "Ropa", "Libreria", "Accesorios", "Muebles" });
            cmbCategoria.Location = new Point(575, 21);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(121, 23);
            cmbCategoria.TabIndex = 1;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { IdProducto, Nombre, Descripcion, Categoria, Precio });
            dgvProductos.Location = new Point(12, 21);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(542, 150);
            dgvProductos.TabIndex = 3;
            // 
            // IdProducto
            // 
            IdProducto.HeaderText = "Id Producto";
            IdProducto.Name = "IdProducto";
            IdProducto.ReadOnly = true;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            // 
            // Descripcion
            // 
            Descripcion.HeaderText = "Descripcion";
            Descripcion.Name = "Descripcion";
            Descripcion.ReadOnly = true;
            // 
            // Categoria
            // 
            Categoria.HeaderText = "Categoria";
            Categoria.Name = "Categoria";
            Categoria.ReadOnly = true;
            // 
            // Precio
            // 
            Precio.HeaderText = "Precio";
            Precio.Name = "Precio";
            Precio.ReadOnly = true;
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.Location = new Point(677, 333);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(94, 41);
            btnAgregarProducto.TabIndex = 4;
            btnAgregarProducto.Text = "Agregar producto";
            btnAgregarProducto.UseVisualStyleBackColor = true;
            btnAgregarProducto.Click += button1_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(179, 177);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(94, 46);
            btnModificar.TabIndex = 5;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(332, 177);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(98, 46);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(603, 50);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(71, 24);
            btnFiltrar.TabIndex = 7;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(144, 144, 255);
            ClientSize = new Size(800, 450);
            Controls.Add(btnFiltrar);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregarProducto);
            Controls.Add(dgvProductos);
            Controls.Add(cmbCategoria);
            Name = "frmMain";
            Text = "Tienda";
            Activated += frmMain_Activated;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbCategoria;
        private DataGridView dgvProductos;
        private Button btnAgregarProducto;
        private Button btnModificar;
        private Button btnEliminar;
        private FileSystemWatcher fileSystemWatcher1;
        private DataGridViewTextBoxColumn IdProducto;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Descripcion;
        private DataGridViewTextBoxColumn Categoria;
        private DataGridViewTextBoxColumn Precio;
        private Button btnFiltrar;
    }
}
