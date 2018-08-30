﻿using Anderson.MF7.Application.Features.Gastos.Command;
using Anderson.MF7.Application.Features.Gastos.ViewModels;
using Anderson.MF7.Domain.Features.Gastos;
using AutoMapper;
using System.Collections.Generic;

namespace Anderson.MF7.Application.Features.Gastos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Gasto, GastoViewModel>().ForMember(g => g.Funcionario, f => f.MapFrom(src => src.Funcionario.Nome));
            CreateMap<List<Gasto>, List<GastoViewModel>>();
            CreateMap<GastoRegisterCommand, Gasto>();
            CreateMap<GastoRemoveCommand, Gasto>();
        }
    }
}
