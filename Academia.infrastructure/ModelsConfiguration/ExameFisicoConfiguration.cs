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
    public class ExameFisicoConfiguration : IEntityTypeConfiguration<ExameFisico>
    {
        public void Configure(EntityTypeBuilder<ExameFisico> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Imc).HasPrecision(3,1).IsRequired();

            builder.Property(x => x.DataExame).IsRequired();
        }
    }
}
