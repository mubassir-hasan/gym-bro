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
    public class WorkoutPlan:BaseAuditableEntity
    {
        

        public long Id { get; private init; }
        public required Title Title { get; set; }
        public string? Description { get; set; }

        public bool IsPublic { get; set; }
        public LanguageEnum Language { get; set; }
        public required string UserId { get; set; }

        public ApplicationUser? User { get; set; }
        public ICollection<WorkoutHistory>? WorkoutHistories { get; set; }

        public ICollection<WorkoutPlanDetails>? WorkoutPlanDetails { get; set;}
        public ICollection<WorkoutPlanDetailsGroup>? WorkoutPlanDetailGroups { get; set;}
        
    }

    public class MapWorkoutPlan : IEntityTypeConfiguration<WorkoutPlan>
    {
        public void Configure(EntityTypeBuilder<WorkoutPlan> builder)
        {

            builder.Property(x => x.Title).HasConversion(v => v.Value, v => Title.Create(v).Value);
            builder.Property(x=>x.Description).HasMaxLength(200);
            builder.HasOne(x => x.User).WithMany(x=>x.WorkoutPlans).HasForeignKey(k=>k.UserId);
        }
    }
}
