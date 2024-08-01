using Academia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.infrastructure.ModelsConfiguration
{
    public class ExercicioConfiguration : IEntityTypeConfiguration<Exercicio>
    {
        public void Configure(EntityTypeBuilder<Exercicio> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasMaxLength(100).IsRequired();

            builder.Property(x => x.Serie).IsRequired();

            builder.Property(x => x.Repeticao).IsRequired();

            builder.Property(x => x.Musculo).HasMaxLength(100).IsRequired();
        }
    }
}
