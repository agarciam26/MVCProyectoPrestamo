using System;
using System.Collections.Generic;

namespace MVCProyectoPrestamo.Models.EntidadesBD
{
    public partial class Roles
    {
        public Roles()
        {
            Permisos = new HashSet<Permisos>();
            UsuarioRol = new HashSet<UsuarioRol>();
        }

        public int RolRol { get; set; }
        public string RolNombre { get; set; }

        public virtual ICollection<Permisos> Permisos { get; set; }
        public virtual ICollection<UsuarioRol> UsuarioRol { get; set; }
    }
}
