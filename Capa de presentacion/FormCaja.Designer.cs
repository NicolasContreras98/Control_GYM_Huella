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
            this.dgvCuotas = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Cuotas = new System.Windows.Forms.TabPage();
            this.txtCod_cuota = new System.Windows.Forms.TextBox();
            this.txtNum_venta = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnUlt7diasCUOTA = new System.Windows.Forms.Button();
            this.btnHoyCUOTA = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnVerInformes = new System.Windows.Forms.Button();
            this.cbMesCUOTA = new System.Windows.Forms.ComboBox();
            this.btnBorrarCuota = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbAñoCUOTA = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalCuotasResult = new System.Windows.Forms.Label();
            this.lblTotalMesCuotaResult = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTotalHoyCuotasResult = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Ventas = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbAñoVENTA = new System.Windows.Forms.ComboBox();
            this.cbMesVENTA = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuotas)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Cuotas.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Ventas.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCuotas
            // 
            this.dgvCuotas.AllowUserToAddRows = false;
            this.dgvCuotas.AllowUserToDeleteRows = false;
            this.dgvCuotas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvCuotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuotas.Location = new System.Drawing.Point(0, 21);
            this.dgvCuotas.Name = "dgvCuotas";
            this.dgvCuotas.ReadOnly = true;
            this.dgvCuotas.Size = new System.Drawing.Size(550, 485);
            this.dgvCuotas.TabIndex = 2;
            this.dgvCuotas.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCuotas_RowHeaderMouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.dgvCuotas);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(6, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 515);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Membresias/Cuotas";
            // 
            // btnBorrarVenta
            // 
            this.btnBorrarVenta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBorrarVenta.BackColor = System.Drawing.Color.IndianRed;
            this.btnBorrarVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarVenta.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBorrarVenta.Location = new System.Drawing.Point(91, 248);
            this.btnBorrarVenta.Name = "btnBorrarVenta";
            this.btnBorrarVenta.Size = new System.Drawing.Size(75, 30);
            this.btnBorrarVenta.TabIndex = 9;
            this.btnBorrarVenta.Text = "Eliminar";
            this.btnBorrarVenta.UseVisualStyleBackColor = false;
            this.btnBorrarVenta.Click += new System.EventHandler(this.btnBorrarVenta_Click);
            // 
            // lblTotalHoyResult
            // 
            this.lblTotalHoyResult.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalHoyResult.AutoSize = true;
            this.lblTotalHoyResult.BackColor = System.Drawing.Color.Silver;
            this.lblTotalHoyResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHoyResult.Location = new System.Drawing.Point(102, 95);
            this.lblTotalHoyResult.Name = "lblTotalHoyResult";
            this.lblTotalHoyResult.Size = new System.Drawing.Size(35, 16);
            this.lblTotalHoyResult.TabIndex = 7;
            this.lblTotalHoyResult.Text = "0.00";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Silver;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.ForestGreen;
            this.label8.Location = new System.Drawing.Point(88, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "$";
            // 
            // lblTotalMesResult
            // 
            this.lblTotalMesResult.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalMesResult.AutoSize = true;
            this.lblTotalMesResult.BackColor = System.Drawing.Color.Silver;
            this.lblTotalMesResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMesResult.Location = new System.Drawing.Point(102, 59);
            this.lblTotalMesResult.Name = "lblTotalMesResult";
            this.lblTotalMesResult.Size = new System.Drawing.Size(35, 16);
            this.lblTotalMesResult.TabIndex = 4;
            this.lblTotalMesResult.Text = "0.00";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Silver;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.ForestGreen;
            this.label7.Location = new System.Drawing.Point(88, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "$";
            // 
            // lblVentasResult
            // 
            this.lblVentasResult.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVentasResult.AutoSize = true;
            this.lblVentasResult.BackColor = System.Drawing.Color.Silver;
            this.lblVentasResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVentasResult.Location = new System.Drawing.Point(102, 25);
            this.lblVentasResult.Name = "lblVentasResult";
            this.lblVentasResult.Size = new System.Drawing.Size(35, 16);
            this.lblVentasResult.TabIndex = 2;
            this.lblVentasResult.Text = "0.00";
            // 
            // btnVerDetalle
            // 
            this.btnVerDetalle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVerDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnVerDetalle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerDetalle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVerDetalle.Location = new System.Drawing.Point(83, 284);
            this.btnVerDetalle.Name = "btnVerDetalle";
            this.btnVerDetalle.Size = new System.Drawing.Size(90, 30);
            this.btnVerDetalle.TabIndex = 6;
            this.btnVerDetalle.Text = "Ver detalle";
            this.btnVerDetalle.UseVisualStyleBackColor = false;
            this.btnVerDetalle.Click += new System.EventHandler(this.btnVerDetalle_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "HOY :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "ESTE MES :";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Location = new System.Drawing.Point(88, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "$";
            // 
            // lblTotalVentas
            // 
            this.lblTotalVentas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalVentas.AutoSize = true;
            this.lblTotalVentas.BackColor = System.Drawing.Color.Silver;
            this.lblTotalVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVentas.Location = new System.Drawing.Point(27, 25);
            this.lblTotalVentas.Name = "lblTotalVentas";
            this.lblTotalVentas.Size = new System.Drawing.Size(64, 16);
            this.lblTotalVentas.TabIndex = 1;
            this.lblTotalVentas.Text = "TOTAL :";
            // 
            // dgvVentas
            // 
            this.dgvVentas.AllowUserToAddRows = false;
            this.dgvVentas.AllowUserToDeleteRows = false;
            this.dgvVentas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Location = new System.Drawing.Point(0, 21);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.ReadOnly = true;
            this.dgvVentas.Size = new System.Drawing.Size(550, 485);
            this.dgvVentas.TabIndex = 0;
            this.dgvVentas.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvVentas_RowHeaderMouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.dgvVentas);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(6, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(556, 515);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ventas realizadas";
            // 
            // tabControl1
            // 
            this.tabControl1.CausesValidation = false;
            this.tabControl1.Controls.Add(this.Cuotas);
            this.tabControl1.Controls.Add(this.Ventas);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(6, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(818, 555);
            this.tabControl1.TabIndex = 25;
            // 
            // Cuotas
            // 
            this.Cuotas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Cuotas.Controls.Add(this.groupBox1);
            this.Cuotas.Controls.Add(this.txtCod_cuota);
            this.Cuotas.Controls.Add(this.txtNum_venta);
            this.Cuotas.Controls.Add(this.panel1);
            this.Cuotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cuotas.Location = new System.Drawing.Point(4, 25);
            this.Cuotas.Name = "Cuotas";
            this.Cuotas.Padding = new System.Windows.Forms.Padding(3);
            this.Cuotas.Size = new System.Drawing.Size(810, 526);
            this.Cuotas.TabIndex = 0;
            this.Cuotas.Text = "Cuotas";
            // 
            // txtCod_cuota
            // 
            this.txtCod_cuota.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCod_cuota.Location = new System.Drawing.Point(675, 38);
            this.txtCod_cuota.Name = "txtCod_cuota";
            this.txtCod_cuota.Size = new System.Drawing.Size(100, 26);
            this.txtCod_cuota.TabIndex = 26;
            this.txtCod_cuota.Visible = false;
            // 
            // txtNum_venta
            // 
            this.txtNum_venta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNum_venta.Location = new System.Drawing.Point(675, 5);
            this.txtNum_venta.Name = "txtNum_venta";
            this.txtNum_venta.Size = new System.Drawing.Size(100, 26);
            this.txtNum_venta.TabIndex = 25;
            this.txtNum_venta.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.btnUlt7diasCUOTA);
            this.panel1.Controls.Add(this.btnHoyCUOTA);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnVerInformes);
            this.panel1.Controls.Add(this.cbMesCUOTA);
            this.panel1.Controls.Add(this.btnBorrarCuota);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbAñoCUOTA);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblTotalCuotasResult);
            this.panel1.Controls.Add(this.lblTotalMesCuotaResult);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.lblTotalHoyCuotasResult);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(562, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 390);
            this.panel1.TabIndex = 40;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Silver;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 242);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 43;
            this.label13.Text = "MES :";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Silver;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 208);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 42;
            this.label12.Text = "AÑO :";
            // 
            // btnUlt7diasCUOTA
            // 
            this.btnUlt7diasCUOTA.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUlt7diasCUOTA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnUlt7diasCUOTA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUlt7diasCUOTA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUlt7diasCUOTA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUlt7diasCUOTA.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUlt7diasCUOTA.Location = new System.Drawing.Point(128, 148);
            this.btnUlt7diasCUOTA.Name = "btnUlt7diasCUOTA";
            this.btnUlt7diasCUOTA.Size = new System.Drawing.Size(74, 46);
            this.btnUlt7diasCUOTA.TabIndex = 41;
            this.btnUlt7diasCUOTA.Text = "ULT. 7 DIAS";
            this.btnUlt7diasCUOTA.UseVisualStyleBackColor = false;
            this.btnUlt7diasCUOTA.Click += new System.EventHandler(this.btnUlt7diasCUOTA_Click);
            // 
            // btnHoyCUOTA
            // 
            this.btnHoyCUOTA.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHoyCUOTA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnHoyCUOTA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHoyCUOTA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoyCUOTA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoyCUOTA.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnHoyCUOTA.Location = new System.Drawing.Point(47, 148);
            this.btnHoyCUOTA.Name = "btnHoyCUOTA";
            this.btnHoyCUOTA.Size = new System.Drawing.Size(75, 46);
            this.btnHoyCUOTA.TabIndex = 40;
            this.btnHoyCUOTA.Text = "HOY";
            this.btnHoyCUOTA.UseVisualStyleBackColor = false;
            this.btnHoyCUOTA.Click += new System.EventHandler(this.btnHoyCUOTA_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Silver;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(44, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 16);
            this.label6.TabIndex = 29;
            this.label6.Text = "HOY :";
            // 
            // btnVerInformes
            // 
            this.btnVerInformes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVerInformes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnVerInformes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerInformes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerInformes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerInformes.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVerInformes.Location = new System.Drawing.Point(58, 322);
            this.btnVerInformes.Name = "btnVerInformes";
            this.btnVerInformes.Size = new System.Drawing.Size(137, 51);
            this.btnVerInformes.TabIndex = 37;
            this.btnVerInformes.Text = "Informes";
            this.btnVerInformes.UseVisualStyleBackColor = false;
            this.btnVerInformes.Click += new System.EventHandler(this.btnVerInformes_Click);
            // 
            // cbMesCUOTA
            // 
            this.cbMesCUOTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMesCUOTA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMesCUOTA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbMesCUOTA.FormattingEnabled = true;
            this.cbMesCUOTA.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.cbMesCUOTA.Location = new System.Drawing.Point(47, 234);
            this.cbMesCUOTA.Name = "cbMesCUOTA";
            this.cbMesCUOTA.Size = new System.Drawing.Size(155, 28);
            this.cbMesCUOTA.TabIndex = 39;
            this.cbMesCUOTA.SelectedIndexChanged += new System.EventHandler(this.cbMesCUOTA_SelectedIndexChanged);
            // 
            // btnBorrarCuota
            // 
            this.btnBorrarCuota.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBorrarCuota.BackColor = System.Drawing.Color.IndianRed;
            this.btnBorrarCuota.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrarCuota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrarCuota.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarCuota.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBorrarCuota.Location = new System.Drawing.Point(91, 286);
            this.btnBorrarCuota.Name = "btnBorrarCuota";
            this.btnBorrarCuota.Size = new System.Drawing.Size(75, 30);
            this.btnBorrarCuota.TabIndex = 31;
            this.btnBorrarCuota.Text = "Eliminar";
            this.btnBorrarCuota.UseVisualStyleBackColor = false;
            this.btnBorrarCuota.Click += new System.EventHandler(this.btnBorrarCuota_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 30;
            this.label4.Text = "TOTAL :";
            // 
            // cbAñoCUOTA
            // 
            this.cbAñoCUOTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAñoCUOTA.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbAñoCUOTA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAñoCUOTA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbAñoCUOTA.FormattingEnabled = true;
            this.cbAñoCUOTA.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cbAñoCUOTA.Location = new System.Drawing.Point(47, 200);
            this.cbAñoCUOTA.Name = "cbAñoCUOTA";
            this.cbAñoCUOTA.Size = new System.Drawing.Size(155, 28);
            this.cbAñoCUOTA.TabIndex = 38;
            this.cbAñoCUOTA.SelectedIndexChanged += new System.EventHandler(this.cbAñoCUOTA_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Silver;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 16);
            this.label5.TabIndex = 27;
            this.label5.Text = "ESTE MES :";
            // 
            // lblTotalCuotasResult
            // 
            this.lblTotalCuotasResult.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalCuotasResult.AutoSize = true;
            this.lblTotalCuotasResult.BackColor = System.Drawing.Color.Silver;
            this.lblTotalCuotasResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCuotasResult.Location = new System.Drawing.Point(102, 25);
            this.lblTotalCuotasResult.Name = "lblTotalCuotasResult";
            this.lblTotalCuotasResult.Size = new System.Drawing.Size(35, 16);
            this.lblTotalCuotasResult.TabIndex = 33;
            this.lblTotalCuotasResult.Text = "0.00";
            // 
            // lblTotalMesCuotaResult
            // 
            this.lblTotalMesCuotaResult.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalMesCuotaResult.AutoSize = true;
            this.lblTotalMesCuotaResult.BackColor = System.Drawing.Color.Silver;
            this.lblTotalMesCuotaResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMesCuotaResult.Location = new System.Drawing.Point(102, 59);
            this.lblTotalMesCuotaResult.Name = "lblTotalMesCuotaResult";
            this.lblTotalMesCuotaResult.Size = new System.Drawing.Size(35, 16);
            this.lblTotalMesCuotaResult.TabIndex = 28;
            this.lblTotalMesCuotaResult.Text = "0.00";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Silver;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.ForestGreen;
            this.label11.Location = new System.Drawing.Point(88, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 16);
            this.label11.TabIndex = 36;
            this.label11.Text = "$";
            // 
            // lblTotalHoyCuotasResult
            // 
            this.lblTotalHoyCuotasResult.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalHoyCuotasResult.AutoSize = true;
            this.lblTotalHoyCuotasResult.BackColor = System.Drawing.Color.Silver;
            this.lblTotalHoyCuotasResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHoyCuotasResult.Location = new System.Drawing.Point(102, 95);
            this.lblTotalHoyCuotasResult.Name = "lblTotalHoyCuotasResult";
            this.lblTotalHoyCuotasResult.Size = new System.Drawing.Size(35, 16);
            this.lblTotalHoyCuotasResult.TabIndex = 32;
            this.lblTotalHoyCuotasResult.Text = "0.00";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Silver;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.ForestGreen;
            this.label10.Location = new System.Drawing.Point(88, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 16);
            this.label10.TabIndex = 35;
            this.label10.Text = "$";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Silver;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.ForestGreen;
            this.label9.Location = new System.Drawing.Point(88, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 16);
            this.label9.TabIndex = 34;
            this.label9.Text = "$";
            // 
            // Ventas
            // 
            this.Ventas.Controls.Add(this.groupBox2);
            this.Ventas.Controls.Add(this.panel2);
            this.Ventas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ventas.Location = new System.Drawing.Point(4, 25);
            this.Ventas.Name = "Ventas";
            this.Ventas.Padding = new System.Windows.Forms.Padding(3);
            this.Ventas.Size = new System.Drawing.Size(810, 526);
            this.Ventas.TabIndex = 1;
            this.Ventas.Text = "Ventas";
            this.Ventas.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cbAñoVENTA);
            this.panel2.Controls.Add(this.btnVerDetalle);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnBorrarVenta);
            this.panel2.Controls.Add(this.lblVentasResult);
            this.panel2.Controls.Add(this.lblTotalMesResult);
            this.panel2.Controls.Add(this.lblTotalVentas);
            this.panel2.Controls.Add(this.lblTotalHoyResult);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cbMesVENTA);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(562, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(234, 390);
            this.panel2.TabIndex = 42;
            // 
            // cbAñoVENTA
            // 
            this.cbAñoVENTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAñoVENTA.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbAñoVENTA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAñoVENTA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbAñoVENTA.FormattingEnabled = true;
            this.cbAñoVENTA.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.cbAñoVENTA.Location = new System.Drawing.Point(57, 150);
            this.cbAñoVENTA.Name = "cbAñoVENTA";
            this.cbAñoVENTA.Size = new System.Drawing.Size(138, 28);
            this.cbAñoVENTA.TabIndex = 41;
            // 
            // cbMesVENTA
            // 
            this.cbMesVENTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMesVENTA.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbMesVENTA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMesVENTA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbMesVENTA.FormattingEnabled = true;
            this.cbMesVENTA.Location = new System.Drawing.Point(57, 184);
            this.cbMesVENTA.Name = "cbMesVENTA";
            this.cbMesVENTA.Size = new System.Drawing.Size(138, 28);
            this.cbMesVENTA.TabIndex = 40;
            // 
            // FormCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(818, 555);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCaja";
            this.Text = "S";
            this.Load += new System.EventHandler(this.FormCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuotas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.Cuotas.ResumeLayout(false);
            this.Cuotas.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Ventas.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvCuotas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTotalVentas;
        private System.Windows.Forms.Label lblVentasResult;
        private System.Windows.Forms.Label lblTotalMesResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalHoyResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnVerDetalle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBorrarVenta;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Cuotas;
        private System.Windows.Forms.TabPage Ventas;
        private System.Windows.Forms.Button btnVerInformes;
        private System.Windows.Forms.Button btnBorrarCuota;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTotalHoyCuotasResult;
        private System.Windows.Forms.Label lblTotalMesCuotaResult;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalCuotasResult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCod_cuota;
        private System.Windows.Forms.TextBox txtNum_venta;
        private System.Windows.Forms.ComboBox cbMesCUOTA;
        private System.Windows.Forms.ComboBox cbAñoCUOTA;
        private System.Windows.Forms.ComboBox cbAñoVENTA;
        private System.Windows.Forms.ComboBox cbMesVENTA;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnUlt7diasCUOTA;
        private System.Windows.Forms.Button btnHoyCUOTA;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
    }
}