using GymBro.Domain.Common;
using GymBro.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Domain.Entities
{
    public sealed class Equipment:BaseAuditableEntity
    {
        public Equipment( Title title, string? image)
        {
            Title = title;
            Image = image;
        }

        public int Id { get; private init; }
        public Title Title { get; set; }
        public string? Image { get; set; }


        public ICollection<ExerciseEquipment>? ExerciseEquipments { get; set; }

    }
}
