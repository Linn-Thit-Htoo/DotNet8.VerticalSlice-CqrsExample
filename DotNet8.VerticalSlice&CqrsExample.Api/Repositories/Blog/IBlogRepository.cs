using DotNet8.VerticalSlice_CqrsExample.Models.Setup.Blog;

namespace DotNet8.VerticalSlice_CqrsExample.Api.Repositories.Blog;

public interface IBlogRepository
{
    Task<BlogListResponseModel> GetBlogsAsync();
    Task<BlogModel> GetBlogByIdAsync(long id);
    Task<int> CreateBlogAsync(BlogRequestModel requestModel);
    Task<int> UpdateBlogAsync(BlogRequestModel requestModel, long id);
    Task<int> DeleteBlogAsync(long id);
}