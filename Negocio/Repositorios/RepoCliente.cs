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
    public class RepoCliente : IRepoCliente
    {
        private readonly AppDbContext db;
        private readonly IMapper mapper;

        public RepoCliente(AppDbContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }
        public async Task<ClienteDTO> Actualizar(ClienteDTO modelo)
        {
            try
            {
                Cliente clienteDB = await db.Clientes.SingleAsync(s => s.Id == modelo.Id);
                Cliente cliente = mapper.Map<ClienteDTO, Cliente>(modelo, clienteDB);
                var update = db.Clientes.Update(cliente);
                await db.SaveChangesAsync();
                string tabla = "mtabla";
                return mapper.Map<Cliente, ClienteDTO>(update.Entity);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<ClienteDTO> Agregar(ClienteDTO modelo)
        {
            try
            {
                Cliente cliente = mapper.Map<ClienteDTO, Cliente>(modelo);
                cliente.Activo = true;
                var add = await db.Clientes.AddAsync(cliente);
                await db.SaveChangesAsync();
                ClienteDTO uFinal = mapper.Map<Cliente, ClienteDTO>(add.Entity);
                return uFinal;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> DarBaja(int id)
        {
            Cliente cliente = await db.Clientes.FindAsync(id);
            cliente.Activo = false;
            db.Clientes.Update(cliente);
            int update = await db.SaveChangesAsync();
            if (update == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<List<ClienteDTO>> ObtenerTodosActivos()
        {
            try
            {
                List<ClienteDTO> clientes = mapper.Map<List<Cliente>, List<ClienteDTO>>(
                                                db.Clientes
                                                .Where(w => w.Activo == true)
                                                .ToList());

                return clientes;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
