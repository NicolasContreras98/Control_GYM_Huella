using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Control_Gym.Capa_logica;

namespace Control_Gym.Capa_de_datos
{
    internal class CMembresiaD
    {
        private ConexionBD conexionBD = ConexionBD.Instancia;
        private CCuotaD cCuotaD = new CCuotaD();

        public bool TieneTipoMembresia(int dni, int cod_tipo)
        {
            string query = "select COUNT(cod_membresia) from membresias where dni_socio = @dni_socio and cod_tipo_membresia = @cod_tipo_membresia;";

            try
            {
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());

                comando.Parameters.Add(new SqlParameter("@dni_socio", dni));
                comando.Parameters.Add(new SqlParameter("@cod_tipo_membresia", cod_tipo));

                int resultado = (int)comando.ExecuteScalar();

                if (resultado >= 1)
                {
                    return true;    
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error." + ex);
                return false;
            }
        }

        public int CrearMembresia(CMembresia cMembresia)
        {
            string query = "INSERT INTO membresias(cod_tipo_membresia, dni_socio, fecha_inicio, fecha_fin) VALUES (@cod_tipo_membresia, @dni_socio, @fecha_inicio, @fecha_fin); SELECT SCOPE_IDENTITY();";

            try
            {
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());

                comando.Parameters.Add(new SqlParameter("@cod_tipo_membresia", cMembresia.cod_tipo_membresia));
                comando.Parameters.Add(new SqlParameter("@dni_socio", cMembresia.dni_socio));
                comando.Parameters.Add(new SqlParameter("@fecha_inicio", cMembresia.fecha_inicio));
                comando.Parameters.Add(new SqlParameter("@fecha_fin", cMembresia.fecha_fin));

                int idMembresia = Convert.ToInt32(comando.ExecuteScalar());
                cCuotaD.CrearCuota(idMembresia);

                return idMembresia;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al crear la membresia.");
                return -1; 
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }


        public bool SocioExiste(int dni)
        {
            string query = "SELECT COUNT(*) FROM socios WHERE dni_socio = '" + dni + "'";
			try
			{
				SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
				int resultado = (int)comando.ExecuteScalar();
				if(resultado == 0)
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

        public bool EmailExiste(string email)
        {
            string query = "SELECT COUNT(*) FROM socios WHERE email = '" + email + "'";
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
                MessageBox.Show("Error al verificar si el E-mail existe.");
                return false;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }

        }

        public List<CMembresia> TraerMembresias()
        {
            List<CMembresia> membresias = new List<CMembresia>();
            string query = "select * from membresias inner join tipos_membresias on membresias.cod_tipo_membresia = tipos_membresias.cod_tipo_membresia";
            try
            {
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    CMembresia membresia = new CMembresia
                    {
                        cod_membresia = Convert.ToInt32(reader["cod_membresia"].ToString()),
                        cod_tipo_membresia = Convert.ToInt32(reader["cod_tipo_membresia"].ToString()),
                        dni_socio = Convert.ToInt32(reader["dni_socio"].ToString()),
                        fecha_inicio = DateTime.Parse(reader["fecha_inicio"].ToString()),
                        fecha_fin = DateTime.Parse(reader["fecha_fin"].ToString()),
                        nombre_tipo = reader["nombre"].ToString(),
                        precio_tipo = Convert.ToDecimal(reader["precio"].ToString()),
                        cantidad_dias = Convert.ToInt32(reader["cantidad_dias"].ToString())
                    };

                    membresias.Add(membresia);
                }

                reader.Close();
                return membresias;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al mostrar las membresias: " + ex);
                throw;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }
        public List<CMembresia> CargarGrilla()
        {
            List<CMembresia> membresias = new List<CMembresia>();
            string query = "select cod_membresia as 'ID', dni_socio as 'Dni socio', fecha_inicio as 'Fecha de inicio', fecha_fin as 'Fecha de fin', nombre as 'Tipo de membresia',precio as 'Precio' from membresias inner join tipos_membresias on membresias.cod_tipo_membresia = tipos_membresias.cod_tipo_membresia";
            try
            {
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    CMembresia membresia = new CMembresia
                    {
                        cod_membresia = Convert.ToInt32(reader["ID"].ToString()),
                        dni_socio = Convert.ToInt32(reader["Dni socio"].ToString()),
                        fecha_inicio = DateTime.Parse(reader["Fecha de inicio"].ToString()),
                        fecha_fin = DateTime.Parse(reader["Fecha de fin"].ToString()),
                        nombre_tipo = reader["Tipo de membresia"].ToString(),
                        precio_tipo = Convert.ToDecimal(reader["Precio"].ToString()),
                    };
                    membresias.Add(membresia);
                }

                reader.Close();
                return membresias;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al mostrar las membresias: " + ex);
                throw;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        public void EditarMembresia(CMembresia cMembresia)
        {
            string query = "UPDATE membresias SET cod_tipo_membresia = @cod_tipo_membresia, dni_socio = @dni_socio, fecha_inicio = @fecha_inicio, fecha_fin = @fecha_fin WHERE cod_membresia = @cod_membresia";

            try
            {
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());

                comando.Parameters.Add(new SqlParameter("@cod_tipo_membresia", cMembresia.cod_tipo_membresia));
                comando.Parameters.Add(new SqlParameter("@dni_socio", cMembresia.dni_socio));
                comando.Parameters.Add(new SqlParameter("@fecha_inicio", cMembresia.fecha_inicio));
                comando.Parameters.Add(new SqlParameter("@fecha_fin", cMembresia.fecha_fin));
                comando.Parameters.Add(new SqlParameter("@cod_membresia", cMembresia.cod_membresia));

                comando.ExecuteNonQuery();
                MessageBox.Show("Membresía actualizada correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la membresía: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        public void EliminarMembresia(int id)
        {
            string query = "DELETE FROM membresias WHERE cod_membresia = @cod_membresia";

            try
            {
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());

                comando.Parameters.Add(new SqlParameter("@cod_membresia", id));

                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("La membresía ha sido eliminada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se encontró ninguna membresía con el ID proporcionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la membresía: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }



        public List<CMembresia> BuscarPorDNI(int dni)
        {

            string query = "select cod_membresia as 'ID', membresias.cod_tipo_membresia as 'ID tipo',dni_socio as 'Dni socio', fecha_inicio as 'Fecha de inicio', fecha_fin as 'Fecha de fin', nombre as 'Tipo de membresia',precio as 'Precio', cantidad_dias as 'Dias de duración' from membresias inner join tipos_membresias on membresias.cod_tipo_membresia = tipos_membresias.cod_tipo_membresia where dni_socio ='" + dni + "'";
            List<CMembresia> membresias = new List<CMembresia>();
            try
            {
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    CMembresia membresia = new CMembresia
                    {
                        cod_membresia = Convert.ToInt32(reader["ID"].ToString()),
                        cod_tipo_membresia = Convert.ToInt32(reader["ID tipo"].ToString()),
                        dni_socio = Convert.ToInt32(reader["Dni socio"].ToString()),
                        fecha_inicio = DateTime.Parse(reader["Fecha de inicio"].ToString()),
                        fecha_fin = DateTime.Parse(reader["Fecha de fin"].ToString()),
                        nombre_tipo = reader["Tipo de membresia"].ToString(),
                        precio_tipo = Convert.ToDecimal(reader["Precio"].ToString()),
                        cantidad_dias = Convert.ToInt32(reader["Dias de duración"].ToString())
                    };

                    membresias.Add(membresia);
                }

                reader.Close();
                return membresias;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al mostrar las membresias: " + ex);
                throw;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }            
        }
        public void Renovar(CMembresia cMembresia)
        {
            string query = "UPDATE membresias SET fecha_inicio = @fecha_inicio, fecha_fin = @fecha_fin WHERE cod_membresia = @cod_membresia";
            string query3 = "select cantidad_dias from tipos_membresias t inner join membresias m on t.cod_tipo_membresia = m.cod_tipo_membresia where cod_membresia ='"+ cMembresia.cod_membresia +"'";

            try
            {
                SqlCommand updateMembresia = new SqlCommand(query, conexionBD.AbrirConexion());
                SqlCommand canttDiasPorTipo = new SqlCommand(query3, conexionBD.AbrirConexion());
                int cantidad_dias = (int)canttDiasPorTipo.ExecuteScalar();
                cMembresia.fecha_inicio = DateTime.Now;
                DateTime fechaInicio = cMembresia.fecha_inicio;
                DateTime fechaFin = fechaInicio.AddDays(cantidad_dias);
                cMembresia.fecha_fin = fechaFin;

                updateMembresia.Parameters.Add(new SqlParameter("@fecha_inicio", cMembresia.fecha_inicio.ToString("yyyy/MM/dd")));
                updateMembresia.Parameters.Add(new SqlParameter("@fecha_fin", cMembresia.fecha_fin.ToString("yyyy/MM/dd")));
                updateMembresia.Parameters.Add(new SqlParameter("@cod_membresia", cMembresia.cod_membresia));


                cCuotaD.CrearCuota(cMembresia.cod_membresia);
                updateMembresia.ExecuteNonQuery();
                MessageBox.Show("Membresía renovada correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al renovar la membresía: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        public Dictionary<string, int> ObtenerTotalMembresiasPorMes()
        {
            Dictionary<string, int> membresiasPorMes = new Dictionary<string, int>();

            string query = "SELECT DATENAME(MONTH, m.fecha_inicio) AS Mes, SUM(tm.precio) AS TotalMembresiasVendidas " +
                         "FROM membresias m " +
                         "JOIN tipos_membresias tm ON m.cod_tipo_membresia = tm.cod_tipo_membresia " +
                         "GROUP BY DATENAME(MONTH, m.fecha_inicio), DATEPART(MONTH, m.fecha_inicio) " +
                         "ORDER BY DATEPART(MONTH, m.fecha_inicio)";

            SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                membresiasPorMes.Add(reader["Mes"].ToString(), Convert.ToInt32(reader["TotalMembresiasVendidas"]));
            }

            conexionBD.CerrarConexion();
            return membresiasPorMes;
        }
    }
}
