using BookStore.Enums;
using BookStore.Interfaces;
using BookStore.Models;
using System;

namespace BookStore.Services;

public class MenuService : IMenuService
{
    public void ShowMainMenu()
    {
        bool isMenu = true;

        do
        {
            Console.Clear();
            Console.WriteLine("************ MENY *************");
            Console.WriteLine();
            Console.WriteLine("[1] Lägg till ny bok");
            Console.WriteLine("[2] Se hela boklistan");
            Console.WriteLine("[3] Se mer detaljer om en bok");
            Console.WriteLine("[0] Avsluta programmet");
            Console.Write("\nDitt val: ");

            string option = Console.ReadLine()!;

            switch (option)
            {
                case "1":
                    ShowAddBookMenu();
                    break;
                case "2":
                    ShowAllBooksMenu();
                    break;
                case "3":
                    ShowOneBookMenu();
         
                    break;
                case "0":
                    QuitProgram();
                    break;
                default:
                    Console.WriteLine("Vänligen välj ett korrekt alternativ");
                    break;
            }

            Console.ReadKey();
        } while (isMenu);
    }

    private static void ShowAddBookMenu()
    {
        Console.Clear();
        Console.Write("Ange boktitel: ");
        string title = Console.ReadLine()!;
        Console.Write("Ange författare: ");
        string author = Console.ReadLine()!;
        Console.Write("Ange ISBN: ");
        string isbn = Console.ReadLine()!;
        Console.Write("Ange kategori (printed, audio, sale): ");
        string type = Console.ReadLine()!;
        type = type.ToLower();
        if (Enum.TryParse(type, out BookTypes bookType))
        {
            IBookService addService = new BookService();
            switch (type)
            {
                case "printed":
                    BookModel book = new(title, author, isbn, bookType);
                    addService.AddBook(book);
                    Console.WriteLine($"\nDu har lagt till boken {book.BookTitle}."); 
                    break;
                case "audio":
                    Console.Write("Ange bokens längd i minuter: ");
                    string inputLength = Console.ReadLine()!;
                    if (int.TryParse(inputLength, out int length))
                    {
                        AudiobookModel book2 = new(title, author, isbn, bookType, length );
                        addService.AddBook(book2);
                        Console.WriteLine($"\nDu har lagt till boken {book2.BookTitle}.");
                    }
                    else
                    {
                        Console.WriteLine($"\nNåt fel");
                    }
                    break;
            }
        }
        else
        {
            // FIXA DETTA!
            Console.WriteLine("Invalid book type entered.");
        }

        ReturnToMenu();
    }

    private static void ShowAllBooksMenu()
    {
        Console.Clear();
        IBookService displayAllService = new BookService();
        bool contentExist = displayAllService.DisplayAllBooks();
        if (!contentExist) Console.WriteLine("Du har inget innehåll i din lista");
        ReturnToMenu();
    }

    private static void ShowOneBookMenu()
    {
        Console.Clear();
        IBookService displayAllService = new BookService();
        bool contentExist = displayAllService.DisplayAllBooks();

        if (!contentExist) 
        { 
            Console.WriteLine("Du har inget innehåll i din lista");
            ReturnToMenu();
        }
        else
        {
            bool isRunning = true;
            Console.WriteLine("\nVilken bok vill du har mer information om?");

            do
            { 
                Console.Write("Ange nummer: ");
                string input = Console.ReadLine()!;
            
               if (int.TryParse(input, out int number))
               {
                    IBookService displayOneService = new BookService();
                    isRunning = displayOneService.DisplayOneBook(number);
                
                    if (isRunning)
                    {
                        Console.Clear();
                        displayAllService.DisplayAllBooks();
                        Console.WriteLine("\nFelaktigt valt nummer. Vänligen försök igen.");
                    }
                    else
                    {
                        ReturnToMenu();
                    }
               }
               else
               {
                    Console.Clear();
                    displayAllService.DisplayAllBooks();
                    Console.WriteLine("\nInget nummer. Vänligen försök igen.");
               }
            } while (isRunning);
        }
    }

    private void QuitProgram()
    {
        Console.Write("\nVill du verkligen avsluta programmet J/N ?");
        ConsoleKeyInfo key = Console.ReadKey(true);

        switch(key.Key)
        {
            case ConsoleKey.J:
                Environment.Exit(0);
                break;
            case ConsoleKey.N:
                Console.Clear();
                ShowMainMenu();
                break;
            default:
                Console.WriteLine("\nDu har angett ett felaktigt val");
                ReturnToMenu();
                break;
        }

    }

    private static void ReturnToMenu()
    {
        Console.Write("\n\nTryck på valfri tangent för att återgå till menyn..");
    }
}
