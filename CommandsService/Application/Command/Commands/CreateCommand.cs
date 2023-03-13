using CommandsService.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CommandsService.Application.Command.Commands
{
	public class CreateCommandRequest : IRequest<ApiResponse<CreateCommandRequest>>
	{
		[Required]
		public string HowTo { get; set; }
		[Required]
		public string CommandLine { get; set; }
		public int PlatformId { get; set; }
	}
}
