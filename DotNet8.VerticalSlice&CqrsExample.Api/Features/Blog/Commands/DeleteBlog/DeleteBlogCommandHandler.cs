using DotNet8.VerticalSlice_CqrsExample.Api.Repositories.Blog;
using MediatR;

namespace DotNet8.VerticalSlice_CqrsExample.Api.Features.Blog.Commands.DeleteBlog
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, int>
    {
        private readonly IBlogRepository _blogRepository;

        public DeleteBlogCommandHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<int> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            if (request.BlogId <= 0)
                throw new Exception("Id is invalid,");

            return await _blogRepository.DeleteBlogAsync(request.BlogId);
        }
    }
}
