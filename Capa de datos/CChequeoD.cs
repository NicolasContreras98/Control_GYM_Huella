using Control_Gym.Capa_logica;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Control_Gym.Capa_de_datos
{
    internal class CChequeoD
    {
        private ConexionBD conexionBD = ConexionBD.Instancia;

        public int ContarTiposMembresia(int dni)
        {
            string query = "select COUNT(dni_socio) from membresias where dni_socio = '" + dni + "'";
            try
            {
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                int resultado = (int)comando.ExecuteScalar();
                return resultado;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al verificar si el socio existe.");
                return 0;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        public string[] buscarPorDni(int dni, int cod_tipo_membresia)
        {
            List<string> result = new List<string>();

            string query = "SELECT fecha_inicio, fecha_fin FROM Membresias WHERE dni_socio = @dni and cod_tipo_membresia = @cod_tipo_membresia";

            try
            {
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                comando.Parameters.AddWithValue("@dni", dni);
                comando.Parameters.AddWithValue("@cod_tipo_membresia", cod_tipo_membresia);

                SqlDataReader reader = comando.ExecuteReader();

                CultureInfo culturaEspañola = new CultureInfo("es-ES");

                while (reader.Read())
                {
                    DateTime fecha_inicio = DateTime.Parse(reader["fecha_inicio"].ToString());
                    DateTime fecha_fin = DateTime.Parse(reader["fecha_fin"].ToString());
                    DateTime fecha_actual = DateTime.Now;
                    TimeSpan diferencia = (fecha_fin - fecha_actual);
                    int dias_restantes = (diferencia.Days)+1;

                    // Formatear las fechas con el nombre del mes
                    string fechaInicioFormateada = fecha_inicio.ToString("dd 'de' MMMM", culturaEspañola);
                    string fechaFinFormateada = fecha_fin.ToString("dd 'de' MMMM", culturaEspañola);

                    result.Add(fechaInicioFormateada);
                    result.Add(fechaFinFormateada);
                    result.Add(dias_restantes.ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al buscar el DNI: " + ex);
                throw;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }

            return result.ToArray();
        }


        public string[] buscarPorDni(int dni)
        {
            List<string> result = new List<string>();

            string query = "SELECT fecha_inicio, fecha_fin  FROM Membresias WHERE dni_socio = @dni";

            try
            {
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                comando.Parameters.AddWithValue("@dni", dni);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    DateTime fecha_inicio = DateTime.Parse(reader["fecha_inicio"].ToString());
                    DateTime fecha_fin = DateTime.Parse(reader["fecha_fin"].ToString());
                    DateTime fecha_actual = DateTime.Now;
                    TimeSpan diferencia = (fecha_fin - fecha_actual);
                    int dias_restantes = (diferencia.Days)+1;

                    result.Add(fecha_inicio.ToString("dd 'de' MMMM"));
                    result.Add(fecha_fin.ToString("dd 'de' MMMM"));
                    result.Add(dias_restantes.ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al buscar el DNI: " + ex);
                throw;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }

            return result.ToArray();
        }

        public ClsSocio[] traerDatosDeSocioPorDni(int dni)
        {
            ClsSocio[] array = new ClsSocio[1];
            try
            {
                conexionBD.AbrirConexion();
                string query = "select * from socios where dni_socio = @dni";
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                comando.Parameters.AddWithValue("@dni", dni);
                SqlDataReader reader = comando.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        string nombre = reader["nombre"].ToString();
                        string apellido = reader["apellido"].ToString();

                        ClsSocio socio = new ClsSocio(nombre, apellido);
                        array.SetValue(socio, 0);
                    }
                }
                return array;
            }
            catch
            {
                MessageBox.Show("Error al traer los datos del socio");
                return null;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }
    }
}
