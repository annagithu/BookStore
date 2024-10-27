using BookStore.Handlers.Authors;
using BookStore.InternalContracts.AuthorCommands;
using BookStore.InternalContracts.BooksCommands;
using BookStore.InternalContracts.Models;
using BookStore.Services;
using BookStore.Services.Authors;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController : Controller
    {


        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateAuthor")]
        public async Task<AuthorModel> CreateAuthor([FromBody] AuthorModel model)
        {
            var createdAuthor = await _mediator.Send(model);

            return (AuthorModel)createdAuthor;
        }

        

        [HttpGet("GetAuthorById")]
        public async Task<AuthorModel> GetAuthorById(int id)
        {
            var author = await _mediator.Send(new GetAuthorByIdCommand { Id = id});
            return author;
        }



        [HttpGet("GetAllAuthors")]
        public async Task<List<AuthorModel>> GetAllAuthors(int Take, int Skip )
        {
            var authors = await _mediator.Send(new GetAllAuthorsCommand { Take = Take, Skip = Skip});
            return authors;
        }

        [HttpDelete("DeleteAuthor")]
        public async Task<string> DeleteAuthor(int id)
        {
            var responce = await _mediator.Send(new DeleteAuthorCommand { Id = id });
            return responce;
        }

        [HttpPost("SortAuthors")]
        public async Task<List<AuthorModel>> SortAuthors(SortAuthorsCommand sortAuthorsCommand)
        {
            var responce = await _mediator.Send(sortAuthorsCommand);
            return responce;
        }

        [HttpPost("FilterAuthors")]
        public async Task<List<AuthorModel>> FilterAuthors(FilterAuthorsCommand filterAuthorsCommand)
        {
            var responce = await _mediator.Send(filterAuthorsCommand);
            return responce;
        }
    }
}
