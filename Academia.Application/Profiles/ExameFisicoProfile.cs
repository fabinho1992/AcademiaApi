using Academia.Application.Dtos.ExameFisicoDto;
using Academia.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Application.Profiles
{
    public class ExameFisicoProfile : Profile
    {
        public ExameFisicoProfile()
        {
            CreateMap<ExameFisico, RequestExameFisicoDto>().ReverseMap();
            CreateMap<ExameFisico, ResponseExameFisicoDto>().ForMember(x => x.Aluno,
                op => op.MapFrom(x => x.Aluno.Nome)).ForMember(x => x.Professor, op =>
                op.MapFrom(x => x.Professor.Nome)).ReverseMap();
                
        }
    }
}
