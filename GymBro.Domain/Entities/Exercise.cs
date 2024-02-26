using GymBro.Domain.Common;
using GymBro.Domain.Enums;
using GymBro.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Domain.Entities
{
    public class Exercise:BaseAuditableEntity
    {
        public Exercise(Title title, bool isPublic, string userId, int totalTimeRequiredToFinishInMin, LanguageEnum language)
        {
            Title = title;
            IsPublic = isPublic;
            UserId = userId;
            TotalTimeRequiredToFinishInMin = totalTimeRequiredToFinishInMin;
            Language = language;
        }

        public long Id { get; private init; }
        public Title Title { get; set; }
        public bool IsPublic { get; set; }
        /// <summary>
        /// insted of actual count from database we will use estimate total to save some resource
        /// </summary>
        public int TotalPeopleLikes { get; set; }
        public int TotalPeopleUsed { get; set; }
        public required string UserId { get; set; }
        public int TotalTimeRequiredToFinishInMin { get; set; }
        public LanguageEnum Language { get; set; }

        public ApplicationUser? User { get; set; }
        public ICollection<ExerciseDetails>? RoutineDetails { get; set; }

        public ICollection<WorkoutHistory>? WorkoutHistories { get; set; }
        public ICollection<ExerciseEquipment>? ExerciseEquipments { get; set; }
        public ICollection<ExerciseMuscle>? ExerciseMuscles { get; set; }
    }

    public class MapRoutine : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.HasOne(x => x.User).WithMany(x=>x.Routines).HasForeignKey(x=>x.UserId);
        }
    }
}
