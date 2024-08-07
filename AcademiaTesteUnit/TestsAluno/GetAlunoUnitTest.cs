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
    public class GetAlunoUnitTest : IClassFixture<ControllerTests>
    {
        private readonly AlunoController _controller;

        public GetAlunoUnitTest(ControllerTests controllerTests)
        {
            _controller = new AlunoController(controllerTests._unitToWork, controllerTests._mapper);
        }

        [Fact]
        public async Task GetIdAluno_Return_OK()
        {
            //Arrange
            var alunoId = 2;

            //Act
            var data = await _controller.GetById(alunoId);

            //Assert
            var resultado = data.Should().BeOfType<OkObjectResult>();
            resultado.Subject.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetIdAluno_Return_NotFound()
        {
            //Arrange
            var alunoId = 999;

            //Act
            var data = await _controller.GetById(alunoId);

            //Assert
            data.Should().BeOfType<NotFoundObjectResult>()
                .Subject.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task GetIdAluno_Return_BadRequest()
        {
            //Arrange
            var alunoId = -1;

            //Act
            var data = await _controller.GetById(alunoId);

            //Assert
            data.Should().BeOfType<BadRequestObjectResult>()
                .Subject.StatusCode.Should().Be(400);
        }
    }
}
