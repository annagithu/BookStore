namespace BookStore.InternalContracts.References
{
    public class References
    {
        public enum BooksParameters
        {
            Name,
            Author,
            Pages,
            YearOfPublication,
            Condition
        }

        public enum AuthorParameters
        {
            Surname,
            Name,
            Patronymic,
            BirthYear
        }

        public enum OrderKind
        {
            ASC,
            DESC
        }

        public enum Condition
        {
            Terrify,
            Normal,
            Good
        }

    }
}
