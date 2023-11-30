using BookStore.Interfaces;

namespace BookStore.Models;

public class AudiobookModel : IAudiobook
{ 
    public int? BookLength { get; set; }
    public string BookTitle { get; set; } = null!;
    public string BookAuthor { get; set; } = null!;
    public string? BookIsbn { get; set; }
    public BookTypes BookType { get; set; }

    public AudiobookModel()
    {

    }

    public AudiobookModel(string title, string author, string? isbn, BookTypes type, int length)    
    {
        BookTitle = title;
        BookAuthor = author;
        BookIsbn = isbn;
        BookType = type;
        BookLength = length;
    }

}
