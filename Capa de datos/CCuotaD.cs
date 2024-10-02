using Control_Gym.Capa_logica;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Control_Gym.Capa_de_datos
{
    internal class CCuotaD
    {
        private ConexionBD conexionBD = ConexionBD.Instancia;

        public void CrearCuota(int cod_membresia)
        {
            string query = "INSERT INTO CUOTAS(cod_membresia, fecha_pago) VALUES(@cod_membresia, @fecha_pago)";
            try
            {   
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                comando.Parameters.Add(new SqlParameter("@cod_membresia", cod_membresia));
                comando.Parameters.Add(new SqlParameter("@fecha_pago", DateTime.Now.ToString("yyyy/dd/MM")));

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw; 
            }
        }

        public List<CCuota> TraerCuotas()
        {
            List<CCuota> cuotas = new List<CCuota>();
            string query = "select c.cod_cuota, c.fecha_pago, s.idSocio, t.nombre, t.precio from cuotas c inner join membresias m on c.cod_membresia = m.cod_membresia inner join tipos_membresias t on m.cod_tipo_membresia = t.cod_tipo_membresia inner join socios s on m.idSocio = s.idSocio;";
            try
            {
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    CCuota cuota = new CCuota
                    {
                        cod_cuota = Convert.ToInt32(reader["cod_cuota"].ToString()),
                        fecha_pago = DateTime.Parse(reader["fecha_pago"].ToString()),
                        idSocio = Convert.ToInt32(reader["idSocio"].ToString()), // Usando idSocio en lugar de dni_socio
                        nombre_membresia = reader["nombre"].ToString(),
                        precio = Convert.ToDecimal(reader["precio"].ToString())
                    };

                    cuotas.Add(cuota);
                }

                reader.Close();
                return cuotas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al mostrar las cuotas: " + ex);
                throw;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }


        public decimal ObtenerTotal()
        {
            string query = "SELECT ISNULL(SUM(t.precio),0) as total FROM cuotas c INNER JOIN membresias m ON c.cod_membresia = m.cod_membresia INNER JOIN tipos_membresias t ON m.cod_tipo_membresia = t.cod_tipo_membresia;";

            try
            {
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    decimal total = Convert.ToDecimal(reader["total"]);

                    reader.Close();
                    return total;
                }
                else
                {
                    reader.Close();
                    return 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al obtener el total");
                throw;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        public decimal ObtenerTotalMesActual()
        {
            string query = "SELECT ISNULL(SUM(t.precio),0) as total FROM cuotas c INNER JOIN membresias m ON c.cod_membresia = m.cod_membresia INNER JOIN tipos_membresias t ON m.cod_tipo_membresia = t.cod_tipo_membresia where MONTH(c.fecha_pago) = MONTH(GETDATE()) AND YEAR(c.fecha_pago) = YEAR(GETDATE());";

            try
            {
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    decimal total = Convert.ToDecimal(reader["total"]);

                    reader.Close();
                    return total;
                }
                else
                {
                    reader.Close();
                    return 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al obtener el total de este mes");
                throw;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        public decimal ObtenerTotalHoy()
        {
            string query = "SELECT ISNULL(SUM(t.precio), 0) as total " +
                           "FROM cuotas c " +
                           "INNER JOIN membresias m ON c.cod_membresia = m.cod_membresia " +
                           "INNER JOIN tipos_membresias t ON m.cod_tipo_membresia = t.cod_tipo_membresia " +
                           "WHERE CONVERT(DATE, c.fecha_pago) = @fechaHoy";

            SqlConnection conexion = null;
            SqlCommand comando = null;
            SqlDataReader reader = null;

            try
            {
                // Abrir conexión
                conexion = conexionBD.AbrirConexion();

                // Crear comando
                comando = new SqlCommand(query, conexion);

                // Parámetro para la fecha de prueba
                var fechaHoy = DateTime.Now.Date; // Usar para pruebas con los datos actuales
                                                           // var fechaHoy = DateTime.Now.Date; // Para producción
                comando.Parameters.AddWithValue("@fechaHoy", fechaHoy);

                // Ejecutar comando y leer resultados
                reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    decimal total = Convert.ToDecimal(reader["total"]);
                    return total;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al obtener el total de hoy: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            finally
            {
                // Cerrar el lector de datos si está abierto
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }

                // Liberar recursos del comando
                if (comando != null)
                {
                    comando.Dispose();
                }

                // Cerrar la conexión
                if (conexion != null)
                {
                    conexionBD.CerrarConexion();
                }
            }
        }


    }
}
