using GymBro.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Application.Muscles.Queries.GetAllMuscles
{
    public record GetAllMusclesQuery:BasePageModel,IQuery<PaginatedList<MuscleListItemDTO>?>
    {
        public string? Query { get; set; }
    }
}
