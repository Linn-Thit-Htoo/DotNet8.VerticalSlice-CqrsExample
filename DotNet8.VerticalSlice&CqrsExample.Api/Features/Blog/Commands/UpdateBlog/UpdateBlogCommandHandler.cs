using DotNet8.VerticalSlice_CqrsExample.Api.Repositories.Blog;
using MediatR;

namespace DotNet8.VerticalSlice_CqrsExample.Api.Features.Blog.Commands.UpdateBlog;

public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, int>
{
    private readonly IBlogRepository _blogRepository;

    public UpdateBlogCommandHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        if (request.BlogId <= 0)
            throw new Exception("Blog Id cannot be empty.");

        return await _blogRepository.UpdateBlogAsync(request.BlogRequestModel, request.BlogId);
    }
}