using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows.Forms;

namespace Control_Gym.Capa_de_datos
{
    internal class CHuellaD
    {
        private ConexionBD conexionBD = ConexionBD.Instancia;

        public bool ResetearHuella(int id_socio)
        {
            string query = "delete huellas_digitales where id_socio = @id_socio";
            try
            {
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                comando.Parameters.AddWithValue("@id_socio", id_socio);
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool GuardarHuella(int id_socio, byte[] huella)
        {
            try
            {
                // Verificar cuántas huellas ya tiene el socio
                string consultaConteo = "SELECT COUNT(*) FROM huellas_digitales WHERE id_socio = @id_socio";
                SqlCommand comandoConteo = new SqlCommand(consultaConteo, conexionBD.AbrirConexion());
                comandoConteo.Parameters.AddWithValue("@id_socio", id_socio);
                int numeroHuellas = (int)comandoConteo.ExecuteScalar();

                // Permitir máximo 3 huellas
                if (numeroHuellas >= 3)
                {
                    MessageBox.Show("El socio ya tiene el máximo permitido de 3 huellas registradas.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                string consultaInsert = "INSERT INTO huellas_digitales (id_socio, huella, fecha_registro) VALUES (@id_socio, @huella, GETDATE())";
                SqlCommand comandoInsert = new SqlCommand(consultaInsert, conexionBD.AbrirConexion());
                comandoInsert.Parameters.AddWithValue("@id_socio", id_socio);
                comandoInsert.Parameters.AddWithValue("@huella", huella);

                comandoInsert.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la huella: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }
        public List<(int id_socio, byte[] huella)> ObtenerHuellasDesdeDB()
        {
            List<(int, byte[])> huellas = new List<(int, byte[])>();
            string query = "SELECT id_socio, huella FROM huellas_digitales";

            SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());

            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    int idSocio = (int)reader["id_socio"];
                    byte[] huella = reader["huella"] as byte[];
                    huellas.Add((idSocio, huella));
                }
            }

            return huellas;
        }

    }
}
