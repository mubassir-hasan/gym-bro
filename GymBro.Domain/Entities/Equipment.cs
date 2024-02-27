﻿using GymBro.Domain.Common;
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
    public sealed class Equipment:BaseAuditableEntity
    {
        

        public long Id { get; private init; }
        public Title Title { get; set; }
        public string? Image { get; set; }

        public string? UserId { get; set; }


        public ApplicationUser? User { get; set; }
        public ICollection<ExerciseEquipment>? ExerciseEquipments { get; set; }

    }

    public class MapEquipment : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.HasOne(x=>x.User).WithMany(x=>x.Equipments).HasForeignKey(k=>k.UserId).IsRequired(false);
            builder.Property(x=>x.Title).HasConversion
        }
    }
}
