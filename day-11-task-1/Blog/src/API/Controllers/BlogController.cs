[ApiController]
[Route("api/[controller]")]
public class BlogController : ControllerBase
{
    private readonly IMediator _mediator;

    public BlogController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<Blog>>> GetAllBlogs()
    {
        var query = new GetAllBlogsQuery();
        var blogs = await _mediator.Send(query);
        return Ok(blogs);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Blog>> GetBlogById(int id)
    {
        var query = new GetBlogByIdQuery { Id = id };
        var blog = await _mediator.Send(query);

        if (blog == null)
        {
            return NotFound();
        }

        return Ok(blog);
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateBlog([FromBody] CreateBlogCommand command)
    {
        var blogId = await _mediator.Send(command);
        return Ok(blogId);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateBlog(int id, [FromBody] UpdateBlogCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBlog(int id)
    {
        var command = new DeleteBlogCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
