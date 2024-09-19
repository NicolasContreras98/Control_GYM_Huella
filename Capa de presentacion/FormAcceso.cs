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
                if (!string.IsNullOrWhiteSpace(txtDniEmpleado.Text) && !string.IsNullOrWhiteSpace(txtContraseñaEmpleado.Text))
                {
                    CAcceso cAcc = new CAcceso(Convert.ToInt32(txtDniEmpleado.Text), txtContraseñaEmpleado.Text);
                    List<CAcceso> acceso = cAcceso.Login(cAcc);

                    if (acceso.Count == 0)
                    {
                        MessageBox.Show("Datos incorrectos.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtDniEmpleado.Text = "";
                        txtContraseñaEmpleado.Text = "";
                        return;
                    }

                    if (acceso[0] != null)
                    {
                        string rol = acceso[0].rol;

                        // Pasar el rol al método VerificarLicenciaEmpleado
                        if (VerificarLicenciaEmpleado(Convert.ToInt32(txtDniEmpleado.Text), rol))
                        {
                            FormContenedor formContenedor = new FormContenedor(acceso[0].dni_empleado, acceso[0].nombre, rol);
                            formContenedor.Show();

                            txtDniEmpleado.Text = "";
                            txtContraseñaEmpleado.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Tu licencia ha expirados.", "Error de acceso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtDniEmpleado.Text = "";
                            txtContraseñaEmpleado.Text = "";
                        }
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


        private bool VerificarLicenciaEmpleado(int dniEmpleado, string rol)
        {
            // Si el usuario es empleado, no necesita verificación de licencia
            if (rol == "Empleado")
            {
                MessageBox.Show("Iniciaste sesión como Empleado", "Acesso limitado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return true; // Permitir acceso sin verificar la licencia
            }

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
            // Modificar la consulta para obtener también el rol del empleado
            string query = @"
                SELECT DATEDIFF(day, GETDATE(), Licencias.FechaExpiracion) AS DiasRestantes, 
                       Empleados.rol
                FROM Licencias 
                JOIN Empleados ON Licencias.dni_empleado = Empleados.dni_empleado
                WHERE Licencias.dni_empleado = @dni_empleado 
                  AND Licencias.Estado = 'Activa' 
                  AND Licencias.FechaExpiracion >= GETDATE()";

            int diasRestantes = 0;
            string rol = "";

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
                            // Leer el rol del empleado
                            rol = reader["rol"].ToString();
                        }
                    }
                }

                // Mostrar el rol y los días restantes de licencia
                if (diasRestantes > 0)
                {
                    string mensaje = $"Iniciaste sesión como {rol}. Usted tiene {diasRestantes} días de licencia restantes.";
                    MessageBox.Show(mensaje, "Licencia ACTIVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Tu licencia ha expirado.", "Licencia Expirada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
