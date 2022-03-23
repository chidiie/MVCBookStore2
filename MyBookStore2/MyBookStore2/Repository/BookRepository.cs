using MyBookStore2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookStore2.Repository
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

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel() { Id = 1, Title = "MVCBook", Author = "Chidinma Ejike" },
                new BookModel() { Id = 2, Title = "Atomic Habits", Author = "James Clear" },
                new BookModel() { Id = 3, Title = "Spring Rolls", Author = "Charlie Wood" },
                new BookModel() { Id = 4, Title = "Trouble in America", Author = "Ryan Reynolds" },
                new BookModel() { Id = 5, Title = "Java", Author = "Simon Cent" }
            };
        }
    }
}
