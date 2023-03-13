using CommandsService.Application.Platform.Queries;
using CommandsService.Models;
using CommandsService.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
    [ApiController]
    [Route("api/c/[controller]")]
    public class PlatformsController : ControllerBaseCustom
    {
		private readonly IMediator _mediator;

		public PlatformsController(IMediator mediator)
        {
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<ActionResult<ApiResponse<IReadOnlyList<FindAllPlatformsRequest>>>> GetPlatforms()
		{
			var reply = await _mediator.Send(new FindAllPlatformsRequest());
			return Ok(reply);
		}

		[HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("INBOUND");
            return Ok("Inbound test");
        }
    }
}
