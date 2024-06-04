using DotNet8.VerticalSlice_CqrsExample.Models.Setup.Blog;
using MediatR;

namespace DotNet8.VerticalSlice_CqrsExample.Api.Features.Blog.Queries.GetBlogList
{
    public class GetBlogListQuery : IRequest<BlogListResponseModel>
    {
    }
}