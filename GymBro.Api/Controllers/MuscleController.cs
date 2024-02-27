using GymBro.Application.Muscles.Commands.CreateMuscle;
using GymBro.Application.Muscles.Queries.GetAllMuscles;
using Microsoft.AspNetCore.Mvc;

namespace GymBro.Api.Controllers
{
    public class MuscleController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateMuscleCommand command)
        {
            var result= await Mediator.Send(command);
            if (result.IsFailure)
            {
                return HandleFailuer(result);
            }
            return CreatedAtAction("",new {id=result.Value },result.Value);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllMusclesQuery query)
        {
            var result=await Mediator.Send(query);
            return Ok(result);
        }
    }
}
