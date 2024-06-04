using DotNet8.VerticalSlice_CqrsExample.Models.Setup.Blog;
using MediatR;

namespace DotNet8.VerticalSlice_CqrsExample.Api.Features.Blog.Queries.GetBlogById
{
    public class GetBlogByIdQuery : IRequest<BlogModel>
    {
        public long BlogId { get; set; }
    }
}
