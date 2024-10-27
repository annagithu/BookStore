using BookStore.InternalContracts.Models;
using BookStore.InternalContracts.Commands;
using BookStore.Services;
using BookStore.Services.BooksService;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using BookStore.InternalContracts.BooksCommands;

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
            var createdBook = await _mediator.Send(model);

            return (BookModel)createdBook;
        }



        [HttpGet("GetBookById")]
        public async Task<BookModel> GetBookById(int id)
        {
            var book = await _mediator.Send( new GetBookByIdCommand {Id = id});
            return (BookModel)book;
        }



        [HttpGet("GetAllBooks")]
        public async Task<List<BookModel>> GetAllBooks(int take, int skip)
        {
            var books = await _mediator.Send(new GetAllBooksCommand { Take = take, Skip = skip });
            return books;
        }


        [HttpDelete("DeleteBook")]

        public async Task<string> DeleteBook(int id)
        {
            var responce = await _mediator.Send(new DeleteBookCommand { Id = id});
            return responce;
        }

        [HttpPost("SortBooks")]
        public async Task<List<BookModel>> SortBooks(SortBooksCommand sortBooksCommand)
        {
            var responce = await _mediator.Send(sortBooksCommand);
            return responce;
        }

        [HttpPost("FilterBooks")]
        public async Task<List<BookModel>> FilterBooks(FilterBooksCommand filterBooksCommand)
        {
            var responce = await _mediator.Send(filterBooksCommand);
            return responce;
        }
    }
}
