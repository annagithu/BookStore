using Xunit;
using BookStore.Controllers.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.InternalContracts.BooksQueries;
using BookStore.InternalContracts.Models;
using MediatR;
using Moq;

namespace BookStore.Controllers.Books.Tests
{
    public class BooksControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly BooksController _controller;

        public BooksControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new BooksController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateBook_ReturnsBookModel_WhenCalled()
        {
 
            var bookModel = new BookModel { Id = 9, Name = "lalalend", Author = "ryan gosling", Condition = InternalContracts.References.References.Condition.Terrify, Pages = 70, YearOfPublication = 2020 };
            _mediatorMock.Setup(m => m.Send(bookModel, It.IsAny<CancellationToken>()))
                         .ReturnsAsync(bookModel);

 
            var result = await _controller.CreateBook(bookModel);

 
            var actionResult = Assert.IsType<BookModel>(result);
            Assert.Equal(bookModel, actionResult);
            _mediatorMock.Verify(m => m.Send(bookModel, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task UpdateBook_ReturnsString_WhenCalled()
        {
 
            var updateBookQuery = new UpdateBookQuery { Id = 9, Name = "lalalend", Author = "ryan gosling", Condition = InternalContracts.References.References.Condition.Terrify, Pages = 70, YearOfPublication = 2020 };
            var expectedResponse = "1 row has been updated";
            _mediatorMock.Setup(m => m.Send(updateBookQuery, It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedResponse);

 
            var result = await _controller.UpdateBook(updateBookQuery);

 
            Assert.Equal(expectedResponse, result);
            _mediatorMock.Verify(m => m.Send(updateBookQuery, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetBookById_ReturnsBookModel_WhenCalled()
        {

            int bookId = 1;
            var expectedBook = new BookModel { Id = 9, Name = "lalalend", Author = "ryan gosling", Condition = InternalContracts.References.References.Condition.Terrify, Pages = 70, YearOfPublication = 2020 };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetBookByIdQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedBook);


            var result = await _controller.GetBookById(bookId);


            var actionResult = Assert.IsType<BookModel>(result);
            Assert.Equal(expectedBook, actionResult);
            _mediatorMock.Verify(m => m.Send(It.IsAny<GetBookByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetAllBooks_ReturnsListOfBookModel_WhenCalled()
        {
 
            var expectedBooks = new List<BookModel>
        {
            new BookModel { Id = 9, Name = "lalalend", Author = "ryan gosling", Condition = InternalContracts.References.References.Condition.Terrify, Pages = 70, YearOfPublication = 2020 },
            new BookModel { Id = 10, Name = "lalalend", Author = "ryan gosling", Condition = InternalContracts.References.References.Condition.Terrify, Pages = 70, YearOfPublication = 2020 }
        };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllBooksQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedBooks);

 
            var result = await _controller.GetAllBooks();

 
            var actionResult = Assert.IsType<List<BookModel>>(result);
            Assert.Equal(expectedBooks.Count, actionResult.Count);
            _mediatorMock.Verify(m => m.Send(It.IsAny<GetAllBooksQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteBook_ReturnsString_WhenCalled()
        {
 
            int bookId = 1;
            var expectedResponse = "1 row has been deleted";
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteBookQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedResponse);

 
            var result = await _controller.DeleteBook(bookId);

 
            Assert.Equal(expectedResponse, result);
            _mediatorMock.Verify(m => m.Send(It.IsAny<DeleteBookQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task SortBooks_ReturnsListOfBookModel_WhenCalled()
        {
 
            var sortBooksQuery = new SortBooksQuery { Parameter = InternalContracts.References.References.BooksParameters.YearOfPublication, Value = InternalContracts.References.References.OrderKind.DESC };
            var expectedSortedBooks = new List<BookModel>
        {
            new BookModel {Id = 9, Name = "lalalend", Author = "ryan gosling", Condition = InternalContracts.References.References.Condition.Terrify, Pages = 70, YearOfPublication = 2020},
            new BookModel {Id = 10, Name = "lalalend", Author = "ryan gosling", Condition = InternalContracts.References.References.Condition.Terrify, Pages = 70, YearOfPublication = 2020}
        };
            _mediatorMock.Setup(m => m.Send(sortBooksQuery, It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedSortedBooks);

 
            var result = await _controller.SortBooks(sortBooksQuery);

 
            var actionResult = Assert.IsType<List<BookModel>>(result);
            Assert.Equal(expectedSortedBooks.Count, actionResult.Count);
            _mediatorMock.Verify(m => m.Send(sortBooksQuery, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task FilterBooks_ReturnsListOfBookModel_WhenCalled()
        {
 
            var filterBooksQuery = new FilterBooksQuery { Parameter = InternalContracts.References.References.BooksParameters.Author, Value = "ryan gosling" };
            var expectedFilteredBooks = new List<BookModel>
        {
            new BookModel { Id = 9, Name = "lalalend", Author = "ryan gosling", Condition = InternalContracts.References.References.Condition.Terrify, Pages = 70, YearOfPublication = 2020 } ,
            new BookModel { Id = 10, Name = "lalalend", Author = "ryan gosling", Condition = InternalContracts.References.References.Condition.Terrify, Pages = 70, YearOfPublication = 2020 }
        };
            _mediatorMock.Setup(m => m.Send(filterBooksQuery, It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedFilteredBooks);

 
            var result = await _controller.FilterBooks(filterBooksQuery);

 
            var actionResult = Assert.IsType<List<BookModel>>(result);
            Assert.Equal(expectedFilteredBooks.Count, actionResult.Count);
            _mediatorMock.Verify(m => m.Send(filterBooksQuery, It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}