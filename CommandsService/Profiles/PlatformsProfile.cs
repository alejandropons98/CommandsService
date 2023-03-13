using AutoMapper;
using CommandsService.Application.Platform.Queries;
using CommandsService.Models;

namespace CommandsService.Profiles
{
    public class PlatformsProfile : Profile
	{
		public PlatformsProfile()
		{
			CreateMap<Platform, FindAllPlatformsRequest>();
		}
	}
}
