using System;
using System.Collections.Generic;

namespace MVCProyectoPrestamo.Models.EntidadesBD
{
    public partial class PreCliente
    {
        public PreCliente()
        {
            PreSolicitud = new HashSet<PreSolicitud>();
            Usuario = new HashSet<Usuario>();
        }

        public int CliCliente { get; set; }
        public string CliNombre { get; set; }
        public string CliApellido { get; set; }
        public decimal CliNit { get; set; }
        public DateTime CliNacimiento { get; set; }

        public virtual ICollection<PreSolicitud> PreSolicitud { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
