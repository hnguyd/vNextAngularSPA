using vNextAngularSPA.Data;
using vNextAngularSPA.Model;

namespace vNextAngularSPA.Data.Infrastructure 
{
public class DatabaseFactory : Disposable, IDatabaseFactory
{
    private ApplicationDbContext dbContext;
	public DatabaseFactory(ApplicationDbContext dbContext)
	{
		this.dbContext = dbContext;
	}
	public ApplicationDbContext Get()
    {
        return this.dbContext ?? (this.dbContext = new ApplicationDbContext());
    }
    protected override void DisposeCore()
    {
        if (dbContext != null)
            dbContext.Dispose();
    }
}
}
