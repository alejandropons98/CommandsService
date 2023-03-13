using CommandsService.Data.Interfaces;
using CommandsService.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandsService.Data.Repositories
{
	public class CommandRepo : GenericRepo<Platform>, ICommandRepo
	{
		public CommandRepo(AppDbContext context) : base(context)
		{

		}

		public async Task<Command> CreateCommand(Command command)
		{
			_context.Commands.Add(command);
			await _context.SaveChangesAsync();
			return command;
		}

		public async Task<Command> GetCommand(int platformId, int commandId)
		{
			return await _context.Commands.Where(c => c.PlatformId == platformId && c.Id == commandId).FirstOrDefaultAsync();
		}

		public async Task<IReadOnlyList<Command>> GetCommandsForPlatform(int platformId)
		{
			return await _context.Commands.Where(c => c.PlatformId == platformId).ToListAsync();
		}

		public async Task<bool> PlatformExists(int platformId)
		{
			return await _context.Platforms.AnyAsync(p => p.Id == platformId);
		}
	}
}
