using AutoMapper;
using CommandsService.Application.Command.Commands;
using CommandsService.Application.Command.Queries;
using CommandsService.Models;

namespace CommandsService.Profiles
{
	public class CommandsProfile : Profile
	{
		public CommandsProfile() {
			CreateMap<Command, CreateCommandRequest>();
			CreateMap<CreateCommandRequest, Command>();
			CreateMap<Command, FindAllCommandsByPlatformRequest>();
		}
	}
}
