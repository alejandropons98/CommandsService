using CommandsService.Application.Command.Commands;
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

		[HttpGet("{commandId}", Name = "GetCommandForPlatform")]
		public async Task<ActionResult<ApiResponse<FindAllCommandsByPlatformRequest>>> GetCommandForPlatform(int platformId, int commandId)
		{
			var reply = await _mediator.Send(new FindCommandByPlatformRequest { PlatformId = platformId, Id= commandId });
			return Ok(reply);
		}

		[HttpPost]
		public async Task<ActionResult<ApiResponse<CreateCommandRequest>>> CreateCommandForPlatform(int platformId, CreateCommandRequest command)
		{
			command.PlatformId = platformId;
			var reply = await _mediator.Send(command);
			return Ok(reply);
		}


	}
}
