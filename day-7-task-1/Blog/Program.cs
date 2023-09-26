

class Here
{
    static void Main()
    {
        var p = new PostController();
        var c = new CommentController();
        p.Create("First blog", "The Content");
        p.ReadAll().ForEach(pp =>
        {
            Console.WriteLine(pp.Title);
            Console.WriteLine(pp.Content);
            c.Create(pp.PostId, "This is a comment here");
        });

        Console.WriteLine("Hello, World!");
    }
}