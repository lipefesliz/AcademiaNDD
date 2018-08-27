using AutoMapper;
using BancoTabajara.Application.Features.Usuarios.Commands;
using BancoTabajara.Application.Features.Usuarios.ViewModels;
using BancoTabajara.Domain.Features.Usuarios;

namespace BancoTabajara.Application.Features.Usuarios
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<UsuarioRegisterCommand, Usuario>();
            CreateMap<UsuarioRemoveCommand, Usuario>();
            CreateMap<UsuarioUpdateCommand, Usuario>();
        }
    }
}
