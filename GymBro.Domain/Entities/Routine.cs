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
    public class Routine:BaseAuditableEntity
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public int MinSetCount { get; set; }
        public int MinRepsCount {  get; set; }
        public bool IsPublic { get; set; }
        /// <summary>
        /// insted of actual count from database we will use estimate total to save some resource
        /// </summary>
        public int TotalPeopleLikes { get; set; }
        public int TotalPeopleUsed { get; set; }
        public required string UserId { get; set; }

        public ApplicationUser? User { get; set; }
        public ICollection<RoutineDetails>? RoutineDetails { get; set; }
    }

    public class MapRoutine : IEntityTypeConfiguration<Routine>
    {
        public void Configure(EntityTypeBuilder<Routine> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.HasOne(x => x.User).WithMany(x=>x.Routines).HasForeignKey(x=>x.UserId);
        }
    }
}
