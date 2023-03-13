namespace CommandsService.Data.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IGenericRepo<T> Repository<T>() where T : class, new();
		ICommandRepo commandRepo { get; }
	}
}
