using CommandsService.Data.Interfaces;
using CommandsService.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using MediatR;

namespace CommandsService.Data
{
	public static class ServiceRegistration
	{
		public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
		{
			services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMem"));

			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
			services.AddScoped<ICommandRepo, CommandRepo>();

			services.AddMediatR(Assembly.GetExecutingAssembly());
			services.AddAutoMapper(Assembly.GetExecutingAssembly());


			return services;

		}
	}
}
