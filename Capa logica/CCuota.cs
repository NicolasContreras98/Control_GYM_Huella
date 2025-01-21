using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Gym.Capa_logica
{
    internal class CCuota
    {
        public int cod_cuota { get; set; }
        public DateTime fecha_pago { get; set; }
        public int dniSocio { get; set; } // Cambiado a dniSocio
        public string nombre_membresia { get; set; }
        public decimal precio { get; set; }
    }
}
