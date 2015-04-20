using System;
using System.Collections.Generic;
using vNextAngularSPA.Data;
using vNextAngularSPA.Data.Infrastructure;
using vNextAngularSPA.Model;

namespace vNextAngularSPA.Service
{
    public interface IBookmarkedPlaceService
    {
        BookmarkedPlace GetById(int Id);
        IEnumerable<BookmarkedPlace> GetAll();
        IEnumerable<BookmarkedPlace> GetMany(string userName);
    }
    public class BookmarkedPlaceService : IBookmarkedPlaceService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IBookmarkedPlaceRepository bookmarkedPlaceRepository;
        public BookmarkedPlaceService(IUnitOfWork unitOfWork, IBookmarkedPlaceRepository bookmarkedPlaceRepository)
        {
            this.unitOfWork = unitOfWork;
            this.bookmarkedPlaceRepository = bookmarkedPlaceRepository;
        }

        public BookmarkedPlace GetById(int Id)
        {
            return bookmarkedPlaceRepository.GetById(x => x.Id == Id);
        }

        public IEnumerable<BookmarkedPlace> GetAll()
        {
            return bookmarkedPlaceRepository.GetAll();
        }

        public IEnumerable<BookmarkedPlace> GetMany(string userName)
        {
            return bookmarkedPlaceRepository.GetMany(x => x.UserName == userName);
        }
    }
}
