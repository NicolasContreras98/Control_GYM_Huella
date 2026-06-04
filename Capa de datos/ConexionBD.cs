using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Control_Gym.Capa_de_datos;

namespace Control_Gym.Capa_de_datos
{
    public class ConexionBD
    {
        private static ConexionBD instancia;
        private string cadenaConexion = "Server=localhost\\SQLEXPRESS;Database=control_gym_huella;Trusted_Connection=True;";

        private SqlConnection conexion;

        private ConexionBD()
        {
            conexion = new SqlConnection(cadenaConexion);
        }

        public static ConexionBD Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ConexionBD();
                }
                return instancia;
            }
        }

        public SqlConnection AbrirConexion()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
            return conexion;
        }

        public void CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}
