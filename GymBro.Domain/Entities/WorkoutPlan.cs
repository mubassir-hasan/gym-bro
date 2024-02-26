using GymBro.Domain.Common;
using GymBro.Domain.Enums;
using GymBro.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Domain.Entities
{
    public class WorkoutPlan:BaseAuditableEntity
    {
        public WorkoutPlan(Title title, string? description, bool isPublic, LanguageEnum language, string userId)
        {
            Title = title;
            Description = description;
            IsPublic = isPublic;
            Language = language;
            UserId = userId;
        }

        public long Id { get; private init; }
        public Title Title { get; set; }
        public string? Description { get; set; }

        public bool IsPublic { get; set; }
        public LanguageEnum Language { get; set; }
        public required string UserId { get; set; }

        public ApplicationUser? User { get; set; }
        public List<WorkoutHistory>? WorkoutHistories { get; set; }
    }
}
