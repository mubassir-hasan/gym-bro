using GymBro.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Domain.Entities
{
    public class ExerciseDetails
    {
        public long Id { get; private init; }
        public RoutineDetailType Type { get; set; }
        public required string Details { get; set; }
        public long  ExerciseId { get; set; }

        public Exercise? Exercise { get; set; }
    }

    public class MapRoutineDetails : IEntityTypeConfiguration<ExerciseDetails>
    {
        public void Configure(EntityTypeBuilder<ExerciseDetails> builder) 
        {
            builder.Property(x => x.Details).IsRequired();
            builder.HasOne(x => x.Exercise).WithMany(x => x.ExerciseDetails).HasForeignKey(x => x.ExerciseId);
        }
    }
}
