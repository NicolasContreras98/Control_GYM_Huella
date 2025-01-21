using Control_Gym.Capa_de_datos;
using Control_Gym.Capa_logica;
using System;
using System.Data;
using System.Data.SqlClient;
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
            CargarVentas();
            CargarCuotas();

            btnVerDetalle.Visible = false;
            btnBorrarCuota.Visible = false;
            btnBorrarVenta.Visible = false;
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


        private void CargarCuotas()
        {
            DataTable tablaCuotas = cCuotaD.TraerCuotas();
            dgvCuotas.DataSource = tablaCuotas;

            // Configuración de las columnas
            dgvCuotas.Columns[0].HeaderText = "Cod. Cuota";
            dgvCuotas.Columns[1].HeaderText = "Fecha de Pago";
            dgvCuotas.Columns[2].HeaderText = "DNI Socio";
            dgvCuotas.Columns[3].HeaderText = "Tipo de Membresía";
            dgvCuotas.Columns[4].HeaderText = "Monto";

            dgvCuotas.AutoResizeColumns();
            dgvCuotas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Actualización de totales
            lblTotalCuotasResult.Text = cCuotaD.ObtenerTotal().ToString();
            lblTotalMesCuotaResult.Text = cCuotaD.ObtenerTotalMesActual().ToString();
            lblTotalHoyCuotasResult.Text = cCuotaD.ObtenerTotalHoy().ToString();
        }


        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (dgvVentas.SelectedRows.Count > 0)
            {
                int num_venta = Convert.ToInt32(dgvVentas.SelectedRows[0].Cells["num_venta"].Value);

                FormVerDetalle formDetalle = new FormVerDetalle(num_venta);

                DialogResult result = formDetalle.ShowDialog();

                btnVerDetalle.Visible=false;
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
                    CargarCuotas(); // Recarga los datos en el DataGridView de las cuotas
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

        private void lblTotalHoyCuotasResult_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalMesCuotaResult_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalCuotasResult_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtCod_cuota_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lblTotalHoyResult_Click_1(object sender, EventArgs e)
        {

        }

        public void LoadArtificial()
        {
            CargarVentas();
            CargarCuotas();

            btnVerDetalle.Visible = false;
            btnBorrarCuota.Visible = false;
            btnBorrarVenta.Visible = false;
        }
    }
}
