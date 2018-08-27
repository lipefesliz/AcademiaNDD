using AutoMapper;
using BancoTabajara.Application.Features.Contas.Commands;
using BancoTabajara.Application.Features.Contas.ViewModels;
using BancoTabajara.Domain.Features.Contas;
using System.Collections.Generic;

namespace BancoTabajara.Application.Features.Contas
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Conta, ContaExtractViewModel>().ForMember(dest => dest.Name, m => m.MapFrom(src => src.Cliente.Nome));
            CreateMap<Conta, ContaViewModel>();
            CreateMap<List<Conta>, List<ContaViewModel>>();
            CreateMap<ContaRegisterCommand, Conta>();
            CreateMap<ContaUpdateCommand, Conta>();
            CreateMap<ContaRemoveCommand, Conta>();
        }
    }
}
