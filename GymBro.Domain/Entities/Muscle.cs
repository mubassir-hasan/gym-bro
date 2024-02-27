using GymBro.Domain.Common;
using GymBro.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Domain.Entities
{
    public class Muscle : BaseAuditableEntity
    {
        

        public int Id { get; private init; }
        public Title Title { get; set; }
        public string? Image { get; set; }

        public ICollection<ExerciseMuscle>? ExerciseMuscles { get; set; }
    }
}
