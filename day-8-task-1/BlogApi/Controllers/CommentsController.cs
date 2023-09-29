using Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
    private readonly BloggingContext _context;

    public CommentsController(BloggingContext context)
    {
        _context = context;
    }

    // GET: api/Comments
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
    {
        return await _context.Comments.ToListAsync();
    }

    // GET: api/Comments/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Comment>> GetComment(int id)
    {
        var Comment = await _context.Comments.FindAsync(id);

        if (Comment == null)
        {
            return NotFound();
        }

        return Comment;
    }

    // Comment api/Comments
    [HttpPost]
    public async Task<ActionResult<Comment>> CommentComment(Comment Comment)
    {
        try
        {

            _context.Comments.Add(Comment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetComment), new { id = Comment.CommentId }, Comment);
        }
        catch (Exception e)
        {
            return NotFound();
        }
    }

    // PUT api/Comments/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutComment(int id, Comment Comment)
    {
        if (id != Comment.CommentId)
        {
            return BadRequest();
        }

        _context.Entry(Comment).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return Ok(await _context.Comments.FindAsync(id));

    }

    // DELETE api/Comments/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComment(int id)
    {
        var Comment = await _context.Comments.FindAsync(id);

        if (Comment == null)
        {
            return NotFound();
        }

        _context.Comments.Remove(Comment);
        await _context.SaveChangesAsync();

        return Ok(Comment);
    }
}