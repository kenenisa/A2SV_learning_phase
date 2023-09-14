using System;
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
