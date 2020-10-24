using System;
using System.Collections.Generic;

namespace MVCProyectoPrestamo.Models.EntidadesBD
{
    public partial class UsuarioRol
    {
        public int UsrUsuarioRol { get; set; }
        public int UseUsuario { get; set; }
        public int RolRol { get; set; }

        public virtual Roles RolRolNavigation { get; set; }
        public virtual Usuario UseUsuarioNavigation { get; set; }
    }
}
