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
    public class RepoUsuario : IRepoUsuario
    {
        private readonly AppDbContext db;
        private readonly IMapper mapper;

        public RepoUsuario(AppDbContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }

        public async Task<UsuarioDTO> Agregar(UsuarioDTO modelo)
        {
            try
            {

                string passInicial = Generador.GenerarPassword(25);
                Usuario usuario = mapper.Map<UsuarioDTO, Usuario>(modelo);
                string passwordInicial = Generador.GenerarPassword(25);
                usuario.Password = Encriptacion.GetSHA256(passwordInicial);
                //usuario.Rol = await db.Roles.SingleAsync(s => s.Id == modelo.Rol.Id);
                if (usuario.MesaOperativa != null)
                {
                    //usuario.MesaOperativa = await db.MesasOperativas.SingleAsync(s => s.Id == modelo.MesaOperativa.Id);
                    db.Entry(usuario.MesaOperativa).State = EntityState.Unchanged;
                }
                //guardar en BD
                    db.Entry(usuario.Rol).State = EntityState.Unchanged;
                    var addUsuario = await db.Usuarios.AddAsync(usuario);
                    await db.SaveChangesAsync();
                    UsuarioDTO uFinal = mapper.Map<Usuario, UsuarioDTO>(addUsuario.Entity);
                    uFinal.PassInicial = passwordInicial;
                    return uFinal;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> Eliminar(int Id)
        {
            Usuario usuario = await db.Usuarios.FindAsync(Id);
            db.Usuarios.Remove(usuario);
            int eliminar = await db.SaveChangesAsync();
            if (eliminar == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<UsuarioDTO> Login(VMLogin vmLogin)
        {
            try
            {
                vmLogin.Password = Encriptacion.GetSHA256(vmLogin.Password);
                UsuarioDTO usuario = mapper.Map<Usuario, UsuarioDTO>(await db.Usuarios.Include(i => i.Rol)
                                                                    .Include(i => i.MesaOperativa)
                                                                    .SingleAsync(u => u.NombreUsuario == vmLogin.Usuario &&
                                                                                      u.Password == vmLogin.Password &&
                                                                                      u.Activo == true));
                return usuario;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Task<UsuarioDTO> Modificar(UsuarioDTO modelo)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioDTO> Obtener(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UsuarioDTO>> Obtener()
        {
            try
            {
                List<UsuarioDTO> usuarios = 
                    mapper.Map<List<Usuario>, List<UsuarioDTO>>(db.Usuarios.Include(i => i.Rol)
                                                                           .Include(i => i.MesaOperativa).ToList());
                return usuarios;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
