namespace Control_Gym.Capa_de_presentacion
{
    partial class FormSocio
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSocio));
            this.dgvSocios = new System.Windows.Forms.DataGridView();
            this.txtDniSocio = new System.Windows.Forms.TextBox();
            this.txtNombreSocio = new System.Windows.Forms.TextBox();
            this.txtApellidoSocio = new System.Windows.Forms.TextBox();
            this.txtTelefonoSocio = new System.Windows.Forms.TextBox();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.lblDomicilio = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtBuscarSocio = new System.Windows.Forms.TextBox();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.lblDni = new System.Windows.Forms.Label();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDni2Membresia = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocios)).BeginInit();
            this.panelContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSocios
            // 
            this.dgvSocios.AllowUserToAddRows = false;
            this.dgvSocios.AllowUserToDeleteRows = false;
            this.dgvSocios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSocios.Location = new System.Drawing.Point(325, 60);
            this.dgvSocios.Name = "dgvSocios";
            this.dgvSocios.ReadOnly = true;
            this.dgvSocios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSocios.Size = new System.Drawing.Size(724, 511);
            this.dgvSocios.TabIndex = 50;
            this.dgvSocios.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSocios_RowHeaderMouseClick);
            // 
            // txtDniSocio
            // 
            this.txtDniSocio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDniSocio.Location = new System.Drawing.Point(143, 72);
            this.txtDniSocio.Name = "txtDniSocio";
            this.txtDniSocio.Size = new System.Drawing.Size(176, 22);
            this.txtDniSocio.TabIndex = 0;
            this.txtDniSocio.Click += new System.EventHandler(this.txtDniSocio_Click);
            this.txtDniSocio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDniSocio_KeyDown);
            this.txtDniSocio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDniSocio_KeyPress);
            this.txtDniSocio.Leave += new System.EventHandler(this.txtDniSocio_Leave);
            this.txtDniSocio.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtDniSocio_MouseDown);
            // 
            // txtNombreSocio
            // 
            this.txtNombreSocio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreSocio.Location = new System.Drawing.Point(143, 108);
            this.txtNombreSocio.Name = "txtNombreSocio";
            this.txtNombreSocio.Size = new System.Drawing.Size(176, 22);
            this.txtNombreSocio.TabIndex = 1;
            this.txtNombreSocio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombreSocio_KeyDown);
            this.txtNombreSocio.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtNombreSocio_MouseDown);
            // 
            // txtApellidoSocio
            // 
            this.txtApellidoSocio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidoSocio.Location = new System.Drawing.Point(143, 148);
            this.txtApellidoSocio.Name = "txtApellidoSocio";
            this.txtApellidoSocio.Size = new System.Drawing.Size(176, 22);
            this.txtApellidoSocio.TabIndex = 2;
            this.txtApellidoSocio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtApellidoSocio_KeyDown);
            this.txtApellidoSocio.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtApellidoSocio_MouseDown);
            // 
            // txtTelefonoSocio
            // 
            this.txtTelefonoSocio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefonoSocio.Location = new System.Drawing.Point(143, 186);
            this.txtTelefonoSocio.Name = "txtTelefonoSocio";
            this.txtTelefonoSocio.Size = new System.Drawing.Size(176, 22);
            this.txtTelefonoSocio.TabIndex = 3;
            this.txtTelefonoSocio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTelefonoSocio_KeyDown);
            this.txtTelefonoSocio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefonoSocio_KeyPress);
            this.txtTelefonoSocio.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtTelefonoSocio_MouseDown);
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDomicilio.Location = new System.Drawing.Point(143, 266);
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(176, 22);
            this.txtDomicilio.TabIndex = 5;
            this.txtDomicilio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDomicilio_KeyDown);
            this.txtDomicilio.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtDomicilio_MouseDown);
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(143, 302);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(176, 22);
            this.txtEmail.TabIndex = 6;
            this.txtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmail_KeyDown);
            this.txtEmail.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtEmail_MouseDown);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(12, 111);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(82, 16);
            this.lblNombre.TabIndex = 9;
            this.lblNombre.Text = "NOMBRE *";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.Location = new System.Drawing.Point(12, 151);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(89, 16);
            this.lblApellido.TabIndex = 10;
            this.lblApellido.Text = "APELLIDO *";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.Location = new System.Drawing.Point(12, 189);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(87, 16);
            this.lblTelefono.TabIndex = 11;
            this.lblTelefono.Text = "TELEFONO";
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaNacimiento.Location = new System.Drawing.Point(12, 232);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(121, 16);
            this.lblFechaNacimiento.TabIndex = 12;
            this.lblFechaNacimiento.Text = "FECHA DE NAC.";
            // 
            // lblDomicilio
            // 
            this.lblDomicilio.AutoSize = true;
            this.lblDomicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDomicilio.Location = new System.Drawing.Point(12, 269);
            this.lblDomicilio.Name = "lblDomicilio";
            this.lblDomicilio.Size = new System.Drawing.Size(82, 16);
            this.lblDomicilio.TabIndex = 13;
            this.lblDomicilio.Text = "DOMICILIO";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(12, 305);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(56, 16);
            this.lblEmail.TabIndex = 14;
            this.lblEmail.Text = "E-MAIL";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGuardar.Location = new System.Drawing.Point(143, 341);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 30);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnModificar.Location = new System.Drawing.Point(143, 341);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 30);
            this.btnModificar.TabIndex = 10;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.BackColor = System.Drawing.Color.IndianRed;
            this.btnBorrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBorrar.Location = new System.Drawing.Point(244, 341);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 30);
            this.btnBorrar.TabIndex = 8;
            this.btnBorrar.Text = "Eliminar";
            this.btnBorrar.UseVisualStyleBackColor = false;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Gray;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelar.Location = new System.Drawing.Point(143, 377);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 30);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtBuscarSocio
            // 
            this.txtBuscarSocio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarSocio.Location = new System.Drawing.Point(382, 28);
            this.txtBuscarSocio.Multiline = true;
            this.txtBuscarSocio.Name = "txtBuscarSocio";
            this.txtBuscarSocio.Size = new System.Drawing.Size(189, 26);
            this.txtBuscarSocio.TabIndex = 21;
            this.txtBuscarSocio.TextChanged += new System.EventHandler(this.txtBuscarSocio_TextChanged);
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(143, 226);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(176, 22);
            this.dtpFechaNacimiento.TabIndex = 4;
            this.dtpFechaNacimiento.ValueChanged += new System.EventHandler(this.dtpFechaNacimiento_ValueChanged);
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDni.Location = new System.Drawing.Point(12, 75);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(43, 16);
            this.lblDni.TabIndex = 27;
            this.lblDni.Text = "DNI *";
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelContenedor.Controls.Add(this.label2);
            this.panelContenedor.Controls.Add(this.label1);
            this.panelContenedor.Controls.Add(this.btnCancelar);
            this.panelContenedor.Controls.Add(this.dtpFechaNacimiento);
            this.panelContenedor.Controls.Add(this.pictureBox1);
            this.panelContenedor.Controls.Add(this.lblDni2Membresia);
            this.panelContenedor.Controls.Add(this.btnBorrar);
            this.panelContenedor.Controls.Add(this.txtBuscarSocio);
            this.panelContenedor.Controls.Add(this.dgvSocios);
            this.panelContenedor.Controls.Add(this.btnGuardar);
            this.panelContenedor.Controls.Add(this.btnModificar);
            this.panelContenedor.Controls.Add(this.txtTelefonoSocio);
            this.panelContenedor.Controls.Add(this.txtEmail);
            this.panelContenedor.Controls.Add(this.txtDniSocio);
            this.panelContenedor.Controls.Add(this.txtDomicilio);
            this.panelContenedor.Controls.Add(this.txtNombreSocio);
            this.panelContenedor.Controls.Add(this.txtApellidoSocio);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 0);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(1050, 605);
            this.panelContenedor.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(127, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "ATENCIÓN!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "*El DNI no se podrá modificar mas adelente!";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(577, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // lblDni2Membresia
            // 
            this.lblDni2Membresia.AutoSize = true;
            this.lblDni2Membresia.Location = new System.Drawing.Point(379, 12);
            this.lblDni2Membresia.Name = "lblDni2Membresia";
            this.lblDni2Membresia.Size = new System.Drawing.Size(26, 13);
            this.lblDni2Membresia.TabIndex = 23;
            this.lblDni2Membresia.Text = "DNI";
            // 
            // FormSocio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1050, 605);
            this.ControlBox = false;
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblDomicilio);
            this.Controls.Add(this.lblFechaNacimiento);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.panelContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(536, 560);
            this.Name = "FormSocio";
            this.Text = "FormSocio";
            this.Load += new System.EventHandler(this.FormSocio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocios)).EndInit();
            this.panelContenedor.ResumeLayout(false);
            this.panelContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSocios;
        private System.Windows.Forms.TextBox txtDniSocio;
        private System.Windows.Forms.TextBox txtNombreSocio;
        private System.Windows.Forms.TextBox txtApellidoSocio;
        private System.Windows.Forms.TextBox txtTelefonoSocio;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.Label lblDomicilio;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txtBuscarSocio;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Label lblDni2Membresia;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}