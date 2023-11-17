﻿using GymBro.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Domain.Entities
{
    public class WorkoutPlan:BaseAuditableEntity
    {
        public long Id { get; set; }
        public long RoutineId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
    }
}
