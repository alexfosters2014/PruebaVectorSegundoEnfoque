using AccesoDatos;
using AutoMapper;
using Comun;
using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.OtherModels;
using Modelo.ViewModels;
using Negocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repositorios
{
    public class RepoFuncionario : IRepoFuncionario
    {
        private readonly AppDbContext db;
        private readonly IMapper mapper;

        public RepoFuncionario(AppDbContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }

        public async Task<FuncionarioDTO> Actualizar(FuncionarioDTO modelo)
        {
            try
            {
                Funcionario funcionarioDB = await db.Funcionarios.SingleOrDefaultAsync(s => s.Id == modelo.Id);
                Funcionario funcionario = mapper.Map<FuncionarioDTO, Funcionario>(modelo, funcionarioDB);
                var update = db.Funcionarios.Update(funcionario);
                await db.SaveChangesAsync();
                return mapper.Map<Funcionario, FuncionarioDTO>(update.Entity);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<FuncionarioDTO> Agregar(FuncionarioDTO modelo)
        {
             try
            {
                Funcionario funcionario = mapper.Map<FuncionarioDTO, Funcionario>(modelo);
               
                    //usuario.MesaOperativa = await db.MesasOperativas.SingleAsync(s => s.Id == modelo.MesaOperativa.Id);
                    db.Entry(funcionario.RespondeA).State = EntityState.Unchanged;
                      //guardar en BD
                    db.Entry(funcionario.TipoContrato).State = EntityState.Unchanged;
                    db.Entry(funcionario.Rubro).State = EntityState.Unchanged;
                    funcionario.EstadoActividad = SD.EstadoFuncionarioEnum.ACTIVO.ToString();
                    funcionario.TipoResumido = SD.EstadoRotatividad.FIJO.ToString();
                    var add = await db.Funcionarios.AddAsync(funcionario);
                    await db.SaveChangesAsync();
                    FuncionarioDTO uFinal = mapper.Map<Funcionario, FuncionarioDTO>(add.Entity);
                    return uFinal;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> ImportarFuncionarios(List<FuncionarioImport> modelo)
        {
            try
            {
                List<MesaOperativa> mops = db.MesasOperativas.ToList(); 
                List<TipoContrato> tcs = db.TiposContratos.ToList();
                List<Rubro> rubros = db.Rubros.ToList();

               // List<FuncionarioDTOSinValid> funcionariosSinValid = 
                List<Funcionario> funcionarios = mapper.Map<List<FuncionarioImport>, List<Funcionario>>(modelo); ;

                foreach(var funcionario in funcionarios) {
                    //Funcionario funcionario = mapper.Map<FuncionarioDTOSinValid, Funcionario>(funSV);
                    funcionario.RespondeA = mops.SingleOrDefault(s => s.Id == funcionario.RespondeA.Id);
                    funcionario.TipoContrato = tcs.SingleOrDefault(s => s.Id == funcionario.TipoContrato.Id);
                    funcionario.Rubro = rubros.SingleOrDefault(s => s.Id == funcionario.Rubro.Id);

                db.Entry(funcionario.RespondeA).State = EntityState.Unchanged;
                //guardar en BD
                db.Entry(funcionario.TipoContrato).State = EntityState.Unchanged;
                db.Entry(funcionario.Rubro).State = EntityState.Unchanged;
                funcionario.EstadoActividad = SD.EstadoFuncionarioEnum.ACTIVO.ToString();
                funcionario.TipoResumido = SD.EstadoRotatividad.FIJO.ToString();
                await db.Funcionarios.AddAsync(funcionario);
                }
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un error: "+e.Message);
            }
        }

        public async Task<bool> DarBaja(ModelBajaFuncionario modelo)
        {
            Funcionario funcionario = await db.Funcionarios.SingleOrDefaultAsync(s => s.Id == modelo.Id);
            funcionario.EstadoActividad = SD.EstadoFuncionarioEnum.BAJA_DEFINITIVA.ToString();
            funcionario.FechaEgreso = modelo.FechaBaja;
            funcionario.Observaciones = $"Motivo Baja: {modelo.Motivo} - (Otros: {funcionario.Observaciones})";
            db.Funcionarios.Update(funcionario);
            int update = await db.SaveChangesAsync();
            if (update == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> FuncionarioDuplicado(GeneralTransport modelo)
        {
            try
            {
                int contarDuplicados = await db.Funcionarios.CountAsync(c => c.Cedula == modelo.Data);
                return (contarDuplicados > 1 ? true : false);
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error");
            }
        }

        public async Task<List<FuncionarioDTO>> ObtenerActivos()
        {
            try
            {
                List<FuncionarioDTO> funcionarios = mapper.Map<List<Funcionario>, List<FuncionarioDTO>>(
                                                db.Funcionarios
                                                .Include(i => i.TipoContrato)
                                                .Include(i => i.RespondeA)
                                                .Include(i => i.Rubro)
                                                .Where(w => w.EstadoActividad == SD.EstadoFuncionarioEnum.ACTIVO.ToString())
                                                .ToList());

                return funcionarios;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<FuncionarioDTO>> ObtenerBajas()
        {
            try
            {
                List<FuncionarioDTO> funcionarios = mapper.Map<List<Funcionario>, List<FuncionarioDTO>>(
                                                db.Funcionarios
                                                .Include(i => i.TipoContrato)
                                                .Include(i => i.RespondeA)
                                                .Include(i => i.Rubro)
                                                .Where(w => w.EstadoActividad == SD.EstadoFuncionarioEnum.BAJA_PARA_LIQUIDACION.ToString()
                                                            || w.EstadoActividad == SD.EstadoFuncionarioEnum.BAJA_DEFINITIVA.ToString())
                                                .ToList());

                return funcionarios;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<FuncionarioDTO>> ObtenerFiltro(FiltroBusquedaFuncionario filtro)
        {
            try
            {
                List<FuncionarioDTO> funcionarios;
                string[] cadenastring = filtro.Busqueda.Split(" ");

                if (cadenastring.Length == 2)
                {
                    funcionarios = mapper.Map<List<Funcionario>, List<FuncionarioDTO>>(
                               db.Funcionarios
                               .Include(i => i.TipoContrato)
                               .Include(i => i.RespondeA)
                               .Include(i => i.Rubro)
                               .Where(w =>
                               (filtro.Rubro == "*" ? w.Rubro.Nombre == w.Rubro.Nombre : w.Rubro.Nombre == filtro.Rubro) &&
                               (!filtro.Activo ? w.EstadoActividad == w.EstadoActividad : w.EstadoActividad == SD.EstadoFuncionarioEnum.ACTIVO.ToString()) &&
                               (w.Nombres.Contains(cadenastring[0]) && w.Apellidos.Contains(cadenastring[1]) ||
                                w.Nombres.Contains(filtro.Busqueda) || w.Apellidos.Contains(filtro.Busqueda) )
                               )
                               .ToList());
                }
                else
                {
                    funcionarios = mapper.Map<List<Funcionario>, List<FuncionarioDTO>>(
                                db.Funcionarios
                                .Include(i => i.TipoContrato)
                                .Include(i => i.RespondeA)
                                .Include(i => i.Rubro)
                                .Where(w =>
                                (filtro.Rubro == "*" ? w.Rubro.Nombre == w.Rubro.Nombre : w.Rubro.Nombre == filtro.Rubro) &&
                                (!filtro.Activo ? w.EstadoActividad == w.EstadoActividad : w.EstadoActividad == SD.EstadoFuncionarioEnum.ACTIVO.ToString()) &&
                                (SD.IsNumeric(filtro.Busqueda) ? (w.Numero == SD.ConvertStringToInt(filtro.Busqueda) || w.Cedula.Contains(filtro.Busqueda))
                                : (w.Nombres.Contains(filtro.Busqueda) || w.Apellidos.Contains(filtro.Busqueda)))
                                )
                                .ToList());
                }
                return funcionarios;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<FuncionarioDTO>> ObtenerTodos()
        {
            try
            {
                List<FuncionarioDTO> funcionarios = mapper.Map<List<Funcionario>, List<FuncionarioDTO>>(
                                                db.Funcionarios
                                                .Include(i => i.TipoContrato)
                                                .Include(i => i.RespondeA)
                                                .Include(i => i.Rubro)
                                                .ToList());
                    
                return funcionarios;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<FuncionarioDTO>> ObtenerTodosActivosSegunMOP(GeneralTransport modelo)
        {
            try
            {
                List<FuncionarioDTO> funcionarios = mapper.Map<List<Funcionario>, List<FuncionarioDTO>>(
                                                db.Funcionarios
                                                .Include(i => i.TipoContrato)
                                                .Include(i => i.RespondeA)
                                                .Include(i => i.Rubro)
                                                .Where(w => (w.EstadoActividad == SD.EstadoFuncionarioEnum.ACTIVO.ToString()
                                                              || (w.FechaEgreso != null && w.FechaEgreso > modelo.Fecha))
                                                              && w.RespondeA.Id == modelo.Valor)
                                                .ToList());

                return funcionarios;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<int> CantidadActivos()
        {
            return await db.Funcionarios.CountAsync(c => c.EstadoActividad == SD.EstadoFuncionarioEnum.ACTIVO.ToString());
        }


        public async Task<FuncionarioDTO> ObtenerFuncionarioNumero(GeneralTransport generalTransport)
        {
            try
            {
                FuncionarioDTO funcionarioDTO = mapper.Map<Funcionario, FuncionarioDTO>(
                                                await db.Funcionarios
                                                .Include(i => i.TipoContrato)
                                                .Include(i => i.RespondeA)
                                                .Include(i => i.Rubro)
                                                .SingleOrDefaultAsync(w => w.Numero == generalTransport.Valor) );

                return funcionarioDTO;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<FuncionarioDTO>> BusquedaFuncionariosEnMesaOperativaActivos(GeneralTransport busqueda)
        {
            try
            {
                string[] cadenastring = busqueda.Data.Split(" ");
                List<FuncionarioDTO> funcionariosDTO = null;

                if (cadenastring.Length == 2)
                {
                    funcionariosDTO = mapper.Map<List<Funcionario>, List<FuncionarioDTO>>(
                                                db.Funcionarios
                                                    .Include(i => i.TipoContrato)
                                                    .Include(i => i.RespondeA)
                                                    .Include(i => i.Rubro)
                                                    .Where(w => (w.RespondeA.Id == busqueda.Valor &&
                                                                 w.Nombres.Contains(cadenastring[0]) &&
                                                                 w.Apellidos.Contains(cadenastring[1])) &&
                                                                 w.EstadoActividad == SD.EstadoFuncionarioEnum.ACTIVO.ToString())
                                                    .ToList() );
                }
                else
                {
                    funcionariosDTO = mapper.Map<List<Funcionario>, List<FuncionarioDTO>>(
                                                db.Funcionarios
                                                    .Include(i => i.TipoContrato)
                                                    .Include(i => i.RespondeA)
                                                    .Include(i => i.Rubro)
                                                    .Where(w => (w.RespondeA.Id == busqueda.Valor &&
                                                                    (SD.IsNumeric(busqueda.Data) ?
                                                                       (w.Numero == SD.ConvertStringToInt(busqueda.Data) || w.Cedula.Contains(busqueda.Data)) :
                                                                       (w.Nombres.Contains(busqueda.Data) || w.Apellidos.Contains(busqueda.Data)))) &&
                                                                        w.EstadoActividad == SD.EstadoFuncionarioEnum.ACTIVO.ToString())
                                                    .ToList() );

                }

                return funcionariosDTO;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        }
}
