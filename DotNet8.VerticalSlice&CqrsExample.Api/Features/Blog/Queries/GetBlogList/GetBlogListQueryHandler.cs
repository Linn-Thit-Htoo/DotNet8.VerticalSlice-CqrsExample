using DotNet8.VerticalSlice_CqrsExample.Api.Repositories.Blog;
using DotNet8.VerticalSlice_CqrsExample.Models.Setup.Blog;
using MediatR;

namespace DotNet8.VerticalSlice_CqrsExample.Api.Features.Blog.Queries.GetBlogList
{
    public class GetBlogListQueryHandler : IRequestHandler<GetBlogListQuery, BlogListResponseModel>
    {
        private readonly IBlogRepository _blogRepository;

        public GetBlogListQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<BlogListResponseModel> Handle(GetBlogListQuery request, CancellationToken cancellationToken)
        {
            return await _blogRepository.GetBlogsAsync();
        }
    }
}