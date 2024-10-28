using BookStore.InternalContracts.AuthorQueries;
using BookStore.InternalContracts.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        [HttpPut("CreateAuthor")]
        public async Task<AuthorModel> CreateAuthor([FromBody] AuthorModel model)
        {
            return await _mediator.Send(model);
        }

        [HttpPut("UpdateAuthor")]
        public async Task UpdateAuthor([FromBody] UpdateAuthorCommand model)
        {
            await _mediator.Send(model);
        }

        [HttpDelete("DeleteAuthor")]
        public async Task DeleteAuthor(int id)
        {
            await _mediator.Send(new DeleteAuthorCommand { Id = id });
        }

        [HttpGet("GetAuthorById")]
        public async Task<AuthorModel> GetAuthorById(int id)
        {
            return await _mediator.Send(new GetAuthorByIdQuery { Id = id });
        }

        [HttpGet("GetAllAuthors")]
        public async Task<List<AuthorModel>> GetAllAuthors(int take = 10, int skip = 0 )
        {
            return await _mediator.Send(new GetAllAuthorsQuery { Take = take, Skip = skip });
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
