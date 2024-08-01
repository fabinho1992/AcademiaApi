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
    public class TreinoConfiguration : IEntityTypeConfiguration<Treino>
    {
        public void Configure(EntityTypeBuilder<Treino> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasMaxLength(100).IsRequired();

            builder.Property(x => x.Descricao).HasMaxLength(180).IsRequired();

            builder.HasMany(t => t.Exercicios)
                .WithMany(e => e.Treinos)
                .UsingEntity<TreinoExercicio>(
                    x => x
                .HasOne(te => te.Exercicio)
                .WithMany()
                .HasForeignKey(te => te.ExercicioId),
                     j => j
                .HasOne(te => te.Treino)
                .WithMany()
                .HasForeignKey(te => te.TreinoId),
                    j => j
                .ToTable("TreinoExercicio")
        );
        }
    }
}
