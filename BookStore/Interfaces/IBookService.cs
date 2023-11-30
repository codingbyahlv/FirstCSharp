namespace BookStore.Interfaces;

public interface IBookService
{
    void AddBook(IBook book);

    bool DisplayAllBooks();

    bool DisplayOneBook(int number);
}
