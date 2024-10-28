﻿using BookStore.InternalContracts.Models;
using BookStore.InternalContracts.References;
using MediatR;

namespace BookStore.InternalContracts.BooksQueries
{
    public class FilterBooksQuery : IRequest<List<BookModel>>
    {
        public References.References.BooksParameters Parameter { get; set; }

        public string? Value { get; set; }
    }
}