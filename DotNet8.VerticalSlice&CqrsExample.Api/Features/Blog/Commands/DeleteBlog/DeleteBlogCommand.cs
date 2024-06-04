using MediatR;

namespace DotNet8.VerticalSlice_CqrsExample.Api.Features.Blog.Commands.DeleteBlog;

public class DeleteBlogCommand : IRequest<int>
{
    public long BlogId { get; set; }
}