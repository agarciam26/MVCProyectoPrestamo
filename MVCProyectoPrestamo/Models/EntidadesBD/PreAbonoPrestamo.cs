using System;
using System.Collections.Generic;

namespace MVCProyectoPrestamo.Models.EntidadesBD
{
    public partial class PreAbonoPrestamo
    {
        public PreAbonoPrestamo()
        {
            PreDetalleAbonoPrestamo = new HashSet<PreDetalleAbonoPrestamo>();
        }

        public int AbonAbonoPrestamo { get; set; }
        public DateTime? AbonFechaDepago { get; set; }
        public decimal AbonMonto { get; set; }
        public string AbonMoneda { get; set; }
        public decimal AbonInteresAcumulado { get; set; }

        public virtual ICollection<PreDetalleAbonoPrestamo> PreDetalleAbonoPrestamo { get; set; }
    }
}
