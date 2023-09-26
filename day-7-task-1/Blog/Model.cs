using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;


public class Comment
{
    public int CommentId { get; set; }
    public int PostId { get; set; }
    public required string Text { get; set; }

    public required DateTime CreatedAt { get; set; }

    public Post Post { get; set; }
}

public class Post
{
    public int PostId { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }

    public required DateTime CreatedAt { get; set; }

    public ICollection<Comment> Comments { get; }

}
public class BloggingContext : DbContext
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }


    public string DbPath { get; }

    public BloggingContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "blogging.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

