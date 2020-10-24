using System;
using System.Collections.Generic;

namespace MVCProyectoPrestamo.Models.EntidadesBD
{
    public partial class PreDetalleAbonoPrestamo
    {
        public int DetabonoDetalleAbonoPrestamo { get; set; }
        public int AbonAbonoPrestamo { get; set; }
        public int PrePrestamo { get; set; }

        public virtual PreAbonoPrestamo AbonAbonoPrestamoNavigation { get; set; }
        public virtual PrePrestamo PrePrestamoNavigation { get; set; }
    }
}
