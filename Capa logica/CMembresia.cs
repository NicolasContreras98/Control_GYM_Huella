using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Control_Gym.Capa_de_datos;

namespace Control_Gym.Capa_logica
{
    internal class CMembresia
    {
        public int cod_membresia { get; set; }
        public int cod_tipo_membresia { get; set; }
        public int id_socio { get; set; } //agrego id_socio
        public int dni_socio { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public string nombre_tipo { get; set; }
        public decimal precio_tipo { get; set; }
        public int cantidad_dias { get; set; }
        public CMembresia() { 
        
        }
        private CMembresiaD cMembresiaD = new CMembresiaD();
        public CMembresia(int cod_tipo_membresia, int dni_socio,int id_socio, DateTime fecha_inicio, DateTime fecha_fin)
        {
            this.cod_membresia = cod_membresia;
            this.cod_tipo_membresia = cod_tipo_membresia;
            this.dni_socio = dni_socio;
            this.id_socio = id_socio;
            this.fecha_inicio = fecha_inicio;
            this.fecha_fin = fecha_fin;
        }
        public CMembresia(int cod_membresia, int cod_tipo_membresia, int dni_socio,int id_socio, DateTime fecha_inicio, DateTime fecha_fin)
        {
            this.cod_membresia = cod_membresia;
            this.cod_tipo_membresia = cod_tipo_membresia;
            this.dni_socio = dni_socio;
            this.id_socio = id_socio;
            this.fecha_inicio = fecha_inicio;
            this.fecha_fin = fecha_fin;
        }
        public CMembresia(int cod_membresia, int cod_tipo_membresia, int dni_socio,int id_socio, DateTime fecha_inicio, DateTime fecha_fin, string nombre_tipo, decimal precio_tipo, int cantidad_dias)
        {
            this.cod_membresia = cod_membresia;
            this.cod_tipo_membresia = cod_tipo_membresia;
            this.dni_socio = dni_socio;
            this.id_socio = id_socio;
            this.fecha_inicio = fecha_inicio;
            this.fecha_fin = fecha_fin;
            this.nombre_tipo = nombre_tipo;
            this.precio_tipo = precio_tipo;
            this.cantidad_dias = cantidad_dias;
        }
        public CMembresia(int cod_tipo_membresia)
        {
            this.cod_tipo_membresia = cod_tipo_membresia;
        }

        public void CrearMembresia(CMembresia cMembresia)
        {
            cMembresiaD.CrearMembresia(cMembresia);
        }

        public List<CMembresia> TraerMembresias()
        {
            List<CMembresia> membresias = cMembresiaD.TraerMembresias();
            cMembresiaD.TraerMembresias();
            return membresias;
        }

        public void EditarMembresia(CMembresia cMembresia)
        {
            cMembresiaD.EditarMembresia(cMembresia);
        }

        public List<CMembresia> CargarGrilla()
        {
            List<CMembresia> membresias = cMembresiaD.CargarGrilla();
            cMembresiaD.CargarGrilla();
            return membresias;
        }

        public void EliminarMembresia(int id)
        {
            cMembresiaD.EliminarMembresia(id);
        }

        public List<CMembresia> BuscarPorDNI(int dni)
        {
            List<CMembresia> membresias = cMembresiaD.BuscarPorDNI(dni);
            return membresias;
        }

        public void Renovar(CMembresia cMembresia)
        {
            CMembresia membresia = new CMembresia();
            membresia.Renovar(cMembresia);
        }
    }
}
