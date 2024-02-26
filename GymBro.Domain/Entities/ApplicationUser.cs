using GymBro.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Domain.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? ProfilePicture { get; set; }
        public int Age { get; set; }
        public GenderEnum? Gender { get; set; }
        public int HeightInCentimeter {  get; set; }
        public float Weight { get; set; }
        public ICollection<Exercise>? Routines { get; set; }
        public List<WorkoutHistory>? WorkoutHistories { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
