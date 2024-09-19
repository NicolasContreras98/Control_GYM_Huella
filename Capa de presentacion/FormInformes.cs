using Control_Gym.Capa_de_datos;
using Control_Gym.Capa_logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Control_Gym.Capa_de_presentacion
{
    public partial class FormInformes : Form
    {
        private CVentaD cVentaD = new CVentaD();
        private CMembresiaD cMembresiaD = new CMembresiaD();

        public FormInformes()
        {
            InitializeComponent();
            CargarGraficoVentas();
            CargarGraficoMembresias();
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

        private void CargarGraficoMembresias()
        {
            // Configurar datos del gráfico de membresías
            chartMembresias.Series.Clear();
            Series series = chartMembresias.Series.Add("Membresías");
            series.ChartType = SeriesChartType.Column;  // Cambiar a gráfico de columnas

            // Obtener el total de membresías vendidas por mes
            Dictionary<string, int> membresiasPorMes = cMembresiaD.ObtenerTotalMembresiasPorMes();

            foreach (var membresia in membresiasPorMes)
            {
                // Agregar los puntos con el mes y el total recaudado
                DataPoint point = new DataPoint();
                point.SetValueXY(membresia.Key, membresia.Value);
                point.Label = $"{membresia.Value.ToString("C", new CultureInfo("es-AR"))}";
                series.Points.Add(point);
            }

            // Configurar el eje X y el eje Y
            var chartArea = chartMembresias.ChartAreas[0];

            // Quitar la cuadrícula
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
