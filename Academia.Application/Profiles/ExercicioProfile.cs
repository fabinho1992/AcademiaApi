﻿using Academia.Application.Dtos.ExercicioDto;
using Academia.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Application.Profiles
{
    public class ExercicioProfile : Profile
    {
        public ExercicioProfile()
        {
            CreateMap<Exercicio, RequestExercicioDto>().ReverseMap();
            CreateMap<Exercicio, ResponseExercicioDto>().ReverseMap();
            CreateMap<ExercicioReferenciaDto, Exercicio>().ReverseMap();
            CreateMap<ExercicioReferenciaDto, ResponseExercicioDto>().ReverseMap();
            CreateMap<Exercicio, PutExercicioDto>().ReverseMap();
        }
    }
}
