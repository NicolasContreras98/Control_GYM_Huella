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

    internal class CEmpleadoD
    {
        private ConexionBD conexionBD = ConexionBD.Instancia;
        
        // CRUD //

        public void CrearEmpleado(CEmpleado cEmpleado)
        {
            try
            {
                string query = "INSERT INTO Empleados(dni_empleado, nombre, apellido, telefono, fecha_nac, domicilio, email, contraseña, rol) VALUES (@dni_empleado, @nombre, @apellido,@telefono,@fecha_nac,@domicilio,@email,@contraseña, @rol)";

                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                comando.Parameters.Add(new SqlParameter("@dni_empleado", cEmpleado.dni_empleado));
                comando.Parameters.Add(new SqlParameter("@nombre", cEmpleado.nombre));
                comando.Parameters.Add(new SqlParameter("@apellido", cEmpleado.apellido));
                comando.Parameters.Add(new SqlParameter("@telefono", cEmpleado.telefono));
                comando.Parameters.Add(new SqlParameter("@fecha_nac", cEmpleado.fecha_nac));
                comando.Parameters.Add(new SqlParameter("@domicilio", cEmpleado.domicilio));
                comando.Parameters.Add(new SqlParameter("@email", cEmpleado.email));
                comando.Parameters.Add(new SqlParameter("@contraseña", cEmpleado.contraseña));
                comando.Parameters.Add(new SqlParameter("@rol", cEmpleado.rol));
                comando.ExecuteNonQuery();
                MessageBox.Show("Empleado agregado correctamente.");
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error al crear el empleado en la CAPA DE DATOS. ", ex);
            }
        }

        public void EditarEmpleado(CEmpleado cEmpleado)
        {
            try
            {
                string query = "UPDATE empleados SET nombre = @nombre, apellido = @apellido, telefono = @telefono, fecha_nac = @fecha_nac, domicilio = @domicilio, email = @email, contraseña = @contraseña, rol = @rol WHERE dni_empleado = @dni_empleado";


                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                comando.Parameters.Add(new SqlParameter("@dni_empleado", cEmpleado.dni_empleado));
                comando.Parameters.Add(new SqlParameter("@nombre", cEmpleado.nombre));
                comando.Parameters.Add(new SqlParameter("@apellido", cEmpleado.apellido));
                comando.Parameters.Add(new SqlParameter("@telefono", cEmpleado.telefono));
                comando.Parameters.Add(new SqlParameter("@fecha_nac", cEmpleado.fecha_nac));
                comando.Parameters.Add(new SqlParameter("@domicilio", cEmpleado.domicilio));
                comando.Parameters.Add(new SqlParameter("@email", cEmpleado.email));
                comando.Parameters.Add(new SqlParameter("@contraseña", cEmpleado.contraseña));
                comando.Parameters.Add(new SqlParameter("@rol", cEmpleado.rol));

                comando.ExecuteNonQuery();
                MessageBox.Show("Empleado actualizado correctamente.");
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error al actualizar el empleado en la CAPA DE DATOS: ", ex);
            }
        }

        public void EliminarEmpleado(int dni)
        {
            string verificarAdminQuery = "SELECT COUNT(*) FROM Empleados WHERE rol = 'Administrador'";
            string eliminarEmpleadoQuery = "DELETE FROM Empleados WHERE dni_empleado = @dni";

            try
            {
                // Verificar cuántos administradores hay en la base de datos
                using (SqlCommand verificarAdminCmd = new SqlCommand(verificarAdminQuery, conexionBD.AbrirConexion()))
                {
                    int totalAdministradores = (int)verificarAdminCmd.ExecuteScalar(); // Obtiene la cantidad de administradores

                    // Verificar si el empleado que intentas eliminar es un administrador
                    string rolEmpleadoQuery = "SELECT rol FROM Empleados WHERE dni_empleado = @dni";
                    using (SqlCommand rolEmpleadoCmd = new SqlCommand(rolEmpleadoQuery, conexionBD.AbrirConexion()))
                    {
                        rolEmpleadoCmd.Parameters.AddWithValue("@dni", dni);
                        string rolEmpleado = (string)rolEmpleadoCmd.ExecuteScalar();

                        // Si el empleado es administrador y es el último administrador, no permitir la eliminación
                        if (rolEmpleado == "Administrador" && totalAdministradores <= 1)
                        {
                            MessageBox.Show("No puedes eliminar este empleado porque es el último administrador del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                // Si pasa la verificación, proceder con la eliminación
                using (SqlCommand eliminarCmd = new SqlCommand(eliminarEmpleadoQuery, conexionBD.AbrirConexion()))
                {
                    eliminarCmd.Parameters.AddWithValue("@dni", dni);
                    eliminarCmd.ExecuteNonQuery();
                    MessageBox.Show("Empleado eliminado correctamente.");
                }
            }
            catch (Exception ex)
            {
                if (ex is SqlException sqlException && sqlException.Number == 547)
                {
                    MessageBox.Show("No se puede eliminar el empleado porque tiene ventas relacionadas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error al eliminar el empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }


        // FIN CRUD //

        public List<CEmpleado> TraerEmpleados()
        {
            List<CEmpleado> Empleados = new List<CEmpleado>();
            string query = "select * from empleados";
            try
            {
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    CEmpleado Empleado = new CEmpleado
                    {
                        dni_empleado = Convert.ToInt32(reader["dni_empleado"].ToString()),
                        nombre = reader["nombre"].ToString(),
                        apellido = reader["apellido"].ToString(),
                        telefono = reader["telefono"].ToString(),
                        fecha_nac = DateTime.Parse(reader["fecha_nac"].ToString()),
                        domicilio = reader["domicilio"].ToString(),
                        email = reader["email"].ToString(),
                        contraseña = reader["contraseña"].ToString(),
                        rol = reader["rol"].ToString()
                    };

                    Empleados.Add(Empleado);
                }

                reader.Close();
                return Empleados;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al mostrar los Empleados: " + ex);
                throw;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }
        public List<CEmpleado> CargarGrilla()
        {
            List<CEmpleado> Empleados = new List<CEmpleado>();
            string query = "select dni_empleado as 'DNI', nombre as 'Nombre', apellido as 'Apellido', telefono as 'Teléfono', fecha_nac as 'Fecha de Nacimiento',domicilio as 'Domicilio', email as 'E-Mail', contraseña as 'Contraseña' from Empleados";
            try
            {
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    CEmpleado Empleado = new CEmpleado
                    {
                        
                        dni_empleado = Convert.ToInt32(reader["DNI"].ToString()),
                        nombre = reader["Nombre"].ToString(),
                        apellido = reader["Apellido"].ToString(),
                        telefono = reader["Teléfono"].ToString(),
                        fecha_nac = DateTime.Parse(reader["Fecha de Nacimiento"].ToString()),
                        domicilio = reader["Domicilio"].ToString(),
                        email = reader["E-Mail"].ToString(),
                        contraseña = reader["Contraseña"].ToString(),
                        rol = reader["rol"].ToString()
                    };
                    Empleados.Add(Empleado);
                }

                reader.Close();
                return Empleados;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al mostrar los Empleados: " + ex);
                throw;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        public bool DniExiste(int dni)
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
            catch (Exception)
            {
                MessageBox.Show("Error al verificar si el DNI existe.");
                return false;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }
    }
}
