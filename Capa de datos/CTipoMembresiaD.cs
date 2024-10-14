using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using Control_Gym.Capa_logica;

namespace Control_Gym.Capa_de_datos
{
    internal class CTipoMembresiaD
    {
        ConexionBD conexionBD = ConexionBD.Instancia;
        public List<CTipoMembresia> traerTipos()
        {
            List<CTipoMembresia> tipos_membresias = new List<CTipoMembresia>();
            try
            {
                conexionBD.AbrirConexion();
                string query = "select * from tipos_membresias";
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                SqlDataReader reader = comando.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        int cod_tipo_membresia = Convert.ToInt32(reader["cod_tipo_membresia"]);
                        string nombre = reader["nombre"].ToString();
                        int cantidadDias = Convert.ToInt32(reader["cantidad_dias"]);

                        CTipoMembresia tipoMembresia = new CTipoMembresia(cod_tipo_membresia, nombre);
                        tipoMembresia.cantidad_dias = cantidadDias;
                        tipos_membresias.Add(tipoMembresia);
                    }
                }
                return tipos_membresias;
            }
            catch
            {
                MessageBox.Show("Error al traer los tipos");
                return null;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        public List<CTipoMembresia> traerTiposDelSocio(int id_socio )
        {
            List<CTipoMembresia> tipos_membresias = new List<CTipoMembresia>();
            try
            {
                string query = "SELECT tipos_membresias.* FROM membresias INNER JOIN tipos_membresias ON membresias.cod_tipo_membresia = tipos_membresias.cod_tipo_membresia WHERE membresias.id_socio = @id_socio";
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                comando.Parameters.AddWithValue("@id_socio", id_socio);
                SqlDataReader reader = comando.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        int cod_tipo_membresia = Convert.ToInt32(reader["cod_tipo_membresia"]);
                        string nombre = reader["nombre"].ToString();
                        int cantidadDias = Convert.ToInt32(reader["cantidad_dias"]);

                        CTipoMembresia tipoMembresia = new CTipoMembresia(cod_tipo_membresia, nombre);
                        tipoMembresia.cantidad_dias = cantidadDias;
                        tipos_membresias.Add(tipoMembresia);
                    }
                }
                reader.Close();
                return tipos_membresias;
            }
            catch
            {
                MessageBox.Show("Error al traer los tipos");
                return null;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }
    }
}
