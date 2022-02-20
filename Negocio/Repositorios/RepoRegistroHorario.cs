using AccesoDatos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Modelo;
using Negocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repositorios
{
    public class RepoRegistroHorario : IRepoRegistroHorario
    {
        private readonly AppDbContext db;
        private readonly IMapper mapper;

        public RepoRegistroHorario(AppDbContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }
        public async Task<bool> RegistrarHorarioFuncionario(OperativaDiariaDTO modelo)
        {
            try { 
            OperativaDiaria operativa = mapper.Map<OperativaDiariaDTO, OperativaDiaria>(modelo);
            //revisar si no hay duplicados u horarios traspuestos
            RegistroHora registroHora = new()
            {
                Fecha = operativa.Fecha,
                Funcionario = operativa.FuncionarioOperativo,
                Servicio = operativa.Servicio,
                HoraEntrada = operativa.HoraEntrada,
                HoraSalida = operativa.HoraSalida,
                Computo = operativa.Computo,
                Falta = operativa.Computo.ComputaFalta ? 1 : 0,
                Observaciones = operativa.Observaciones,
                Facturable = operativa.Facturable
            };
            registroHora = await CalculoHorario(registroHora);

                db.Entry(registroHora.Funcionario).State = EntityState.Unchanged;
                db.Entry(registroHora.Servicio).State = EntityState.Unchanged;
                db.Entry(registroHora.Computo).State = EntityState.Unchanged;
                await db.RegistrosHoras.AddAsync(registroHora);
                await db.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private async Task<RegistroHora> CalculoHorario(RegistroHora registroDiario)
        {
            return registroDiario;
        }
    }
}
