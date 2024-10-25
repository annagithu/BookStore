using System.Text.Json.Serialization;
using MediatR;

namespace BookStore.InternalContracts.Models
{
    public class BookModel : IRequest<BookModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public string YearOfPublication { get; set; }

        public int Pages { get; set; }

        public Condition Condition { get; set; }
    }

    public enum Condition 
    {
        Terrify,
        Normal,
        Good
    }
}
