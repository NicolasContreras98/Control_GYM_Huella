using Control_Gym.Capa_de_datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Gym.Capa_logica
{
    internal class CAcceso
    {
        private CAccesoD cAccesoD = new CAccesoD();
        public int dni_empleado { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public DateTime fecha_nac { get; set; }
        public string domicilio { get; set; }
        public string email { get; set; }
        public string contraseña { get; set; }
        public string rol { get; set; }

        public CAcceso() { }
        public CAcceso(int dni_empleado, string nombre, string apellido, string telefono, DateTime fecha_nac, string domicilio, string email, string contraseña, string rol)
        {
            this.dni_empleado = dni_empleado;
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
            this.fecha_nac = fecha_nac;
            this.domicilio = domicilio;
            this.email = email;
            this.contraseña = contraseña;
            this.rol = rol;
        }
        public CAcceso(int dni_empleado, string contraseña)
        {
            this.dni_empleado = dni_empleado;
            this.contraseña = contraseña;
        }

        public List<CAcceso> Login(CAcceso cAcc)
        {
            List<CAcceso> acceso = cAccesoD.Login(cAcc);
            return acceso;
        }
    }
}
