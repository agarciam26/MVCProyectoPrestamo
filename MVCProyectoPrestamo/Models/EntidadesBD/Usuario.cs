using System;
using System.Collections.Generic;

namespace MVCProyectoPrestamo.Models.EntidadesBD
{
    public partial class Usuario
    {
        public Usuario()
        {
            UsuarioRol = new HashSet<UsuarioRol>();
        }

        public int UseUsuario { get; set; }
        public string UseNombre { get; set; }
        public string UsePassword { get; set; }
        public string UseEstatus { get; set; }
        public int CliCliente { get; set; }
        public int EmpPuesto { get; set; }

        public virtual PreCliente CliClienteNavigation { get; set; }
        public virtual ICollection<UsuarioRol> UsuarioRol { get; set; }
    }
}
