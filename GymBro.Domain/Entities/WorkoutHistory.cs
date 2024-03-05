using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymBro.Domain.Entities
{
    public sealed class WorkoutHistory
    {
        
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
            builder.HasKey(builder => builder.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x=>x.Exercise).WithMany(x=>x.WorkoutHistories).HasForeignKey(x=>x.ExerciseId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.WorkoutPlan).WithMany(x => x.WorkoutHistories).HasForeignKey(k => k.WorkoutPlanId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ApplicationUser).WithMany(x => x.WorkoutHistories).HasForeignKey(k => k.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
