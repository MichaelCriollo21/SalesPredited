using Context.Class;
using Context.Context;
using Context.Interface;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly SalesPredictionContext dbContext;
    private bool disposed;
    private Dictionary<string, object> repositories;

    public UnitOfWork(SalesPredictionContext salesPredictionContext)
    {
        this.dbContext = salesPredictionContext;
    }

    public void SaveChanges()
    {
        dbContext.SaveChanges();
    }

    public SalesPredictionContext GetContext()
    {
        return this.dbContext;
    }

    public Repository<T> Repository<T>() where T : class
    {
        if (repositories == null)
        {
            repositories = new Dictionary<string, object>();
        }
        var type = typeof(T).Name;
        if (!repositories.ContainsKey(type))
        {
            var repositoryType = typeof(Repository<>);
            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), dbContext);
            repositories.Add(type, repositoryInstance);
        }
        return (Repository<T>)repositories[type];
    }

    public virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
