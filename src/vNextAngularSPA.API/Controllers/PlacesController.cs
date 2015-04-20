using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using vNextAngularSPA.Service;
using vNextAngularSPA.Model;
using vNextAngularSPA.Data;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PlacesController : BaseController
    {
        private readonly IBookmarkedPlaceService bookmarkedPlaceService;
		public PlacesController(IBookmarkedPlaceService bookMarkedPlaceService)
		{
			bookmarkedPlaceService = bookMarkedPlaceService;
		}
		//private readonly ApplicationDbContext dbContext;
		//public PlacesController(ApplicationDbContext context)
		//{
		//	dbContext = context;
		//}
		// GET: api/values
		[HttpGet]
        public List<BookmarkedPlace> Get(string userName, int page = 0, int pageSize = 10)
        {
            var bookMarks = bookmarkedPlaceService.GetMany(userName);

            var totalCount = bookMarks.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var paginationHeader = new
            {
                TotalCount = totalCount,
                TotalPages = totalPages,
            };

            var jsonPaginationHeader = new string[] { Newtonsoft.Json.JsonConvert.SerializeObject(paginationHeader) };
            Context.Response.Headers.Add("x-pagination", jsonPaginationHeader);

            var results = bookMarks
                .Skip(pageSize * page)
                .Take(pageSize)
                .ToList();

            return results;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
