using Control_Gym.Capa_logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Control_Gym.Capa_de_datos
{
    internal class CMembresiaD
    {
        private ConexionBD conexionBD = ConexionBD.Instancia;
        private CCuotaD cCuotaD = new CCuotaD();

        public bool TieneTipoMembresia(int id_socio, int cod_tipo)
        {
            string query = @"SELECT COUNT(*) 
                     FROM membresias 
                     WHERE id_socio = @id_socio 
                     AND cod_tipo_membresia = @cod_tipo";

            try
            {
                SqlCommand cmd = new SqlCommand(query, conexionBD.AbrirConexion());
                cmd.Parameters.AddWithValue("@id_socio", id_socio);
                cmd.Parameters.AddWithValue("@cod_tipo", cod_tipo);

                int resultado = Convert.ToInt32(cmd.ExecuteScalar());
                return resultado > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar membresía: " + ex.Message);
                return false;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        public DataTable TraerMembresias()
        {
            // Consulta que incluye el nombre completo del socio y su DNI junto con los datos de membresía
            string query = @"
        SELECT 
            m.cod_membresia,
            m.cod_tipo_membresia,
            s.dni_socio,
            (s.nombre + ' ' + s.apellido) AS nombre_completo,
            m.fecha_inicio,
            m.fecha_fin,
            t.nombre AS tipo_membresia,
            t.precio,
            t.cantidad_dias
        FROM membresias m
        INNER JOIN (
            SELECT 
                id_socio, 
                MAX(fecha_inicio) AS UltimaFechaInicio
            FROM membresias
            GROUP BY id_socio
        ) ultima_membresia ON m.id_socio = ultima_membresia.id_socio 
            AND m.fecha_inicio = ultima_membresia.UltimaFechaInicio
        LEFT JOIN tipos_membresias t ON m.cod_tipo_membresia = t.cod_tipo_membresia
        LEFT JOIN socios s ON m.id_socio = s.id_socio;
    ";

            DataTable tabla = new DataTable();

            try
            {
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                SqlDataReader reader = comando.ExecuteReader();

                // Cargar los datos en el DataTable
                tabla.Load(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al mostrar las membresías: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }

            return tabla;
        }

        public int CrearMembresia(CMembresia cMembresia)
        {
            string query = @"
    INSERT INTO membresias (cod_tipo_membresia, id_socio, fecha_inicio, fecha_fin) 
    VALUES (@cod_tipo_membresia, @id_socio, @fecha_inicio, @fecha_fin); 
    SELECT SCOPE_IDENTITY();";

            int idMembresia = -1;

            SqlConnection conn = null;
            SqlTransaction tx = null;

            try
            {
                conn = conexionBD.AbrirConexion();
                tx = conn.BeginTransaction();

                // 1. Insertar membresía
                SqlCommand cmd = new SqlCommand(query, conn, tx);
                cmd.Parameters.AddWithValue("@cod_tipo_membresia", cMembresia.cod_tipo_membresia);
                cmd.Parameters.AddWithValue("@id_socio", cMembresia.id_socio);
                cmd.Parameters.AddWithValue("@fecha_inicio", cMembresia.fecha_inicio.Date);
                cmd.Parameters.AddWithValue("@fecha_fin", cMembresia.fecha_fin.Date);

                idMembresia = Convert.ToInt32(cmd.ExecuteScalar());

                // 2. Registrar cuota
                SqlCommand cmdCuota = new SqlCommand("sp_RegistrarCuota", conn, tx);
                cmdCuota.CommandType = CommandType.StoredProcedure;
                cmdCuota.Parameters.AddWithValue("@cod_membresia", idMembresia);
                cmdCuota.ExecuteNonQuery();

                tx.Commit();
            }
            catch (Exception ex)
            {
                if (tx != null)
                    tx.Rollback();

                MessageBox.Show("Error al crear membresía: " + ex.Message);
                idMembresia = -1;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }

            return idMembresia;
        }

        public void ActualizarMembresia(CMembresia cMembresia)
        {
            string query = @"UPDATE membresias 
                     SET cod_tipo_membresia = @cod_tipo_membresia,  
                         fecha_inicio = @fecha_inicio, 
                         fecha_fin = @fecha_fin 
                     WHERE cod_membresia = @cod_membresia";

            SqlConnection conn = null;
            SqlTransaction tx = null;

            try
            {
                conn = conexionBD.AbrirConexion();
                tx = conn.BeginTransaction();

                // 1. Actualizar membresía
                SqlCommand comando = new SqlCommand(query, conn, tx);
                comando.Parameters.AddWithValue("@cod_tipo_membresia", cMembresia.cod_tipo_membresia);
                comando.Parameters.AddWithValue("@fecha_inicio", cMembresia.fecha_inicio);
                comando.Parameters.AddWithValue("@fecha_fin", cMembresia.fecha_fin);
                comando.Parameters.AddWithValue("@cod_membresia", cMembresia.cod_membresia);

                comando.ExecuteNonQuery();

                // 2. Registrar cuota
                SqlCommand cmdCuota = new SqlCommand("sp_RegistrarCuota", conn, tx);
                cmdCuota.CommandType = CommandType.StoredProcedure;
                cmdCuota.Parameters.AddWithValue("@cod_membresia", cMembresia.cod_membresia);

                cmdCuota.ExecuteNonQuery();

                tx.Commit();

                MessageBox.Show("Membresía actualizada correctamente");
            }
            catch (Exception ex)
            {
                if (tx != null)
                    tx.Rollback();

                MessageBox.Show("Error en base de datos: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        public bool RenovarMembresia(int codMembresia, DateTime fechaElegida)
        {
            SqlConnection conn = null;
            SqlTransaction trans = null;

            try
            {
                conn = conexionBD.AbrirConexion();
                trans = conn.BeginTransaction();

                int dias = 0;
                DateTime fechaFinActual;

                // 1. Obtener datos actuales
                using (SqlCommand cmd = new SqlCommand(@"
            SELECT tm.cantidad_dias, m.fecha_fin
            FROM membresias m
            INNER JOIN tipos_membresias tm 
                ON m.cod_tipo_membresia = tm.cod_tipo_membresia
            WHERE m.cod_membresia = @cod_membresia", conn, trans))
                {
                    cmd.Parameters.AddWithValue("@cod_membresia", codMembresia);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (!dr.Read())
                            throw new Exception("No se encontró la membresía");

                        dias = Convert.ToInt32(dr["cantidad_dias"]);
                        fechaFinActual = Convert.ToDateTime(dr["fecha_fin"]);
                    }
                }

                DateTime nuevaFechaInicio;

                // SI está vencida → usar fecha elegida (ej: hoy)
                if (fechaFinActual < DateTime.Now)
                {
                    nuevaFechaInicio = fechaElegida;
                }
                else
                {
                    // SI NO está vencida → acumular desde el vencimiento
                    nuevaFechaInicio = fechaFinActual;
                }

                DateTime nuevaFechaFin = nuevaFechaInicio.AddDays(dias);

                // 3. Update
                using (SqlCommand cmdUpdate = new SqlCommand(@"
            UPDATE membresias
            SET fecha_inicio = @fecha_inicio,
                fecha_fin = @fecha_fin,
                estado = 'Activa'
            WHERE cod_membresia = @cod_membresia", conn, trans))
                {
                    cmdUpdate.Parameters.AddWithValue("@fecha_inicio", nuevaFechaInicio);
                    cmdUpdate.Parameters.AddWithValue("@fecha_fin", nuevaFechaFin);
                    cmdUpdate.Parameters.AddWithValue("@cod_membresia", codMembresia);

                    cmdUpdate.ExecuteNonQuery();
                }

                // 4. Registrar cuota
                using (SqlCommand cmdCuota = new SqlCommand("sp_RegistrarCuota", conn, trans))
                {
                    cmdCuota.CommandType = CommandType.StoredProcedure;
                    cmdCuota.Parameters.AddWithValue("@cod_membresia", codMembresia);
                    cmdCuota.ExecuteNonQuery();
                }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback(); // ✔ CORRECTO

                MessageBox.Show("Error al renovar membresía: " + ex.Message);
                return false;
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

        public bool SocioExiste(int dni)
        {
            string query = "SELECT COUNT(*) FROM socios WHERE dni_socio = '" + dni + "'";
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

        public DataTable BuscarPorDNI(string criterioBusqueda)
        {
            string query = @"
                SELECT 
                    m.cod_membresia AS cod_membresia, 
                    m.cod_tipo_membresia AS cod_tipo_membresia,
                    s.dni_socio AS dni_socio,
                    (s.nombre + ' ' + s.apellido) AS nombre_completo,
                    m.fecha_inicio AS fecha_inicio,
                    m.fecha_fin AS fecha_fin,
                    t.nombre AS tipo_membresia,
                    t.precio AS precio,
                    t.cantidad_dias AS cantidad_dias
                FROM membresias m
                LEFT JOIN tipos_membresias t ON m.cod_tipo_membresia = t.cod_tipo_membresia
                LEFT JOIN socios s ON m.id_socio = s.id_socio
                WHERE s.nombre LIKE @criterio OR s.apellido LIKE @criterio OR s.dni_socio LIKE @criterio";

            try
            {
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                comando.Parameters.AddWithValue("@criterio", "%" + criterioBusqueda + "%"); // Agregar el parámetro con comodines

                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataTable dtMembresias = new DataTable();
                adapter.Fill(dtMembresias);

                return dtMembresias;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al mostrar las membresías: " + ex.Message);
                throw;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        public Dictionary<string, int> ObtenerTotalMembresias(int? mes = null, int? año = null, bool agruparPorDia = false)
        {
            Dictionary<string, int> datos = new Dictionary<string, int>();

            string query = @"
        SELECT 
            FORMAT(c.fecha_pago, @Formato, 'es-ES') AS Etiqueta, 
            SUM(tm.precio) AS TotalMembresiasVendidas
        FROM cuotas c
        JOIN membresias m ON c.cod_membresia = m.cod_membresia
        JOIN tipos_membresias tm ON m.cod_tipo_membresia = tm.cod_tipo_membresia
        WHERE 1 = 1"; // Condición inicial para facilitar la concatenación de filtros

            // Agregar filtros según los parámetros proporcionados
            if (mes.HasValue)
            {
                query += " AND DATEPART(MONTH, c.fecha_pago) = @Mes";
            }
            if (año.HasValue)
            {
                query += " AND DATEPART(YEAR, c.fecha_pago) = @Año";
            }

            // Determinar el formato de agrupación
            string formato = agruparPorDia ? "dd MMMM" : "MMMM yyyy";

            query += @"
        GROUP BY FORMAT(c.fecha_pago, @Formato, 'es-ES'), DATEPART(YEAR, c.fecha_pago), DATEPART(MONTH, c.fecha_pago)
        ORDER BY DATEPART(YEAR, c.fecha_pago), DATEPART(MONTH, c.fecha_pago);";

            SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());

            // Agregar parámetros si se proporcionan
            if (mes.HasValue)
            {
                comando.Parameters.AddWithValue("@Mes", mes.Value);
            }
            if (año.HasValue)
            {
                comando.Parameters.AddWithValue("@Año", año.Value);
            }
            comando.Parameters.AddWithValue("@Formato", formato);

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                datos.Add(reader["Etiqueta"].ToString(), Convert.ToInt32(reader["TotalMembresiasVendidas"]));
            }

            conexionBD.CerrarConexion();
            return datos;
        }

        public int ObtenerCantidadSocios(int? mes = null, int? año = null)
        {
            string query = @"
        SELECT COUNT(DISTINCT m.id_socio) AS CantidadSocios
        FROM membresias m
        WHERE 1 = 1"; // Condición inicial para facilitar la concatenación de filtros

            // Agregar filtros según los parámetros proporcionados
            if (mes.HasValue)
            {
                query += " AND DATEPART(MONTH, m.fecha_inicio) = @Mes";
            }
            if (año.HasValue)
            {
                query += " AND DATEPART(YEAR, m.fecha_inicio) = @Año";
            }

            SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());

            // Agregar parámetros si se proporcionan
            if (mes.HasValue)
            {
                comando.Parameters.AddWithValue("@Mes", mes.Value);
            }
            if (año.HasValue)
            {
                comando.Parameters.AddWithValue("@Año", año.Value);
            }

            int cantidadSocios = Convert.ToInt32(comando.ExecuteScalar());
            conexionBD.CerrarConexion();
            return cantidadSocios;
        }

        public int ObtenerCantidadCuotas(int? mes = null, int? año = null)
        {
            string query = @"
        SELECT COUNT(*) AS CantidadCuotas
        FROM cuotas c
        WHERE 1 = 1"; // Condición inicial para facilitar la concatenación de filtros

            // Agregar filtros según los parámetros proporcionados
            if (mes.HasValue)
            {
                query += " AND DATEPART(MONTH, c.fecha_pago) = @Mes";
            }
            if (año.HasValue)
            {
                query += " AND DATEPART(YEAR, c.fecha_pago) = @Año";
            }

            SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());

            // Agregar parámetros si se proporcionan
            if (mes.HasValue)
            {
                comando.Parameters.AddWithValue("@Mes", mes.Value);
            }
            if (año.HasValue)
            {
                comando.Parameters.AddWithValue("@Año", año.Value);
            }

            int cantidadCuotas = Convert.ToInt32(comando.ExecuteScalar());
            conexionBD.CerrarConexion();
            return cantidadCuotas;
        }
    }
}
