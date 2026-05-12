using Control_Gym.Capa_logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Control_Gym.Capa_de_datos
{
    internal class CCuotaD
    {
        private ConexionBD conexionBD = ConexionBD.Instancia;

        public void RegistrarCuota(int codMembresia)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_RegistrarCuota", conexionBD.AbrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cod_membresia", codMembresia);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar cuota: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        public DataTable ObtenerCuotas(string filtro, int? mes = null, int? año = null)
        {
            DataTable tabla = new DataTable();
            SqlConnection conn = null;

            try
            {
                conn = conexionBD.AbrirConexion();

                string query = @"
                SELECT 
                    c.cod_cuota AS Id,
                    s.dni_socio AS DNI,
                    (s.nombre + ' ' + s.apellido) AS [Nombre Completo],
                    c.fecha_pago AS [Fecha de pago],
                    tm.nombre AS Tipo,
                    c.monto AS Monto
                FROM cuotas c
                INNER JOIN membresias m ON c.cod_membresia = m.cod_membresia
                INNER JOIN socios s ON m.id_socio = s.id_socio
                INNER JOIN tipos_membresias tm ON m.cod_tipo_membresia = tm.cod_tipo_membresia
                WHERE 1=1";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                DateTime hoy = DateTime.Today;

                switch (filtro)
                {
                    case "HOY":
                        query += " AND CAST(c.fecha_pago AS DATE) = @hoy";
                        cmd.Parameters.AddWithValue("@hoy", hoy);
                        break;

                    case "ULTIMOS7DIAS":
                        DateTime inicio7 = hoy.AddDays(-6); // incluye hoy
                        DateTime fin7 = hoy.AddDays(1);     // exclusivo para evitar problemas de hora

                        query += " AND c.fecha_pago >= @inicio7 AND c.fecha_pago < @fin7";
                        cmd.Parameters.AddWithValue("@inicio7", inicio7);
                        cmd.Parameters.AddWithValue("@fin7", fin7);
                        break;

                    case "MES":
                        if (mes.HasValue && año.HasValue)
                        {
                            DateTime inicioMes = new DateTime(año.Value, mes.Value, 1);
                            DateTime finMes = inicioMes.AddMonths(1);

                            query += " AND c.fecha_pago >= @inicioMes AND c.fecha_pago < @finMes";
                            cmd.Parameters.AddWithValue("@inicioMes", inicioMes);
                            cmd.Parameters.AddWithValue("@finMes", finMes);
                        }
                        break;

                    case "AÑO":
                        if (año.HasValue)
                        {
                            DateTime inicioAño = new DateTime(año.Value, 1, 1);
                            DateTime finAño = inicioAño.AddYears(1);

                            query += " AND c.fecha_pago >= @inicioAño AND c.fecha_pago < @finAño";
                            cmd.Parameters.AddWithValue("@inicioAño", inicioAño);
                            cmd.Parameters.AddWithValue("@finAño", finAño);
                        }
                        break;
                }

                cmd.CommandText = query;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener cuotas: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }

            return tabla;
        }

        public DataTable TraerTotales()
        {
            string query = @"SELECT
                    SUM(monto) AS TotalGeneral,
                    SUM(CASE 
                        WHEN MONTH(fecha_pago) = MONTH(GETDATE()) 
                        AND YEAR(fecha_pago) = YEAR(GETDATE())
                        THEN monto ELSE 0 END) AS TotalMes,
                    SUM(CASE 
                        WHEN CAST(fecha_pago AS DATE) = CAST(GETDATE() AS DATE)
                        THEN monto ELSE 0 END) AS TotalHoy
                    FROM cuotas";

            DataTable tabla = new DataTable();

            try
            {
                SqlCommand cmd = new SqlCommand(query, conexionBD.AbrirConexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular totales: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }

            return tabla;
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
