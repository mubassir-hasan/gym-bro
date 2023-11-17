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
    public class RoutineDetails
    {
        public long Id { get; set; }
        public RoutineDetailType Type { get; set; }
        public string? Detail { get; set; }
        public  long  RoutineId { get; set; }

        public Routine? Routine { get; set; }
    }

    public class MapRoutineDetails : IEntityTypeConfiguration<RoutineDetails>
    {
        public void Configure(EntityTypeBuilder<RoutineDetails> builder)
        {
            builder.Property(x => x.Detail).IsRequired();
            builder.HasOne(x => x.Routine).WithMany(x => x.RoutineDetails).HasForeignKey(x => x.RoutineId);
        }
    }
}
