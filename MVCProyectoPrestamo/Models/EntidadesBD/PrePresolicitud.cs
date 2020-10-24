using System;
using System.Collections.Generic;

namespace MVCProyectoPrestamo.Models.EntidadesBD
{
    public partial class PrePresolicitud
    {
        public PrePresolicitud()
        {
            PreSolicitud = new HashSet<PreSolicitud>();
        }

        public int PrePresolicitud1 { get; set; }
        public DateTime? PreFecha { get; set; }
        public string PreNombreCliente { get; set; }
        public string PreApellidoCliente { get; set; }
        public decimal PreTelefono { get; set; }
        public string PreDireccion { get; set; }
        public string PreCorreo { get; set; }
        public decimal PreDpiCliente { get; set; }
        public decimal PreIngresosCliente { get; set; }
        public decimal PreMontoPrestamo { get; set; }
        public decimal PrePlazoPrestamo { get; set; }
        public decimal PreCuotaPrestamo { get; set; }
        public string PreNombreRecomen { get; set; }
        public decimal PreTelefonoRecomen { get; set; }
        public decimal PreDpiRecomen { get; set; }

        public virtual ICollection<PreSolicitud> PreSolicitud { get; set; }
    }
}
