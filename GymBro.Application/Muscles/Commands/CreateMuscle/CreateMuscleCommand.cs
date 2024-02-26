using GymBro.Abstractions.Messaging;
using GymBro.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Application.Muscles.Commands.CreateMuscle
{
    public sealed record CreateMuscleCommand(string Title,string? Image)
    :ICommand<int>;
}
