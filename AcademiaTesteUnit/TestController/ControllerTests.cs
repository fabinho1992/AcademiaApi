using Academia.Application.Profiles;
using Academia.Domain.Interfaces;
using Academia.infrastructure.Context;
using Academia.infrastructure.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AcademiaTesteUnit.TestController
{
    public class ControllerTests
    {
        public IUnitofWork _unitToWork;
        public IMapper _mapper;
        public static DbContextOptions<AppDbContext> _dbContextOptions { get; }

        //public static string connectionString = "Data Source=DESKTOP-13IIORA\\SQLEXPRESS;Initial Catalog=ApiAcademia;Integrated Security=True;TrustServerCertificate=True;";
        public static string connectionString = "Data Source=DESKTOP-7JJ4VOJ\\SQLEXPRESS;Initial Catalog=ApiAcademia;Integrated Security=True;TrustServerCertificate=True;";

        static ControllerTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(connectionString).Options;
        }

        public ControllerTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AlunoProfile());
            });

            _mapper = config.CreateMapper();
            var context = new AppDbContext(_dbContextOptions);
            _unitToWork = new UnitOfWork(context);
        }
    }
}
