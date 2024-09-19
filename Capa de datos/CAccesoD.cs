using Control_Gym.Capa_logica;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Control_Gym.Capa_de_datos
{
    internal class CAccesoD
    {
        private ConexionBD conexionBD = ConexionBD.Instancia;
        public bool EmpleadoExiste(int dni)
        {
            string query = "SELECT COUNT(*) FROM empleados WHERE dni_empleado = '" + dni + "'";
            try
            {
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                int resultado = (int)comando.ExecuteScalar();
                if (resultado == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar si el empleado existe."+ ex);
                return false;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }
        public List<CAcceso> Login(CAcceso cAcc)
        {
            string query = "SELECT * FROM empleados WHERE dni_empleado = @dni_empleado AND contraseña = @contraseña";
            List<CAcceso> datos = new List<CAcceso>();

            try
            {
                using (SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion()))
                {
                    // Utiliza parámetros para evitar inyecciones SQL
                    comando.Parameters.AddWithValue("@dni_empleado", cAcc.dni_empleado);
                    comando.Parameters.AddWithValue("@contraseña", cAcc.contraseña);

                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        CAcceso acceso = new CAcceso
                        {
                            dni_empleado = Convert.ToInt32(reader["dni_empleado"].ToString()),
                            nombre = reader["nombre"].ToString(),
                            apellido = reader["apellido"].ToString(),
                            telefono = reader["telefono"].ToString(),
                            fecha_nac = DateTime.Parse(reader["fecha_nac"].ToString()),
                            domicilio = reader["domicilio"].ToString(),
                            email = reader["email"].ToString(),
                            contraseña = reader["contraseña"].ToString(),
                            rol = reader["rol"].ToString() // Asumiendo que tienes la columna "rol"
                        };

                        datos.Add(acceso);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al intentar iniciar sesión: " + ex.Message);
                throw;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }

            return datos;
        }
    }
}
