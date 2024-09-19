using Control_Gym.Capa_de_datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_Gym.Capa_logica
{
    internal class CEmpleado
    {
        public int dni_empleado { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string domicilio { get; set; }
        public string email { get; set; }
        public string contraseña { get; set; }
        public string rol {  get; set; }
        public DateTime fecha_nac { get; set; }

        public CEmpleado()
        {

        }

        private CEmpleadoD cEmpleadoD = new CEmpleadoD();
        public CEmpleado(int dni_empleado,  string nombre, string apellido, string telefono, DateTime fecha_nac, string domicilio, string email, string contraseña, string rol)
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

        public CEmpleado(int dni_empleado)
        {
            this.dni_empleado = dni_empleado;
        }

        // CRUD //
        public void CrearEmpleado(CEmpleado cEmpleado)
        {
            try
            {
                cEmpleadoD.CrearEmpleado(cEmpleado);
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show("Error al crear el empleado en la CAPA DE LOGICA DE NEGOCIO: " + ex);
            }
        }

        public void EditarEmpleado(CEmpleado cEmpleado)
        {
            try
            {
                cEmpleadoD.EditarEmpleado(cEmpleado);
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show("Error al actualizar el empleado en la CAPA DE LOGICA DE NEGOCIO: " + ex);
            }
        }
        public void EliminarEmpleado(int id)
        {
            try
            {
                cEmpleadoD.EliminarEmpleado(id);
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show("Error al eliminar el empleado en la CAPA DE LOGICA DE NEGOCIO: " + ex);
            }
            
        }

        // FIN CRUD //

        public List<CEmpleado> TraerEmpleados()
        {
            List<CEmpleado> Empleados = cEmpleadoD.TraerEmpleados();
            cEmpleadoD.TraerEmpleados();
            return Empleados;
        }

        public List<CEmpleado> CargarGrilla()
        {
            List<CEmpleado> Empleados = cEmpleadoD.CargarGrilla();
            cEmpleadoD.CargarGrilla();
            return Empleados;
        }
    }
}
