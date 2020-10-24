using System;
using System.Collections.Generic;

namespace MVCProyectoPrestamo.Models.EntidadesBD
{
    public partial class PreEmpleado
    {
        public PreEmpleado()
        {
            PreSolicitud = new HashSet<PreSolicitud>();
        }

        public int EmpEmpleado { get; set; }
        public string EmpNombre { get; set; }
        public string EmpApellido { get; set; }
        public string EmpPuesto { get; set; }

        public virtual ICollection<PreSolicitud> PreSolicitud { get; set; }
    }
}
