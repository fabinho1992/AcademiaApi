using Academia.Application.Dtos.AlunoDto;
using Academia.Domain.Models.Enuns;
using Academia.WebApi.Controllers;
using AcademiaTesteUnit.TestController;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaTesteUnit.TestsAluno
{
    public class PostAlunoUnitTest : IClassFixture<ControllerTests>
    {
        private readonly AlunoController _alunoController;

        public PostAlunoUnitTest(ControllerTests controllerTests)
        {
            _alunoController = new AlunoController(controllerTests._unitToWork, controllerTests._mapper);
        }

        [Fact]
        public async Task CreatedAluno_Return_Ok()
        {
            //Arrange
            var aluno = new RequestAlunoDto
            {
                Nome = "Testsdasadas",
                Cpf = "1111111111",
                Email = "teste@gmail",
                Altura = 2,
                DataCadastro = DateTime.Now,
                DataNascimento = DateTime.Now,
                Endereco = "rua Teste",
                Peso = 100,
                Plano = Plano.Basico,
                Telefone = "21223131"

            };

            //Act
            var data = await _alunoController.Post(aluno);

            //Assert
            var resultado = data.Should().BeOfType<CreatedAtRouteResult>();
            resultado.Subject.StatusCode.Should().Be(201);
        }

        [Fact]
        public async Task CreatedAluno_Return_BadRequest()
        {
            //Arrange
            RequestAlunoDto? aluno = null;

            //Act
            var data = await _alunoController.Post(aluno!);

            //Assert
            var resultado = data.Should().BeOfType<BadRequestObjectResult>();
            resultado.Subject.StatusCode.Should().Be(400);
        }
    }
}
