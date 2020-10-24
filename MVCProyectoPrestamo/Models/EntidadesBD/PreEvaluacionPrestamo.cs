using System;
using System.Collections.Generic;

namespace MVCProyectoPrestamo.Models.EntidadesBD
{
    public partial class PreEvaluacionPrestamo
    {
        public PreEvaluacionPrestamo()
        {
            PreDetalleEvaluacion = new HashSet<PreDetalleEvaluacion>();
        }

        public int EvaEvaluacionPrestamo { get; set; }
        public DateTime? EvaFecha { get; set; }
        public string EvaEstatus { get; set; }
        public string EvaDescripcion { get; set; }

        public virtual ICollection<PreDetalleEvaluacion> PreDetalleEvaluacion { get; set; }
    }
}
