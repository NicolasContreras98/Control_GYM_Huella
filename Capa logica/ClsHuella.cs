using Control_Gym.Capa_de_datos;
using libzkfpcsharp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_Gym.Capa_logica
{
    internal class ClsHuella
    {
        public int id_huella { get; set; }
        public int id_socio { get; set; }
        public byte[] huella { get; set; }
        public DateTime fecha_registro { get; set; }

        public ClsHuella() { }

        private CHuellaD cHuellaD = new CHuellaD();

        public bool ResetearHuella(int id_socio)
        {
            return cHuellaD.ResetearHuella(id_socio);
        }
        
    }
}
