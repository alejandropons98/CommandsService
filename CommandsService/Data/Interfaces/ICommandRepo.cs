using CommandsService.Models;

namespace CommandsService.Data.Interfaces
{
	public interface ICommandRepo : IGenericRepo<Platform>
	{
		#region Platforms

		Task<bool> PlatformExists(int platformId);


		#endregion

		#region Commands

		Task<IReadOnlyList<Command>> GetCommandsForPlatform(int platformId);
		Task<Command> GetCommand(int platformId, int commandId);
		Task<Command> CreateCommand(Command command);


		#endregion
	}
}
