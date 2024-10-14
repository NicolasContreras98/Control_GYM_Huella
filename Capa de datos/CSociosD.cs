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
            string query = "SELECT s.nombre, s.apellido,s.dni_socio, m.cod_tipo_membresia, m.fecha_inicio, m.fecha_fin FROM socios s LEFT JOIN membresias m on s.id_socio = m.id_socio WHERE s.id_socio = @id_socio";
            string queryCount = "select COUNT(id_socio) from membresias where id_socio = @id_socio";
            ClsSocio[] socioEncontrado = new ClsSocio[1];
            try
            {                
                string nombre = null;
                string apellido = null;
                int dni = 0;
                DateTime? fecha_inicio = null;
                DateTime? fecha_fin = null;
                List<CTipoMembresia> tipos_membresias = new List<CTipoMembresia>();

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
                    fecha_inicio = reader["fecha_inicio"] != DBNull.Value ? DateTime.Parse(reader["fecha_inicio"].ToString()) : (DateTime?)null;
                    fecha_fin = reader["fecha_fin"] != DBNull.Value ? DateTime.Parse(reader["fecha_fin"].ToString()) : (DateTime?)null;                    
                }
                reader.Close();
                if(count > 0)
                {
                    CTipoMembresiaD tipoMembresia = new CTipoMembresiaD();
                    tipos_membresias = tipoMembresia.traerTiposDelSocio(idSocio);                    
                }
                ClsSocio socio = new ClsSocio(idSocio, dni, nombre, apellido, fecha_inicio, fecha_fin, tipos_membresias);
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
            string query = "SELECT s.nombre, s.apellido,s.dni_socio, m.cod_tipo_membresia, m.fecha_inicio, m.fecha_fin FROM socios s LEFT JOIN membresias m on s.id_socio = m.id_socio WHERE s.id_socio = @id_socio and m.cod_tipo_membresia = @cod_tipo_membresia";
            string queryCount = "select COUNT(id_socio) from membresias where id_socio = @id_socio";
            ClsSocio[] socioEncontrado = new ClsSocio[1];
            try
            {
                string nombre = null;
                string apellido = null;
                int dni = 0;
                DateTime? fecha_inicio = null;
                DateTime? fecha_fin = null;

                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                SqlCommand comandoCount = new SqlCommand(queryCount, conexionBD.AbrirConexion());

                comando.Parameters.AddWithValue("@id_socio", idSocio);
                comando.Parameters.AddWithValue("@cod_tipo_membresia", cod_tipo_membresia);
                comandoCount.Parameters.AddWithValue("@id_socio", idSocio);
                int count = (int)comandoCount.ExecuteScalar();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    nombre = reader["nombre"].ToString();
                    apellido = reader["apellido"].ToString();
                    dni = Convert.ToInt32(reader["dni_socio"].ToString());
                    fecha_inicio = reader["fecha_inicio"] != DBNull.Value ? DateTime.Parse(reader["fecha_inicio"].ToString()) : (DateTime?)null;
                    fecha_fin = reader["fecha_fin"] != DBNull.Value ? DateTime.Parse(reader["fecha_fin"].ToString()) : (DateTime?)null;
                }
                reader.Close();
                
                ClsSocio socio = new ClsSocio(idSocio, dni, nombre, apellido, fecha_inicio, fecha_fin);
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

        public int GuardarSocio(int dni, string nombre, string apellido, DateTime fechaNacimiento, string telefono, string domicilio, string email)
        {
            int idSocio = 0;
            string query = "INSERT INTO socios(dni_socio,nombre,apellido,fecha_nac,telefono,domicilio,email)VALUES(@dni, @nombre, @apellido, @fechaNacimiento, @telefono, @domicilio, @email); SELECT SCOPE_IDENTITY();";
            try
            {
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());

                comando.Parameters.AddWithValue("@dni", dni);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@apellido", apellido);
                comando.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
                comando.Parameters.AddWithValue("@telefono", telefono);
                comando.Parameters.AddWithValue("@domicilio", domicilio);
                comando.Parameters.AddWithValue("@email", email);

                idSocio = Convert.ToInt32(comando.ExecuteScalar()); // Retorna el id del socio recién registrado
                
                MessageBox.Show("Nuevo socio adherido");
                return idSocio;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al añadir un nuevo socio: " + ex.Message);
                return idSocio;
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

        public void EliminarDatos(int id_socio, string name)
        {
            string query = "DELETE socios WHERE id_socio = @id_socio"; //CAMBIO dni_socio POR id_socio
            try
            {
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                comando.Parameters.AddWithValue("@id_socio", id_socio);
                comando.ExecuteNonQuery();
                MessageBox.Show("Eliminaste los datos del socio "+ name);
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
            string query = "SELECT COUNT(*) FROM membresias WHERE dni_socio = '" + dni + "'";
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
            catch (Exception)
            {
                MessageBox.Show("Error al verificar si el socio existe.");
                return false;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }
    }
}
