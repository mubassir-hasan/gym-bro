using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Domain.Entities
{
    public class ExerciseEquipment
    {
        public long Id { get; private init; }
        public long ExerciseId { get; set; }
        public long EquipmentId { get; set; }

        public Exercise? Exercise { get; set; }
        public Equipment? Equipment { get; set; }
    }

    public class MapExerciseEquipment : IEntityTypeConfiguration<ExerciseEquipment>
    {
        public void Configure(EntityTypeBuilder<ExerciseEquipment> builder)
        {
            builder.HasOne(x => x.Exercise).WithMany(x => x.ExerciseEquipments).HasForeignKey(k => k.ExerciseId);
            builder.HasOne(x => x.Equipment).WithMany(x => x.ExerciseEquipments).HasForeignKey(k => k.EquipmentId);
        }
    }
}
