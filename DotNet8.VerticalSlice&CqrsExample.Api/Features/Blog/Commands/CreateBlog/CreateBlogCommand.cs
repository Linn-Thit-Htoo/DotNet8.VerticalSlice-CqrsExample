using DotNet8.VerticalSlice_CqrsExample.Models.Setup.Blog;
using MediatR;

namespace DotNet8.VerticalSlice_CqrsExample.Api.Features.Blog.Commands.CreateBlog;

public class CreateBlogCommand : IRequest<int>
{
    public BlogRequestModel BlogRequestModel { get; set; }
}