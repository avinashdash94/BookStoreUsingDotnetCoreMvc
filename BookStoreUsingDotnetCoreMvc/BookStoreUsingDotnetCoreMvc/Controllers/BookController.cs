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
        public BookController()
        {
            _bookRepository = new BookRepository();
        }
        public ViewResult GetAllBooks()
        {
            var data = _bookRepository.GetAllBooks();
            return View(data);
        }
        [Route("book-details/{id}", Name ="bookDetailsRoute")]
        public ViewResult GetBook(int id)
        {
            //To pass dynamic data means some extra data with the our model data this is the way
            //Using ExpandoObject() ; we can add extra data with our model data
            dynamic data = new ExpandoObject();
            data.book = _bookRepository.GetBookById(id);
            data.Name = "Avinash";
            return View(data) ;
        }

        public List<BookModel> SearchBooks(string  bookName, string authorName)
        {
            return _bookRepository.SerachBook(bookName, authorName);
        }

        public ViewResult AddNewBook()
        {
            return View();
        }

        [HttpPost]
        public ViewResult AddNewBook(BookModel bookModel)
        {
            return View();
        }
    }
}
