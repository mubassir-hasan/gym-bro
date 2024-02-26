using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Domain.Entities
{
    public class ExerciseMuscle
    {
        public long Id { get; private init; }
        public int MuscleId { get; set; }
        public long ExerciseId { get; set; }

        public Exercise? Exercise { get; set; }
        public Muscle? Muscles { get; set; }
    }

    public class MapExerciseMuscle : IEntityTypeConfiguration<ExerciseMuscle>
    {
        public void Configure(EntityTypeBuilder<ExerciseMuscle> builder)
        {
            builder.HasOne(x => x.Exercise).WithMany(x => x.ExerciseMuscles).HasForeignKey(k => k.ExerciseId);
            builder.HasOne(x => x.Muscles).WithMany(x => x.ExerciseMuscles).HasForeignKey(x => x.MuscleId);
        }
    }
}
