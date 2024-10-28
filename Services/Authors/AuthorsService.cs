using AutoMapper;
using BookStore.Helpers;
using BookStore.InternalContracts.AuthorQueries;
using BookStore.InternalContracts.BooksQueries;
using BookStore.InternalContracts.Models;
using BookStore.Repositories.Authors;

namespace BookStore.Services.Authors
{
    public class AuthorsService(IAuthorsRepository authorsRepository, IMapper mapper) : IAuthorsService
    {
        private readonly IAuthorsRepository _authorsRepository = authorsRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<AuthorModel> CreateAuthor(AuthorModel model)
        {
            var author = await _authorsRepository.GetAuthorById(model.Id);
            if (author != null) throw new AppException($"Author with the ID {model.Id} already exist"); 
            else  return await _authorsRepository.CreateAuthor(model); 
        }

        public async Task UpdateAuthor(UpdateAuthorCommand updateAuthorCommand)
        {

            var author = await _authorsRepository.GetAuthorById(updateAuthorCommand.Id) ?? throw new AppException($"Author with the ID {updateAuthorCommand.Id} doesn't exist");
            author = _mapper.Map<AuthorModel>(updateAuthorCommand);
            await _authorsRepository.UpdateAuthor(author);
        }

        public async Task DeleteAuthor(int id)
        {
            var author = await _authorsRepository.GetAuthorById(id) ?? throw new AppException($"Author with the ID {id} doesn't exist");
            await _authorsRepository.DeleteAuthor(author);
        }

        public async Task<AuthorModel> GetAuthorById(int id)
        {
            var author = await _authorsRepository.GetAuthorById(id);
            if (author == null)  throw new AppException($"Author with the ID {id} doesn't exist"); 
            return author; 
        }

        public async Task<List<AuthorModel>> GetAllAuthors(GetAllAuthorsQuery getAllAuthorsQuery)
        {
            if (getAllAuthorsQuery.Take <= 0 || getAllAuthorsQuery.Skip < 0) throw new AppException("The Skip value must be greater than or equal to 0. The Take value must be greater than 0.");
            return await _authorsRepository.GetAllAuthors(getAllAuthorsQuery.Take, getAllAuthorsQuery.Skip);
        }

        public async Task<List<AuthorModel>> SortAuthors(SortAuthorsQuery sortAuthorsQuery)
        {
            return await _authorsRepository.SortAuthors(sortAuthorsQuery.Parameter.ToString(), sortAuthorsQuery.Value);
        }

        public async Task<List<AuthorModel>> FilterAuthors(FilterAuthorsQuery filterAuthorsQuery)
        {
            
            return await _authorsRepository.FilterAuthors(filterAuthorsQuery.Parameters.ToString(), filterAuthorsQuery.Value);
        }
    }
}
