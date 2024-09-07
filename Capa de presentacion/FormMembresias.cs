using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Control_Gym.Capa_de_datos;
using Control_Gym.Capa_logica;

namespace Control_Gym.Capa_de_presentacion
{
    public partial class FormMembresias : Form
    {
        private ConexionBD conexionBD = ConexionBD.Instancia;

        private int dni_socio;

        public FormMembresias()
        {
            InitializeComponent();
        }
        public FormMembresias(int dni_socio)
        {
            InitializeComponent();
            this.dni_socio = dni_socio;
        }
        private CTipoMembresia cTipoMembresia = new CTipoMembresia();
        private CMembresia cMembresia = new CMembresia();

        private void CargarGrilla()
        {
            try
            {
                List<CTipoMembresia> tipos = cTipoMembresia.traerTipos();
                List<CMembresia> membresias = cMembresia.TraerMembresias();

                cbTipoMembresia.DataSource = tipos;
                dvgMembresias.DataSource = membresias;
                dvgMembresias.Columns[0].HeaderText = "ID";
                dvgMembresias.Columns[0].Width = 55;
                dvgMembresias.Columns[1].Visible = false;
                dvgMembresias.Columns[2].HeaderText = "Dni del socio";
                dvgMembresias.Columns[3].HeaderText = "Fecha de inicio";
                dvgMembresias.Columns[4].HeaderText = "Fecha de fin";
                dvgMembresias.Columns[5].HeaderText = "Tipo de membresia";
                dvgMembresias.Columns[6].HeaderText = "Precio";
                dvgMembresias.Columns[7].HeaderText = "Dias de duración";
                dvgMembresias.Columns[7].Width = 120;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la grilla: " + ex.Message);
            }
        }

        private void FormMembresias_Load(object sender, EventArgs e)
        {
            btnCancelarMembresia.Visible = false;
            btnActualizarMembresia.Visible = false;
            btnEliminarMembresia.Visible = false;
            dtpFechaFin.Value = dtpFechaFin.Value.AddDays(cMembresia.cantidad_dias);
            dvgMembresias.CellFormatting += dvgMembresias_CellFormatting;
            CargarGrilla();

            if (dni_socio == 0)
            {
                txtDniMembresia.Text = "";
            }
            else
            {
                txtDniMembresia.Text = dni_socio.ToString();
            }
        }

        public void CancelarModificar()
        {
            btnCrearMembresia.Visible = true;
            btnActualizarMembresia.Visible = false;
            btnEliminarMembresia.Visible = false;
            btnCancelarMembresia.Visible = false;

            txtDniMembresia.ReadOnly = false;
        }

        public void LimpiarCampos()
        {
            txtDniMembresia.Text = "";
            cbTipoMembresia.Text = "";
            dtpFechaInicio.Value = DateTime.Now;
        }

        private void btnCrearMembresia_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDniMembresia.Text != "" && cbTipoMembresia.Text != "")
                {
                    CMembresia cMembresia = new CMembresia(Convert.ToInt32(cTipoMembresia.cod_tipo_membresia), Convert.ToInt32(txtDniMembresia.Text), DateTime.Parse(dtpFechaInicio.Value.ToString("yyyy/MM/dd")), DateTime.Parse(dtpFechaFin.Value.ToString("yyyy/MM/dd")));
                    CMembresiaD cMembresiaD = new CMembresiaD();

                    bool existe = cMembresiaD.SocioExiste(cMembresia.dni_socio);

                    int cod_tipo_membresia = cbTipoMembresia.SelectedIndex+1;
                    int dni = Convert.ToInt32(txtDniMembresia.Text);

                    bool TieneTipoMembresia = cMembresiaD.TieneTipoMembresia(dni, cod_tipo_membresia);

                    if (existe)
                    { 
                        if (!TieneTipoMembresia)
                        {
                            cMembresia.CrearMembresia(cMembresia);
                            LimpiarCampos();
                            CargarGrilla();
                            MessageBox.Show("Membresía creada correctamente");
                        }
                        else
                        {
                            MessageBox.Show("El socio ya tiene cargado una membresia de ese tipo.", "alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            LimpiarCampos();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El socio con el DNI especificado no existe en la base de datos.", "alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        LimpiarCampos();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor complete todos los campos", "alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la membresía: " + ex.Message);
            }
        }

        private void btnEliminarMembresia_Click(object sender, EventArgs e)
        {
            try
            {
                if (dvgMembresias.SelectedRows.Count > 0)
                {
                    DataGridViewRow filaSeleccionada = dvgMembresias.SelectedRows[0];
                    int id = Convert.ToInt32(filaSeleccionada.Cells["cod_membresia"].Value);
                    EliminarCuota(id);
                    cMembresia.EliminarMembresia(id);
                    CargarGrilla();
                    LimpiarCampos();
                    CancelarModificar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la membresía: " + ex.Message);
            }
        }

        private void cbTipoMembresia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoMembresia.SelectedItem != null)
            {
                CTipoMembresia tipoSeleccionado = (CTipoMembresia)cbTipoMembresia.SelectedItem;
                int cod_tipo_membresia = tipoSeleccionado.cod_tipo_membresia;
                cTipoMembresia.cod_tipo_membresia = cod_tipo_membresia;

                int cantidadDias = tipoSeleccionado.cantidad_dias;

                DateTime fechaInicio = dtpFechaInicio.Value;

                DateTime fechaFin = fechaInicio.AddDays(cantidadDias);

                dtpFechaFin.Value = fechaFin;
            }
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtpFechaInicio.Value != null)
                {
                    CTipoMembresia tipoSeleccionado = (CTipoMembresia)cbTipoMembresia.SelectedItem;
                    int cantidadDias = tipoSeleccionado.cantidad_dias;
                    DateTime fechaInicio = dtpFechaInicio.Value;
                    DateTime fechaFin = fechaInicio.AddDays(cantidadDias);
                    dtpFechaFin.Value = fechaFin;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado" + ex);
            }
        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dvgMembresias_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 4)
            {
                DateTime fechaFin = (DateTime)dvgMembresias.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                DateTime hoy = DateTime.Now;

                TimeSpan diferencia = fechaFin - hoy;

                if (diferencia.TotalDays < -1)
                {
                    dvgMembresias.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Salmon;
                }
                else if (diferencia.TotalDays <= 5)
                {
                    dvgMembresias.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Yellow;
                }
                else
                {
                    dvgMembresias.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightGreen;
                }
            }
        }

        private void btnActualizarMembresia_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDniMembresia.Text != "")
                {
                    CMembresia cMembresiaG = new CMembresia(Convert.ToInt32(txtCodMembresia.Text), cTipoMembresia.cod_tipo_membresia, Convert.ToInt32(txtDniMembresia.Text), DateTime.Parse(dtpFechaInicio.Value.ToString("yyyy/MM/dd")), DateTime.Parse(dtpFechaFin.Value.ToString("yyyy/MM/dd")));
                    CMembresiaD cMembresiaD = new CMembresiaD();
                    bool existe = cMembresiaD.SocioExiste(cMembresiaG.dni_socio);
                    if (existe)
                    {
                        cMembresia.EditarMembresia(cMembresiaG);
                        CargarGrilla();
                        LimpiarCampos();
                        CancelarModificar();
                    }
                    else
                    {
                        MessageBox.Show("El socio con el DNI especificado no existe en la base de datos. Primero haga el alta del socio.", "alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor ingrese el DNI", "alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la membresía: " + ex.Message);
            }
        }

        private void btnCancelarMembresia_Click(object sender, EventArgs e)
        {
            try
            {
                CancelarModificar();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cancelar la modificación: " + ex.Message);
            }
        }

        private void dvgMembresias_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dvgMembresias.SelectedRows.Count > 0)
                {
                    btnCrearMembresia.Visible = false;
                    btnCancelarMembresia.Visible = true;
                    btnActualizarMembresia.Visible = true;
                    btnEliminarMembresia.Visible = true;

                    txtDniMembresia.ReadOnly = true;

                    DataGridViewRow filaSeleccionada = dvgMembresias.SelectedRows[0];
                    txtCodMembresia.Text = filaSeleccionada.Cells["cod_membresia"].Value.ToString();
                    cbTipoMembresia.Text = filaSeleccionada.Cells["nombre_tipo"].Value.ToString();

                    txtDniMembresia.Text = filaSeleccionada.Cells["dni_socio"].Value.ToString();
                    dtpFechaInicio.Text = filaSeleccionada.Cells["fecha_inicio"].Value.ToString();
                    dtpFechaFin.Text = filaSeleccionada.Cells["fecha_fin"].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Selecciona una fila en la grilla antes de cargar los datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de la membresía: " + ex.Message);
            }
        }

        private void txtDniMembresia_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsDigit(e.KeyChar))
                {
                    string currentText = txtDniMembresia.Text;

                    if (currentText.Length + 1 > 8)
                    {
                        e.Handled = true;
                    }
                }
                else if (!char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
                if ((e.KeyChar >= 33 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
                {
                    MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtBuscarDni_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscarDni.Text != "")
                {
                    List<CMembresia> membresias = cMembresia.BuscarPorDNI(Convert.ToInt32(txtBuscarDni.Text));
                    dvgMembresias.DataSource = membresias;
                }
                else
                {
                    CargarGrilla();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar membresías: " + ex.Message);
            }
        }

        private void txtDniMembresia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtDniMembresia_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ((TextBox)sender).ContextMenuStrip = new ContextMenuStrip();
            }
        }

        private void cbTipoMembresia_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ((ComboBox)sender).ContextMenuStrip = new ContextMenuStrip();
            }
        }

        private void cbTipoMembresia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtDniMembresia_Click(object sender, EventArgs e)
        {
            if (txtDniMembresia.ReadOnly)
            {
                MessageBox.Show("No se puede modificar el DNI", "alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void EliminarCuota(int codMembresia)
        {
            try
            {
                // Eliminar la cuota
                string query = "DELETE FROM cuotas WHERE cod_membresia = @codMembresia";
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                comando.Parameters.AddWithValue("@codMembresia", codMembresia);
                comando.ExecuteNonQuery();
                MessageBox.Show("Se ha eliminado la cuota con código: " + codMembresia.ToString());
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
    }
}
