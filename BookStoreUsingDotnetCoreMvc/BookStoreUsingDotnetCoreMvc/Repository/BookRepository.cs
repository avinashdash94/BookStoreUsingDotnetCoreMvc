using BookStoreUsingDotnetCoreMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreUsingDotnetCoreMvc.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel> SerachBook(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) && x.Author.Contains(authorName)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id =1, Title="MVC", Author="Nitish"},
                new BookModel(){Id =2, Title="C#", Author="Moni"},
                new BookModel(){Id =3, Title="Java", Author="Roni"},
                new BookModel(){Id =4, Title="Php", Author="Tony"}

            };
        }
    }

}
