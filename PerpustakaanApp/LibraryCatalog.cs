using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PerpustakaanApp;

public class LibraryCatalog
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void RemoveBook(string book)
    {
        Book bookToRemove = books.FirstOrDefault(u => u.Title == book);
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            Console.WriteLine($"Data dengan id {book} berhasil dihapus ! \n");
        }
        else
        {
            ErrorHandler.HandleError($"Buku dengan judul {book} tidak ada !");
        }
        Console.ReadLine();
    }

    public void FindBook(string title)
    {
        // Mencari buku yang cocok berdasarkan judul yang mengandung kata kunci
        var searchBooks = books.Where(u => Regex.IsMatch(u.Title, title, RegexOptions.IgnoreCase)).ToList();

        if (searchBooks.Count == 0)
        {
            Console.WriteLine("No books found matching the title or part of the title.");

        }
        else
        {
            Console.WriteLine("Buku berhasil ditemukan");
            foreach (var item in searchBooks)
            {
                Console.WriteLine($"Title: {item.Title}, Author: {item.Author}, Publication Year: {item.PublicationYear}");
            }
            
        }
    }


    public void ListBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("The library catalog is empty. No books have been added yet.");
        }
        else
        {
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Publication Year: {book.PublicationYear}");
            }
        }
    }
}

