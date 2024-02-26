using GymBro.Abstractions;
using GymBro.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Application.Muscles.Commands.CreateMuscle
{
    internal class CreateMuscleCommandHandler : ICommandHandler<CreateMuscleCommand,int>
    {
        public async Task<Result<int>> Handle(CreateMuscleCommand request, CancellationToken cancellationToken)
        {
            return 1;
        }
    }
}
