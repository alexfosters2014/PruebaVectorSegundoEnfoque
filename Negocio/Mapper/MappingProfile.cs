using AccesoDatos;
using AutoMapper;
using Modelo;
using Modelo.OtherModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RolDTO, Rol>().ReverseMap();
            CreateMap<UsuarioDTO, Usuario>().ReverseMap();
            CreateMap<MesaOperativaDTO, MesaOperativa>().ReverseMap();
            CreateMap<TipoContratoDTO, TipoContrato>().ReverseMap();
            CreateMap<FuncionarioDTO, Funcionario>().ReverseMap();
            CreateMap<ClienteDTO, Cliente>().ReverseMap();
            CreateMap<ServicioDTO, Servicio>().ReverseMap();
            CreateMap<RubroDTO, Rubro>().ReverseMap();

            CreateMap<PlanificacionDiariaDTO, PlanificacionDiaria>().ReverseMap();
            CreateMap<PreferenciaFuncionarioServicioDTO, PreferenciaFuncionarioServicio>().ReverseMap();

            CreateMap<PlanificacionDiariaDTO, OperativaDiaria>().ReverseMap();

            CreateMap<ComputoDTO, Computo>().ReverseMap();
            CreateMap<AusenciaDTO, Ausencia>().ReverseMap();
            CreateMap<RegistroHoraDTO, RegistroHora>().ReverseMap();
            CreateMap<NombrePuestoDTO, NombrePuesto>().ReverseMap();
            CreateMap<FuncionarioImport, Funcionario>().ReverseMap();

            CreateMap<TipoContratoImport, TipoContrato>().ReverseMap();
            CreateMap<RubroImport, Rubro>().ReverseMap();
            CreateMap<MesaOpImport, MesaOperativa>().ReverseMap();

            CreateMap<ClienteImport, Cliente>().ReverseMap();
            CreateMap<ServicioImport, Servicio>().ReverseMap();

        }
    }
}
