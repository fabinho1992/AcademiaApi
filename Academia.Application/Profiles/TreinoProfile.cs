using Academia.Application.Dtos.AlunoDto;
using Academia.Application.Dtos.TreinoDto;
using Academia.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Application.Profiles
{
    public class TreinoProfile : Profile
    {
        public TreinoProfile()
        {
            CreateMap<Treino, RequestTreinoDto>().ReverseMap();
            CreateMap<Treino, ResponseTreinoDto>().ForMember(x =>
                        x.Aluno, op => op.MapFrom(x => x.Aluno.Nome)).ForMember(x =>
                        x.Exercicios, op => op.MapFrom(x => x.Exercicios));
            
        }
    }
}
