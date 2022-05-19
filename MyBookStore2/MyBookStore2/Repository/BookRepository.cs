using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyBookStore2.Data;
using MyBookStore2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookStore2.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context = null;
        private readonly IConfiguration _configuration;

        public BookRepository(BookStoreContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                Description = model.Description,
                Title = model.Title,
                LanguageId = model.LanguageId,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                CoverImageUrl = model.CoverImageUrl,
                BookPdfUrl = model.BookPdfUrl,

            };

            var gallery = new List<BookGallery>();
            newBook.BookGallery = new List<BookGallery>();

            foreach (var file in model.Gallery)
            {
                newBook.BookGallery.Add(new BookGallery()
                {
                    Name = file.Name,
                    URL = file.URL
                });
            }

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;

        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            return await _context.Books.Select(book => new BookModel()
            {
                Author = book.Author,
                Title = book.Title,
                Category = book.Category,
                TotalPages = book.TotalPages,
                Description = book.Description,
                Id = book.Id,
                LanguageId = book.LanguageId,
                Language = book.Language.Name,
                CoverImageUrl = book.CoverImageUrl,
            }).ToListAsync();
        }

        public async Task<List<BookModel>> GetTopBooksAsync(int count)
        {
            return await _context.Books.Select(book => new BookModel()
            {
                Author = book.Author,
                Title = book.Title,
                Category = book.Category,
                TotalPages = book.TotalPages,
                Description = book.Description,
                Id = book.Id,
                LanguageId = book.LanguageId,
                Language = book.Language.Name,
                CoverImageUrl = book.CoverImageUrl,
            }).Take(count).ToListAsync();
        }

        public async Task<BookModel> GetBookById(int id)
        {
            return await _context.Books.Where(x => x.Id == id).Select(book => new BookModel()
            {
                Author = book.Author,
                Title = book.Title,
                Category = book.Category,
                TotalPages = book.TotalPages,
                Description = book.Description,
                Id = book.Id,
                LanguageId = book.LanguageId,
                Language = book.Language.Name,
                CoverImageUrl = book.CoverImageUrl,
                Gallery = book.BookGallery.Select(bookimage => new GalleryModel()
                {
                    Id = bookimage.Id,
                    Name = bookimage.Name,
                    URL = bookimage.URL
                }).ToList(),
                BookPdfUrl = book.BookPdfUrl
            }).FirstOrDefaultAsync();

        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return null;

        }
        public string GetAppName()
        {
            return _configuration["AppName"];
        }
    }
}
