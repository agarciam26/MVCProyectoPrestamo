using System;
using System.Collections.Generic;

namespace MVCProyectoPrestamo.Models.EntidadesBD
{
    public partial class PreAuditoria
    {
        public PreAuditoria()
        {
            PreDetalleEvaluacion = new HashSet<PreDetalleEvaluacion>();
        }

        public int AudAuditoria { get; set; }
        public DateTime? AudFecha { get; set; }
        public string AudEstatus { get; set; }
        public string AudDescripcion { get; set; }

        public virtual ICollection<PreDetalleEvaluacion> PreDetalleEvaluacion { get; set; }
    }
}
