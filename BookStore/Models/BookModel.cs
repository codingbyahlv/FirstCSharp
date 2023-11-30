using BookStore.Interfaces;

namespace BookStore.Models;

public class BookModel : IBook
{
    public string BookTitle { get; set; } = null!;
    public string BookAuthor { get; set; } = null!;
    public string? BookIsbn { get; set; }
    public BookTypes BookType { get; set; }

    public BookModel()
    {

    }

    public BookModel(string title, string author, string? isbn, BookTypes type)
    {
        BookTitle = title;
        BookAuthor = author;
        BookIsbn = isbn;
        BookType = type;
    }
}
