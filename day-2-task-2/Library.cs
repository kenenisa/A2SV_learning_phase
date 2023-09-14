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