using Microsoft.AspNetCore.Mvc;
using MyBookStore2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookStore2.Components
{
    public class TopBooksViewComponent : ViewComponent
    {
        private readonly IBookRepository _bookRepository;

        public TopBooksViewComponent(IBookRepository bookRepository )
        {
            _bookRepository = bookRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var books = await _bookRepository.GetTopBooksAsync(count);
            return View(books);
        }
    }
}
