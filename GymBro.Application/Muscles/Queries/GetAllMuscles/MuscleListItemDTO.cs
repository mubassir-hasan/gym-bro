using GymBro.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Application.Muscles.Queries.GetAllMuscles
{
    public record MuscleListItemDTO(int Id,Title Title,string? Image);
    
}
