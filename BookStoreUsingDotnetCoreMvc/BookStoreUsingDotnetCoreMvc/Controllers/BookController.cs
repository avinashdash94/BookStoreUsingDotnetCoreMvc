using BookStoreUsingDotnetCoreMvc.Models;
using BookStoreUsingDotnetCoreMvc.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreUsingDotnetCoreMvc.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;

        //We added dependency for BookRepository in Staup class
        public BookController(BookRepository bookRepository)
        {
            //_bookRepository = new BookRepository();
            _bookRepository = bookRepository;
        }
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }
        [Route("book-details/{id}", Name ="bookDetailsRoute")]
        public async Task<ViewResult> GetBook(int id)
        {
            //**To pass dynamic data means some extra data with the our model data this is the way
            //** For testing Using ExpandoObject() ; we can add extra data with our model data
            //** dynamic data = new ExpandoObject();
            var data = await _bookRepository.GetBookById(id);
            //data.Name = "Avinash";
            return View(data) ;
        }

        public List<BookModel> SearchBooks(string  bookName, string authorName)
        {
            return _bookRepository.SerachBook(bookName, authorName);
        }

        public ViewResult AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
           int id = await _bookRepository.AddNewBook(bookModel);
            if(id > 0)
            {
                //It will return to the AddNew Book Page so it will make the field Empty
                return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
            }
            return View();
        }
    }
}
