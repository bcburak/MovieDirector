using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieDirector.API.Common;
using MovieDirectorApp.Application.Commands;
using MovieDirectorApp.Application.Queries;
using MovieDirectorApp.Domain.Entities;

namespace MovieDirector.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
    private readonly IMediator _mediator;

    public MovieController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("getAllMovies")]
    public async Task<IActionResult> GetAll()
    {
        var movies = await _mediator.Send(new GetAllMoviesQuery());
        if (movies is null)
            return NotFound(ResponseModel<IEnumerable<Movie>>.Failure("Record is not found."));
        //Movie , Could be extended with DTOs
        return Ok(ResponseModel<IEnumerable<Movie>>.SuccessResponse(movies, "success"));
    }

    [HttpPost]
    [Route("createMovie")]
    public async Task<IActionResult> CreateMovie([FromBody] CreateMovieCommand command)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _mediator.Send(command);
        return Ok(ResponseModel<string>.SuccessResponse(result, "success"));
    }
    [HttpPut("updateMovie")]
    public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovieCommand command)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _mediator.Send(command);
        if (!result)
            return NotFound();

        return Ok(ResponseModel<bool>.SuccessResponse(result, "success"));
    }

    [HttpPut("deleteMovie/{id:guid}")]
    public async Task<IActionResult> DeleteMovie(string id)
    {
        var result = await _mediator.Send(new DeleteMovieCommand(id));
        if (!result)
            return NotFound();

        return Ok(ResponseModel<bool>.SuccessResponse(result, "success"));
    }


}
