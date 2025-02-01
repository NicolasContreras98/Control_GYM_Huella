namespace Control_Gym.Capa_de_presentacion
{
    partial class FormInformes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInformes));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.BarraTitulo = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnVerTodo = new System.Windows.Forms.Button();
            this.btnFiltrarPorAño = new System.Windows.Forms.Button();
            this.btnFiltrarPorMes = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAño = new System.Windows.Forms.ComboBox();
            this.lblCantSocios = new System.Windows.Forms.Label();
            this.lblCantCuotas = new System.Windows.Forms.Label();
            this.chartMembresias = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chartVentas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMembresias)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // BarraTitulo
            // 
            this.BarraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BarraTitulo.Controls.Add(this.label4);
            this.BarraTitulo.Controls.Add(this.pictureBox1);
            this.BarraTitulo.Cursor = System.Windows.Forms.Cursors.Default;
            this.BarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.BarraTitulo.Name = "BarraTitulo";
            this.BarraTitulo.Size = new System.Drawing.Size(904, 39);
            this.BarraTitulo.TabIndex = 14;
            this.BarraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BarraTitulo_MouseDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 31);
            this.label4.TabIndex = 2;
            this.label4.Text = "Informes";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(861, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(5, 39);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(896, 433);
            this.tabControl1.TabIndex = 20;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.chartMembresias);
            this.tabPage1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(888, 402);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Membresias";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightGray;
            this.groupBox2.Controls.Add(this.btnVerTodo);
            this.groupBox2.Controls.Add(this.btnFiltrarPorAño);
            this.groupBox2.Controls.Add(this.btnFiltrarPorMes);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cbMes);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbAño);
            this.groupBox2.Controls.Add(this.lblCantSocios);
            this.groupBox2.Controls.Add(this.lblCantCuotas);
            this.groupBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(882, 112);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtros para las Membresias";
            // 
            // btnVerTodo
            // 
            this.btnVerTodo.BackColor = System.Drawing.Color.ForestGreen;
            this.btnVerTodo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerTodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerTodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerTodo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVerTodo.Location = new System.Drawing.Point(646, 44);
            this.btnVerTodo.Name = "btnVerTodo";
            this.btnVerTodo.Size = new System.Drawing.Size(123, 42);
            this.btnVerTodo.TabIndex = 38;
            this.btnVerTodo.Text = "Ver Todo";
            this.btnVerTodo.UseVisualStyleBackColor = false;
            this.btnVerTodo.Click += new System.EventHandler(this.btnVerTodo_Click);
            // 
            // btnFiltrarPorAño
            // 
            this.btnFiltrarPorAño.BackColor = System.Drawing.Color.ForestGreen;
            this.btnFiltrarPorAño.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrarPorAño.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrarPorAño.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrarPorAño.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFiltrarPorAño.Location = new System.Drawing.Point(517, 44);
            this.btnFiltrarPorAño.Name = "btnFiltrarPorAño";
            this.btnFiltrarPorAño.Size = new System.Drawing.Size(123, 42);
            this.btnFiltrarPorAño.TabIndex = 37;
            this.btnFiltrarPorAño.Text = "Filtrar por Año";
            this.btnFiltrarPorAño.UseVisualStyleBackColor = false;
            this.btnFiltrarPorAño.Click += new System.EventHandler(this.btnFiltrarPorAño_Click);
            // 
            // btnFiltrarPorMes
            // 
            this.btnFiltrarPorMes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnFiltrarPorMes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrarPorMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrarPorMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrarPorMes.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFiltrarPorMes.Location = new System.Drawing.Point(388, 44);
            this.btnFiltrarPorMes.Name = "btnFiltrarPorMes";
            this.btnFiltrarPorMes.Size = new System.Drawing.Size(123, 42);
            this.btnFiltrarPorMes.TabIndex = 36;
            this.btnFiltrarPorMes.Text = "Filtrar por Mes";
            this.btnFiltrarPorMes.UseVisualStyleBackColor = false;
            this.btnFiltrarPorMes.Click += new System.EventHandler(this.btnFiltrarPorMes_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(6, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Cant. Cuotas:";
            // 
            // cbMes
            // 
            this.cbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbMes.FormattingEnabled = true;
            this.cbMes.Items.AddRange(new object[] {
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
            this.cbMes.Location = new System.Drawing.Point(219, 70);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(138, 28);
            this.cbMes.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Cant. Socios:";
            // 
            // cbAño
            // 
            this.cbAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAño.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAño.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAño.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbAño.FormattingEnabled = true;
            this.cbAño.Location = new System.Drawing.Point(219, 33);
            this.cbAño.Name = "cbAño";
            this.cbAño.Size = new System.Drawing.Size(138, 28);
            this.cbAño.TabIndex = 25;
            // 
            // lblCantSocios
            // 
            this.lblCantSocios.AutoSize = true;
            this.lblCantSocios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantSocios.ForeColor = System.Drawing.Color.Black;
            this.lblCantSocios.Location = new System.Drawing.Point(128, 37);
            this.lblCantSocios.Name = "lblCantSocios";
            this.lblCantSocios.Size = new System.Drawing.Size(79, 20);
            this.lblCantSocios.TabIndex = 22;
            this.lblCantSocios.Text = "_______";
            // 
            // lblCantCuotas
            // 
            this.lblCantCuotas.AutoSize = true;
            this.lblCantCuotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantCuotas.ForeColor = System.Drawing.Color.Black;
            this.lblCantCuotas.Location = new System.Drawing.Point(128, 72);
            this.lblCantCuotas.Name = "lblCantCuotas";
            this.lblCantCuotas.Size = new System.Drawing.Size(79, 20);
            this.lblCantCuotas.TabIndex = 24;
            this.lblCantCuotas.Text = "_______";
            // 
            // chartMembresias
            // 
            chartArea3.Name = "ChartArea1";
            this.chartMembresias.ChartAreas.Add(chartArea3);
            this.chartMembresias.Location = new System.Drawing.Point(0, 118);
            this.chartMembresias.Name = "chartMembresias";
            series3.ChartArea = "ChartArea1";
            series3.Name = "Series1";
            this.chartMembresias.Series.Add(series3);
            this.chartMembresias.Size = new System.Drawing.Size(882, 285);
            this.chartMembresias.TabIndex = 20;
            this.chartMembresias.Text = "chart1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 441);
            this.panel1.TabIndex = 21;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(5, 475);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(899, 5);
            this.panel2.TabIndex = 22;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(899, 39);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(5, 436);
            this.panel3.TabIndex = 23;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chartVentas);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(888, 402);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Ventas";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chartVentas
            // 
            chartArea4.Name = "ChartArea1";
            this.chartVentas.ChartAreas.Add(chartArea4);
            this.chartVentas.Location = new System.Drawing.Point(8, 6);
            this.chartVentas.Name = "chartVentas";
            this.chartVentas.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series4.ChartArea = "ChartArea1";
            series4.Name = "Series1";
            this.chartVentas.Series.Add(series4);
            this.chartVentas.Size = new System.Drawing.Size(873, 390);
            this.chartVentas.TabIndex = 22;
            this.chartVentas.Text = "chart1";
            // 
            // FormInformes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(904, 480);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.BarraTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormInformes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormInformes";
            this.BarraTitulo.ResumeLayout(false);
            this.BarraTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMembresias)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BarraTitulo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblCantCuotas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCantSocios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMembresias;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.ComboBox cbAño;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnFiltrarPorAño;
        private System.Windows.Forms.Button btnFiltrarPorMes;
        private System.Windows.Forms.Button btnVerTodo;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVentas;
    }
}