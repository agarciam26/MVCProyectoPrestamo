using System;
using System.Collections.Generic;

namespace MVCProyectoPrestamo.Models.EntidadesBD
{
    public partial class PreDetalleEvaluacion
    {
        public int DetevalDetalleEvaluacion { get; set; }
        public int SolSolicitud { get; set; }
        public int EvaEvaluacion { get; set; }
        public int AudAuditoria { get; set; }

        public virtual PreAuditoria AudAuditoriaNavigation { get; set; }
        public virtual PreEvaluacionPrestamo EvaEvaluacionNavigation { get; set; }
        public virtual PreSolicitud SolSolicitudNavigation { get; set; }
    }
}
