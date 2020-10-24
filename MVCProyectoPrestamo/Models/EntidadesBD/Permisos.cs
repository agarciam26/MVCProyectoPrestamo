using System;
using System.Collections.Generic;

namespace MVCProyectoPrestamo.Models.EntidadesBD
{
    public partial class Permisos
    {
        public int PerPermisos { get; set; }
        public string UseNombre { get; set; }
        public string UseEstatus { get; set; }
        public int RolRol { get; set; }

        public virtual Roles RolRolNavigation { get; set; }
    }
}
