using GymBro.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Domain.Entities
{
    public sealed class WorkoutHistory
    {
        [Key]
        public Guid Id { get; private init; }
        public long ExerciseId { get; set; }
        public long WorkoutPlanId { get; set; }
        public float WeightInPound { get; set; }
        public DateTime CreatedDate { get; set; }

        public required string UserId { get; set; }

        public Exercise? Exercise { get; set; }
        public WorkoutPlan? WorkoutPlan { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
    }

    public sealed class MapWorkoutHistory : IEntityTypeConfiguration<WorkoutHistory>
    {
        public void Configure(EntityTypeBuilder<WorkoutHistory> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
