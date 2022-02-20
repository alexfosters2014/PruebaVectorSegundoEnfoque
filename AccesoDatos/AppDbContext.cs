using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
         
        }
        
        public DbSet<Ausencia> Ausencias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Computo> Computos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<MesaOperativa> MesasOperativas { get; set; }
        public DbSet<PlanificacionDiaria> PlanificacionesDiarias { get; set; }
        public DbSet<OperativaDiaria> OperativasDiarias { get; set; }
        public DbSet<RegistroHora> RegistrosHoras { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<TipoContrato> TiposContratos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rubro> Rubros { get; set; }
        public DbSet<NombrePuesto> NombresPuestos { get; set; }
        public DbSet<PreferenciaFuncionarioServicio> PreferenciasFuncionariosServicio { get; set; }

    }
}
