using Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly BloggingContext _context;

    public PostsController(BloggingContext context)
    {
        _context = context;
    }

    // GET: api/Posts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
    {
        return await _context.Posts.ToListAsync();
    }

    // GET: api/Posts/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Post>> GetPost(int id)
    {
        var Post = await _context.Posts.FindAsync(id);

        if (Post == null)
        {
            return NotFound();
        }

        return Post;
    }

    // POST api/Posts
    [HttpPost]
    public async Task<ActionResult<Post>> PostPost(Post Post)
    {
        try
        {

            _context.Posts.Add(Post);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPost), new { id = Post.PostId }, Post);
        }
        catch (Exception _)
        {
            return NotFound();
        }
    }

    // PUT api/Posts/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPost(int id, Post Post)
    {
        if (id != Post.PostId)
        {
            return BadRequest();
        }

        _context.Entry(Post).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return Ok(await _context.Posts.FindAsync(id));

    }

    // DELETE api/Posts/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        var Post = await _context.Posts.FindAsync(id);

        if (Post == null)
        {
            return NotFound();
        }

        _context.Posts.Remove(Post);
        await _context.SaveChangesAsync();

        return Ok(Post);
    }
}