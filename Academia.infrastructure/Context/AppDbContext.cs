using Academia.Domain.Models;
using Academia.infrastructure.ModelsConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<ExameFisico> ExamesFisicos { get; set; }
        public DbSet<Treino> Treinos { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoConfiguration ());
            modelBuilder.ApplyConfiguration(new ProfessorConfiguration ());
            modelBuilder.ApplyConfiguration(new ExameFisicoConfiguration ());
            modelBuilder.ApplyConfiguration(new TreinoConfiguration ());
            modelBuilder.ApplyConfiguration(new ExercicioConfiguration ());


            base.OnModelCreating(modelBuilder);
        }
    }
}
