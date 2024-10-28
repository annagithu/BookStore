using BookStore.Handlers.Authors;
using BookStore.InternalContracts.AuthorQueries;
using BookStore.InternalContracts.BooksQueries;
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
            return await _mediator.Send(model);
        }

        [HttpPut("UpdateAuthor")]
        public async Task<string> UpdateAuthor([FromBody] UpdateAuthorQuery model)
        {
            return await _mediator.Send(model);
        }

        [HttpGet("GetAuthorById")]
        public async Task<AuthorModel> GetAuthorById(int id)
        {
            return await _mediator.Send(new GetAuthorByIdQuery { Id = id });
        }

        [HttpGet("GetAllAuthors")]
        public async Task<List<AuthorModel>> GetAllAuthors(int? take = 10, int? skip = 0 )
        {
            return await _mediator.Send(new GetAllAuthorsQuery { Take = take, Skip = skip });
        }

        [HttpDelete("DeleteAuthor")]
        public async Task<string> DeleteAuthor(int id)
        {
            return await _mediator.Send(new DeleteAuthorQuery { Id = id });
        }

        [HttpPost("SortAuthors")]
        public async Task<List<AuthorModel>> SortAuthors(SortAuthorsQuery sortAuthorsQuery)
        {
            return await _mediator.Send(sortAuthorsQuery);
        }

        [HttpPost("FilterAuthors")]
        public async Task<List<AuthorModel>> FilterAuthors(FilterAuthorsQuery filterAuthorsQuery)
        {
            return await _mediator.Send(filterAuthorsQuery);
        }
    }
}
