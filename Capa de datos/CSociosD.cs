using System;
using System.Data;
using System.Data.SqlClient;
using Control_Gym.Capa_logica;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Control_Gym.Capa_de_datos
{
    internal class CSociosD
    {
        private ConexionBD conexionBD = ConexionBD.Instancia;

        public bool VerificarSiYaTieneHuella(int id_socio)
        {
            string query = "select COUNT(id_socio) from huellas_digitales where id_socio = @id_socio";
            try
            {
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                comando.Parameters.AddWithValue("@id_socio", id_socio);
                int count = (int)comando.ExecuteScalar();
                if(count > 0)
                {
                    return true; //SI TIENE HUELLA REGISTRADA
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar si ya tiene huella registrada", ex.Message);
                throw;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        public ClsSocio[] ObtenerDatosSocio(int idSocio)
        {
            string query = "SELECT s.nombre, s.apellido, s.dni_socio, m.cod_tipo_membresia, m.fecha_inicio, m.fecha_fin, DATEDIFF(DAY, GETDATE(), m.fecha_fin) as diferencia  FROM socios s LEFT JOIN membresias m on s.id_socio = m.id_socio WHERE s.id_socio = @id_socio";
            string queryCount = "SELECT COUNT(id_socio) FROM membresias WHERE id_socio = @id_socio";

            ClsSocio[] socioEncontrado = new ClsSocio[1];

            try
            {
                string nombre = null;
                string apellido = null;
                int dni = 0;
                string fecha_inicio_formateada = null;
                string fecha_fin_formateada = null;
                List<CTipoMembresia> tipos_membresias = new List<CTipoMembresia>();
                int diferencia = 0;


                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                SqlCommand comandoCount = new SqlCommand(queryCount, conexionBD.AbrirConexion());

                comando.Parameters.AddWithValue("@id_socio", idSocio);
                comandoCount.Parameters.AddWithValue("@id_socio", idSocio);
                int count = (int)comandoCount.ExecuteScalar();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    nombre = reader["nombre"].ToString();
                    apellido = reader["apellido"].ToString();
                    dni = Convert.ToInt32(reader["dni_socio"].ToString());
                    diferencia = Convert.ToInt32(reader["diferencia"].ToString());

                    // Formateo de las fechas
                    DateTime? fecha_inicio = reader["fecha_inicio"] != DBNull.Value ? DateTime.Parse(reader["fecha_inicio"].ToString()) : (DateTime?)null;
                    DateTime? fecha_fin = reader["fecha_fin"] != DBNull.Value ? DateTime.Parse(reader["fecha_fin"].ToString()) : (DateTime?)null;

                    fecha_inicio_formateada = fecha_inicio.HasValue ? fecha_inicio.Value.ToString("dd 'de' MMMM 'de' yyyy") : null;
                    fecha_fin_formateada = fecha_fin.HasValue ? fecha_fin.Value.ToString("dd 'de' MMMM 'de' yyyy") : null;
                }
                reader.Close();

                if (count > 0)
                {
                    CTipoMembresiaD tipoMembresia = new CTipoMembresiaD();
                    tipos_membresias = tipoMembresia.traerTiposDelSocio(idSocio);
                }

                // Modificar la clase ClsSocio para aceptar las fechas formateadas como string o adaptar si ya lo permite
                ClsSocio socio = new ClsSocio(idSocio, dni, nombre, apellido, fecha_inicio_formateada, fecha_fin_formateada, tipos_membresias,diferencia);
                socioEncontrado.SetValue(socio, 0);
                return socioEncontrado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al buscar el socio: " + ex.Message);
                throw;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }


        public ClsSocio[] ObtenerDatosSocio(int idSocio, int cod_tipo_membresia)
        {
            string query = "SELECT s.nombre, s.apellido, s.dni_socio, m.cod_tipo_membresia, m.fecha_inicio, m.fecha_fin, DATEDIFF(DAY, GETDATE(), m.fecha_fin) as diferencia  FROM socios s LEFT JOIN membresias m ON s.id_socio = m.id_socio WHERE s.id_socio = @id_socio AND m.cod_tipo_membresia = @cod_tipo_membresia";
            ClsSocio[] socioEncontrado = new ClsSocio[1];
            try
            {
                string nombre = null;
                string apellido = null;
                int dni = 0;
                string fecha_inicio = null;
                string fecha_fin = null;
                int diferencia = 0;

                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());

                comando.Parameters.AddWithValue("@id_socio", idSocio);
                comando.Parameters.AddWithValue("@cod_tipo_membresia", cod_tipo_membresia);

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    nombre = reader["nombre"].ToString();
                    apellido = reader["apellido"].ToString();
                    dni = Convert.ToInt32(reader["dni_socio"].ToString());
                    fecha_inicio = reader["fecha_inicio"] != DBNull.Value ? DateTime.Parse(reader["fecha_inicio"].ToString()).ToString("dd 'de' MMMM") : null;
                    fecha_fin = reader["fecha_fin"] != DBNull.Value ? DateTime.Parse(reader["fecha_fin"].ToString()).ToString("dd 'de' MMMM") : null;
                    diferencia = Convert.ToInt32(reader["diferencia"].ToString());
                }
                reader.Close();

                ClsSocio socio = new ClsSocio(idSocio, dni, nombre, apellido, fecha_inicio, fecha_fin, diferencia);
                socioEncontrado[0] = socio;
                return socioEncontrado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al buscar el socio: " + ex.Message);
                throw;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }


        public void GuardarSocio(int dni, string nombre, string apellido, DateTime fechaNacimiento, string telefono, string domicilio, string email, byte[] huella)
        {
            string procedimiento = "sp_GuardarSocioConHuella";  // Nombre del procedimiento almacenado
            try
            {
                SqlCommand comando = new SqlCommand(procedimiento, conexionBD.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;

                // Parámetros para el procedimiento almacenado
                comando.Parameters.AddWithValue("@dni", dni);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@apellido", apellido);
                comando.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
                comando.Parameters.AddWithValue("@telefono", telefono);
                comando.Parameters.AddWithValue("@domicilio", domicilio);
                comando.Parameters.AddWithValue("@email", email);
                comando.Parameters.AddWithValue("@huella", huella);  // Pasar la huella como parámetro
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al añadir un nuevo socio: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        public void ModificarSocio(int id_socio, string nombre, string apellido, DateTime fechaNacimiento, string telefono, string domicilio, string email)
        {
            string query = "UPDATE socios SET nombre = @nombre, apellido = @apellido, fecha_nac = @fechaNacimiento, telefono = @telefono, domicilio = @domicilio, email = @email WHERE id_socio = @id_socio";

            try
            {
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());

                comando.Parameters.AddWithValue("@id_socio", id_socio); //CAMBIO dni POR id_socio
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@apellido", apellido);
                comando.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
                comando.Parameters.AddWithValue("@telefono", telefono);
                comando.Parameters.AddWithValue("@domicilio", domicilio);
                comando.Parameters.AddWithValue("@email", email);

                comando.ExecuteNonQuery();
                MessageBox.Show("Datos modificados");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar un socio: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        public DataTable CargarDatos()
        {
          
            string query = "SELECT * FROM socios";
            DataTable tabla = new DataTable();
            try 
            {
                SqlDataReader leer;
                
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                
                leer= comando.ExecuteReader();
                tabla.Load(leer);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
           
             finally
            {
                conexionBD.CerrarConexion();
            }

            return tabla;
        }

        public void EliminarDatos(int id_socio)
        {
            string query = "EXEC EliminarSocio @id_socio";  // Llamamos al procedimiento almacenado
            try
            {
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                comando.Parameters.AddWithValue("@id_socio", id_socio);
                comando.ExecuteNonQuery();
                Program.isModifiying = false;
                Program.idSocioSeleccionado = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar un socio: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }


        public ClsSocio TraerIdSocioPorDni(int dni)
        {
            ClsSocio socio = null;
            
            try
            {                
                string consulta = "SELECT id_socio, dni_socio FROM socios WHERE dni_socio = @dni_socio";

                SqlCommand comando = new SqlCommand(consulta, conexionBD.AbrirConexion());
                    {
                        comando.Parameters.AddWithValue("@dni_socio", dni);

                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                socio = new ClsSocio
                                {
                                    Id_socio = lector.GetInt32(0),
                                    Dni = lector.GetInt32(1),                                    
                                };
                            }
                        }
                    }                
            }
            catch (Exception ex)
            {                
                Console.WriteLine("Error al obtener el socio: " + ex.Message);
            }

            return socio;
        }

        public DataTable Filtrar(string dni)
        {
            ClsSocio clsSocio= new ClsSocio();
            string query = "SELECT * FROM socios WHERE nombre LIKE '%"+dni+"%' OR apellido LIKE '%"+dni+ "%' OR dni_socio LIKE '%"+dni+"%'";
            DataTable tabla = new DataTable();

            try
            {
                SqlDataReader leer;
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                leer = comando.ExecuteReader();
                tabla.Load(leer);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }

            finally
            {
                conexionBD.CerrarConexion();
            }

            return tabla;
        }        

        public bool MembresiaActiva(int dni)
        {
            string query = "SELECT COUNT(*) FROM membresias WHERE id_socio = '" + dni + "'";
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
                MessageBox.Show("Error al verificar si el socio tiene membresia activa: "+ ex.Message);
                return false;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }
    }
}
