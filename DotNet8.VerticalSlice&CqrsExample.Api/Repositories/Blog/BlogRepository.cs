using DotNet8.VerticalSlice_CqrsExample.DbService.Entities;
using DotNet8.VerticalSlice_CqrsExample.Models;
using DotNet8.VerticalSlice_CqrsExample.Models.Setup.Blog;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.VerticalSlice_CqrsExample.Api.Repositories.Blog;

public class BlogRepository : IBlogRepository
{
    private readonly AppDbContext _appDbContext;

    public BlogRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    #region Get Blogs Async

    public async Task<BlogListResponseModel> GetBlogsAsync()
    {
        try
        {
            var dataLst = await _appDbContext.TblBlogs
           .AsNoTracking()
           .OrderByDescending(x => x.BlogId)
           .ToListAsync();

            var lst = dataLst.Select(x => x.Change()).ToList();
            BlogListResponseModel responseModel = new()
            {
                DataLst = lst
            };

            return responseModel;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    #endregion

    #region MyRegion

    #endregion
    public async Task<int> CreateBlogAsync(BlogRequestModel requestModel)
    {
        try
        {
            await _appDbContext.TblBlogs.AddAsync(requestModel.Change());
            return await _appDbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<int> DeleteBlogAsync(long id)
    {
        try
        {
            var item = await _appDbContext.TblBlogs
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.BlogId == id)
                ?? throw new ("No data found.");

            _appDbContext.TblBlogs.Remove(item);

            return await _appDbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<BlogModel> GetBlogByIdAsync(long id)
    {
        try
        {
            var item = await _appDbContext.TblBlogs
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.BlogId == id)
                ?? throw new Exception("No data found.");

            return item.Change();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<int> UpdateBlogAsync(BlogRequestModel requestModel, long id)
    {
        try
        {
            var item = await _appDbContext.TblBlogs
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.BlogId == id)
                ?? throw new Exception("Blog Id cannot be empty.");

            if (!string.IsNullOrEmpty(requestModel.BlogTitle))
            {
                item.BlogTitle = requestModel.BlogTitle;
            }

            if (!string.IsNullOrEmpty(requestModel.BlogAuthor))
            {
                item.BlogAuthor = requestModel.BlogAuthor;
            }

            if (!string.IsNullOrEmpty(requestModel.BlogContent))
            {
                item.BlogContent = requestModel.BlogContent;
            }
            _appDbContext.Entry(item).State = EntityState.Modified;

            return await _appDbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}