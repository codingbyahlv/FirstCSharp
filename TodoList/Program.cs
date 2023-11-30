using System;
using System.Collections.Generic;

namespace TodoList
{
    class TodoItem(string description)
    {
        public string Description { get; set; } = description;
        public bool IsDone { get; set; } = false;
    }



    internal class Program
    {
        static void PrintAllTodos(List<TodoItem> todoList)
        {
            //foreach (var todo in todoList)
            //{
            //    Console.WriteLine($"- {todo.Description} - Klar: {todo.IsDone}");
            //}
            for (int i = 0; i < todoList.Count; i++)
            {
                Console.WriteLine($"[{i+1}] {todoList[i].Description} - {(todoList[i].IsDone ? "Klar" : "Ej klar")}");
            }
        }



        static void Main(string[] args)
        {
            bool isMenu = true;
            List<TodoItem> todoList = new List<TodoItem>();
            todoList.Add(new TodoItem("Göra läxan"));
            todoList.Add(new TodoItem("Handla"));
            todoList.Add(new TodoItem("Städa"));
            todoList[0].IsDone = true;

            do
            {
                Console.Clear();
                Console.WriteLine("************ MENY *************");
                Console.WriteLine();
                Console.WriteLine("[1] Se din todolista");
                Console.WriteLine("[2] Lägg till ny todo");
                Console.WriteLine("[3] Markera todo som slutförd");
                Console.WriteLine("[Q] Avsluta programmet");
                Console.WriteLine();
                Console.Write("Ditt val: ");

                string option = Console.ReadLine()!;

                if (!string.IsNullOrEmpty(option))
                {
                    Console.Clear();
                    switch (option)
                    {
                        case "1":
                            Console.WriteLine("******** DIN LISTA ********");
                            PrintAllTodos(todoList);
                            Console.WriteLine();
                            Console.WriteLine("Kvar att göra");
                            foreach (var todo in todoList)
                            {
                                if (!todo.IsDone)
                                {                              
                                    Console.WriteLine($"- {todo.Description}");
                                }
                            }
                            Console.WriteLine();
                            Console.WriteLine("Klara - Bra jobbat!");
                            foreach (var todo in todoList)
                            {
                                if (todo.IsDone)
                                {
                                    Console.WriteLine($"- {todo.Description}");

                                }
                            }
                            Console.WriteLine();
                            bool exit = false;
                            Console.WriteLine("Tryck X för att återgå till menyn...");
                            do 
                            { 
                                ConsoleKeyInfo key = Console.ReadKey(true);
                                if (key.Key == ConsoleKey.X) exit = true;
                            }
                            while(!exit);
                            break;
                        case "2":
                            Console.WriteLine("Lägg till");
                            // Implement code to add a new todo
                            break;
                        case "3":
                            Console.WriteLine("Markera todo som slutförd");
                            // Implement code to mark a todo as done
                            break;
                        case "Q":
                            Console.WriteLine("Programmet avslutat");
                            isMenu = false;
                            break;
                        default:
                            Console.WriteLine("Ogiltigt val");
                            break;
                    }
                    

                }
            } while (isMenu);

            Console.ReadKey();
        }
    }
}