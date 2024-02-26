using GymBro.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Domain.Entities
{
    public class WorkoutPlanDetails
    {
        public long Id { get; private init; }
        public long WorkoutId { get; set; }
        public long ExerciseId { get; set; }
        public DayOfWeek ExerciseDay { get; set; }
        public required string UserId { get; set; }
        public int MinSetCount { get; set; }
        public int MinRepsCount { get; set; }


        public WorkoutPlan? WorkoutPlan { get; set; }
        public Exercise? Exercise { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
