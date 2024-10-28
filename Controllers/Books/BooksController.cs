using BookStore.InternalContracts.Models;
using BookStore.InternalContracts.AuthorQueries;
using BookStore.Services;
using BookStore.Services.BooksService;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using BookStore.InternalContracts.BooksQueries;

namespace BookStore.Controllers.Books
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : Controller
    {

        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateBook")]
        public async Task<BookModel> CreateBook([FromBody] BookModel model)
        {
            return await _mediator.Send(model);
        }

        [HttpPut("UpdateBook")]
        public async Task<string> UpdateBook([FromBody] UpdateBookQuery updateBookQuery)
        {
            return await _mediator.Send(updateBookQuery);
        }


        [HttpGet("GetBookById")]
        public async Task<BookModel> GetBookById(int id)
        {
            return await _mediator.Send(new GetBookByIdQuery { Id = id });
        }

        [HttpGet("GetAllBooks")]
        public async Task<List<BookModel>> GetAllBooks(int? take = 10, int? skip = 0)
        {
            return await _mediator.Send(new GetAllBooksQuery { Take = take, Skip = skip });
        }

        [HttpDelete("DeleteBook")]
        public async Task<string> DeleteBook(int id)
        {
            return await _mediator.Send(new DeleteBookQuery { Id = id });
        }

        [HttpPost("SortBooks")]
        public async Task<List<BookModel>> SortBooks(SortBooksQuery sortBooksQuery)
        {
            return await _mediator.Send(sortBooksQuery);
        }

        [HttpPost("FilterBooks")]
        public async Task<List<BookModel>> FilterBooks(FilterBooksQuery filterBooksQuery)
        {
            return await _mediator.Send(filterBooksQuery);
        }
    }
}
