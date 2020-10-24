using System;
using System.Collections.Generic;

namespace MVCProyectoPrestamo.Models.EntidadesBD
{
    public partial class PreSolicitud
    {
        public PreSolicitud()
        {
            PreDetalleEvaluacion = new HashSet<PreDetalleEvaluacion>();
            PrePrestamo = new HashSet<PrePrestamo>();
        }

        public int SolSolicitud { get; set; }
        public int SolPrePresolicitud { get; set; }
        public DateTime? SolFecha { get; set; }
        public int CliCliente { get; set; }
        public int EmpEmpleado { get; set; }
        public string SolEstadosCuenta { get; set; }
        public string SolReciboServicios { get; set; }
        public string SolEstatus { get; set; }
        public string SolTipoMoneda { get; set; }
        public decimal UseUsuario { get; set; }

        public virtual PreCliente CliClienteNavigation { get; set; }
        public virtual PreEmpleado EmpEmpleadoNavigation { get; set; }
        public virtual PrePresolicitud SolPrePresolicitudNavigation { get; set; }
        public virtual ICollection<PreDetalleEvaluacion> PreDetalleEvaluacion { get; set; }
        public virtual ICollection<PrePrestamo> PrePrestamo { get; set; }
    }
}
