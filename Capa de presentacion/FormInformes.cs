using Control_Gym.Capa_de_datos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Control_Gym.Capa_de_presentacion
{
    public partial class FormInformes : Form
    {
        private readonly CVentaD cVentaD = new CVentaD();
        private readonly CMembresiaD cMembresiaD = new CMembresiaD();
        private readonly int añoActual = DateTime.Now.Year;
        
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        


        public FormInformes()
        {
            InitializeComponent();
            CargarGraficoVentas();
            CargarGraficoMembresias(año: añoActual);
            CargarComboBox();
        }

        private void CargarGraficoVentas()
        {
            // Configurar datos del gráfico de ventas
            chartVentas.Series.Clear();
            Series series = chartVentas.Series.Add("Ventas");
            series.ChartType = SeriesChartType.Column;  // Cambiar a gráfico de columnas

            // Obtener el total de ventas por mes
            Dictionary<string, int> ventasPorMes = cVentaD.ObtenerTotalVentasPorMes();

            foreach (var venta in ventasPorMes)
            {
                // Agregar los puntos con el mes y el total de ventas
                DataPoint point = new DataPoint();
                point.SetValueXY(venta.Key, venta.Value);
                point.Label = $"{venta.Value.ToString("C", new CultureInfo("es-AR"))}";
                series.Points.Add(point);
            }

            // Configurar el eje X y el eje Y
            var chartArea = chartVentas.ChartAreas[0];

            // Quitar la cuadrícula
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
        }

        private void CargarGraficoMembresias(int? mes = null, int? año = null, bool agruparPorDia = false)
        {
            // Configurar datos del gráfico de membresías
            chartMembresias.Series.Clear();
            Series series = chartMembresias.Series.Add("Membresías");
            series.ChartType = SeriesChartType.Column; // Gráfico de columnas

            // Obtener el total de membresías vendidas (filtradas por mes y/o año, y agrupadas por día o mes)
            Dictionary<string, int> datos = cMembresiaD.ObtenerTotalMembresias(mes, año, agruparPorDia);

            // Crear una instancia de TextInfo para el idioma español
            TextInfo textInfo = new CultureInfo("es-ES", false).TextInfo;

            foreach (var item in datos)
            {
                DataPoint point = new DataPoint();
                string etiqueta = textInfo.ToTitleCase(item.Key.ToLower()); // Capitalizar primera letra
                point.SetValueXY(etiqueta, item.Value);

                // Formatear la etiqueta sin alterar el valor del gráfico
                point.Label = item.Value >= 1000 ? $"{item.Value / 1000} Mil" : item.Value.ToString();

                series.Points.Add(point);
            }

            // Configurar el eje X y el eje Y
            var chartArea = chartMembresias.ChartAreas[0];

            // Quitar la cuadrícula
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;

            // Formatear las etiquetas del eje X
            chartArea.AxisX.LabelStyle.Font = new Font("Arial", 10, FontStyle.Bold); // Negrita
            chartArea.AxisX.LabelStyle.Format = agruparPorDia ? "dd MMMM" : "MMMM yyyy"; // Formato de etiquetas en el eje X
            chartArea.AxisX.Interval = 1; // Mostrar todas las etiquetas

            // Obtener la cantidad de socios y cuotas
            int cantidadSocios = cMembresiaD.ObtenerCantidadSocios(mes, año);
            int cantidadCuotas = cMembresiaD.ObtenerCantidadCuotas(mes, año);

            // Actualizar los Label
            lblCantSocios.Text = $"{cantidadSocios}";
            lblCantCuotas.Text = $"{cantidadCuotas}";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CargarComboBox()
        {
            // Configurar el ComboBox para el año
            for (int año = añoActual - 5; año <= añoActual + 5; año++) // Rango de años (5 años atrás y 5 adelante)
            {
                cbAño.Items.Add(año);
            }
            cbAño.SelectedItem = añoActual; // Seleccionar el año actual
            cbMes.SelectedIndex = DateTime.Now.Month - 1; // Seleccionar el mes actual
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mover la ventana: " + ex.Message);
            }
        }

        private void btnFiltrarPorMes_Click(object sender, EventArgs e)
        {
            // Obtener el mes y año seleccionados desde los ComboBox
            int mesSeleccionado = cbMes.SelectedIndex + 1; // Los meses en ComboBox empiezan en 0
            int añoSeleccionado = (int)cbAño.SelectedItem;

            // Cargar el gráfico filtrado por mes y año
            CargarGraficoMembresias(mes: mesSeleccionado, año: añoSeleccionado, agruparPorDia: true);
        }

        private void btnFiltrarPorAño_Click(object sender, EventArgs e)
        {
            // Obtener el año seleccionado desde el ComboBox
            int añoSeleccionado = (int)cbAño.SelectedItem;

            // Cargar el gráfico filtrado por año
            CargarGraficoMembresias(año: añoSeleccionado, agruparPorDia: false);
        }

        private void btnVerTodo_Click(object sender, EventArgs e)
        {
            CargarGraficoMembresias();
        }
    }
}
