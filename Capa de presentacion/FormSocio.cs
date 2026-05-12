using System;
using System.Drawing;
using System.Windows.Forms;
using Control_Gym.Capa_de_datos;
using Control_Gym.Capa_logica;



namespace Control_Gym.Capa_de_presentacion
{
    public partial class FormSocio : Form
    {
        readonly CMembresiaD cMembresiaD = new CMembresiaD();
        readonly CSociosD cSociosD = new CSociosD();
        private readonly FormContenedor formContenedor;
        readonly ClsSocio oClsSocio = new ClsSocio();
        string metodo = Properties.Settings.Default.MetodoVerificacion;


        private ClsHuella cHuella = new ClsHuella();

        public FormSocio()
        {
            InitializeComponent();
        }

        private void FormSocio_Load(object sender, EventArgs e)
        {
            MostrarOcultarElementos();
            limpiarCampos();
            CancelarModificar();
            OcultarAdvertencia();
            CargarGrilla();
        }

        public void LoadArtificial()
        {
            MostrarOcultarElementos();
            limpiarCampos();
            CancelarModificar();
            OcultarAdvertencia();
            CargarGrilla();
        }

        public FormSocio(FormContenedor formContenedor)
        {
            InitializeComponent();
            this.formContenedor = formContenedor;
        }

        public void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string metodo = Properties.Settings.Default.MetodoVerificacion;

                bool huellaOk = true;
                byte[] huella = null;

                if (metodo == "Huella")
                {
                    huellaOk = Program.HuellaTemplate != null;
                    huella = Program.HuellaTemplate;
                }

                if (txtDniSocio.Text != "" &&
                    txtNombreSocio.Text != "" &&
                    txtApellidoSocio.Text != "" &&
                    huellaOk)
                {
                    int dni = Convert.ToInt32(txtDniSocio.Text);
                    string nombre = txtNombreSocio.Text.Trim();
                    string apellido = txtApellidoSocio.Text.Trim();
                    DateTime fechaNacimiento = dtpFechaNacimiento.Value;
                    string telefono = txtTelefonoSocio.Text;
                    string domicilio = txtDomicilio.Text.Trim();
                    string email = txtEmail.Text.Trim();

                    bool existeDNI = cMembresiaD.SocioExiste(dni);
                    bool existeEmail = cMembresiaD.EmailExiste(email);

                    if (existeDNI)
                    {
                        MessageBox.Show("El DNI ya está en uso.", "Alerta",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    oClsSocio.GuardarSocio(
                        dni, nombre, apellido, fechaNacimiento,
                        telefono, domicilio, email, huella);

                    dgvSocios.DataSource = oClsSocio.CargarDatos();

                    limpiarCampos();
                    CancelarModificar();
                    ResetearArrayDeHuellas();

                    formContenedor.SeleccionarBotonMembresias();
                    formContenedor.AbrirFormMembresias(dni);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Por favor complete los campos obligatorios",
                        "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar un socio: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                ClsSocio clsSocio = new ClsSocio();
                int id_socio = Convert.ToInt32(txtIdSocio.Text); //AGREGO id_socio 
                int dni = Convert.ToInt32(txtDniSocio.Text);
                string nombre = txtNombreSocio.Text;
                string apellido = txtApellidoSocio.Text;
                DateTime fechaNacimiento = dtpFechaNacimiento.Value;
                string telefono = txtTelefonoSocio.Text;
                string domicilio = txtDomicilio.Text;
                string email = txtEmail.Text;

                ClsSocio oclsSocio = new ClsSocio();
                oclsSocio.ModificarSocio(id_socio, nombre, apellido, fechaNacimiento, telefono, domicilio, email); //SACO dni PARA QUE VERIFIQUE POR id_socio
                dgvSocios.DataSource = clsSocio.CargarDatos();

                limpiarCampos();
                CancelarModificar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar socio: " + ex.Message);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Mostrar mensaje de confirmación
                DialogResult resultado = MessageBox.Show(
                    "¿Estás seguro de que deseas eliminar completamente al socio?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                // Si el usuario confirma la eliminación
                if (resultado == DialogResult.Yes)
                {
                    ClsSocio clsSocio = new ClsSocio();
                    int id_socio = Convert.ToInt32(txtIdSocio.Text);

                    // Llamar al método de eliminación sin necesidad de verificar si tiene huella o membresía activa
                    clsSocio.EliminarDatos(id_socio);
                    dgvSocios.DataSource = clsSocio.CargarDatos();

                    limpiarCampos();
                    CancelarModificar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar socio: " + ex.Message);
            }
        }

        private void CargarGrilla()
        {
            dgvSocios.DataSource = oClsSocio.CargarDatos();
            //dgvSocios.Columns[0].HeaderText = "ID";
            dgvSocios.Columns[0].Visible = false;
            dgvSocios.Columns[1].HeaderText = "DNI";
            dgvSocios.Columns[2].HeaderText = "Nombre";
            dgvSocios.Columns[3].HeaderText = "Apellido";
            dgvSocios.Columns[4].HeaderText = "Teléfono";
            dgvSocios.Columns[5].HeaderText = "Fecha de Creación";
            dgvSocios.Columns[6].HeaderText = "Domicilio";
            dgvSocios.Columns[7].HeaderText = "E-mail";

            dgvSocios.AutoResizeColumns();
            dgvSocios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvSocios_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtIdSocio.Text = dgvSocios.SelectedCells[0].Value.ToString(); //AGREGO id_socio DEL INPUT INVISIBLE PARA QUE SE HAGAN
                                                                           //LAS CONDICIONES POR ESTE CAMPO EN LUGAR DEL DNI (POR EJ. EN EL WHERE DEL BORRAR)

            if (metodo == "Lector de huellas")
            {
                if (cSociosD.VerificarSiYaTieneHuella(Convert.ToInt32(txtIdSocio.Text)))
                {
                    btnBorrarHuella.Visible = true;
                    btnRegistrarHuella.Visible = false;
                }
                else
                {
                    btnRegistrarHuella.Visible = true; // No tiene huella entonces muestra el boton para registrar.
                    btnBorrarHuella.Visible = false;
                }
            }
                

            btnGuardar.Visible = false;
            btnCancelar.Visible = true;
            btnBorrar.Visible = true;
            btnModificar.Visible = true;
            btnCancelarRegHuella.Visible = false;

            Program.isRegistering = false;
            Program.isIdentifying = false;
            Program.isModifiying = true;

            txtDniSocio.Text = dgvSocios.SelectedCells[1].Value.ToString();
            txtNombreSocio.Text = dgvSocios.SelectedCells[2].Value.ToString();
            txtApellidoSocio.Text = dgvSocios.SelectedCells[3].Value.ToString();
            txtTelefonoSocio.Text = dgvSocios.SelectedCells[4].Value.ToString();
            dtpFechaNacimiento.Text = dgvSocios.SelectedCells[5].Value.ToString();
            txtDomicilio.Text = dgvSocios.SelectedCells[6].Value.ToString();
            txtEmail.Text = dgvSocios.SelectedCells[7].Value.ToString();

            txtDniSocio.ReadOnly = true;
            Program.idSocioSeleccionado = Convert.ToInt32(txtIdSocio.Text);
        }

        private void txtBuscarSocio_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ClsSocio clsSocio = new ClsSocio();

                if (txtBuscarSocio.Text != "")
                {
                    string dni = txtBuscarSocio.Text;
                    dgvSocios.DataSource = clsSocio.Filtrar(dni);
                }
                else
                {
                    dgvSocios.DataSource = clsSocio.CargarDatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar socio: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarCampos();
                CancelarModificar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cancelar la operación: " + ex.Message);
            }
        }

        public void CancelarModificar()
        {
            txtBuscarSocio.Clear();
            btnGuardar.Enabled = true;
            btnGuardar.Visible = false;
            btnCancelar.Visible = false;
            btnBorrar.Visible = false;
            btnModificar.Visible = false;
            btnBorrarHuella.Visible = false;
            btnRegistrarHuella.Visible = false;
            btnCancelarRegHuella.Visible = false;
            txtDniSocio.ReadOnly = false;

            Program.idSocioSeleccionado = -1;
            Program.isRegistering = true;
            Program.isModifiying = false;
            Program.isIdentifying = false;
        }

        public void limpiarCampos()
        {
            txtDniSocio.Text = "";
            txtNombreSocio.Text = "";
            txtApellidoSocio.Text = "";
            txtTelefonoSocio.Text = "";
            dtpFechaNacimiento.Text = "";
            txtDomicilio.Text = "";
            txtEmail.Text = "";
        }

        private void MostrarAdvertencia()
        {
            label1.Visible = true;
            label2.Visible = true;
        }

        private void OcultarAdvertencia()
        {
            label1.Visible = false;
            label2.Visible = false;
        }

        private void txtDniSocio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                string currentText = txtDniSocio.Text;

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
                return;
            }
        }

        private void txtTelefonoSocio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            if ((e.KeyChar >= 33 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtDniSocio_Click(object sender, EventArgs e)
        {
            Program.isModifiying = false;
            Program.isIdentifying = false; 
            Program.isRegistering = true;

            btnGuardar.Visible = true;
            btnCancelar.Visible = true;


            if (txtDniSocio.ReadOnly)
            {
                MessageBox.Show("No se puede modificar el DNI", "alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MostrarAdvertencia();
            }
        }

        private void txtDniSocio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtNombreSocio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtApellidoSocio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtTelefonoSocio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtDomicilio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtDniSocio_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ((TextBox)sender).ContextMenuStrip = new ContextMenuStrip();
            }
        }

        private void txtNombreSocio_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ((TextBox)sender).ContextMenuStrip = new ContextMenuStrip();
            }
        }

        private void txtApellidoSocio_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ((TextBox)sender).ContextMenuStrip = new ContextMenuStrip();
            }
        }

        private void txtTelefonoSocio_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ((TextBox)sender).ContextMenuStrip = new ContextMenuStrip();
            }
        }

        private void txtDomicilio_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ((TextBox)sender).ContextMenuStrip = new ContextMenuStrip();
            }
        }

        private void txtEmail_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ((TextBox)sender).ContextMenuStrip = new ContextMenuStrip();
            }
        }

        private void txtDniSocio_Leave(object sender, EventArgs e)
        {
            OcultarAdvertencia();
        }

        public void btnRegistrarHuella_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.idSocioSeleccionado == -1)
                {
                    Program.isRegistering = true;

                    btnModificar.Visible = false;
                    btnGuardar.Enabled = false;
                    btnCancelar.Visible = false;
                    btnRegistrarHuella.Enabled = false;
                    btnCancelarRegHuella.Visible = true;
                    dgvSocios.Enabled = false;
                    btnBorrar.Visible = false;
                    textRes.Text = $"Presione el mismo dedo {Program.REGISTER_FINGER_COUNT} veces";
                }
                else
                {
                    Program.isModifiying = true;

                    btnModificar.Visible = false;
                    btnGuardar.Enabled = false;
                    btnCancelar.Visible = false;
                    btnRegistrarHuella.Enabled = false;
                    btnCancelarRegHuella.Visible = true;
                    dgvSocios.Enabled = false;
                    btnBorrar.Visible = false;
                    textRes.Text = $"Presione el mismo dedo {Program.REGISTER_FINGER_COUNT} veces";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al intentar registrar la huella: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetearArrayDeHuellas()
        {
            // Reiniciar el contador de registros
            Program.RegisterCount = 0;
            Program.REGISTER_FINGER_COUNT = 3;

            if (Program.RegTmps != null)
            {
                Program.RegTmps = new byte[Program.REGISTER_FINGER_COUNT][];

                for (int i = 0; i < Program.REGISTER_FINGER_COUNT; i++)
                {
                    // Asignar un nuevo arreglo de bytes de tamaño 2048 a cada índice para que no quede null
                    Program.RegTmps[i] = new byte[2048];
                }
            }

            // Reinicializar el array de la huella capturada
            Program.CapTmp = new byte[2048];
            Program.HuellaTemplate = new byte[2048];
        }

        public void btnCancelarRegHuella_Click(object sender, EventArgs e)
        {
            try
            {
                textRes.Text = "";
                btnRegistrarHuella.Visible = true;
                btnRegistrarHuella.Enabled = true;
                btnBorrarHuella.Visible = false;
                btnCancelarRegHuella.Visible = false;
                dgvSocios.Enabled = true;
                btnGuardar.Visible = false;
                btnGuardar.Enabled = true;
                picHuella.Image = null;

                ResetearArrayDeHuellas();

                Program.isRegistering = false;
                Program.isModifiying = false;
                Program.isIdentifying = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cancelar el registro de huella digital: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ResetearHuella(int id_socio)
        {
            try
            {
                if (id_socio > 0)
                {
                    return cHuella.ResetearHuella(id_socio);
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al intentar resetear la huella: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Devuelve false en caso de excepción.
            }
        }

        private void btnBorrarHuella_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Está seguro que desea borrar la huella?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (ResetearHuella(Convert.ToInt32(txtIdSocio.Text)))
                    {
                        CancelarModificar();
                        btnRegistrarHuella.Visible = true; // No tiene huella entonces muestra el boton para registrar.
                        btnBorrarHuella.Visible = false;

                        Program.idSocioSeleccionado = Convert.ToInt32(txtIdSocio.Text);
                        Program.isRegistering = false;
                        Program.isModifiying = true;
                        Program.isIdentifying = false;

                        MessageBox.Show("La huella ha sido borrada exitosamente. Registrela nuevamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnRegistrarHuella_Click(null, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show("Error al borrar las huellas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }
                }
                else if (result == DialogResult.No)
                {
                    CancelarModificar();
                    limpiarCampos();
                    MessageBox.Show("La operación ha sido cancelada.", "Cancelación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al intentar borrar la huella: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormSocio_Leave(object sender, EventArgs e)
        {
            CancelarModificar();
            btnCancelarRegHuella_Click(null, EventArgs.Empty);
        }

        private void txtNombreSocio_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.MetodoVerificacion == "Lector de huellas")
            {
                btnRegistrarHuella.Visible = true;
            }
        }

        private void txtApellidoSocio_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.MetodoVerificacion == "Lector de huellas")
            {
                btnRegistrarHuella.Visible = true;
            }
        }

        public void MostrarOcultarElementos()
        {
            if (string.IsNullOrEmpty(metodo))
            {
                metodo = "Lector de huellas";
            }

            if (metodo == "Teclado numérico")
            {
                btnRegistrarHuella.Visible = false;
                btnBorrarHuella.Visible = false;
                btnCancelarRegHuella.Visible = false;
                picHuella.Visible = false;
            }
            else
            {
                btnRegistrarHuella.Visible = true;
                btnBorrarHuella.Visible = true;
                btnCancelarRegHuella.Visible = true;
                picHuella.Visible = true;
            }
        }
    }
}
