namespace Control_Gym.Capa_de_presentacion
{
    partial class FormProductos
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
            this.lblCodProducto = new System.Windows.Forms.Label();
            this.lblCodProveedor = new System.Windows.Forms.Label();
            this.lblCodTipoProducto = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.cmbTipoProducto = new System.Windows.Forms.ComboBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCodProducto = new System.Windows.Forms.TextBox();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.dtpFechaVenc = new System.Windows.Forms.DateTimePicker();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblFechaVencimiento = new System.Windows.Forms.Label();
            this.txtGanancia = new System.Windows.Forms.TextBox();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.lblGanancia = new System.Windows.Forms.Label();
            this.lblCosto = new System.Windows.Forms.Label();
            this.lblPrecioVenta = new System.Windows.Forms.Label();
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblCodigoProducto = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCodProducto
            // 
            this.lblCodProducto.AutoSize = true;
            this.lblCodProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodProducto.Location = new System.Drawing.Point(175, 33);
            this.lblCodProducto.Name = "lblCodProducto";
            this.lblCodProducto.Size = new System.Drawing.Size(104, 16);
            this.lblCodProducto.TabIndex = 0;
            this.lblCodProducto.Text = "Cod producto:";
            this.lblCodProducto.Visible = false;
            // 
            // lblCodProveedor
            // 
            this.lblCodProveedor.AutoSize = true;
            this.lblCodProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodProveedor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCodProveedor.Location = new System.Drawing.Point(49, 15);
            this.lblCodProveedor.Name = "lblCodProveedor";
            this.lblCodProveedor.Size = new System.Drawing.Size(88, 16);
            this.lblCodProveedor.TabIndex = 1;
            this.lblCodProveedor.Text = "Proveedor :";
            // 
            // lblCodTipoProducto
            // 
            this.lblCodTipoProducto.AutoSize = true;
            this.lblCodTipoProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodTipoProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCodTipoProducto.Location = new System.Drawing.Point(3, 41);
            this.lblCodTipoProducto.Name = "lblCodTipoProducto";
            this.lblCodTipoProducto.Size = new System.Drawing.Size(134, 16);
            this.lblCodTipoProducto.TabIndex = 2;
            this.lblCodTipoProducto.Text = "Tipo de producto :";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNombre.Location = new System.Drawing.Point(67, 67);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(70, 16);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre :";
            // 
            // cmbTipoProducto
            // 
            this.cmbTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTipoProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmbTipoProducto.FormattingEnabled = true;
            this.cmbTipoProducto.Location = new System.Drawing.Point(143, 36);
            this.cmbTipoProducto.Name = "cmbTipoProducto";
            this.cmbTipoProducto.Size = new System.Drawing.Size(156, 24);
            this.cmbTipoProducto.TabIndex = 1;
            this.cmbTipoProducto.SelectedIndexChanged += new System.EventHandler(this.cmbTipoProducto_SelectedIndexChanged);
            this.cmbTipoProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbTipoProducto_KeyDown);
            this.cmbTipoProducto.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbTipoProducto_MouseDown);
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNombre.Location = new System.Drawing.Point(143, 65);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(156, 22);
            this.txtNombre.TabIndex = 2;
            this.txtNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombre_KeyDown);
            this.txtNombre.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtNombre_MouseDown);
            // 
            // txtCodProducto
            // 
            this.txtCodProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodProducto.Location = new System.Drawing.Point(312, 30);
            this.txtCodProducto.Name = "txtCodProducto";
            this.txtCodProducto.Size = new System.Drawing.Size(156, 22);
            this.txtCodProducto.TabIndex = 0;
            this.txtCodProducto.Visible = false;
            this.txtCodProducto.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.txtCodProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodProducto_KeyDown);
            this.txtCodProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodProducto_KeyPress);
            this.txtCodProducto.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtCodProducto_MouseDown);
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProveedor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(143, 7);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(156, 24);
            this.cmbProveedor.TabIndex = 0;
            this.cmbProveedor.SelectedIndexChanged += new System.EventHandler(this.cmbProveedor_SelectedIndexChanged);
            this.cmbProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbProveedor_KeyDown);
            this.cmbProveedor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbProveedor_MouseDown);
            // 
            // dtpFechaVenc
            // 
            this.dtpFechaVenc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaVenc.Location = new System.Drawing.Point(504, 90);
            this.dtpFechaVenc.Name = "dtpFechaVenc";
            this.dtpFechaVenc.Size = new System.Drawing.Size(156, 22);
            this.dtpFechaVenc.TabIndex = 6;
            // 
            // txtCod
            // 
            this.txtCod.Location = new System.Drawing.Point(831, 18);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(97, 21);
            this.txtCod.TabIndex = 25;
            this.txtCod.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(832, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 15);
            this.label1.TabIndex = 24;
            this.label1.Text = "Producto solicitante: ";
            this.label1.Visible = false;
            // 
            // txtStock
            // 
            this.txtStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtStock.Location = new System.Drawing.Point(143, 92);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(156, 22);
            this.txtStock.TabIndex = 3;
            this.txtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtStock.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStock_KeyDown);
            this.txtStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStock_KeyPress);
            this.txtStock.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtStock_MouseDown);
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStock.Location = new System.Drawing.Point(83, 93);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(54, 16);
            this.lblStock.TabIndex = 22;
            this.lblStock.Text = "Stock :";
            // 
            // lblFechaVencimiento
            // 
            this.lblFechaVencimiento.AutoSize = true;
            this.lblFechaVencimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaVencimiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFechaVencimiento.Location = new System.Drawing.Point(331, 96);
            this.lblFechaVencimiento.Name = "lblFechaVencimiento";
            this.lblFechaVencimiento.Size = new System.Drawing.Size(167, 16);
            this.lblFechaVencimiento.TabIndex = 20;
            this.lblFechaVencimiento.Text = "Fecha de vencimiento :";
            // 
            // txtGanancia
            // 
            this.txtGanancia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGanancia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtGanancia.Location = new System.Drawing.Point(504, 64);
            this.txtGanancia.Name = "txtGanancia";
            this.txtGanancia.ReadOnly = true;
            this.txtGanancia.Size = new System.Drawing.Size(156, 22);
            this.txtGanancia.TabIndex = 19;
            this.txtGanancia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCosto
            // 
            this.txtCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCosto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCosto.Location = new System.Drawing.Point(504, 38);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(156, 22);
            this.txtCosto.TabIndex = 5;
            this.txtCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCosto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCosto_KeyDown);
            this.txtCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCosto_KeyPress);
            this.txtCosto.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtCosto_MouseDown);
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPrecioVenta.Location = new System.Drawing.Point(504, 12);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(156, 22);
            this.txtPrecioVenta.TabIndex = 4;
            this.txtPrecioVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPrecioVenta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrecioVenta_KeyDown);
            this.txtPrecioVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioVenta_KeyPress);
            this.txtPrecioVenta.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtPrecioVenta_MouseDown);
            // 
            // lblGanancia
            // 
            this.lblGanancia.AutoSize = true;
            this.lblGanancia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGanancia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGanancia.Location = new System.Drawing.Point(417, 69);
            this.lblGanancia.Name = "lblGanancia";
            this.lblGanancia.Size = new System.Drawing.Size(81, 16);
            this.lblGanancia.TabIndex = 16;
            this.lblGanancia.Text = "Ganancia :";
            // 
            // lblCosto
            // 
            this.lblCosto.AutoSize = true;
            this.lblCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCosto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCosto.Location = new System.Drawing.Point(443, 42);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(55, 16);
            this.lblCosto.TabIndex = 15;
            this.lblCosto.Text = "Costo :";
            // 
            // lblPrecioVenta
            // 
            this.lblPrecioVenta.AutoSize = true;
            this.lblPrecioVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPrecioVenta.Location = new System.Drawing.Point(374, 15);
            this.lblPrecioVenta.Name = "lblPrecioVenta";
            this.lblPrecioVenta.Size = new System.Drawing.Size(124, 16);
            this.lblPrecioVenta.TabIndex = 14;
            this.lblPrecioVenta.Text = "Precio de venta :";
            // 
            // btnCrear
            // 
            this.btnCrear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCrear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCrear.Location = new System.Drawing.Point(685, 34);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(75, 30);
            this.btnCrear.TabIndex = 7;
            this.btnCrear.Text = "Agregar";
            this.btnCrear.UseVisualStyleBackColor = false;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.IndianRed;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEliminar.Location = new System.Drawing.Point(766, 34);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 30);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnModificar.Location = new System.Drawing.Point(685, 34);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 30);
            this.btnModificar.TabIndex = 10;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(6, 18);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.Size = new System.Drawing.Size(960, 268);
            this.dgvProductos.TabIndex = 19;
            this.dgvProductos.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvProductos_RowHeaderMouseClick);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(11, 37);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(146, 21);
            this.txtBuscar.TabIndex = 20;
            this.txtBuscar.Visible = false;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // lblCodigoProducto
            // 
            this.lblCodigoProducto.AutoSize = true;
            this.lblCodigoProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoProducto.Location = new System.Drawing.Point(9, 18);
            this.lblCodigoProducto.Name = "lblCodigoProducto";
            this.lblCodigoProducto.Size = new System.Drawing.Size(148, 16);
            this.lblCodigoProducto.TabIndex = 21;
            this.lblCodigoProducto.Text = "Codigo de producto:";
            this.lblCodigoProducto.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Gray;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelar.Location = new System.Drawing.Point(685, 64);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 30);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCod);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblCodigoProducto);
            this.groupBox1.Controls.Add(this.txtBuscar);
            this.groupBox1.Controls.Add(this.dgvProductos);
            this.groupBox1.Controls.Add(this.lblCodProducto);
            this.groupBox1.Controls.Add(this.txtCodProducto);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1028, 296);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            // 
            // FormProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(974, 448);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.dtpFechaVenc);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.cmbProveedor);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.lblFechaVencimiento);
            this.Controls.Add(this.cmbTipoProducto);
            this.Controls.Add(this.txtGanancia);
            this.Controls.Add(this.lblGanancia);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.txtPrecioVenta);
            this.Controls.Add(this.lblCosto);
            this.Controls.Add(this.lblPrecioVenta);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblCodTipoProducto);
            this.Controls.Add(this.lblCodProveedor);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.btnModificar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormProductos";
            this.Text = "FormProductos";
            this.Load += new System.EventHandler(this.FormProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCodProducto;
        private System.Windows.Forms.Label lblCodProveedor;
        private System.Windows.Forms.Label lblCodTipoProducto;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.ComboBox cmbTipoProducto;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCodProducto;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblCodigoProducto;
        private System.Windows.Forms.Label lblGanancia;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.Label lblPrecioVenta;
        private System.Windows.Forms.TextBox txtGanancia;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.Label lblFechaVencimiento;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaVenc;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}