namespace Control_Gym.Capa_de_presentacion
{
    partial class FormVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVentas));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnVerificar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtDniEmpleado = new System.Windows.Forms.TextBox();
            this.txtDniCliente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.lblNoEncontrado = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAgregarCarrito = new System.Windows.Forms.Button();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbCodProducto = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.txtCodProducto = new System.Windows.Forms.TextBox();
            this.dvgCarrito = new System.Windows.Forms.DataGridView();
            this.cod_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stock_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotal_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnVenta = new System.Windows.Forms.Button();
            this.lblTotalAPagar = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgCarrito)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnVerificar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.txtDniEmpleado);
            this.groupBox1.Controls.Add(this.txtDniCliente);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(37, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 220);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos para la venta";
            // 
            // btnVerificar
            // 
            this.btnVerificar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnVerificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerificar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVerificar.Location = new System.Drawing.Point(263, 41);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(79, 42);
            this.btnVerificar.TabIndex = 1;
            this.btnVerificar.Text = "Verificar si existe";
            this.btnVerificar.UseVisualStyleBackColor = false;
            this.btnVerificar.Visible = false;
            this.btnVerificar.Click += new System.EventHandler(this.btnVerificar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fecha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "DNI Empleado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "DNI Cliente";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Location = new System.Drawing.Point(120, 130);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(205, 22);
            this.dtpFecha.TabIndex = 2;
            // 
            // txtDniEmpleado
            // 
            this.txtDniEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDniEmpleado.Location = new System.Drawing.Point(120, 92);
            this.txtDniEmpleado.Name = "txtDniEmpleado";
            this.txtDniEmpleado.Size = new System.Drawing.Size(128, 22);
            this.txtDniEmpleado.TabIndex = 1;
            this.txtDniEmpleado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDniEmpleado_KeyDown);
            this.txtDniEmpleado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDniEmpleado_KeyPress);
            this.txtDniEmpleado.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtDniEmpleado_MouseDown);
            // 
            // txtDniCliente
            // 
            this.txtDniCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDniCliente.Location = new System.Drawing.Point(120, 53);
            this.txtDniCliente.Name = "txtDniCliente";
            this.txtDniCliente.Size = new System.Drawing.Size(128, 22);
            this.txtDniCliente.TabIndex = 0;
            this.txtDniCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDniCliente_KeyDown);
            this.txtDniCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDniCliente_KeyPress);
            this.txtDniCliente.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtDniCliente_MouseDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(170, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Descuento ";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Location = new System.Drawing.Point(110, 172);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(54, 22);
            this.txtDescuento.TabIndex = 6;
            this.txtDescuento.Text = "0";
            this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDescuento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescuento_KeyDown);
            this.txtDescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescuento_KeyPress);
            this.txtDescuento.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtDescuento_MouseDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.cbCategoria);
            this.groupBox2.Controls.Add(this.lblNoEncontrado);
            this.groupBox2.Controls.Add(this.txtStock);
            this.groupBox2.Controls.Add(this.lblStock);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtSubtotal);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtCantidad);
            this.groupBox2.Controls.Add(this.txtNombreProducto);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtDescuento);
            this.groupBox2.Controls.Add(this.txtPrecio);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cbCodProducto);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtCodProducto);
            this.groupBox2.Controls.Add(this.btnAgregarCarrito);
            this.groupBox2.Controls.Add(this.btnQuitar);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(434, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(499, 220);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Agregar al carrito";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(227, 45);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 16);
            this.label13.TabIndex = 63;
            this.label13.Text = "Producto";
            // 
            // cbCategoria
            // 
            this.cbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(100, 42);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(121, 24);
            this.cbCategoria.TabIndex = 3;
            this.cbCategoria.SelectedIndexChanged += new System.EventHandler(this.cbCategoria_SelectedIndexChanged);
            // 
            // lblNoEncontrado
            // 
            this.lblNoEncontrado.AutoSize = true;
            this.lblNoEncontrado.ForeColor = System.Drawing.Color.Red;
            this.lblNoEncontrado.Location = new System.Drawing.Point(171, 0);
            this.lblNoEncontrado.Name = "lblNoEncontrado";
            this.lblNoEncontrado.Size = new System.Drawing.Size(172, 16);
            this.lblNoEncontrado.TabIndex = 23;
            this.lblNoEncontrado.Text = "Producto no encontrado";
            this.lblNoEncontrado.Visible = false;
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(346, 76);
            this.txtStock.Name = "txtStock";
            this.txtStock.ReadOnly = true;
            this.txtStock.Size = new System.Drawing.Size(88, 22);
            this.txtStock.TabIndex = 12;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(294, 79);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(46, 16);
            this.lblStock.TabIndex = 21;
            this.lblStock.Text = "Stock";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 142);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 16);
            this.label11.TabIndex = 19;
            this.label11.Text = "Cantidad";
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Location = new System.Drawing.Point(347, 110);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(88, 22);
            this.txtSubtotal.TabIndex = 13;
            this.txtSubtotal.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(284, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 12;
            this.label9.Text = "Subtotal";
            this.label9.Visible = false;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(100, 139);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(95, 22);
            this.txtCantidad.TabIndex = 5;
            this.txtCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCantidad_KeyDown);
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            this.txtCantidad.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtCantidad_MouseDown);
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Location = new System.Drawing.Point(100, 77);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.ReadOnly = true;
            this.txtNombreProducto.Size = new System.Drawing.Size(172, 22);
            this.txtNombreProducto.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 16);
            this.label10.TabIndex = 16;
            this.label10.Text = "Producto";
            // 
            // btnAgregarCarrito
            // 
            this.btnAgregarCarrito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAgregarCarrito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarCarrito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCarrito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarCarrito.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAgregarCarrito.Location = new System.Drawing.Point(312, 147);
            this.btnAgregarCarrito.Name = "btnAgregarCarrito";
            this.btnAgregarCarrito.Size = new System.Drawing.Size(105, 47);
            this.btnAgregarCarrito.TabIndex = 7;
            this.btnAgregarCarrito.Text = "Agregar al carrito";
            this.btnAgregarCarrito.UseVisualStyleBackColor = false;
            this.btnAgregarCarrito.Click += new System.EventHandler(this.btnAgregarCarrito_Click);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(100, 107);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(95, 22);
            this.txtPrecio.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "Precio";
            // 
            // cbCodProducto
            // 
            this.cbCodProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCodProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCodProducto.FormattingEnabled = true;
            this.cbCodProducto.ItemHeight = 16;
            this.cbCodProducto.Location = new System.Drawing.Point(302, 40);
            this.cbCodProducto.Name = "cbCodProducto";
            this.cbCodProducto.Size = new System.Drawing.Size(178, 24);
            this.cbCodProducto.TabIndex = 4;
            this.cbCodProducto.SelectedIndexChanged += new System.EventHandler(this.cbCodProducto_SelectedIndexChanged);
            this.cbCodProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbCodProducto_KeyDown);
            this.cbCodProducto.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cbCodProducto_MouseDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Categoría";
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackColor = System.Drawing.Color.IndianRed;
            this.btnQuitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnQuitar.Location = new System.Drawing.Point(312, 147);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(105, 47);
            this.btnQuitar.TabIndex = 8;
            this.btnQuitar.Text = "Quitar del carrito";
            this.btnQuitar.UseVisualStyleBackColor = false;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // txtCodProducto
            // 
            this.txtCodProducto.Location = new System.Drawing.Point(362, 0);
            this.txtCodProducto.Name = "txtCodProducto";
            this.txtCodProducto.Size = new System.Drawing.Size(118, 22);
            this.txtCodProducto.TabIndex = 3;
            this.txtCodProducto.Visible = false;
            this.txtCodProducto.TextChanged += new System.EventHandler(this.txtCodProducto_TextChanged);
            this.txtCodProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodProducto_KeyDown);
            this.txtCodProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodProducto_KeyPress);
            this.txtCodProducto.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtCodProducto_MouseDown);
            // 
            // dvgCarrito
            // 
            this.dvgCarrito.AllowUserToAddRows = false;
            this.dvgCarrito.AllowUserToDeleteRows = false;
            this.dvgCarrito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgCarrito.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod_producto,
            this.nombre_producto,
            this.precio_producto,
            this.cantidad,
            this.stock_producto,
            this.descuento,
            this.subtotal_producto});
            this.dvgCarrito.Location = new System.Drawing.Point(25, 267);
            this.dvgCarrito.Name = "dvgCarrito";
            this.dvgCarrito.ReadOnly = true;
            this.dvgCarrito.Size = new System.Drawing.Size(691, 326);
            this.dvgCarrito.TabIndex = 60;
            this.dvgCarrito.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dvgCarrito_RowHeaderMouseClick);
            // 
            // cod_producto
            // 
            this.cod_producto.HeaderText = "COD PRODUCTO";
            this.cod_producto.Name = "cod_producto";
            this.cod_producto.ReadOnly = true;
            // 
            // nombre_producto
            // 
            this.nombre_producto.HeaderText = "NOMBRE";
            this.nombre_producto.Name = "nombre_producto";
            this.nombre_producto.ReadOnly = true;
            // 
            // precio_producto
            // 
            this.precio_producto.HeaderText = "PRECIO U.";
            this.precio_producto.Name = "precio_producto";
            this.precio_producto.ReadOnly = true;
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "CANTIDAD";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            // 
            // stock_producto
            // 
            this.stock_producto.HeaderText = "STOCK";
            this.stock_producto.Name = "stock_producto";
            this.stock_producto.ReadOnly = true;
            // 
            // descuento
            // 
            this.descuento.HeaderText = "DESCUENTO";
            this.descuento.Name = "descuento";
            this.descuento.ReadOnly = true;
            // 
            // subtotal_producto
            // 
            this.subtotal_producto.HeaderText = "SUBTOTAL";
            this.subtotal_producto.Name = "subtotal_producto";
            this.subtotal_producto.ReadOnly = true;
            // 
            // btnVenta
            // 
            this.btnVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVenta.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVenta.Image = ((System.Drawing.Image)(resources.GetObject("btnVenta.Image")));
            this.btnVenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVenta.Location = new System.Drawing.Point(805, 409);
            this.btnVenta.Name = "btnVenta";
            this.btnVenta.Size = new System.Drawing.Size(152, 68);
            this.btnVenta.TabIndex = 9;
            this.btnVenta.Text = "Realizar venta";
            this.btnVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVenta.UseVisualStyleBackColor = false;
            this.btnVenta.Click += new System.EventHandler(this.btnVenta_Click);
            // 
            // lblTotalAPagar
            // 
            this.lblTotalAPagar.AutoSize = true;
            this.lblTotalAPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAPagar.Location = new System.Drawing.Point(741, 297);
            this.lblTotalAPagar.Name = "lblTotalAPagar";
            this.lblTotalAPagar.Size = new System.Drawing.Size(297, 37);
            this.lblTotalAPagar.TabIndex = 19;
            this.lblTotalAPagar.Text = "TOTAL A PAGAR:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(833, 356);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(113, 37);
            this.lblTotal.TabIndex = 20;
            this.lblTotal.Text = "$ 0.00";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.ForestGreen;
            this.label12.Location = new System.Drawing.Point(827, 356);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 37);
            this.label12.TabIndex = 61;
            this.label12.Text = "$";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(33, 244);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 20);
            this.label7.TabIndex = 62;
            this.label7.Text = "CARRITO";
            // 
            // FormVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1050, 605);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblTotalAPagar);
            this.Controls.Add(this.btnVenta);
            this.Controls.Add(this.dvgCarrito);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormVentas";
            this.Text = "FormVentas";
            this.Load += new System.EventHandler(this.FormVentas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgCarrito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.TextBox txtDniEmpleado;
        private System.Windows.Forms.TextBox txtDniCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbCodProducto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCodProducto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.DataGridView dvgCarrito;
        private System.Windows.Forms.Button btnAgregarCarrito;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnVenta;
        private System.Windows.Forms.Button btnVerificar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblTotalAPagar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblNoEncontrado;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio_producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn stock_producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotal_producto;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbCategoria;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
    }
}