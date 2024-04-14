using Application.Requests.Users;
using Application.Requests.Users.Commands;
using Application.Requests.Users.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(IList<UserDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IList<UserDto>>> GetUsers()
    {
        return Ok(await Mediator.Send(new GetUsersQuery()));
    }

    [HttpGet("{userId:guid}")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<UserDto>> GetUserById(Guid userId)
    {
        return Ok(await Mediator.Send(new GetUserByIdQuery(userId)));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    public async Task<ActionResult<Guid>> CreateUser([FromBody] CreateUserCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteUser(Guid userId)
    {
        await Mediator.Send(new DeleteUserCommand(userId));
        return NoContent();
    }
}
