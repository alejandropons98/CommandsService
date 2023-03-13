using CommandsService.Data.Interfaces;
using System.Collections;

namespace CommandsService.Data.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
        private readonly AppDbContext _context;
        private Hashtable _repositories;

        private ICommandRepo _commandRepo;
        public ICommandRepo commandRepo => _commandRepo ?? new CommandRepo(_context);


        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepo<T> Repository<T>() where T : class, new()
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepo<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepo<T>)_repositories[type];
        }

	}
}
