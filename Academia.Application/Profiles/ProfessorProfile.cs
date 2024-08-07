using Academia.Application.Dtos.ProfessorDto;
using Academia.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Application.Profiles
{
    public class ProfessorProfile : Profile
    {
        public ProfessorProfile()
        {
            CreateMap<Professor, RequestProfessorDto>().ReverseMap();
            CreateMap<Professor, ResponseProfessorDefault>().ReverseMap();
        }
    }
}
