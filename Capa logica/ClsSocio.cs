using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using Control_Gym.Capa_de_datos;

namespace Control_Gym.Capa_logica
{
    internal class ClsSocio
    {
        public int Id_socio { get; set; } //agrego id_socio
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string Domicilio { get; set; }
        public string Email { get; set; }
        //Agrego los campos de la tabla membresia para el join para el chequeo
        public DateTime? Fecha_Inicio { get; set; }
        public DateTime? Fecha_Fin { get; set; }
        public List<CTipoMembresia> Tipos_membresias { get; set; } = new List<CTipoMembresia>();

        public ClsSocio(int Id_socio, int Dni, string Nombre, string Apellido, string Telefono, DateTime FechaDeNacimiento, string Domicilio, string Email, List<CTipoMembresia> tipos_membresias)
        {
            this.Id_socio = Id_socio;  //agrego id_socio
            this.Dni = Dni; 
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Telefono = Telefono;
            this.FechaDeNacimiento = FechaDeNacimiento;
            this.Domicilio = Domicilio;
            this.Email = Email;
            this.Tipos_membresias = tipos_membresias;
        }
        public ClsSocio(int id_socio, int dni, string nombre, string apellido,  DateTime? fecha_Inicio, DateTime? fecha_Fin, List<CTipoMembresia> tipos_membresias)
        {
            this.Id_socio = id_socio;
            this.Dni = dni;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Fecha_Inicio = fecha_Inicio;
            this.Fecha_Fin = fecha_Fin;
            this.Tipos_membresias = tipos_membresias;
        }
        public ClsSocio(int id_socio, int dni, string nombre, string apellido, DateTime? fecha_Inicio, DateTime? fecha_Fin)
        {
            this.Id_socio = id_socio;
            this.Dni = dni;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Fecha_Inicio = fecha_Inicio;
            this.Fecha_Fin = fecha_Fin;
        }

        public ClsSocio()
        {
        }

        public ClsSocio(string nombre, string apellido)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
        }

        public int GuardarSocio(int dni, string nombre, string apellido, DateTime fechaNacimiento, string telefono, string domicilio, string email)
        { 
            CSociosD CSociosD = new CSociosD();
            return CSociosD.GuardarSocio(dni, nombre, apellido, fechaNacimiento, telefono, domicilio, email);
        }
        public void ModificarSocio(int id_socio, string nombre, string apellido, DateTime fechaNacimiento, string telefono, string domicilio, string email)
        {
            CSociosD cSociosD = new CSociosD();
            cSociosD.ModificarSocio(id_socio, nombre, apellido, fechaNacimiento, telefono, domicilio, email);
        }
        public DataTable CargarDatos()
        {
           
            CSociosD cSociosD = new CSociosD();
            DataTable tabla = new DataTable();
            tabla = cSociosD.CargarDatos();

            return tabla;
        }
        public void EliminarDatos(int id_socio, string nombre)
        {
            CSociosD cSociosD = new CSociosD();
            cSociosD.EliminarDatos(id_socio, nombre);  //CAMBUI dni POR id_socio 
        }
         public DataTable Filtrar(string dni)
        {

            CSociosD cSociosD = new CSociosD();
            DataTable tabla = new DataTable();
            tabla = cSociosD.Filtrar(dni);

            return tabla;
        }
    }
}