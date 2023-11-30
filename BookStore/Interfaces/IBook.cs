using BookStore.Enums;

namespace BookStore.Interfaces
{
    public interface IBook
    {
        string BookAuthor { get; set; }
        string? BookIsbn { get; set; }
        string BookTitle { get; set; }
        BookTypes BookType { get; set; }
    }
}