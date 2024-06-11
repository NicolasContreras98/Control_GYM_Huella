namespace Control_Gym.Capa_de_presentacion
{
    partial class FormMembresias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMembresias));
            this.txtDniMembresia = new System.Windows.Forms.TextBox();
            this.lblDniMembresia = new System.Windows.Forms.Label();
            this.btnActualizarMembresia = new System.Windows.Forms.Button();
            this.btnEliminarMembresia = new System.Windows.Forms.Button();
            this.btnCancelarMembresia = new System.Windows.Forms.Button();
            this.btnCrearMembresia = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dvgMembresias = new System.Windows.Forms.DataGridView();
            this.txtBuscarDni = new System.Windows.Forms.TextBox();
            this.lblDni2Membresia = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbTipoMembresia = new System.Windows.Forms.ComboBox();
            this.lblTipoMembresia = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFinMembresia = new System.Windows.Forms.Label();
            this.lblFechaInicioMembresia = new System.Windows.Forms.Label();
            this.txtCodMembresia = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgMembresias)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDniMembresia
            // 
            this.txtDniMembresia.Location = new System.Drawing.Point(185, 23);
            this.txtDniMembresia.Name = "txtDniMembresia";
            this.txtDniMembresia.Size = new System.Drawing.Size(200, 26);
            this.txtDniMembresia.TabIndex = 0;
            this.txtDniMembresia.Click += new System.EventHandler(this.txtDniMembresia_Click);
            this.txtDniMembresia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDniMembresia_KeyDown);
            this.txtDniMembresia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDniMembresia_KeyPress);
            this.txtDniMembresia.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtDniMembresia_MouseDown);
            // 
            // lblDniMembresia
            // 
            this.lblDniMembresia.AutoSize = true;
            this.lblDniMembresia.Location = new System.Drawing.Point(19, 29);
            this.lblDniMembresia.Name = "lblDniMembresia";
            this.lblDniMembresia.Size = new System.Drawing.Size(40, 20);
            this.lblDniMembresia.TabIndex = 7;
            this.lblDniMembresia.Text = "DNI";
            // 
            // btnActualizarMembresia
            // 
            this.btnActualizarMembresia.BackColor = System.Drawing.Color.ForestGreen;
            this.btnActualizarMembresia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizarMembresia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarMembresia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarMembresia.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnActualizarMembresia.Location = new System.Drawing.Point(3, 27);
            this.btnActualizarMembresia.Name = "btnActualizarMembresia";
            this.btnActualizarMembresia.Size = new System.Drawing.Size(75, 30);
            this.btnActualizarMembresia.TabIndex = 6;
            this.btnActualizarMembresia.Text = "Modificar";
            this.btnActualizarMembresia.UseVisualStyleBackColor = false;
            this.btnActualizarMembresia.Click += new System.EventHandler(this.btnActualizarMembresia_Click);
            // 
            // btnEliminarMembresia
            // 
            this.btnEliminarMembresia.BackColor = System.Drawing.Color.IndianRed;
            this.btnEliminarMembresia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarMembresia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarMembresia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarMembresia.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEliminarMembresia.Location = new System.Drawing.Point(106, 27);
            this.btnEliminarMembresia.Name = "btnEliminarMembresia";
            this.btnEliminarMembresia.Size = new System.Drawing.Size(75, 30);
            this.btnEliminarMembresia.TabIndex = 4;
            this.btnEliminarMembresia.Text = "Eliminar";
            this.btnEliminarMembresia.UseVisualStyleBackColor = false;
            this.btnEliminarMembresia.Click += new System.EventHandler(this.btnEliminarMembresia_Click);
            // 
            // btnCancelarMembresia
            // 
            this.btnCancelarMembresia.BackColor = System.Drawing.Color.Gray;
            this.btnCancelarMembresia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarMembresia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarMembresia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarMembresia.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelarMembresia.Location = new System.Drawing.Point(207, 27);
            this.btnCancelarMembresia.Name = "btnCancelarMembresia";
            this.btnCancelarMembresia.Size = new System.Drawing.Size(75, 30);
            this.btnCancelarMembresia.TabIndex = 5;
            this.btnCancelarMembresia.Text = "Cancelar";
            this.btnCancelarMembresia.UseVisualStyleBackColor = false;
            this.btnCancelarMembresia.Click += new System.EventHandler(this.btnCancelarMembresia_Click);
            // 
            // btnCrearMembresia
            // 
            this.btnCrearMembresia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnCrearMembresia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrearMembresia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearMembresia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearMembresia.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCrearMembresia.Location = new System.Drawing.Point(3, 27);
            this.btnCrearMembresia.Name = "btnCrearMembresia";
            this.btnCrearMembresia.Size = new System.Drawing.Size(75, 30);
            this.btnCrearMembresia.TabIndex = 3;
            this.btnCrearMembresia.Text = "Agregar";
            this.btnCrearMembresia.UseVisualStyleBackColor = false;
            this.btnCrearMembresia.Click += new System.EventHandler(this.btnCrearMembresia_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnEliminarMembresia);
            this.panel1.Controls.Add(this.btnCancelarMembresia);
            this.panel1.Controls.Add(this.btnCrearMembresia);
            this.panel1.Controls.Add(this.btnActualizarMembresia);
            this.panel1.Location = new System.Drawing.Point(586, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(286, 111);
            this.panel1.TabIndex = 19;
            // 
            // dvgMembresias
            // 
            this.dvgMembresias.AllowUserToAddRows = false;
            this.dvgMembresias.AllowUserToDeleteRows = false;
            this.dvgMembresias.AllowUserToOrderColumns = true;
            this.dvgMembresias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgMembresias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgMembresias.Location = new System.Drawing.Point(12, 236);
            this.dvgMembresias.MultiSelect = false;
            this.dvgMembresias.Name = "dvgMembresias";
            this.dvgMembresias.ReadOnly = true;
            this.dvgMembresias.Size = new System.Drawing.Size(1015, 357);
            this.dvgMembresias.TabIndex = 111;
            this.dvgMembresias.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dvgMembresias_CellFormatting);
            this.dvgMembresias.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dvgMembresias_RowHeaderMouseClick);
            // 
            // txtBuscarDni
            // 
            this.txtBuscarDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarDni.Location = new System.Drawing.Point(69, 204);
            this.txtBuscarDni.Name = "txtBuscarDni";
            this.txtBuscarDni.Size = new System.Drawing.Size(189, 26);
            this.txtBuscarDni.TabIndex = 7;
            this.txtBuscarDni.TextChanged += new System.EventHandler(this.txtBuscarDni_TextChanged);
            // 
            // lblDni2Membresia
            // 
            this.lblDni2Membresia.AutoSize = true;
            this.lblDni2Membresia.Location = new System.Drawing.Point(66, 188);
            this.lblDni2Membresia.Name = "lblDni2Membresia";
            this.lblDni2Membresia.Size = new System.Drawing.Size(26, 13);
            this.lblDni2Membresia.TabIndex = 14;
            this.lblDni2Membresia.Text = "DNI";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbTipoMembresia);
            this.groupBox2.Controls.Add(this.lblTipoMembresia);
            this.groupBox2.Controls.Add(this.dtpFechaFin);
            this.groupBox2.Controls.Add(this.dtpFechaInicio);
            this.groupBox2.Controls.Add(this.lblFechaFinMembresia);
            this.groupBox2.Controls.Add(this.lblFechaInicioMembresia);
            this.groupBox2.Controls.Add(this.txtDniMembresia);
            this.groupBox2.Controls.Add(this.lblDniMembresia);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(512, 157);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del socio";
            // 
            // cbTipoMembresia
            // 
            this.cbTipoMembresia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoMembresia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTipoMembresia.FormattingEnabled = true;
            this.cbTipoMembresia.Location = new System.Drawing.Point(185, 54);
            this.cbTipoMembresia.Name = "cbTipoMembresia";
            this.cbTipoMembresia.Size = new System.Drawing.Size(200, 28);
            this.cbTipoMembresia.TabIndex = 1;
            this.cbTipoMembresia.SelectedIndexChanged += new System.EventHandler(this.cbTipoMembresia_SelectedIndexChanged);
            this.cbTipoMembresia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbTipoMembresia_KeyDown);
            this.cbTipoMembresia.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cbTipoMembresia_MouseDown);
            // 
            // lblTipoMembresia
            // 
            this.lblTipoMembresia.AutoSize = true;
            this.lblTipoMembresia.Location = new System.Drawing.Point(19, 62);
            this.lblTipoMembresia.Name = "lblTipoMembresia";
            this.lblTipoMembresia.Size = new System.Drawing.Size(160, 20);
            this.lblTipoMembresia.TabIndex = 24;
            this.lblTipoMembresia.Text = "Tipo de membresia";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Enabled = false;
            this.dtpFechaFin.Location = new System.Drawing.Point(185, 120);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(200, 26);
            this.dtpFechaFin.TabIndex = 33;
            this.dtpFechaFin.ValueChanged += new System.EventHandler(this.dtpFechaFin_ValueChanged);
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(185, 88);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(200, 26);
            this.dtpFechaInicio.TabIndex = 2;
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.dtpFechaInicio_ValueChanged);
            // 
            // lblFechaFinMembresia
            // 
            this.lblFechaFinMembresia.AutoSize = true;
            this.lblFechaFinMembresia.Location = new System.Drawing.Point(19, 123);
            this.lblFechaFinMembresia.Name = "lblFechaFinMembresia";
            this.lblFechaFinMembresia.Size = new System.Drawing.Size(89, 20);
            this.lblFechaFinMembresia.TabIndex = 10;
            this.lblFechaFinMembresia.Text = "Fecha Fin";
            // 
            // lblFechaInicioMembresia
            // 
            this.lblFechaInicioMembresia.AutoSize = true;
            this.lblFechaInicioMembresia.Location = new System.Drawing.Point(19, 91);
            this.lblFechaInicioMembresia.Name = "lblFechaInicioMembresia";
            this.lblFechaInicioMembresia.Size = new System.Drawing.Size(107, 20);
            this.lblFechaInicioMembresia.TabIndex = 8;
            this.lblFechaInicioMembresia.Text = "Fecha Inicio";
            // 
            // txtCodMembresia
            // 
            this.txtCodMembresia.Location = new System.Drawing.Point(709, 209);
            this.txtCodMembresia.Name = "txtCodMembresia";
            this.txtCodMembresia.Size = new System.Drawing.Size(100, 20);
            this.txtCodMembresia.TabIndex = 99;
            this.txtCodMembresia.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(264, 204);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 112;
            this.pictureBox1.TabStop = false;
            // 
            // FormMembresias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1050, 605);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtCodMembresia);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblDni2Membresia);
            this.Controls.Add(this.txtBuscarDni);
            this.Controls.Add(this.dvgMembresias);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMembresias";
            this.Text = "FormMembresias";
            this.Load += new System.EventHandler(this.FormMembresias_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgMembresias)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDniMembresia;
        private System.Windows.Forms.Label lblDniMembresia;
        private System.Windows.Forms.Button btnActualizarMembresia;
        private System.Windows.Forms.Button btnEliminarMembresia;
        private System.Windows.Forms.Button btnCancelarMembresia;
        private System.Windows.Forms.Button btnCrearMembresia;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dvgMembresias;
        private System.Windows.Forms.TextBox txtBuscarDni;
        private System.Windows.Forms.Label lblDni2Membresia;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblFechaFinMembresia;
        private System.Windows.Forms.Label lblFechaInicioMembresia;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.ComboBox cbTipoMembresia;
        private System.Windows.Forms.Label lblTipoMembresia;
        private System.Windows.Forms.TextBox txtCodMembresia;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}