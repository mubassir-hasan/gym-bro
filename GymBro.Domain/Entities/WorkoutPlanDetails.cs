using GymBro.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Domain.Entities
{
    public class WorkoutPlanDetails
    {
        public long Id { get; private init; }
        public long WorkoutPlanId { get; set; }
        public long ExerciseId { get; set; }
        public required string UserId { get; set; }
        public int MinSetCount { get; set; }
        public int MinRepsCount { get; set; }
        public long WorkoutPlanDetailGroupId { get; set; }



        public WorkoutPlan? WorkoutPlan { get; set; }
        public Exercise? Exercise { get; set; }
        public ApplicationUser? User { get; set; }
        public WorkoutPlanDetailsGroup? WorkoutPlanDetailGroup { get; set; }
    }

    public class MapWorkoutPlanDetails : IEntityTypeConfiguration<WorkoutPlanDetails>
    {
        public void Configure(EntityTypeBuilder<WorkoutPlanDetails> builder)
        {
            builder.HasOne(x => x.WorkoutPlan)
                .WithMany(x => x.WorkoutPlanDetails)
                .HasForeignKey(k => k.WorkoutPlanId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x=>x.Exercise)
                .WithMany(x=>x.WorkoutPlanDetails)
                .HasForeignKey(k=>k.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x=>x.User)
                .WithMany(x=>x.WorkoutPlanDetails)
                .HasForeignKey(k=> k.UserId);

            builder.HasOne(x => x.WorkoutPlanDetailGroup)
                .WithMany(x => x.WorkoutPlanDetails)
                .HasForeignKey(k => k.WorkoutPlanDetailGroupId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
