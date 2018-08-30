using Anderson.MF7.Application.Features.Funcionarios.Commands;
using Anderson.MF7.Application.Features.Funcionarios.ViewModels;
using Anderson.MF7.Domain.Features.Funcionarios;
using AutoMapper;
using System.Collections.Generic;

namespace Anderson.MF7.Application.Features.Funcionarios
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Funcionario, FuncionarioViewModel>();
            CreateMap<List<Funcionario>, List<FuncionarioViewModel>>();
            CreateMap<FuncionarioRegisterCommand, Funcionario>();
            CreateMap<FuncionarioUpdateCommand, Funcionario>();
            CreateMap<FuncionarioRemoveCommand, Funcionario>();
        }
    }
}
