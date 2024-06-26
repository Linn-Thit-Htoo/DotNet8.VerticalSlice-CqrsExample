﻿using DotNet8.VerticalSlice_CqrsExample.DbService.Entities;
using DotNet8.VerticalSlice_CqrsExample.Models.Setup.Blog;

namespace DotNet8.VerticalSlice_CqrsExample.Models;

public static class ChangeModel
{
    #region Blog

    public static BlogModel Change(this TblBlog dataModel)
    {
        return new BlogModel
        {
            BlogId = dataModel.BlogId,
            BlogTitle = dataModel.BlogTitle,
            BlogAuthor = dataModel.BlogAuthor,
            BlogContent = dataModel.BlogContent
        };
    }

    public static TblBlog Change(this BlogRequestModel requestModel)
    {
        return new TblBlog
        {
            BlogTitle = requestModel.BlogTitle!,
            BlogAuthor = requestModel.BlogAuthor!,
            BlogContent = requestModel.BlogContent!
        };
    }

    #endregion
}