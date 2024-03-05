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
    public class WorkoutPlanDetailsGroup
    {
        public long Id { get; set; }
        public required Title Title { get; set; }
        public int DisplayOrder { get; set; }

        public long WorkoutPlanId { get; set; }

        public ICollection<WorkoutPlanDetails>? WorkoutPlanDetails { get; set; }
        public WorkoutPlan? WorkoutPlan { get; set; }
    }

    public class MapWorkoutPlanDetailsGroup : IEntityTypeConfiguration<WorkoutPlanDetailsGroup>
    {
        public void Configure(EntityTypeBuilder<WorkoutPlanDetailsGroup> builder)
        {
            builder.Property(x => x.Title).HasConversion(v => v.Value, v => Title.Create(v).Value).IsRequired();
            builder.HasOne(x=>x.WorkoutPlan).WithMany(x=>x.WorkoutPlanDetailGroups).HasForeignKey(x=>x.WorkoutPlanId);
        }
    }
}
