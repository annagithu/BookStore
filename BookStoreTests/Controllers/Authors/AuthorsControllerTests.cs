using Xunit;
using BookStore.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.InternalContracts.Models;
using MediatR;
using BookStore.InternalContracts.AuthorQueries;
using BookStore.Handlers.Books;
using BookStore.Services.Authors;
using Moq;

namespace BookStore.Controllers.Tests
{
    public class AuthorsControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly AuthorsController _controller;

        public AuthorsControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new AuthorsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateAuthor_ReturnsAuthorModel_WhenCalled()
        {
            var authorModel = new AuthorModel { Id = 0, Name = "string", Surname = "string", Patronymic = null, BirthYear = 0 };
            _mediatorMock.Setup(m => m.Send(authorModel, It.IsAny<CancellationToken>()))
                         .ReturnsAsync(authorModel);

            var result = await _controller.CreateAuthor(authorModel);

            var actionResult = Assert.IsType<AuthorModel>(result);
            Assert.Equal(authorModel, actionResult);
            _mediatorMock.Verify(m => m.Send(authorModel, It.IsAny<CancellationToken>()), Times.Once);
        }



        [Fact]
        public async Task GetAuthorById_ReturnsAuthorModel_WhenCalled()
        {
            int authorId = 1;
            var expectedAuthor = new AuthorModel { Id = 8, BirthYear = 3, Name = "hi", Surname = "228", Patronymic = "cat"   };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAuthorByIdQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedAuthor);

            var result = await _controller.GetAuthorById(authorId);

            var actionResult = Assert.IsType<AuthorModel>(result);
            Assert.Equal(expectedAuthor, actionResult);
            _mediatorMock.Verify(m => m.Send(It.IsAny<GetAuthorByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAuthor_ReturnsString_WhenCalled()
        {
            var updateAuthorQuery = new UpdateAuthorQuery { Id = 0, Name = "", Patronymic = "name", Surname = "string", BirthYear = 0 };
            var expectedResponse = "Author updated successfully";
            _mediatorMock.Setup(m => m.Send(updateAuthorQuery, It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedResponse);

            var result = await _controller.UpdateAuthor(updateAuthorQuery);

            Assert.Equal(expectedResponse, result);
            _mediatorMock.Verify(m => m.Send(updateAuthorQuery, It.IsAny<CancellationToken>()), Times.Once);
        }


        [Fact]
        public async Task GetAllAuthors_ReturnsListOfAuthorModel_WhenCalled()
        { 
            var expectedAuthors = new List<AuthorModel>
        {
            new AuthorModel { Id = 1, Name = "first", Surname = "string", Patronymic = "string", BirthYear = 228 },
            new AuthorModel { Id = 2, Name = "second", Surname = "string", Patronymic = "string", BirthYear = 228  }
        };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllAuthorsQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedAuthors);

            var result = await _controller.GetAllAuthors();

            var actionResult = Assert.IsType<List<AuthorModel>>(result);
            Assert.Equal(expectedAuthors.Count, actionResult.Count);
            _mediatorMock.Verify(m => m.Send(It.IsAny<GetAllAuthorsQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteAuthor_ReturnsString_WhenCalled()
        {
            int authorId = 1;
            var expectedResponse = "1 row has been deleted";
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteAuthorQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedResponse);

            var result = await _controller.DeleteAuthor(authorId);

            Assert.Equal(expectedResponse, result);
            _mediatorMock.Verify(m => m.Send(It.IsAny<DeleteAuthorQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task SortAuthors_ReturnsListOfAuthorModel_WhenCalled()
        {
            var sortAuthorsQuery = new SortAuthorsQuery { Parameter = InternalContracts.References.References.AuthorParameters.Name, Value = InternalContracts.References.References.OrderKind.ASC  };
            var expectedSortedAuthors = new List<AuthorModel>
        {
            new AuthorModel { Id = 1, Name = "first", Surname = "string", Patronymic = "string", BirthYear = 228 },
            new AuthorModel { Id = 2, Name = "second", Surname = "string", Patronymic = "string", BirthYear = 228  }
        };
            _mediatorMock.Setup(m => m.Send(sortAuthorsQuery, It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedSortedAuthors);

            var result = await _controller.SortAuthors(sortAuthorsQuery);

            var actionResult = Assert.IsType<List<AuthorModel>>(result);
            Assert.Equal(expectedSortedAuthors.Count, actionResult.Count);
            _mediatorMock.Verify(m => m.Send(sortAuthorsQuery, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task FilterAuthors_ReturnsListOfAuthorModel_WhenCalled()
        {
            var filterAuthorsQuery = new FilterAuthorsQuery { Parameters = InternalContracts.References.References.AuthorParameters.BirthYear, Value = "5" };
            var expectedFilteredAuthors = new List<AuthorModel>
        {
            new AuthorModel { Id = 1, Name = "first", Surname = "string", Patronymic = "string", BirthYear = 5 },
            new AuthorModel { Id = 2, Name = "second", Surname = "string", Patronymic = "string", BirthYear = 5  }
        };
            _mediatorMock.Setup(m => m.Send(filterAuthorsQuery, It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedFilteredAuthors);

            var result = await _controller.FilterAuthors(filterAuthorsQuery);

            var actionResult = Assert.IsType<List<AuthorModel>>(result);
            Assert.Equal(expectedFilteredAuthors.Count, actionResult.Count);
            _mediatorMock.Verify(m => m.Send(filterAuthorsQuery, It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}