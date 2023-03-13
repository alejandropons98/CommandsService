using CommandsService.Models;
using MediatR;

namespace CommandsService.Application.Platform.Queries
{
    public class FindAllPlatformsRequest : IRequest<ApiResponse<IReadOnlyList<FindAllPlatformsRequest>>>
    {
        public string Name { get; set; }
        public string Publisher { get; set; }
        public string Cost { get; set; }
    }
}
