using System;
using System.Collections.Generic;

namespace MVCProyectoPrestamo.Models.EntidadesBD
{
    public partial class PrePrestamo
    {
        public PrePrestamo()
        {
            PreDetalleAbonoPrestamo = new HashSet<PreDetalleAbonoPrestamo>();
        }

        public int PrePrestamo1 { get; set; }
        public int SolSolicitud { get; set; }
        public decimal PreInteres { get; set; }
        public DateTime? PreFechaDesembolso { get; set; }
        public decimal PreMonto { get; set; }

        public virtual PreSolicitud SolSolicitudNavigation { get; set; }
        public virtual ICollection<PreDetalleAbonoPrestamo> PreDetalleAbonoPrestamo { get; set; }
    }
}
