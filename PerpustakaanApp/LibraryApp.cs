using System;
using System.Text.RegularExpressions;

namespace PerpustakaanApp;

public class LibraryApp
{
    public static void Main(string[] args)
    {
        LibraryCatalog catalog = new LibraryCatalog();
        string menu;
        do
        {
            Console.Clear();
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. Find Book");
            Console.WriteLine("4. List Books");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your option: ");
            menu = Console.ReadLine();

            switch (menu)
            {
                case "1":
                    Console.Clear();
                    Book newBook = new Book();
                    Console.Write("Enter the title: ");
                    newBook.Title = Console.ReadLine();
                    Console.Write("Enter the author: ");
                    newBook.Author = Console.ReadLine();
                    bool validYearInput = false;
                    string yearPattern = @"^\d{4}$"; // Validasi tahun 4 digit.
                    do
                    {
                        Console.Write("Enter the publication year (4 digits): ");
                        string inputYear = Console.ReadLine();
                        if (Regex.IsMatch(inputYear, yearPattern))
                        {
                            newBook.PublicationYear = int.Parse(inputYear);
                            validYearInput = true;
                        }
                        else
                        {
                            ErrorHandler.HandleError("Invalid input. Tahun penerbitan harus berupa angka 4 digit.");
                        }
                    } while (!validYearInput);

                    catalog.AddBook(newBook);
                    Console.WriteLine("\nBuku berhasil ditambahkan.");
                    Console.ReadLine();
                    break;

                case "2":
                    Console.Clear();
                    Console.Write("Masukkan judul buku yang ingin dihapus: ");
                    string titleToRemove = Console.ReadLine();
                    catalog.RemoveBook(titleToRemove);

                    break;


                case "3":
                    Console.Clear();
                    Console.Write("Masukkan judul buku yang ingin dicari : ");
                    string searchName = Console.ReadLine();
                    catalog.FindBook(searchName);
                    Console.ReadLine();
                    break;


                case "4":
                    Console.Clear();
                    catalog.ListBooks();
                    Console.ReadLine();
                    break;

                case "5":
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    ErrorHandler.HandleError("Invalid option.");
                    Console.ReadLine();
                    break;
            }

        } while (menu != "5");
    }
}

