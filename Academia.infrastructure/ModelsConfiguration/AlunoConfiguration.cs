using Academia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Academia.infrastructure.ModelsConfiguration
{
    public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasMaxLength(100).IsRequired();

            builder.Property(x => x.Cpf).
                HasMaxLength(11).IsRequired();

            builder.Property(x => x.Endereco).
                HasMaxLength(150).IsRequired();

            builder.Property(x => x.Peso).IsRequired();

            builder.Property(x => x.DataNascimento).IsRequired();

            builder.Property(x => x.Altura).IsRequired();

            builder.Property(x => x.DataCadastro).IsRequired();

            builder.Property(x => x.Telefone).IsRequired().HasColumnType("NVARCHAR");

            builder.Property(x => x.Plano).HasConversion<string>().IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(100).IsRequired();

            builder.HasMany(a => a.Treinos)
                .WithOne(t => t.Aluno)
                .HasForeignKey(t => t.AlunoId);

            builder.HasMany(a => a.ExamesFisicos)
                .WithOne(t => t.Aluno)
                .HasForeignKey(t => t.AlunoId);
        }
    }
}
