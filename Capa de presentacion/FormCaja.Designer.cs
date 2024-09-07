namespace Control_Gym.Capa_de_presentacion
{
    partial class FormCaja
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
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.dgvCuotas = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBorrarCuota = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotalHoyCuotasResult = new System.Windows.Forms.Label();
            this.lblTotalMesCuotaResult = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalCuotasResult = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBorrarVenta = new System.Windows.Forms.Button();
            this.lblTotalHoyResult = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotalMesResult = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblVentasResult = new System.Windows.Forms.Label();
            this.btnVerDetalle = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalVentas = new System.Windows.Forms.Label();
            this.txtNum_venta = new System.Windows.Forms.TextBox();
            this.txtCod_cuota = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuotas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvVentas
            // 
            this.dgvVentas.AllowUserToAddRows = false;
            this.dgvVentas.AllowUserToDeleteRows = false;
            this.dgvVentas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Location = new System.Drawing.Point(30, 36);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.ReadOnly = true;
            this.dgvVentas.Size = new System.Drawing.Size(679, 227);
            this.dgvVentas.TabIndex = 0;
            this.dgvVentas.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvVentas_RowHeaderMouseClick);
            // 
            // dgvCuotas
            // 
            this.dgvCuotas.AllowUserToAddRows = false;
            this.dgvCuotas.AllowUserToDeleteRows = false;
            this.dgvCuotas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvCuotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuotas.Location = new System.Drawing.Point(30, 38);
            this.dgvCuotas.Name = "dgvCuotas";
            this.dgvCuotas.ReadOnly = true;
            this.dgvCuotas.Size = new System.Drawing.Size(679, 225);
            this.dgvCuotas.TabIndex = 2;
            this.dgvCuotas.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCuotas_RowHeaderMouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.btnBorrarCuota);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lblTotalHoyCuotasResult);
            this.groupBox1.Controls.Add(this.lblTotalMesCuotaResult);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblTotalCuotasResult);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dgvCuotas);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(0, 297);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1050, 269);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Membresias/Cuotas";
            // 
            // btnBorrarCuota
            // 
            this.btnBorrarCuota.BackColor = System.Drawing.Color.IndianRed;
            this.btnBorrarCuota.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrarCuota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrarCuota.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarCuota.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBorrarCuota.Location = new System.Drawing.Point(803, 163);
            this.btnBorrarCuota.Name = "btnBorrarCuota";
            this.btnBorrarCuota.Size = new System.Drawing.Size(75, 30);
            this.btnBorrarCuota.TabIndex = 9;
            this.btnBorrarCuota.Text = "Eliminar";
            this.btnBorrarCuota.UseVisualStyleBackColor = false;
            this.btnBorrarCuota.Click += new System.EventHandler(this.btnBorrarCuota_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.ForestGreen;
            this.label11.Location = new System.Drawing.Point(932, 113);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 25);
            this.label11.TabIndex = 12;
            this.label11.Text = "$";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.ForestGreen;
            this.label10.Location = new System.Drawing.Point(932, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 25);
            this.label10.TabIndex = 11;
            this.label10.Text = "$";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.ForestGreen;
            this.label9.Location = new System.Drawing.Point(932, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 25);
            this.label9.TabIndex = 10;
            this.label9.Text = "$";
            // 
            // lblTotalHoyCuotasResult
            // 
            this.lblTotalHoyCuotasResult.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTotalHoyCuotasResult.AutoSize = true;
            this.lblTotalHoyCuotasResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHoyCuotasResult.Location = new System.Drawing.Point(954, 113);
            this.lblTotalHoyCuotasResult.Name = "lblTotalHoyCuotasResult";
            this.lblTotalHoyCuotasResult.Size = new System.Drawing.Size(58, 25);
            this.lblTotalHoyCuotasResult.TabIndex = 9;
            this.lblTotalHoyCuotasResult.Text = "0.00";
            // 
            // lblTotalMesCuotaResult
            // 
            this.lblTotalMesCuotaResult.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTotalMesCuotaResult.AutoSize = true;
            this.lblTotalMesCuotaResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMesCuotaResult.Location = new System.Drawing.Point(954, 77);
            this.lblTotalMesCuotaResult.Name = "lblTotalMesCuotaResult";
            this.lblTotalMesCuotaResult.Size = new System.Drawing.Size(58, 25);
            this.lblTotalMesCuotaResult.TabIndex = 7;
            this.lblTotalMesCuotaResult.Text = "0.00";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(781, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 25);
            this.label6.TabIndex = 8;
            this.label6.Text = "TOTAL HOY :";
            // 
            // lblTotalCuotasResult
            // 
            this.lblTotalCuotasResult.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTotalCuotasResult.AutoSize = true;
            this.lblTotalCuotasResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCuotasResult.Location = new System.Drawing.Point(954, 43);
            this.lblTotalCuotasResult.Name = "lblTotalCuotasResult";
            this.lblTotalCuotasResult.Size = new System.Drawing.Size(58, 25);
            this.lblTotalCuotasResult.TabIndex = 9;
            this.lblTotalCuotasResult.Text = "0.00";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(715, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(221, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "TOTAL ESTE MES :";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(837, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "TOTAL :";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.btnBorrarVenta);
            this.groupBox2.Controls.Add(this.lblTotalHoyResult);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblTotalMesResult);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lblVentasResult);
            this.groupBox2.Controls.Add(this.btnVerDetalle);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dgvVentas);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblTotalVentas);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox2.Location = new System.Drawing.Point(0, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1050, 269);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ventas realizadas";
            // 
            // btnBorrarVenta
            // 
            this.btnBorrarVenta.BackColor = System.Drawing.Color.IndianRed;
            this.btnBorrarVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarVenta.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBorrarVenta.Location = new System.Drawing.Point(803, 203);
            this.btnBorrarVenta.Name = "btnBorrarVenta";
            this.btnBorrarVenta.Size = new System.Drawing.Size(75, 30);
            this.btnBorrarVenta.TabIndex = 9;
            this.btnBorrarVenta.Text = "Eliminar";
            this.btnBorrarVenta.UseVisualStyleBackColor = false;
            this.btnBorrarVenta.Click += new System.EventHandler(this.btnBorrarVenta_Click);
            // 
            // lblTotalHoyResult
            // 
            this.lblTotalHoyResult.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTotalHoyResult.AutoSize = true;
            this.lblTotalHoyResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHoyResult.Location = new System.Drawing.Point(954, 103);
            this.lblTotalHoyResult.Name = "lblTotalHoyResult";
            this.lblTotalHoyResult.Size = new System.Drawing.Size(58, 25);
            this.lblTotalHoyResult.TabIndex = 7;
            this.lblTotalHoyResult.Text = "0.00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.ForestGreen;
            this.label8.Location = new System.Drawing.Point(932, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 25);
            this.label8.TabIndex = 10;
            this.label8.Text = "$";
            // 
            // lblTotalMesResult
            // 
            this.lblTotalMesResult.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTotalMesResult.AutoSize = true;
            this.lblTotalMesResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMesResult.Location = new System.Drawing.Point(954, 71);
            this.lblTotalMesResult.Name = "lblTotalMesResult";
            this.lblTotalMesResult.Size = new System.Drawing.Size(58, 25);
            this.lblTotalMesResult.TabIndex = 4;
            this.lblTotalMesResult.Text = "0.00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.ForestGreen;
            this.label7.Location = new System.Drawing.Point(932, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 25);
            this.label7.TabIndex = 9;
            this.label7.Text = "$";
            // 
            // lblVentasResult
            // 
            this.lblVentasResult.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblVentasResult.AutoSize = true;
            this.lblVentasResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVentasResult.Location = new System.Drawing.Point(954, 38);
            this.lblVentasResult.Name = "lblVentasResult";
            this.lblVentasResult.Size = new System.Drawing.Size(58, 25);
            this.lblVentasResult.TabIndex = 2;
            this.lblVentasResult.Text = "0.00";
            // 
            // btnVerDetalle
            // 
            this.btnVerDetalle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnVerDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnVerDetalle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerDetalle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVerDetalle.Location = new System.Drawing.Point(803, 167);
            this.btnVerDetalle.Name = "btnVerDetalle";
            this.btnVerDetalle.Size = new System.Drawing.Size(92, 30);
            this.btnVerDetalle.TabIndex = 6;
            this.btnVerDetalle.Text = "Ver detalle";
            this.btnVerDetalle.UseVisualStyleBackColor = false;
            this.btnVerDetalle.Click += new System.EventHandler(this.btnVerDetalle_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(781, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "TOTAL HOY :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(715, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "TOTAL ESTE MES :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Location = new System.Drawing.Point(932, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "$";
            // 
            // lblTotalVentas
            // 
            this.lblTotalVentas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTotalVentas.AutoSize = true;
            this.lblTotalVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVentas.Location = new System.Drawing.Point(837, 38);
            this.lblTotalVentas.Name = "lblTotalVentas";
            this.lblTotalVentas.Size = new System.Drawing.Size(99, 25);
            this.lblTotalVentas.TabIndex = 1;
            this.lblTotalVentas.Text = "TOTAL :";
            // 
            // txtNum_venta
            // 
            this.txtNum_venta.Location = new System.Drawing.Point(197, 275);
            this.txtNum_venta.Name = "txtNum_venta";
            this.txtNum_venta.Size = new System.Drawing.Size(100, 20);
            this.txtNum_venta.TabIndex = 6;
            this.txtNum_venta.Visible = false;
            // 
            // txtCod_cuota
            // 
            this.txtCod_cuota.Location = new System.Drawing.Point(353, 275);
            this.txtCod_cuota.Name = "txtCod_cuota";
            this.txtCod_cuota.Size = new System.Drawing.Size(100, 20);
            this.txtCod_cuota.TabIndex = 7;
            this.txtCod_cuota.Visible = false;
            // 
            // FormCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1050, 605);
            this.Controls.Add(this.txtCod_cuota);
            this.Controls.Add(this.txtNum_venta);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCaja";
            this.Text = "FormCaja";
            this.Load += new System.EventHandler(this.FormCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuotas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.DataGridView dgvCuotas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTotalVentas;
        private System.Windows.Forms.Label lblVentasResult;
        private System.Windows.Forms.Label lblTotalMesResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalHoyResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalCuotasResult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotalMesCuotaResult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalHoyCuotasResult;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnVerDetalle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNum_venta;
        private System.Windows.Forms.TextBox txtCod_cuota;
        private System.Windows.Forms.Button btnBorrarCuota;
        private System.Windows.Forms.Button btnBorrarVenta;
    }
}