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

        public int ContarTiposMembresia(byte[] huella)
        {
            string query = "select COUNT(huella) from membresias where huella = @huella";
            try
            {
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                comando.Parameters.AddWithValue("@huella", huella);
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

        public string[] buscarPorHuella(byte[] huella, int cod_tipo_membresia)
        {
            List<string> result = new List<string>();

            string query = "SELECT fecha_inicio, fecha_fin FROM Membresias WHERE huella = @huella and cod_tipo_membresia = @cod_tipo_membresia";

            try
            {
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                comando.Parameters.AddWithValue("@huella", huella);
                comando.Parameters.AddWithValue("@cod_tipo_membresia", cod_tipo_membresia);

                SqlDataReader reader = comando.ExecuteReader();

                CultureInfo culturaEspañola = new CultureInfo("es-ES");

                while (reader.Read())
                {
                    DateTime fecha_inicio = DateTime.Parse(reader["fecha_inicio"].ToString());
                    DateTime fecha_fin = DateTime.Parse(reader["fecha_fin"].ToString());
                    DateTime fecha_actual = DateTime.Now;
                    TimeSpan diferencia = (fecha_fin - fecha_actual);
                    int dias_restantes = (diferencia.Days) + 1;

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
                MessageBox.Show("Hubo un error al buscar la huella: " + ex);
                throw;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }

            return result.ToArray();
        }

        //public string[] buscarPorDni(int dni, int cod_tipo_membresia)
        //{
        //    List<string> result = new List<string>();

        //    string query = "SELECT fecha_inicio, fecha_fin  FROM Membresias WHERE dni_socio = @dni and cod_tipo_membresia = @cod_tipo_membresia";

        //    try
        //    {
        //        SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
        //        comando.Parameters.AddWithValue("@dni", dni);
        //        comando.Parameters.AddWithValue("@cod_tipo_membresia", cod_tipo_membresia);

        //        SqlDataReader reader = comando.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            DateTime fecha_inicio = DateTime.Parse(reader["fecha_inicio"].ToString());
        //            DateTime fecha_fin = DateTime.Parse(reader["fecha_fin"].ToString());
        //            DateTime fecha_actual = DateTime.Now;
        //            TimeSpan diferencia = fecha_fin - fecha_actual;
        //            int dias_restantes = diferencia.Days;

        //            result.Add(fecha_inicio.ToString("dd/MM"));
        //            result.Add(fecha_fin.ToString("dd/MM"));
        //            result.Add(dias_restantes.ToString());

        //        }
        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Hubo un error al buscar el DNI: " + ex);
        //        throw;
        //    }
        //    finally
        //    {
        //        conexionBD.CerrarConexion();
        //    }

        //    return result.ToArray();
        //}

        public string[] buscarPorHuella(byte[] huella)
        {
            List<string> result = new List<string>();

            //string query = "SELECT fecha_inicio, fecha_fin FROM Membresias WHERE huella = @huella";
            string query = "SELECT fecha_inicio, fecha_fin FROM socios s INNER JOIN membresias m ON s.id_socio = m.id_socio INNER JOIN huellas_digitales h ON s.id_socio = h.id_socio WHERE CONVERT(VARCHAR(MAX), h.huella, 1) = @huellaBase64;";

            try
            {
                //string huellaBase64 = Convert.ToBase64String(huella);

                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                comando.Parameters.AddWithValue("@huellaBase64", huella);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    DateTime fecha_inicio = DateTime.Parse(reader["fecha_inicio"].ToString());
                    DateTime fecha_fin = DateTime.Parse(reader["fecha_fin"].ToString());
                    DateTime fecha_actual = DateTime.Now;
                    TimeSpan diferencia = (fecha_fin - fecha_actual);
                    int dias_restantes = (diferencia.Days) + 1;

                    result.Add(fecha_inicio.ToString("dd/MM"));
                    result.Add(fecha_fin.ToString("dd/MM"));
                    result.Add(dias_restantes.ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al buscar la huella: " + ex);
                throw;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }

            return result.ToArray();
        }

        public ClsSocio[] traerDatosDeSocioPorHuella(byte[] huella)
        {
            ClsSocio[] array = new ClsSocio[1];
            try
            {
                conexionBD.AbrirConexion();
                string query = "select * from socios where huella = @huella";
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                comando.Parameters.AddWithValue("@huella", huella);
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

        public string[] BuscarPorIdSocio(int id_socio)
        {
            List<string> result = new List<string>();

            string query = "SELECT fecha_inicio, fecha_fin  FROM Membresias WHERE id_socio = @id_socio";

            try
            {
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                comando.Parameters.AddWithValue("@id_socio", id_socio);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    DateTime fecha_inicio = DateTime.Parse(reader["fecha_inicio"].ToString());
                    DateTime fecha_fin = DateTime.Parse(reader["fecha_fin"].ToString());
                    DateTime fecha_actual = DateTime.Now;
                    TimeSpan diferencia = (fecha_fin - fecha_actual);
                    int dias_restantes = diferencia.Days;

                    result.Add(fecha_inicio.ToString("dd/MM"));
                    result.Add(fecha_fin.ToString("dd/MM"));
                    result.Add(dias_restantes.ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al buscar el socio: " + ex);
                throw;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }

            return result.ToArray();
        }

        //public string[] BuscarPorIdSocio(int idSocio)
        //{
        //    ClsHuella[] huella = new ClsHuella[1];

        //    string query = @"
        //    SELECT s.nombre, s.apellido, m.fecha_inicio, m.fecha_fin, 
        //           DATEDIFF(day, GETDATE(), m.fecha_fin) AS dias_restantes
        //    FROM socios s
        //    JOIN membresias m ON s.id_socio = m.id_socio
        //    WHERE s.id_socio = @id_socio AND m.fecha_fin >= GETDATE()";

        //    SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());

        //    comando.Parameters.AddWithValue("@id_socio", idSocio);
        //    SqlDataReader reader = comando.ExecuteReader();

        //    if (reader.Read())
        //    {
        //        string nombre = reader["nombre"].ToString();
        //        string apellido = reader["apellido"].ToString();
        //        DateTime fecha_inicio = DateTime.Parse(reader["fecha_inicio"].ToString());
        //        DateTime fecha_fin = DateTime.Parse(reader["fecha_fin"].ToString());
        //        int dias_restantes = Convert.ToInt32(reader["dias_restantes"].ToString());

        //        //resultado = new string[]
        //        //        {
        //        //        reader["nombre"].ToString(),
        //        //        reader["apellido"].ToString(),
        //        //        reader["fecha_inicio"].ToString(),
        //        //        reader["fecha_fin"].ToString(),
        //        //        reader["dias_restantes"].ToString()
        //        //        };
        //        //    }

        //    }

        //    return resultado;
        //}


    }
}
