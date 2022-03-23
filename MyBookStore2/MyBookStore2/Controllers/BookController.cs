using Microsoft.AspNetCore.Mvc;
using MyBookStore2.Models;
using MyBookStore2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookStore2.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookrepository = null;

        public BookController()
        {
            _bookrepository = new BookRepository();
        }
       public ViewResult GetAllBooks()
        {
            var data = _bookrepository.GetAllBooks();

            return View();
        }

        public BookModel GetBook(int id)
        {
            return _bookrepository.GetBookById(id);
        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookrepository.SearchBook(bookName, authorName);
        }
    }
}
