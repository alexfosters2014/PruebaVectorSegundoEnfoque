using AccesoDatos;
using Comun;
using Microsoft.EntityFrameworkCore;
using Negocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repositorios
{
    public class Inicializacion : IInicializacion
    {
        private readonly AppDbContext db;

        public Inicializacion(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<bool> PrecargaDatos()
        {
            try
            {
                var datos = await db.Computos.CountAsync(c => c.Id>0);
                if (datos == 0)
                {
                    List<Computo> computos = PrecargaComputos();
                    await db.Computos.AddRangeAsync(computos);
                    await db.SaveChangesAsync();

                    List<Rol> roles = PrecargaRoles();
                    await db.Roles.AddRangeAsync(roles);
                    await db.SaveChangesAsync();

                    List<MesaOperativa> mop = PrecargaMesasOperativas();
                    await db.MesasOperativas.AddRangeAsync(mop);
                    await db.SaveChangesAsync();

                    Usuario admin = new()
                    {
                        NombreUsuario = "admin",
                        Password = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918",
                        Email = "admin@vector.com.uy",
                        Rol = await db.Roles.FindAsync(1),
                        Activo = true
                    };

                    db.Entry(admin.Rol).State = EntityState.Unchanged;
                    await db.Usuarios.AddAsync(admin);

                    admin = new()
                    {
                        NombreUsuario = "alexis",
                        Password = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918",
                        Email = "alexis@vector.com.uy",
                        Rol = await db.Roles.FindAsync(2),
                        MesaOperativa = await db.MesasOperativas.FindAsync(1),
                        Activo = true
                    };

                    db.Entry(admin.Rol).State = EntityState.Unchanged;
                    db.Entry(admin.MesaOperativa).State = EntityState.Unchanged;
                    await db.Usuarios.AddAsync(admin);

                    await db.SaveChangesAsync();

                    Cliente cliente = new()
                    {
                        RutCi = "216201790016",
                        RazonSocial = "FABAMOR S.A",
                        NombreFantasia = "VECTOR SEGURIDAD",
                        Direccion = "AVDA. ITALIA 5661",
                        Telefono = "26045511",
                        Observacion = "Servicio auxiliar",
                        Activo = true
                    };

                    var addCli = await db.Clientes.AddAsync(cliente);
                    await db.SaveChangesAsync();

                    cliente = addCli.Entity;

                    Servicio servicio = new()
                    {
                        NombreDescriptivo = "VECTOR SEGURIDAD MESA 1",
                        Cliente = cliente,
                        Activo = true,
                        Ciudad = "MONTEVIDEO",
                        Departamento = "MONTEVIDEO",
                        Direccion = "AVDA. ITALIA 5661",
                        DependeDe = await db.MesasOperativas.SingleOrDefaultAsync(s => s.Nombre == "MESA 1"),
                        Estado = SD.EstadoServicioEnum.ACTIVO.ToString(),
                        Detalle = "Para MESA 1",
                        GuardiaFisica = true,
                    };
                    db.Entry(servicio.Cliente).State = EntityState.Unchanged;
                    db.Entry(servicio.DependeDe).State = EntityState.Unchanged;
                    await db.SaveChangesAsync();

                    //tipos de contratos
                    TipoContrato tipoContrato = new()
                    {
                        Descripcion = "Modalidad 8hrs Descanso 2x1",
                        CargaTrabajoDiaria = 8,
                        CargaTrabajoSemanal = 40,
                        Tipo = 1,
                        Modalidad = "Carga 8 hrs con 2 descanso una semana y un la proxima"
                    };
                    await db.TiposContratos.AddAsync(tipoContrato);
                    tipoContrato = new()
                    {
                        Descripcion = "Modalidad 6hrs Descanso 2",
                        CargaTrabajoDiaria = 6,
                        CargaTrabajoSemanal = 30,
                        Tipo = 1,
                        Modalidad = "Carga 6 hrs con 2 descansos semanales"
                    };
                    await db.TiposContratos.AddAsync(tipoContrato);
                    await db.SaveChangesAsync();

                    //rubros
                    Rubro rubro = new()
                    {
                        Nombre = "LIMPIEZA",
                        Grupo = "21",
                        SubGrupo = "1"
                    };
                    await db.Rubros.AddAsync(rubro);
                     rubro = new()
                    {
                        Nombre = "SEGURIDAD",
                        Grupo = "8",
                        SubGrupo = "8.2"
                    };
                    await db.Rubros.AddAsync(rubro);
                   
                    await db.SaveChangesAsync();
                } 
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo inicializar algunos datos");
            }
        }

        private List<Computo> PrecargaComputos()
        {
            List<Computo> computos = new();
            Computo computo;
            foreach (var item in SD.EstadosComputosBD) 
            {
                computo = new()
                {
                    NombreDescriptivo = item.Key,
                    ComputaFalta = item.Value
                };
                computos.Add(computo);
            }
            return computos;
        }

        private List<Rol> PrecargaRoles()
        {
            List<Rol> roles = new();
            Rol rol;

            rol = new()
            {
                RolAsignado = SD.RolesEnum.ASISTENTE_OPERATIVO.ToString(),
                Nivel = 1
            };
            roles.Add(rol);

            rol = new()
            {
                RolAsignado = SD.RolesEnum.SUBJEFE_OPERATIVO.ToString(),
                Nivel = 1
            };
            roles.Add(rol);

          
            rol = new()
            {
                RolAsignado = SD.RolesEnum.ADMINISTRADOR.ToString(),
                Nivel = 1
            };
            roles.Add(rol);
            return roles;
        }

        private List<MesaOperativa> PrecargaMesasOperativas()
        {
            List<MesaOperativa> mop = new();

            MesaOperativa mo;

            mo = new()
            {
                Nombre = "MESA 3",
                Descripcion = "LEONARDO PARRILLA"
            };
            mop.Add(mo);

            mo = new()
            {
                Nombre = "MESA 2",
                Descripcion = "EDUARDO ARAUJO"
            };
            mop.Add(mo);

           

            mo = new()
            {
                Nombre = "MESA 1",
                Descripcion = "ADRIAN FERREIRA"
            };
            mop.Add(mo);
            return mop;
        }
    }
}
