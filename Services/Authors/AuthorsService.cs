using AutoMapper;
using BookStore.Helpers;
using BookStore.InternalContracts.AuthorQueries;
using BookStore.InternalContracts.Models;
using BookStore.Repositories.Authors;
using static BookStore.InternalContracts.References.References;

namespace BookStore.Services.Authors
{
    public class AuthorsService(IAuthorsRepository authorsRepository) : IAuthorsService
    {
        private readonly IAuthorsRepository _authorsRepository = authorsRepository;

        public async Task<AuthorModel> CreateAuthor(AuthorModel model)
        {
            var author = await _authorsRepository.GetAuthorById(model.Id);
            if (author != null) { throw new AppException($"Author with the ID {model.Id} already exist"); }
            else { return await _authorsRepository.CreateAuthor(model); };
            
        }

        public async Task<AuthorModel> GetAuthorById(int id)
        {
            var author = await _authorsRepository.GetAuthorById(id);
            if (author == null) { throw new AppException($"Author with the ID {id} doesn't exist"); }
            else { return author; }
        }

        public async Task<List<AuthorModel>> GetAllAuthors(GetAllAuthorsQuery getAllAuthorsQuery)
        {
            if (getAllAuthorsQuery.Take < 0 || getAllAuthorsQuery.Skip < 0) { throw new AppException("Значения Skip и Take должны быть больше или равны нулю"); }
            return await _authorsRepository.GetAllAuthors(getAllAuthorsQuery.Take, getAllAuthorsQuery.Skip);
        }

        public async Task<string> DeleteAuthor(int id)
        {
            var author = await _authorsRepository.GetAuthorById(id);
            if (author == null) { throw new AppException($"Author with the ID {id} doesn't exist"); }
            else { return await _authorsRepository.DeleteAuthor(id); }
        }

        public async Task<List<AuthorModel>> SortAuthors(SortAuthorsQuery sortAuthorsQuery)
        {
            if (!Enum.IsDefined(typeof(AuthorParameters), sortAuthorsQuery.Parameter))
            {
                throw new AppException($"Type of condition {sortAuthorsQuery.Parameter} doesn't exist. Please, enter one of these: {string.Join(", ", Enum.GetNames(typeof(AuthorParameters)))}");
            }

            if (!Enum.IsDefined(typeof(OrderKind), sortAuthorsQuery.Value))
            {
                throw new AppException($"Type of condition {sortAuthorsQuery.Value} doesn't exist. Please, enter one of these: {string.Join(", ", Enum.GetNames(typeof(OrderKind)))}");
            }
            return await _authorsRepository.SortAuthors(sortAuthorsQuery.Parameter.ToString(), sortAuthorsQuery.Value.ToString());
        }

        public async Task<List<AuthorModel>> FilterAuthors(FilterAuthorsQuery filterAuthorsQuery)
        {
            if (!Enum.IsDefined(typeof(AuthorParameters), filterAuthorsQuery.Parameters))
            {
                throw new AppException($"Type of condition {filterAuthorsQuery.Parameters} doesn't exist. Please, enter one of these: {string.Join(", ", Enum.GetNames(typeof(AuthorParameters)))}");
            }
            return await _authorsRepository.FilterAuthors(filterAuthorsQuery.Parameters.ToString(), filterAuthorsQuery.Value.ToString());
        }

        public async Task<string> UpdateAuthor(UpdateAuthorQuery model)
        {
            var author = await _authorsRepository.GetAuthorById(model.Id);
            if (author == null) { throw new AppException($"Author with the ID {model.Id} doesn't exist"); }
            return await _authorsRepository.UpdateAuthor(ParseModels(model));
        }

        public AuthorModel ParseModels(UpdateAuthorQuery updateAuthorQuery)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<UpdateAuthorQuery, AuthorModel>()));
            return mapper.Map<UpdateAuthorQuery, AuthorModel>(updateAuthorQuery);
        }
    }
}
