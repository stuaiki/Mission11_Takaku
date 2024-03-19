//Aiki Takaku Mission 11
//Section 3
//This is an Mission 11 assignment and create a lists of Professor Hilton's favorite books with details.

using Microsoft.AspNetCore.Mvc;
using Mission11_Takaku.Models;
using Mission11_Takaku.Models.ViewModels;
using System.Diagnostics;


//This is controller
namespace Mission11_Takaku.Controllers
{
    public class HomeController : Controller
    {
        //make private _repo to access data using repository
        private IBookstoreRepository _repo;

        public HomeController(IBookstoreRepository temp)
        {
            _repo = temp;
        }

        //This action takes parameter of pageNum which is integer
        public IActionResult Index(int pageNum)
        {
            // pagesize is items on each page
            int pageSize = 10;

            // access to the data in Books table using BookViewListModel and get values both Books table and Pagination info
            var bookData = new BooksListViewModel
            {
                Books = _repo.Books
                .OrderBy(x => x.BookId)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemPerPage = pageSize,
                    TotalItems = _repo.Books.Count()
                }
            };
            return View(bookData);
        }
    }
}
