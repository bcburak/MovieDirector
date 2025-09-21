using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieDirector.API.Common;
using MovieDirectorApp.Application.Commands;

namespace MovieDirector.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DirectorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create a new director
        /// </summary>
        [HttpPost]
        [Route("createDirector")]
        public async Task<IActionResult> CreateDirector([FromBody] CreateDirectorCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var directorId = await _mediator.Send(command);
            return Ok(ResponseModel<string>.SuccessResponse(directorId, "success"));
        }

        /// <summary>
        /// Delete a director by Id
        /// </summary>      

        [HttpPut("deleteDirector/{id:guid}")]
        //[Route("deleteDirector")]
        public async Task<IActionResult> DeleteDirector(Guid id)
        {
            var result = await _mediator.Send(new DeleteDirectorCommand(id));
            if (!result)
                return NotFound();

            return Ok(ResponseModel<bool>.SuccessResponse(result, "success"));
        }
    }
}
