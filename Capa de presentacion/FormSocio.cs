using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Control_Gym.Capa_de_datos;
using Control_Gym.Capa_logica;
using libzkfpcsharp;
using Sample;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;



namespace Control_Gym.Capa_de_presentacion
{
    public partial class FormSocio : Form
    {
        CMembresiaD cMembresiaD = new CMembresiaD();
        CSociosD cSociosD = new CSociosD();
        private FormContenedor formContenedor;

        private ClsHuella cHuella = new ClsHuella();


        public FormSocio(FormContenedor contenedor)
        {
            InitializeComponent();
            formContenedor = contenedor;
        }

        private void AbrirFormEnPanel(object Formhijo)
        {
            try
            {
                if (this.panelContenedor.Controls.Count > 0)
                    this.panelContenedor.Controls.RemoveAt(0);
                Form fh = Formhijo as Form;
                fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;
                this.panelContenedor.Controls.Add(fh);
                this.panelContenedor.Tag = fh;
                fh.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario en el panel: " + ex.Message);
            }
        }

        private void ocultarElementos()
        {
            lblDni.Visible = false;
            lblNombre.Visible = false;
            lblApellido.Visible = false;
            lblTelefono.Visible = false;
            lblFechaNacimiento.Visible = false;
            lblDomicilio.Visible = false;
            lblEmail.Visible = false;

            txtDniSocio.Visible = false;
            txtNombreSocio.Visible = false;
            txtApellidoSocio.Visible = false;
            dtpFechaNacimiento.Visible = false;
            txtTelefonoSocio.Visible = false;
            txtDomicilio.Visible = false;
            txtEmail.Visible = false;
            txtBuscarSocio.Visible = false;

            dgvSocios.Visible = false;

            btnGuardar.Visible = false;
            btnCancelar.Visible = false;
            btnBorrar.Visible = false;
            btnModificar.Visible = false;
            btnRegistrarHuella.Visible = false;
            btnCancelarRegHuella.Visible = false;
        }

        private void dtpFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDniSocio.Text != "" && txtNombreSocio.Text != "" && txtApellidoSocio.Text != "")
                {
                    ClsSocio oClsSocio = new ClsSocio();

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
                        MessageBox.Show("El DNI ya está en uso. No se puede crear el socio.", "alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    else
                    {
                        int idSocio = oClsSocio.GuardarSocio(dni, nombre, apellido, fechaNacimiento, telefono, domicilio, email);
                        dgvSocios.DataSource = oClsSocio.CargarDatos();

                        MessageBox.Show("Socio registrado correctamente. Ahora registre las huellas.");

                        limpiarCampos();
                        CancelarModificar();

                    }
                }
                else
                {
                    MessageBox.Show("Por favor complete los campos obligatorios", "alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                ClsSocio clsSocio = new ClsSocio();
                string nombre = txtNombreSocio.Text;
                int dni = Convert.ToInt32(txtDniSocio.Text);

                bool MembresiaActiva = cSociosD.MembresiaActiva(dni);

                if (MembresiaActiva)
                {
                    MessageBox.Show("No se puede eliminar el socio porque tiene una membresía activa", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    limpiarCampos();
                    CancelarModificar();
                }
                else
                {
                    clsSocio.EliminarDatos(dni, nombre);
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

        private void FormSocio_Load(object sender, EventArgs e)
        {
            try
            {


                OcultarAdvertencia();
                ClsSocio clsSocio = new ClsSocio();

                dgvSocios.DataSource = clsSocio.CargarDatos();
                //dgvSocios.Columns[0].HeaderText = "ID";
                dgvSocios.Columns[0].Visible = false;
                dgvSocios.Columns[1].HeaderText = "DNI";
                dgvSocios.Columns[2].HeaderText = "Nombre";
                dgvSocios.Columns[3].HeaderText = "Apellido";
                dgvSocios.Columns[4].HeaderText = "Teléfono";
                dgvSocios.Columns[5].HeaderText = "Fecha de Nacimiento";
                dgvSocios.Columns[6].HeaderText = "Domicilio";
                dgvSocios.Columns[7].HeaderText = "E-mail";
                btnRegistrarHuella.Visible = false;
                btnResetearHuella.Visible = false;

                CancelarModificar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar socios: " + ex.Message);
            }
        }

        private void dgvSocios_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtIdSocio.Text = dgvSocios.SelectedCells[0].Value.ToString(); //AGREGO id_socio DEL INPUT INVISIBLE PARA QUE SE HAGAN
                                                                           //LAS CONDICIONES POR ESTE CAMPO EN LUGAR DEL DNI (POR EJ. EN EL WHERE DEL BORRAR)
            if (cSociosD.VerificarSiYaTieneHuella(Convert.ToInt32(txtIdSocio.Text)))
            {
                btnResetearHuella.Visible = true;
                btnRegistrarHuella.Visible = false;
            }
            else
            {
                btnRegistrarHuella.Visible = true; // No tiene huella entonces muestra el boton para registrar.
                btnResetearHuella.Visible = false;
            }
            btnGuardar.Visible = false;
            btnCancelar.Visible = true;
            btnBorrar.Visible = true;
            btnModificar.Visible = true;
            btnCancelarRegHuella.Visible = false;


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

        private void btnBuscarSocio_Click(object sender, EventArgs e)
        {

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
            btnGuardar.Visible = true;
            btnCancelar.Visible = false;
            btnBorrar.Visible = false;
            btnModificar.Visible = false;

            txtDniSocio.ReadOnly = false;

        }

        private void limpiarCampos()
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

        private void dgvSocios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRegistrarHuella_Click(object sender, EventArgs e)
        {
            Program.isRegistering = true;
            if (Program.isRegistering)
            {
                btnModificar.Visible = false;
                btnGuardar.Visible = false;
                btnCancelar.Visible = false;
                btnRegistrarHuella.Enabled = false;
                btnCancelarRegHuella.Visible = true;
                dgvSocios.Enabled = false;
                btnBorrar.Visible = false;
                textRes.Text = $"Por favor, presiona el mismo dedo {Program.REGISTER_FINGER_COUNT} veces";
            }
        }

        private void FormSocio_Activated(object sender, EventArgs e)
        {
            Program.isRegistering = true;
            Program.isIdentifying = false;
        }

        private void FormSocio_Deactivate(object sender, EventArgs e)
        {
            Program.isRegistering = false;
            Program.isIdentifying = true;
        }

        public void ActualizarHuella(Bitmap huellaBitmap)
        {
            if (picHuella.InvokeRequired)
            {
                picHuella.Invoke((MethodInvoker)delegate
                {
                    picHuella.Image = huellaBitmap;
                });
            }
            else
            {
                picHuella.Image = huellaBitmap;
            }
        }

        private void btnCancelarRegHuella_Click(object sender, EventArgs e)
        {
            textRes.Text = "";
            Program.isRegistering = false;
            btnRegistrarHuella.Enabled = true;
            btnResetearHuella.Visible = false;
            btnCancelarRegHuella.Visible = false;
            dgvSocios.Enabled = true;
            btnModificar.Visible = true;
            btnGuardar.Visible = true;
            btnCancelar.Visible = true;
            btnBorrar.Visible = true;
            picHuella.Image = null;
            // Reiniciar el contador de registros
            Program.RegisterCount = 0;

            // Reinicializar el array RegTmps
            if (Program.RegTmps != null)
            {
                Program.RegTmps = new byte[Program.REGISTER_FINGER_COUNT][];

                for (int i = 0; i < Program.REGISTER_FINGER_COUNT; i++)
                {
                    // Asignao un nuevo arreglo de bytes de tamaño 2048 a cada índice para que no quede null
                    Program.RegTmps[i] = new byte[2048];
                }
            }

            // Reinicializar el array de la huella capturada
            Program.CapTmp = new byte[2048];

            MessageBox.Show("Registro de huella digital cancelado.");

            Program.isIdentifying = true;
        }

        private void btnResetearHuella_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea resetear la huella?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (ResetearHuella(Convert.ToInt32(txtIdSocio.Text)))
                {
                    btnRegistrarHuella.Visible = true; // No tiene huella entonces muestra el boton para registrar.
                    btnResetearHuella.Visible = false;

                    MessageBox.Show("La huella ha sido reseteada exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al resetear las huellas");
                }
            }
            else if (result == DialogResult.No)
            {

                MessageBox.Show("La operación ha sido cancelada.", "Cancelación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool ResetearHuella(int id_socio)
        {
            if(id_socio > 0)
            {
                return cHuella.ResetearHuella(id_socio);
            }
            return false;
        }
    }
}
