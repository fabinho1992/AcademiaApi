﻿using Academia.Domain.Models.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Application.Dtos.ProfessorDto
{
    public class ResponseProfessorDefault
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Endereco { get; set; }
        public int Telefone { get; set; }
        public string Email { get; set; }
        public string? Experiencia { get; set; }
        public Status Status { get; set; }
    }
}
