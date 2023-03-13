using CommandsService.Application.Command.Queries;
using CommandsService.Models;
using CommandsService.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
	[ApiController]
	[Route("api/c/platforms/{platformId}/[controller]")]
	public class CommandsController : ControllerBaseCustom
	{
		private readonly IMediator _mediator;

		public CommandsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<ActionResult<ApiResponse<IReadOnlyList<FindAllCommandsByPlatformRequest>>>> GetCommandsForPlatform(int platformId)
		{
			var reply = await _mediator.Send(new FindAllCommandsByPlatformRequest { PlatformId = platformId});
			return Ok(reply);
		}


	}
}
