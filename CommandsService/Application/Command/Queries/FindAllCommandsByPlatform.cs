using CommandsService.Models;
using MediatR;

namespace CommandsService.Application.Command.Queries
{
	public class FindAllCommandsByPlatformRequest : IRequest<ApiResponse<IReadOnlyList<FindAllCommandsByPlatformRequest>>>
	{
		public int Id { get; set; }
		public string HowTo { get; set; }
		public string CommandLine { get; set; }
		public int PlatformId { get; set; }
	}
}
