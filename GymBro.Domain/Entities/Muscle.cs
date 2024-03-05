using GymBro.Domain.Common;
using GymBro.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Domain.Entities
{
    public class Muscle : BaseAuditableEntity
    {
        

        public int Id { get; private init; }
        public required Title Title { get; set; }
        public string? Image { get; set; }

        public ICollection<ExerciseMuscle>? ExerciseMuscles { get; set; }
    }

    public class MapMuscle : IEntityTypeConfiguration<Muscle>
    {
        public void Configure(EntityTypeBuilder<Muscle> builder)
        {

            builder.Property(x => x.Title).HasConversion(v => v.Value, v => Title.Create(v).Value);
        }
    }
}
