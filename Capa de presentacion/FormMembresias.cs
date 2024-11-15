using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Control_Gym.Capa_de_datos;
using Control_Gym.Capa_logica;

namespace Control_Gym.Capa_de_presentacion
{
    public partial class FormMembresias : Form
    {
        private readonly ConexionBD conexionBD = ConexionBD.Instancia;
        private readonly CTipoMembresia cTipoMembresia = new CTipoMembresia();
        private readonly CMembresia cMembresia = new CMembresia();
        private readonly CSociosD cSociosD = new CSociosD();
        private readonly int dni_socio;

        public FormMembresias(int dni_socio)
        {
            InitializeComponent();
            this.dni_socio = dni_socio;
        }

        public FormMembresias()
        {
            InitializeComponent();
        }

        private void CargarGrilla()
        {
            try
            {
                // Cargar los tipos de membresía para el ComboBox
                List<CTipoMembresia> tipos = cTipoMembresia.traerTipos();
                cbTipoMembresia.DataSource = tipos;
                cbTipoMembresia.DisplayMember = "nombre";
                cbTipoMembresia.ValueMember = "cod_tipo_membresia";

                // Obtener el DataTable de membresías desde la capa lógica
                DataTable tablaMembresias = cMembresia.TraerMembresias();
                dvgMembresias.DataSource = tablaMembresias;

                // Verificar y configurar las columnas del DataGridView si existen
                if (dvgMembresias.Columns["cod_membresia"] != null)
                {
                    dvgMembresias.Columns["cod_membresia"].HeaderText = "ID";
                    dvgMembresias.Columns["cod_membresia"].Width = 55;
                }

                if (dvgMembresias.Columns["cod_tipo_membresia"] != null)
                    dvgMembresias.Columns["cod_tipo_membresia"].Visible = false;

                if (dvgMembresias.Columns["id_socio"] != null)
                    dvgMembresias.Columns["id_socio"].Visible = false;

                if (dvgMembresias.Columns["dni_socio"] != null)
                    dvgMembresias.Columns["dni_socio"].HeaderText = "DNI";

                if (dvgMembresias.Columns["nombre_completo"] != null)
                    dvgMembresias.Columns["nombre_completo"].HeaderText = "Nombre completo";

                if (dvgMembresias.Columns["fecha_inicio"] != null)
                    dvgMembresias.Columns["fecha_inicio"].HeaderText = "Fecha inicio";

                if (dvgMembresias.Columns["fecha_fin"] != null)
                    dvgMembresias.Columns["fecha_fin"].HeaderText = "Fecha fin";

                if (dvgMembresias.Columns["tipo_membresia"] != null)
                    dvgMembresias.Columns["tipo_membresia"].HeaderText = "Tipo de membresía";

                if (dvgMembresias.Columns["precio"] != null)
                    dvgMembresias.Columns["precio"].HeaderText = "Precio";

                if (dvgMembresias.Columns["cantidad_dias"] != null)
                {
                    dvgMembresias.Columns["cantidad_dias"].HeaderText = "Días de duración";
                    dvgMembresias.Columns["cantidad_dias"].Width = 120;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la grilla: " + ex.Message);
            }
        }

        private void FormMembresias_Load(object sender, EventArgs e)
        {
            dtpFechaFin.Value = dtpFechaFin.Value.AddDays(cMembresia.cantidad_dias);
            dvgMembresias.CellFormatting += dvgMembresias_CellFormatting;
            CargarGrilla();
            CancelarModificar();

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
            txtBuscarDni.Clear();
            btnCrearMembresia.Visible = false;
            btnActualizarMembresia.Visible = false;
            btnEliminarMembresia.Visible = false;
            btnCancelarMembresia.Visible = false;
            lblSocioAgregado.Visible = false;

            txtDniMembresia.ReadOnly = false;
        }

        public void LimpiarCampos()
        {
            txtDniMembresia.Text = "";
            cbTipoMembresia.Text = "";
            dtpFechaInicio.Value = DateTime.Now;
        }

        private async void MostrarSocioAgregado()
        {
            lblSocioAgregado.Visible = true;  // Muestra el label

            // Espera durante 3 segundos (3000 milisegundos)
            await Task.Delay(3000);

            lblSocioAgregado.Visible = false; // Oculta el label después de 3 segundos
        }

        private void btnCrearMembresia_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDniMembresia.Text != "" && cbTipoMembresia.Text != "")
                {
                    int cod_tipo_membresia = cbTipoMembresia.SelectedIndex + 1;
                    int dni = Convert.ToInt32(txtDniMembresia.Text);
                    ClsSocio socio = cSociosD.TraerIdSocioPorDni(dni);                                        

                    CMembresia cMembresia = new CMembresia(Convert.ToInt32(cTipoMembresia.cod_tipo_membresia), Convert.ToInt32(txtDniMembresia.Text), socio.Id_socio, DateTime.Parse(dtpFechaInicio.Value.ToString("yyyy/MM/dd")), DateTime.Parse(dtpFechaFin.Value.ToString("yyyy/MM/dd")));
                    CMembresiaD cMembresiaD = new CMembresiaD();

                    bool existe = cMembresiaD.SocioExiste(cMembresia.dni_socio);
                    //ClsSocio socio = cSociosD.TraerIdSocioPorDni(dni);
                    if (socio != null)
                    {
                        bool TieneTipoMembresia = cMembresiaD.TieneTipoMembresia(socio.Id_socio, cod_tipo_membresia);
                        if (existe)
                        { 
                            if (!TieneTipoMembresia)
                            {
                                cMembresia.CrearMembresia(cMembresia);
                                LimpiarCampos();
                                CargarGrilla();
                                CancelarModificar();

                                MostrarSocioAgregado();
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
                        MessageBox.Show("No existe un socio con ese DNI.");
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
            if (e.RowIndex >= 0 && e.ColumnIndex == 5) // Se cambia de 4 a 5
            {
                var cellValue = dvgMembresias.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (cellValue != null && DateTime.TryParse(cellValue.ToString(), out DateTime fechaFin))
                {
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
                else
                {
                    // Opcional: Color o estilo predeterminado si el valor no es una fecha válida
                    dvgMembresias.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
                }
            }
        }


        private void btnActualizarMembresia_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDniMembresia.Text != "")
                {
                    int dni = Convert.ToInt32(txtDniMembresia.Text);
                    ClsSocio socio = cSociosD.TraerIdSocioPorDni(dni);

                    CMembresia cMembresiaG = new CMembresia(Convert.ToInt32(txtCodMembresia.Text), cTipoMembresia.cod_tipo_membresia, dni,socio.Id_socio, DateTime.Parse(dtpFechaInicio.Value.ToString("yyyy/MM/dd")), DateTime.Parse(dtpFechaFin.Value.ToString("yyyy/MM/dd")));
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

                    // Verificar si la columna "cod_membresia" existe en el DataGridView
                    if (dvgMembresias.Columns.Contains("cod_membresia"))
                    {
                        // Acceder a la celda por nombre de columna
                        txtCodMembresia.Text = filaSeleccionada.Cells["cod_membresia"].Value?.ToString() ?? "";
                    }

                    // Verificar si la columna "tipo_membresia" existe en el DataGridView
                    cbTipoMembresia.Text = filaSeleccionada.Cells["tipo_membresia"].Value?.ToString() ?? "";

                    // Asignar los valores a los controles de la interfaz
                    txtDniMembresia.Text = filaSeleccionada.Cells["dni_socio"].Value?.ToString() ?? "";
                    dtpFechaInicio.Text = filaSeleccionada.Cells["fecha_inicio"].Value?.ToString() ?? DateTime.Now.ToString();
                    dtpFechaFin.Text = filaSeleccionada.Cells["fecha_fin"].Value?.ToString() ?? DateTime.Now.ToString();
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
                if (!string.IsNullOrEmpty(txtBuscarDni.Text))
                {
                    DataTable tablaMembresias = cMembresia.BuscarPorDNI(txtBuscarDni.Text);
                    dvgMembresias.DataSource = tablaMembresias;  // Asigna el DataTable como origen de datos
                }
                else
                {
                    CargarGrilla(); // Si no hay búsqueda, carga la grilla con todos los datos
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
            btnCrearMembresia.Visible = true;
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

        private void btnFechaHoy_Click(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Now;
        }

        private void txtDniMembresia_TextChanged(object sender, EventArgs e)
        {
            if (txtDniMembresia.ReadOnly)
            {
                btnCrearMembresia.Visible = false;
            }
            else
            {
                btnCrearMembresia.Visible = true;
            }
        }

        public void LoadArtificial()
        {
            CargarGrilla();
        }
    }
}
