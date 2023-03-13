using CommandsService.Models;
using MediatR;

namespace CommandsService.Application.Command.Queries
{
	public class FindCommandByPlatformRequest : IRequest<ApiResponse<FindAllCommandsByPlatformRequest>>
	{
		public int Id { get; set; }
		public int PlatformId { get; set; }
	}
}
