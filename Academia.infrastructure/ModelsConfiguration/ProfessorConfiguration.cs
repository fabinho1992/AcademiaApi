using Academia.Domain.Models;
using Academia.Domain.Models.Enuns;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.infrastructure.ModelsConfiguration
{
    public class ProfessorConfiguration : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasMaxLength(100).IsRequired();

            builder.Property(x => x.Cpf).
                HasMaxLength(11).IsRequired();

            builder.Property(x => x.Endereco).
                HasMaxLength(150).IsRequired();

            builder.Property(x => x.DataNascimento).IsRequired();

            builder.Property(x => x.DataCadastro).IsRequired();

            builder.Property(x => x.Telefone).IsRequired();

            builder.Property(x => x.Status).HasConversion<string>().HasDefaultValue(Status.Ativo);

            builder.Property(x => x.Email)
                .HasMaxLength(100).IsRequired();

            builder.HasMany(p => p.ExamesFisicos)
                .WithOne(t => t.Professor)
                .HasForeignKey(t => t.ProfessorId);
                

        }
    }
}
