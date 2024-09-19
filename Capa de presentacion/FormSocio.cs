using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Control_Gym.Capa_de_datos;
using Control_Gym.Capa_logica;



namespace Control_Gym.Capa_de_presentacion
{
    public partial class FormSocio : Form
    {
        CMembresiaD cMembresiaD = new CMembresiaD();
        CSociosD cSociosD = new CSociosD();
        private FormContenedor formContenedor;

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
                        oClsSocio.GuardarSocio(dni, nombre, apellido, fechaNacimiento, telefono, domicilio, email);
                        dgvSocios.DataSource = oClsSocio.CargarDatos();

                        limpiarCampos();
                        CancelarModificar();
                        formContenedor.SeleccionarBotonMembresias();
                        ocultarElementos();
                        AbrirFormEnPanel(new FormMembresias(dni));
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
                int dni = Convert.ToInt32(txtDniSocio.Text);
                string nombre = txtNombreSocio.Text;
                string apellido = txtApellidoSocio.Text;
                DateTime fechaNacimiento = dtpFechaNacimiento.Value;
                string telefono = txtTelefonoSocio.Text;
                string domicilio = txtDomicilio.Text;
                string email = txtEmail.Text;
                
                ClsSocio oclsSocio = new ClsSocio();
                oclsSocio.ModificarSocio(dni, nombre, apellido, fechaNacimiento, telefono, domicilio, email);
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
                dgvSocios.Columns[0].HeaderText = "DNI";
                dgvSocios.Columns[1].HeaderText = "Nombre";
                dgvSocios.Columns[2].HeaderText = "Apellido";
                dgvSocios.Columns[3].HeaderText = "Teléfono";
                dgvSocios.Columns[4].HeaderText = "Fecha de Nacimiento";
                dgvSocios.Columns[5].HeaderText = "Domicilio";
                dgvSocios.Columns[6].HeaderText = "E-mail";

                CancelarModificar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar socios: " + ex.Message);
            }
        }

        private void dgvSocios_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnGuardar.Visible = false;
            btnCancelar.Visible = true;
            btnBorrar.Visible = true;
            btnModificar.Visible = true;
            
            txtDniSocio.Text = dgvSocios.SelectedCells[0].Value.ToString();
            txtNombreSocio.Text = dgvSocios.SelectedCells[1].Value.ToString();
            txtApellidoSocio.Text = dgvSocios.SelectedCells[2].Value.ToString();
            txtTelefonoSocio.Text = dgvSocios.SelectedCells[3].Value.ToString();
            dtpFechaNacimiento.Text = dgvSocios.SelectedCells[4].Value.ToString();
            txtDomicilio.Text = dgvSocios.SelectedCells[5].Value.ToString();
            txtEmail.Text = dgvSocios.SelectedCells[6].Value.ToString();

            txtDniSocio.ReadOnly = true;
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
    }
}
