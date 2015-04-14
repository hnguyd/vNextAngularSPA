using System;
using vNextAngularSPA.Model;
using vNextAngularSPA.Data.Infrastructure;

namespace vNextAngularSPA.Data
{
    public interface IBookmarkedPlaceRepository : IGenericRepository<BookmarkedPlace>
    {
    }

    public class BookmarkedPlaceRepository : GenericRepository<BookmarkedPlace>, IBookmarkedPlaceRepository
    {
        public BookmarkedPlaceRepository(IDatabaseFactory databaseFactory) 
            : base(databaseFactory)
        {

        }
    }
}