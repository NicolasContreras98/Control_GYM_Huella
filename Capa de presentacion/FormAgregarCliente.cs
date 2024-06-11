using Control_Gym.Capa_de_datos;
using Control_Gym.Capa_logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_Gym.Capa_de_presentacion
{
    public partial class FormAgregarCliente : Form
    {
        private string dni_cliente;
        public FormAgregarCliente(string dni_cliente)
        {
            InitializeComponent();
            this.dni_cliente = dni_cliente;
            txtDniCliente.Text = dni_cliente;
        }
        private ConexionBD conexionBD = ConexionBD.Instancia;

        public string DniCliente
        {
            get { return txtDniCliente.Text; }
            set { txtDniCliente.Text = value; }
        }

        public string Nombre
        {
            get { return txtNombre.Text.Trim(); }
            set { txtNombre.Text = value; }
        }

        public string Apellido
        {
            get { return txtApellido.Text.Trim(); }
            set { txtApellido.Text = value; }
        }

        public string Telefono
        {
            get { return txtTelefono.Text; }
            set { txtTelefono.Text = value; }
        }

        public string Domicilio
        {
            get { return txtDomicilio.Text.Trim(); }
            set { txtDomicilio.Text = value; }
        }

        public string Email
        {
            get { return txtEmail.Text.Trim(); }
            set { txtEmail.Text = value; }
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            // Validar campos requeridos
            if (string.IsNullOrWhiteSpace(DniCliente))
            {
                MessageBox.Show("El campo DNI Cliente es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(Nombre))
            {
                MessageBox.Show("El campo Nombre es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(Apellido))
            {
                MessageBox.Show("El campo Apellido es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "INSERT INTO clientes(dni_cliente, nombre, apellido, telefono, domicilio, email) VALUES (@dni_cliente, @nombre, @apellido, @telefono, @domicilio, @email)";
            try
            {
                using (SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion()))
                {
                    comando.Parameters.Add(new SqlParameter("@dni_cliente", DniCliente));
                    comando.Parameters.Add(new SqlParameter("@nombre", Nombre));
                    comando.Parameters.Add(new SqlParameter("@apellido", Apellido));
                    comando.Parameters.Add(new SqlParameter("@telefono", Telefono));
                    comando.Parameters.Add(new SqlParameter("@domicilio", Domicilio));
                    comando.Parameters.Add(new SqlParameter("@email", Email));

                    comando.ExecuteNonQuery();
                }

                MessageBox.Show("Cliente registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Error al registrar el cliente. Error SQL: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el cliente: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }



        private void iconminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void iconcerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtDniCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsDigit(e.KeyChar))
                {
                    string currentText = txtDniCliente.Text;

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

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            if ((e.KeyChar >= 33 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        private void txtDniCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtApellido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
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

        private void txtDniCliente_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ((TextBox)sender).ContextMenuStrip = new ContextMenuStrip();
            }
        }

        private void txtNombre_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ((TextBox)sender).ContextMenuStrip = new ContextMenuStrip();
            }
        }

        private void txtApellido_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ((TextBox)sender).ContextMenuStrip = new ContextMenuStrip();
            }
        }

        private void txtTelefono_MouseDown(object sender, MouseEventArgs e)
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
    }
}
