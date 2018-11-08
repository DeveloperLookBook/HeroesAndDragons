using ServerApp.Models;

namespace ServerApp.Data.Repositories
{
    public interface IRepositoryFactory
    {
        TRepocitory Create<TRepocitory>(RepositorySelectorFunc<TRepocitory> selector) 
            where TRepocitory : class, IRepository;
    }
}