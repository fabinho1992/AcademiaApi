using Academia.Application.Dtos.AlunoDto;
using Academia.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Application.Profiles
{
    public class AlunoProfile : Profile
    {
        public AlunoProfile()
        {
            CreateMap<Aluno, RequestAlunoDto>().ReverseMap();
            CreateMap<Aluno, ResponseAlunoDtoDefault>().ReverseMap();
            CreateMap<Aluno, PutAlunoDto>().ReverseMap();
            CreateMap<Aluno, ResponseAlunoListaExames>().ForMember(x => x.Exames, op => op.MapFrom(x => x.ExamesFisicos));
        }
    }
}
