using Control_Gym.Capa_de_datos;
using Control_Gym.Capa_logica;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace Control_Gym.Capa_de_presentacion
{
    public partial class FormCaja : Form
    {
        private ConexionBD conexionBD = ConexionBD.Instancia;

        public FormCaja()
        {
            InitializeComponent();
        }

        private CVenta cVenta = new CVenta();
        private CCuotaD cCuotaD = new CCuotaD();

        private void FormCaja_Load(object sender, EventArgs e)
        {

        }

        public void LoadArtificial()
        {
            CargarVentas();
            CargarCuotas();
            CargarTotalesCuotas();

            CargarAnios();
            CargarMeses();


            btnVerDetalle.Visible = false;
            btnBorrarCuota.Visible = false;
            btnBorrarVenta.Visible = false;
        }

        private void CargarCuotas()
        {
            dgvCuotas.DataSource = cCuotaD.ObtenerCuotas("HOY");

            // Ocultar ID
            dgvCuotas.Columns["Id"].Visible = false;

            // Formato fecha
            dgvCuotas.Columns["Fecha de pago"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // Formato moneda SIN símbolo $
            dgvCuotas.Columns["Monto"].DefaultCellStyle.Format = "N0";

            // Alineaciones
            dgvCuotas.Columns["DNI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCuotas.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCuotas.Columns["Fecha de pago"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvCuotas.AutoResizeColumns();
            dgvCuotas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarVentas()
        {
            DataTable tablaVentas = cVenta.TraerVentas();
            dgvVentas.DataSource = tablaVentas;

            // Configuración de las columnas
            dgvVentas.Columns[0].HeaderText = "N° Venta";
            dgvVentas.Columns[1].HeaderText = "DNI Cliente";
            dgvVentas.Columns[2].HeaderText = "DNI Empleado";
            dgvVentas.Columns[3].HeaderText = "Fecha";
            dgvVentas.Columns[4].HeaderText = "Total";

            dgvVentas.AutoResizeColumns();
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Actualización de los totales
            lblVentasResult.Text = cVenta.ObtenerTotal().ToString();
            lblTotalMesResult.Text = cVenta.ObtenerTotalMesActual().ToString();
            lblTotalHoyResult.Text = cVenta.ObtenerTotalHoy().ToString();
        }

        private void CargarTotalesCuotas()
        {
            DataTable tabla = cCuotaD.TraerTotalesCuotas();

            if (tabla.Rows.Count > 0)
            {
                var cultura = new CultureInfo("es-AR");

                decimal totalGeneral = Convert.ToDecimal(tabla.Rows[0]["TotalGeneral"]);
                decimal totalMes = Convert.ToDecimal(tabla.Rows[0]["TotalMes"]);
                decimal totalHoy = Convert.ToDecimal(tabla.Rows[0]["TotalHoy"]);

                lblTotalCuotasResult.Text = totalGeneral.ToString("N0", cultura);
                lblTotalMesCuotaResult.Text = totalMes.ToString("N0", cultura);
                lblTotalHoyCuotasResult.Text = totalHoy.ToString("N0", cultura);
            }
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (dgvVentas.SelectedRows.Count > 0)
            {
                int num_venta = Convert.ToInt32(dgvVentas.SelectedRows[0].Cells["num_venta"].Value);

                FormVerDetalle formDetalle = new FormVerDetalle(num_venta);

                DialogResult result = formDetalle.ShowDialog();

                btnVerDetalle.Visible = false;
            }
        }

        private void dgvVentas_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvVentas.SelectedRows.Count > 0)
            {
                txtNum_venta.Text = dgvVentas.SelectedCells[0].Value.ToString();

                btnVerDetalle.Visible = true;
                btnBorrarVenta.Visible = true;
            }
        }

        private void dgvCuotas_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvCuotas.SelectedRows.Count > 0)
            {
                txtCod_cuota.Text = dgvCuotas.SelectedCells[0].Value.ToString();

                btnBorrarCuota.Visible = true;
            }
        }

        private void btnBorrarVenta_Click(object sender, EventArgs e)
        {
            btnBorrarVenta.Visible = false;

            if (!string.IsNullOrEmpty(txtNum_venta.Text))
            {
                int numVenta;
                if (int.TryParse(txtNum_venta.Text, out numVenta))
                {
                    EliminarVenta(numVenta);
                }
                else
                {
                    MessageBox.Show("El número de venta debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un número de venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrarCuota_Click(object sender, EventArgs e)
        {
            btnBorrarCuota.Visible = false;

            if (!string.IsNullOrEmpty(txtCod_cuota.Text))
            {
                int codCuota;
                if (int.TryParse(txtCod_cuota.Text, out codCuota))
                {
                    EliminarCuota(codCuota);
                    dgvCuotas.DataSource = cCuotaD.ObtenerCuotas("HOY");
                }
                else
                {
                    MessageBox.Show("El código de la cuota debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un código de cuota.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void EliminarVenta(int numVenta)
        {
            try
            {
                // Eliminar detalles de la venta
                string queryDetalles = "DELETE FROM detalles_ventas WHERE num_venta = @numVenta";
                SqlCommand comandoDetalles = new SqlCommand(queryDetalles, conexionBD.AbrirConexion());
                comandoDetalles.Parameters.AddWithValue("@numVenta", numVenta);
                comandoDetalles.ExecuteNonQuery();

                // Eliminar la venta
                string queryVenta = "DELETE FROM ventas WHERE num_venta = @numVenta";
                SqlCommand comandoVenta = new SqlCommand(queryVenta, conexionBD.AbrirConexion());
                comandoVenta.Parameters.AddWithValue("@numVenta", numVenta);
                comandoVenta.ExecuteNonQuery();

                MessageBox.Show("Se ha eliminado la venta con número: " + numVenta.ToString());

                CargarVentas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la venta: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        public void EliminarCuota(int codCuota)
        {
            try
            {
                // Eliminar la cuota
                string query = "DELETE FROM cuotas WHERE cod_cuota = @codCuota";
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                comando.Parameters.AddWithValue("@codCuota", codCuota);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la cuota: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        private void btnVerInformes_Click(object sender, EventArgs e)
        {
            FormInformes formInformes = new FormInformes();
            formInformes.ShowDialog();
        }

        private void CargarAnios()
        {
            cbAñoCUOTA.Items.Clear();

            int añoActual = DateTime.Now.Year;

            for (int i = añoActual - 5; i <= añoActual; i++)
            {
                cbAñoCUOTA.Items.Add(i);
            }

            cbAñoCUOTA.SelectedItem = añoActual;
        }

        private void CargarMeses()
        {
            cbMesCUOTA.Items.Clear();

            cbMesCUOTA.Items.Add("Enero");
            cbMesCUOTA.Items.Add("Febrero");
            cbMesCUOTA.Items.Add("Marzo");
            cbMesCUOTA.Items.Add("Abril");
            cbMesCUOTA.Items.Add("Mayo");
            cbMesCUOTA.Items.Add("Junio");
            cbMesCUOTA.Items.Add("Julio");
            cbMesCUOTA.Items.Add("Agosto");
            cbMesCUOTA.Items.Add("Septiembre");
            cbMesCUOTA.Items.Add("Octubre");
            cbMesCUOTA.Items.Add("Noviembre");
            cbMesCUOTA.Items.Add("Diciembre");

            cbMesCUOTA.SelectedIndex = DateTime.Now.Month - 1;
        }

        private void cbAñoCUOTA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAñoCUOTA.SelectedItem == null)
                return;

            int año = Convert.ToInt32(cbAñoCUOTA.SelectedItem);

            // Ignora el mes completamente
            dgvCuotas.DataSource = cCuotaD.ObtenerCuotas("AÑO", null, año);
        }

        private void cbMesCUOTA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMesCUOTA.SelectedItem == null)
                return;

            if (cbAñoCUOTA.SelectedItem == null)
            {
                MessageBox.Show("Primero selecciona un año");
                return;
            }

            int mes = cbMesCUOTA.SelectedIndex + 1;
            int año = Convert.ToInt32(cbAñoCUOTA.SelectedItem);

            dgvCuotas.DataSource = cCuotaD.ObtenerCuotas("MES", mes, año);
        }

        private void btnHoyCUOTA_Click(object sender, EventArgs e)
        {
            dgvCuotas.DataSource = cCuotaD.ObtenerCuotas("HOY");
        }

        private void btnUlt7diasCUOTA_Click(object sender, EventArgs e)
        {
            dgvCuotas.DataSource = cCuotaD.ObtenerCuotas("ULTIMOS7DIAS");
        }
    }
}
