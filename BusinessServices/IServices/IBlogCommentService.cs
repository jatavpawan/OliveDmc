using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface IBlogCommentService
    {
        ResponseModel AddUpdateBlogComment(BlogComment obj);

        ResponseModel GetAllBlogComment();
        ResponseModel deleteBlogComment(int? Id);
        ResponseModel GetBlogCommentById(int? Id);
        ResponseModel GetAllBlogCommentByBlogId(int? blogId);


        
    }
}
