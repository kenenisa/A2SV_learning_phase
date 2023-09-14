using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;



public class MediaItem
{
    public MediaItem(string Title, string MediaType, int Duration)
    {
        this.Title = Title;
        this.MediaType = MediaType;
        this.Duration = Duration;
    }
    public string Title { get; set; }
    public string MediaType { get; set; }
    public int Duration { get; set; }
}

public class Book
{
    public Book(string Title, string Author, string ISBN, int PublicationYear)
    {
        this.Title = Title;
        this.Author = Author;
        this.ISBN = ISBN;
        this.PublicationYear = PublicationYear;
    }
    public string Title;
    public string Author;
    public string ISBN;
    public int PublicationYear;

}
public class Library
{
    public string Name;
    public string Address;
    public List<Book> Books;
    public List<MediaItem> MediaItems;
    public Library(string Name, string Address)
    {
        this.Name = Name;
        this.Address = Address;
        Books = new List<Book>();
        MediaItems = new List<MediaItem>();
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
    }
    public void RemoveBook(Book book)
    {
        Books.Remove(book);
    }
    public void AddMediaItem(MediaItem item)
    {
        MediaItems.Add(item);
    }
    public void RemoveMediaItem(MediaItem item)
    {
        MediaItems.Remove(item);
    }
    public void PrintCatalog()
    {
        Console.WriteLine("Books");
        foreach (Book book in Books)
        {
            Console.WriteLine("Title: " + book.Title);
            Console.WriteLine("Author: " + book.Author);
            Console.WriteLine("ISBN: " + book.ISBN);
            Console.WriteLine("PublicationYear: " + book.PublicationYear);
            Console.WriteLine("-------");
        }

        Console.WriteLine("");
        Console.WriteLine("Media items");
        foreach (MediaItem item in MediaItems)
        {
            Console.WriteLine("Title: " + item.Title);
            Console.WriteLine("Media type: " + item.MediaType);
            Console.WriteLine("Duration: " + item.Duration);
            Console.WriteLine("-------");
        }
    }
}
public class Program
{
    public static string ReadLine(string ask, Func<string, bool> condition)
    {
        Console.Write(ask);
        string read = Console.ReadLine();
        while (condition(read))
        {
            Console.WriteLine("Please enter a valid input");
            Console.Write(ask);
            read = Console.ReadLine();
        }
        return read;
    }
    public static int ReadNumber(string prompt)
    {
        int result = 0;
        ReadLine(prompt, (read) =>
                {
                    return !int.TryParse(read, out result) || result < 0;
                });
        return result;
    }
    public static void Main()
    {
        string name = ReadLine("Library name: ", (read) =>
        {
            return read.Equals("");
        });
        string address = ReadLine("Library address: ", (read) =>
        {
            return read.Equals("");
        });


        Library library = new Library(name, address);
        int choice = -1;

        while (choice != 0)
        {
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Add Media item");
            Console.WriteLine("3. Show Library");
            Console.WriteLine("0. Exit");

            choice = ReadNumber("Enter choice: ");
            if (choice == 1)
            {
                library.AddBook(new Book(
                    ReadLine("Title: ", (read) => { return read.Equals(""); }),
                    ReadLine("Author: ", (read) => { return read.Equals(""); }),
                    ReadLine("ISBN: ", (read) => { return read.Equals(""); }),
                    ReadNumber("PublicationYear: ")
                ));
            }
            else if (choice == 2)
            {
                library.AddMediaItem(new MediaItem(
                    ReadLine("Title: ", (read) => { return read.Equals(""); }),
                    ReadLine("MediaType: ", (read) => { return read.Equals(""); }),
                    ReadNumber("Duration: ")
                ));
            }
            else if (choice == 3)
            {
                Console.WriteLine("+++++++");
                Console.WriteLine("Name: " + library.Name);
                Console.WriteLine("Address: " + library.Address);
                library.PrintCatalog();
                Console.WriteLine("+++++++");
            }
        }

    }
}
