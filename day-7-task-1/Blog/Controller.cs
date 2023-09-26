using System;
using System.Linq;

public class PostController
{
    public BloggingContext db = new BloggingContext();
    public void Create(string T, string C)
    {
        db.Add(
            new Post
            {
                Title = T,
                Content = C,
                CreatedAt = DateTime.Now
            }
        );
        db.SaveChanges();
    }
    public List<Post> ReadAll()
    {
        return db.Posts.OrderBy(p => p.PostId).ToList();
    }
    public Post Update(int I, string T, string C)
    {
        var post = db.Posts.Where(p => p.PostId == I).First();
        post.Title = T;
        post.Content = C;
        db.SaveChanges();
        return post;
    }
    public void Delete(int I)
    {
        var post = db.Posts.Where(p => p.PostId == I).First();
        db.Remove(post);
        db.SaveChanges();
    }

}
/////////////////////////////////////////////////
/////////////// Comment /////////////////////////
////////////////////////////////////////////////
public class CommentController
{
    public BloggingContext db = new BloggingContext();
    public void Create(int PID, string T)
    {
        db.Posts.Where(p => p.PostId == PID).First().Comments.Add(
            new Comment
            {
                Text = T,
                CreatedAt = DateTime.Now
            }
        );
        db.SaveChanges();
    }
    public List<Comment> ReadAll(int PID)
    {
        return db.Posts.Where(p => p.PostId == PID).First().Comments.OrderBy(p => p.PostId).ToList();
    }
    public Comment Update(int I, string T)
    {
        var comment = db.Comments.Where(c => c.CommentId == I).First();
        comment.Text = T;
        db.SaveChanges();
        return comment;
    }
    public void Delete(int I)
    {
        var comment = db.Comments.Where(c => c.CommentId == I).First();
        db.Remove(comment);
        db.SaveChanges();
    }

}
