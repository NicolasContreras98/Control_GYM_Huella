namespace Control_Gym.Capa_de_presentacion
{
    partial class FormAsistencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAsistencia));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAsistenciasDiaActual = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.cbTipoMembresia = new System.Windows.Forms.ComboBox();
            this.lblTipoMembresia = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFinMembresia = new System.Windows.Forms.Label();
            this.lblFechaInicioMembresia = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDni2Membresia = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvAsistencias = new System.Windows.Forms.DataGridView();
            this.lblDiaDeHoy = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencias)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightGray;
            this.groupBox2.Controls.Add(this.btnAsistenciasDiaActual);
            this.groupBox2.Controls.Add(this.btnFiltrar);
            this.groupBox2.Controls.Add(this.cbTipoMembresia);
            this.groupBox2.Controls.Add(this.lblTipoMembresia);
            this.groupBox2.Controls.Add(this.dtpFechaFin);
            this.groupBox2.Controls.Add(this.dtpFechaInicio);
            this.groupBox2.Controls.Add(this.lblFechaFinMembresia);
            this.groupBox2.Controls.Add(this.lblFechaInicioMembresia);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(641, 173);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtros para la Asistencia";
            // 
            // btnAsistenciasDiaActual
            // 
            this.btnAsistenciasDiaActual.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAsistenciasDiaActual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsistenciasDiaActual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsistenciasDiaActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsistenciasDiaActual.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAsistenciasDiaActual.Location = new System.Drawing.Point(507, 96);
            this.btnAsistenciasDiaActual.Name = "btnAsistenciasDiaActual";
            this.btnAsistenciasDiaActual.Size = new System.Drawing.Size(123, 42);
            this.btnAsistenciasDiaActual.TabIndex = 35;
            this.btnAsistenciasDiaActual.Text = "Asistencias del Día Actual";
            this.btnAsistenciasDiaActual.UseVisualStyleBackColor = false;
            this.btnAsistenciasDiaActual.Click += new System.EventHandler(this.btnAsistenciasDiaActual_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFiltrar.Location = new System.Drawing.Point(378, 96);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(123, 42);
            this.btnFiltrar.TabIndex = 34;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // cbTipoMembresia
            // 
            this.cbTipoMembresia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoMembresia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTipoMembresia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipoMembresia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbTipoMembresia.FormattingEnabled = true;
            this.cbTipoMembresia.Location = new System.Drawing.Point(184, 51);
            this.cbTipoMembresia.Name = "cbTipoMembresia";
            this.cbTipoMembresia.Size = new System.Drawing.Size(182, 28);
            this.cbTipoMembresia.TabIndex = 1;
            // 
            // lblTipoMembresia
            // 
            this.lblTipoMembresia.AutoSize = true;
            this.lblTipoMembresia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoMembresia.ForeColor = System.Drawing.Color.Black;
            this.lblTipoMembresia.Location = new System.Drawing.Point(8, 56);
            this.lblTipoMembresia.Name = "lblTipoMembresia";
            this.lblTipoMembresia.Size = new System.Drawing.Size(170, 20);
            this.lblTipoMembresia.TabIndex = 24;
            this.lblTipoMembresia.Text = "Tipo de membresia :";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtpFechaFin.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtpFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(184, 115);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(182, 26);
            this.dtpFechaFin.TabIndex = 33;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtpFechaInicio.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtpFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(184, 83);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(182, 26);
            this.dtpFechaInicio.TabIndex = 2;
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.dtpFechaInicio_ValueChanged);
            // 
            // lblFechaFinMembresia
            // 
            this.lblFechaFinMembresia.AutoSize = true;
            this.lblFechaFinMembresia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFinMembresia.ForeColor = System.Drawing.Color.Black;
            this.lblFechaFinMembresia.Location = new System.Drawing.Point(79, 118);
            this.lblFechaFinMembresia.Name = "lblFechaFinMembresia";
            this.lblFechaFinMembresia.Size = new System.Drawing.Size(99, 20);
            this.lblFechaFinMembresia.TabIndex = 10;
            this.lblFechaFinMembresia.Text = "Fecha Fin :";
            // 
            // lblFechaInicioMembresia
            // 
            this.lblFechaInicioMembresia.AutoSize = true;
            this.lblFechaInicioMembresia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicioMembresia.ForeColor = System.Drawing.Color.Black;
            this.lblFechaInicioMembresia.Location = new System.Drawing.Point(61, 87);
            this.lblFechaInicioMembresia.Name = "lblFechaInicioMembresia";
            this.lblFechaInicioMembresia.Size = new System.Drawing.Size(117, 20);
            this.lblFechaInicioMembresia.TabIndex = 8;
            this.lblFechaInicioMembresia.Text = "Fecha Inicio :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(264, 209);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 115;
            this.pictureBox1.TabStop = false;
            // 
            // lblDni2Membresia
            // 
            this.lblDni2Membresia.AutoSize = true;
            this.lblDni2Membresia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDni2Membresia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDni2Membresia.Location = new System.Drawing.Point(66, 193);
            this.lblDni2Membresia.Name = "lblDni2Membresia";
            this.lblDni2Membresia.Size = new System.Drawing.Size(55, 16);
            this.lblDni2Membresia.TabIndex = 114;
            this.lblDni2Membresia.Text = "Buscar";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(69, 209);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(189, 26);
            this.txtBuscar.TabIndex = 113;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvAsistencias);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1, 251);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(814, 292);
            this.groupBox1.TabIndex = 116;
            this.groupBox1.TabStop = false;
            // 
            // dgvAsistencias
            // 
            this.dgvAsistencias.AllowUserToAddRows = false;
            this.dgvAsistencias.AllowUserToDeleteRows = false;
            this.dgvAsistencias.AllowUserToOrderColumns = true;
            this.dgvAsistencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsistencias.Location = new System.Drawing.Point(6, 8);
            this.dgvAsistencias.Name = "dgvAsistencias";
            this.dgvAsistencias.ReadOnly = true;
            this.dgvAsistencias.Size = new System.Drawing.Size(802, 284);
            this.dgvAsistencias.TabIndex = 1;
            // 
            // lblDiaDeHoy
            // 
            this.lblDiaDeHoy.AutoSize = true;
            this.lblDiaDeHoy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDiaDeHoy.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaDeHoy.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblDiaDeHoy.Location = new System.Drawing.Point(333, 204);
            this.lblDiaDeHoy.Name = "lblDiaDeHoy";
            this.lblDiaDeHoy.Size = new System.Drawing.Size(413, 33);
            this.lblDiaDeHoy.TabIndex = 117;
            this.lblDiaDeHoy.Text = "Miercoles, 22 de Septiembre";
            this.lblDiaDeHoy.Click += new System.EventHandler(this.lblDiaDeHoy_Click);
            // 
            // FormAsistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 555);
            this.Controls.Add(this.lblDiaDeHoy);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblDni2Membresia);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAsistencia";
            this.Text = "FormAsistencia";
            this.Load += new System.EventHandler(this.FormAsistencia_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbTipoMembresia;
        private System.Windows.Forms.Label lblTipoMembresia;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblFechaFinMembresia;
        private System.Windows.Forms.Label lblFechaInicioMembresia;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDni2Membresia;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnAsistenciasDiaActual;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvAsistencias;
        private System.Windows.Forms.Label lblDiaDeHoy;
    }
}