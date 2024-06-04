using DotNet8.VerticalSlice_CqrsExample.Models.Setup.Blog;
using MediatR;

namespace DotNet8.VerticalSlice_CqrsExample.Api.Features.Blog.Commands.UpdateBlog
{
    public class UpdateBlogCommand : IRequest<int>
    {
        public BlogRequestModel BlogRequestModel { get; set; }
        public long BlogId { get; set; }
    }
}
