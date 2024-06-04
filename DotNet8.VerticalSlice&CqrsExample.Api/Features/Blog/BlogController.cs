using DotNet8.VerticalSlice_CqrsExample.Api.Features.Blog.Commands.CreateBlog;
using DotNet8.VerticalSlice_CqrsExample.Api.Features.Blog.Commands.DeleteBlog;
using DotNet8.VerticalSlice_CqrsExample.Api.Features.Blog.Commands.UpdateBlog;
using DotNet8.VerticalSlice_CqrsExample.Api.Features.Blog.Queries.GetBlogById;
using DotNet8.VerticalSlice_CqrsExample.Api.Features.Blog.Queries.GetBlogList;
using DotNet8.VerticalSlice_CqrsExample.Models.Setup.Blog;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.VerticalSlice_CqrsExample.Api.Features.Blog;

[Route("api/[controller]")]
[ApiController]
public class BlogController : BaseController
{
    private readonly IMediator _mediator;

    public BlogController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetBlogs()
    {
        try
        {
            var query = new GetBlogListQuery();
            var lst = await _mediator.Send(query);

            return Content(lst);
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBlogById(long id)
    {
        try
        {
            var query = new GetBlogByIdQuery() { BlogId = id };
            var item = await _mediator.Send(query);

            return Content(item);
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateBlog([FromBody] BlogRequestModel requestModel)
    {
        try
        {
            var command = new CreateBlogCommand() { BlogRequestModel = requestModel };
            int result = await _mediator.Send(command);

            return result > 0 ? Created("Creating Successful.") : BadRequest("Creating Fail");
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchBlog([FromBody] BlogRequestModel requestModel, long id)
    {
        try
        {
            var command = new UpdateBlogCommand()
            {
                BlogRequestModel = requestModel,
                BlogId = id
            };
            int result = await _mediator.Send(command);

            return result > 0 ? Accepted("Updating Successful.") : BadRequest("Updating Fail.");
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBlog(long id)
    {
        try
        {
            var command = new DeleteBlogCommand() { BlogId = id };
            int result = await _mediator.Send(command);

            return result > 0 ? Accepted("Deleting Successful.") : BadRequest("Deleting Fail.");
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }
}