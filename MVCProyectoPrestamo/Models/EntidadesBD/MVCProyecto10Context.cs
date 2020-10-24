using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVCProyectoPrestamo.Models.EntidadesBD
{
    public partial class MVCProyecto10Context : DbContext
    {
        public MVCProyecto10Context()
        {
        }

        public MVCProyecto10Context(DbContextOptions<MVCProyecto10Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<PreAbonoPrestamo> PreAbonoPrestamo { get; set; }
        public virtual DbSet<PreAuditoria> PreAuditoria { get; set; }
        public virtual DbSet<PreCliente> PreCliente { get; set; }
        public virtual DbSet<PreDetalleAbonoPrestamo> PreDetalleAbonoPrestamo { get; set; }
        public virtual DbSet<PreDetalleEvaluacion> PreDetalleEvaluacion { get; set; }
        public virtual DbSet<PreEmpleado> PreEmpleado { get; set; }
        public virtual DbSet<PreEvaluacionPrestamo> PreEvaluacionPrestamo { get; set; }
        public virtual DbSet<PrePresolicitud> PrePresolicitud { get; set; }
        public virtual DbSet<PrePrestamo> PrePrestamo { get; set; }
        public virtual DbSet<PreSolicitud> PreSolicitud { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioRol> UsuarioRol { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost; Database=MVCProyecto10; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permisos>(entity =>
            {
                entity.HasKey(e => e.PerPermisos)
                    .HasName("per_permisos_PK");

                entity.Property(e => e.PerPermisos).HasColumnName("per_permisos");

                entity.Property(e => e.RolRol).HasColumnName("rol_rol");

                entity.Property(e => e.UseEstatus)
                    .IsRequired()
                    .HasColumnName("use_estatus")
                    .HasMaxLength(2);

                entity.Property(e => e.UseNombre)
                    .IsRequired()
                    .HasColumnName("use_nombre")
                    .HasMaxLength(50);

                entity.HasOne(d => d.RolRolNavigation)
                    .WithMany(p => p.Permisos)
                    .HasForeignKey(d => d.RolRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rol_rol2_FK");
            });

            modelBuilder.Entity<PreAbonoPrestamo>(entity =>
            {
                entity.HasKey(e => e.AbonAbonoPrestamo)
                    .HasName("abon_abono_prestamo_PK");

                entity.ToTable("Pre_abono_prestamo");

                entity.Property(e => e.AbonAbonoPrestamo).HasColumnName("abon_abono_prestamo");

                entity.Property(e => e.AbonFechaDepago)
                    .HasColumnName("abon_fecha_depago")
                    .HasColumnType("date");

                entity.Property(e => e.AbonInteresAcumulado)
                    .HasColumnName("abon_interes_acumulado")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.AbonMoneda)
                    .IsRequired()
                    .HasColumnName("abon_moneda")
                    .HasMaxLength(15);

                entity.Property(e => e.AbonMonto)
                    .HasColumnName("abon_monto")
                    .HasColumnType("numeric(10, 0)");
            });

            modelBuilder.Entity<PreAuditoria>(entity =>
            {
                entity.HasKey(e => e.AudAuditoria)
                    .HasName("aud_auditoria_PK");

                entity.ToTable("Pre_auditoria");

                entity.Property(e => e.AudAuditoria).HasColumnName("aud_auditoria");

                entity.Property(e => e.AudDescripcion)
                    .IsRequired()
                    .HasColumnName("aud_descripcion")
                    .HasMaxLength(50);

                entity.Property(e => e.AudEstatus)
                    .IsRequired()
                    .HasColumnName("aud_estatus")
                    .HasMaxLength(2);

                entity.Property(e => e.AudFecha)
                    .HasColumnName("aud_fecha")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<PreCliente>(entity =>
            {
                entity.HasKey(e => e.CliCliente)
                    .HasName("cli_cliente_PK");

                entity.ToTable("Pre_Cliente");

                entity.Property(e => e.CliCliente).HasColumnName("cli_cliente");

                entity.Property(e => e.CliApellido)
                    .IsRequired()
                    .HasColumnName("cli_apellido")
                    .HasMaxLength(50);

                entity.Property(e => e.CliNacimiento)
                    .HasColumnName("cli_nacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.CliNit)
                    .HasColumnName("cli_nit")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.CliNombre)
                    .IsRequired()
                    .HasColumnName("cli_nombre")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PreDetalleAbonoPrestamo>(entity =>
            {
                entity.HasKey(e => e.DetabonoDetalleAbonoPrestamo)
                    .HasName("detabono_detalle_abono_prestamo_PK");

                entity.ToTable("Pre_detalle_abono_prestamo");

                entity.Property(e => e.DetabonoDetalleAbonoPrestamo).HasColumnName("detabono_detalle_abono_prestamo");

                entity.Property(e => e.AbonAbonoPrestamo).HasColumnName("abon_abono_prestamo");

                entity.Property(e => e.PrePrestamo).HasColumnName("pre_prestamo");

                entity.HasOne(d => d.AbonAbonoPrestamoNavigation)
                    .WithMany(p => p.PreDetalleAbonoPrestamo)
                    .HasForeignKey(d => d.AbonAbonoPrestamo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("abon_abono_prestamo_FK");

                entity.HasOne(d => d.PrePrestamoNavigation)
                    .WithMany(p => p.PreDetalleAbonoPrestamo)
                    .HasForeignKey(d => d.PrePrestamo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pre_prestamo_FK");
            });

            modelBuilder.Entity<PreDetalleEvaluacion>(entity =>
            {
                entity.HasKey(e => e.DetevalDetalleEvaluacion)
                    .HasName("deteval_detalle_evaluacion_PK");

                entity.ToTable("Pre_detalle_evaluacion");

                entity.Property(e => e.DetevalDetalleEvaluacion).HasColumnName("deteval_detalle_evaluacion");

                entity.Property(e => e.AudAuditoria).HasColumnName("aud_auditoria");

                entity.Property(e => e.EvaEvaluacion).HasColumnName("eva_evaluacion");

                entity.Property(e => e.SolSolicitud).HasColumnName("sol_solicitud");

                entity.HasOne(d => d.AudAuditoriaNavigation)
                    .WithMany(p => p.PreDetalleEvaluacion)
                    .HasForeignKey(d => d.AudAuditoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("aud_auditoria_FK");

                entity.HasOne(d => d.EvaEvaluacionNavigation)
                    .WithMany(p => p.PreDetalleEvaluacion)
                    .HasForeignKey(d => d.EvaEvaluacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("eva_evaluacion_FK");

                entity.HasOne(d => d.SolSolicitudNavigation)
                    .WithMany(p => p.PreDetalleEvaluacion)
                    .HasForeignKey(d => d.SolSolicitud)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sol_solicitud2_FK");
            });

            modelBuilder.Entity<PreEmpleado>(entity =>
            {
                entity.HasKey(e => e.EmpEmpleado)
                    .HasName("emp_empleado_PK");

                entity.ToTable("Pre_empleado");

                entity.Property(e => e.EmpEmpleado).HasColumnName("emp_empleado");

                entity.Property(e => e.EmpApellido)
                    .IsRequired()
                    .HasColumnName("emp_apellido")
                    .HasMaxLength(50);

                entity.Property(e => e.EmpNombre)
                    .IsRequired()
                    .HasColumnName("emp_nombre")
                    .HasMaxLength(50);

                entity.Property(e => e.EmpPuesto)
                    .IsRequired()
                    .HasColumnName("emp_puesto")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PreEvaluacionPrestamo>(entity =>
            {
                entity.HasKey(e => e.EvaEvaluacionPrestamo)
                    .HasName("eva_evaluacion_prestamo_PK");

                entity.ToTable("Pre_evaluacion_prestamo");

                entity.Property(e => e.EvaEvaluacionPrestamo).HasColumnName("eva_evaluacion_prestamo");

                entity.Property(e => e.EvaDescripcion)
                    .IsRequired()
                    .HasColumnName("eva_descripcion")
                    .HasMaxLength(50);

                entity.Property(e => e.EvaEstatus)
                    .IsRequired()
                    .HasColumnName("eva_estatus")
                    .HasMaxLength(2);

                entity.Property(e => e.EvaFecha)
                    .HasColumnName("eva_fecha")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<PrePresolicitud>(entity =>
            {
                entity.HasKey(e => e.PrePresolicitud1)
                    .HasName("pre_presolicitud_PK");

                entity.ToTable("Pre_presolicitud");

                entity.Property(e => e.PrePresolicitud1).HasColumnName("pre_presolicitud");

                entity.Property(e => e.PreApellidoCliente)
                    .IsRequired()
                    .HasColumnName("pre_apellido_cliente")
                    .HasMaxLength(50);

                entity.Property(e => e.PreCorreo)
                    .HasColumnName("pre_correo")
                    .HasMaxLength(50);

                entity.Property(e => e.PreCuotaPrestamo)
                    .HasColumnName("pre_cuota_prestamo")
                    .HasColumnType("numeric(15, 0)");

                entity.Property(e => e.PreDireccion)
                    .IsRequired()
                    .HasColumnName("pre_direccion")
                    .HasMaxLength(50);

                entity.Property(e => e.PreDpiCliente)
                    .HasColumnName("pre_dpi_cliente")
                    .HasColumnType("numeric(13, 0)");

                entity.Property(e => e.PreDpiRecomen)
                    .HasColumnName("pre_dpi_recomen")
                    .HasColumnType("numeric(13, 0)");

                entity.Property(e => e.PreFecha)
                    .HasColumnName("pre_fecha")
                    .HasColumnType("date");

                entity.Property(e => e.PreIngresosCliente)
                    .HasColumnName("pre_ingresos_cliente")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.PreMontoPrestamo)
                    .HasColumnName("pre_monto_prestamo")
                    .HasColumnType("numeric(15, 0)");

                entity.Property(e => e.PreNombreCliente)
                    .IsRequired()
                    .HasColumnName("pre_nombre_cliente")
                    .HasMaxLength(50);

                entity.Property(e => e.PreNombreRecomen)
                    .IsRequired()
                    .HasColumnName("pre_nombre_recomen")
                    .HasMaxLength(50);

                entity.Property(e => e.PrePlazoPrestamo)
                    .HasColumnName("pre_plazo_prestamo")
                    .HasColumnType("numeric(15, 0)");

                entity.Property(e => e.PreTelefono)
                    .HasColumnName("pre_telefono")
                    .HasColumnType("numeric(8, 0)");

                entity.Property(e => e.PreTelefonoRecomen)
                    .HasColumnName("pre_telefono_recomen")
                    .HasColumnType("numeric(8, 0)");
            });

            modelBuilder.Entity<PrePrestamo>(entity =>
            {
                entity.HasKey(e => e.PrePrestamo1)
                    .HasName("pre_prestamo_PK");

                entity.ToTable("Pre_Prestamo");

                entity.Property(e => e.PrePrestamo1).HasColumnName("pre_prestamo");

                entity.Property(e => e.PreFechaDesembolso)
                    .HasColumnName("pre_fecha_desembolso")
                    .HasColumnType("date");

                entity.Property(e => e.PreInteres)
                    .HasColumnName("pre_interes")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.PreMonto)
                    .HasColumnName("pre_monto")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.SolSolicitud).HasColumnName("sol_solicitud");

                entity.HasOne(d => d.SolSolicitudNavigation)
                    .WithMany(p => p.PrePrestamo)
                    .HasForeignKey(d => d.SolSolicitud)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sol_solicitud_FK");
            });

            modelBuilder.Entity<PreSolicitud>(entity =>
            {
                entity.HasKey(e => e.SolSolicitud)
                    .HasName("sol_solicitud_PK");

                entity.ToTable("Pre_solicitud");

                entity.Property(e => e.SolSolicitud).HasColumnName("sol_solicitud");

                entity.Property(e => e.CliCliente).HasColumnName("cli_cliente");

                entity.Property(e => e.EmpEmpleado).HasColumnName("emp_empleado");

                entity.Property(e => e.SolEstadosCuenta)
                    .IsRequired()
                    .HasColumnName("sol_estados_cuenta")
                    .HasMaxLength(50);

                entity.Property(e => e.SolEstatus)
                    .IsRequired()
                    .HasColumnName("sol_estatus")
                    .HasMaxLength(2);

                entity.Property(e => e.SolFecha)
                    .HasColumnName("sol_fecha")
                    .HasColumnType("date");

                entity.Property(e => e.SolPrePresolicitud).HasColumnName("sol_pre_presolicitud");

                entity.Property(e => e.SolReciboServicios)
                    .IsRequired()
                    .HasColumnName("sol_recibo_servicios")
                    .HasMaxLength(50);

                entity.Property(e => e.SolTipoMoneda)
                    .IsRequired()
                    .HasColumnName("sol_tipo_moneda")
                    .HasMaxLength(15);

                entity.Property(e => e.UseUsuario)
                    .HasColumnName("use_usuario")
                    .HasColumnType("numeric(10, 0)");

                entity.HasOne(d => d.CliClienteNavigation)
                    .WithMany(p => p.PreSolicitud)
                    .HasForeignKey(d => d.CliCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cli_cliente_FK");

                entity.HasOne(d => d.EmpEmpleadoNavigation)
                    .WithMany(p => p.PreSolicitud)
                    .HasForeignKey(d => d.EmpEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("emp_empleado_FK");

                entity.HasOne(d => d.SolPrePresolicitudNavigation)
                    .WithMany(p => p.PreSolicitud)
                    .HasForeignKey(d => d.SolPrePresolicitud)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sol_pre_presolicitud_FK");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RolRol)
                    .HasName("rol_rol_PK");

                entity.Property(e => e.RolRol).HasColumnName("rol_rol");

                entity.Property(e => e.RolNombre)
                    .IsRequired()
                    .HasColumnName("rol_nombre")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.UseUsuario)
                    .HasName("use_usuario_PK");

                entity.Property(e => e.UseUsuario).HasColumnName("use_usuario");

                entity.Property(e => e.CliCliente).HasColumnName("cli_cliente");

                entity.Property(e => e.EmpPuesto).HasColumnName("emp_puesto");

                entity.Property(e => e.UseEstatus)
                    .IsRequired()
                    .HasColumnName("use_estatus")
                    .HasMaxLength(2);

                entity.Property(e => e.UseNombre)
                    .IsRequired()
                    .HasColumnName("use_nombre")
                    .HasMaxLength(50);

                entity.Property(e => e.UsePassword)
                    .IsRequired()
                    .HasColumnName("use_password")
                    .HasMaxLength(50);

                entity.HasOne(d => d.CliClienteNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.CliCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cli_cliente2_FK");
            });

            modelBuilder.Entity<UsuarioRol>(entity =>
            {
                entity.HasKey(e => e.UsrUsuarioRol)
                    .HasName("usr_usuarioRol_PK");

                entity.Property(e => e.UsrUsuarioRol).HasColumnName("usr_usuarioRol");

                entity.Property(e => e.RolRol).HasColumnName("rol_rol");

                entity.Property(e => e.UseUsuario).HasColumnName("use_usuario");

                entity.HasOne(d => d.RolRolNavigation)
                    .WithMany(p => p.UsuarioRol)
                    .HasForeignKey(d => d.RolRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rol_rol_FK");

                entity.HasOne(d => d.UseUsuarioNavigation)
                    .WithMany(p => p.UsuarioRol)
                    .HasForeignKey(d => d.UseUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("use_usuario_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
