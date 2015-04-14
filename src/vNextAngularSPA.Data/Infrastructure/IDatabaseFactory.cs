using System;
using vNextAngularSPA.Data;

namespace vNextAngularSPA.Data.Infrastructure 
{
    public interface IDatabaseFactory : IDisposable
    {
        ApplicationDbContext Get();
    }
}
