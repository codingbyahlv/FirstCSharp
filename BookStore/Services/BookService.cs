using BookStore.Interfaces;
using System;
using System.ComponentModel;

namespace BookStore.Services;

public class BookService : IBookService
{
    private static readonly List<IBook> _bookList = [];

    public void AddBook(IBook book)
    {
        _bookList.Add(book);
    }

    public bool DisplayAllBooks()
    {
        if(_bookList.Count > 0)
        {
            Console.WriteLine("\n************ BOKINFORMATION *************");
            Console.WriteLine("***********  - Hela listan - ************");
            Console.WriteLine();

            for (int i = 0; i < _bookList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_bookList[i].BookTitle}");
            }

            return true;
        }

        return false;
    }

    public bool DisplayOneBook(int number)
    {
        if(number <= _bookList.Count && number > 0)
        {
            Console.Clear();
            Console.WriteLine("\n************ BOKINFORMATION *************");
            Console.WriteLine("************  - Vald bok - **************");
            Console.WriteLine();
            Console.WriteLine($"Titel: {_bookList[number - 1].BookTitle}");
            Console.WriteLine($"Författare: {_bookList[number - 1].BookAuthor}");
            Console.WriteLine($"ISBN: {_bookList[number - 1].BookIsbn}");
            Console.WriteLine($"Bokform: {_bookList[number - 1].BookType}");

            switch(_bookList[number - 1])
            {
                case IAudiobook audiobook:
                    Console.WriteLine($"Längd (minuter): {audiobook.BookLength}");
                    break;
                //case IBook printedbook:
                //    Console.WriteLine("printad");
                //    break;
                default: break;
            }

            return false;
        } 

        return true; 
    }
}
