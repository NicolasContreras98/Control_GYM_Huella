using Control_Gym.Capa_de_datos;
using Control_Gym.Capa_logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_Gym.Capa_de_presentacion
{
    public partial class FormAcceso : Form
    {
        private ConexionBD conexionBD = ConexionBD.Instancia;
        private CAcceso cAcceso = new CAcceso();
        private CAccesoD cAccesoD = new CAccesoD();

        public FormAcceso()
        {
            InitializeComponent();
        }

        public string dni_empleado
        {
            get { return txtDniEmpleado.Text; }
            set { txtDniEmpleado.Text = value; }
        }

        public string contraseña
        {
            get { return txtContraseñaEmpleado.Text; }
            set { txtContraseñaEmpleado.Text = value; }
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDniEmpleado.Text != "" && txtContraseñaEmpleado.Text != "")
                {
                    CAcceso cAcc = new CAcceso(Convert.ToInt32(txtDniEmpleado.Text), txtContraseñaEmpleado.Text);
                    List<CAcceso> acceso = cAcceso.Login(cAcc);

                    if (acceso.Count > 0 && acceso[0] != null)
                    {
                        // Verificar si la licencia está activa
                        if (VerificarLicenciaEmpleado(Convert.ToInt32(txtDniEmpleado.Text)))
                        {
                            FormContenedor formContenedor = new FormContenedor(acceso[0].dni_empleado, acceso[0].nombre);

                            formContenedor.Show();

                            txtDniEmpleado.Text = "";
                            txtContraseñaEmpleado.Text = "";
                        }
                        else
                        {
                            // Si la licencia ha expirado, mostrar un mensaje de error
                            MessageBox.Show("Tu licencia ha expirado. Por favor, contacta con el administrador.", "Licencia Expirada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtDniEmpleado.Text = "";
                            txtContraseñaEmpleado.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Datos incorrectos.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtDniEmpleado.Text = "";
                        txtContraseñaEmpleado.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Uno de los campos está vacío", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión: " + ex.Message);
            }
        }

        private bool VerificarLicenciaEmpleado(int dniEmpleado)
        {
            string query = "SELECT Estado FROM Licencias WHERE dni_empleado = @dni_empleado AND FechaExpiracion >= GETDATE()";
            MostrarDiasRestantesLicencia(dniEmpleado);
            bool licenciaValida = false;



            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conexionBD.AbrirConexion()))
                {
                    cmd.Parameters.AddWithValue("@dni_empleado", dniEmpleado);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Verificar si el estado de la licencia es "Activa"
                            licenciaValida = reader["Estado"].ToString() == "Activa";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar la licencia: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion(); // Asegura cerrar la conexión
            }

            return licenciaValida;
        }

        private void MostrarDiasRestantesLicencia(int dniEmpleado)
        {
            string query = "SELECT DATEDIFF(day, GETDATE(), FechaExpiracion) AS DiasRestantes FROM Licencias WHERE dni_empleado = @dni_empleado AND Estado = 'Activa' AND FechaExpiracion >= GETDATE()";
            int diasRestantes = 0;

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conexionBD.AbrirConexion()))
                {
                    // Agregar parámetro a la consulta
                    cmd.Parameters.AddWithValue("@dni_empleado", dniEmpleado);

                    // Ejecutar el lector de datos
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Leer los días restantes de la licencia
                            diasRestantes = reader.GetInt32(reader.GetOrdinal("DiasRestantes"));
                        }
                    }
                }

                // Mostrar un MessageBox con el número de días restantes
                if (diasRestantes > 0)
                {
                    MessageBox.Show($"El empleado con DNI {dniEmpleado} tiene {diasRestantes} días de licencia restantes.", "Licencia ACTIVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error si ocurre una excepción
                MessageBox.Show("Error al obtener los días restantes de la licencia: " + ex.Message, "Error");
            }
            finally
            {
                // Asegurar que la conexión se cierre
                conexionBD.CerrarConexion();
            }
        }




        private void txtDniEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsDigit(e.KeyChar))
                {
                    string currentText = txtDniEmpleado.Text;

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

        private void txtContraseñaEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)(Keys.Enter))
                {
                    e.Handled = true;
                    btnIniciarSesion_Click(sender, e);
                }
                if (e.KeyChar == ' ')
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtDniEmpleado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtDniEmpleado_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ((TextBox)sender).ContextMenuStrip = new ContextMenuStrip();
            }
        }

        private void txtContraseñaEmpleado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtContraseñaEmpleado_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ((TextBox)sender).ContextMenuStrip = new ContextMenuStrip();
            }
        }

        private void txtContraseñaEmpleado_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDniEmpleado_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblDni_Click(object sender, EventArgs e)
        {

        }

        private void lblContraseña_Click(object sender, EventArgs e)
        {

        }
    }
}
