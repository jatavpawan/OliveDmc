using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface IBlogCommentRepository
    {
        ResponseModel AddUpdateBlogComment(BlogComment obj);

        ResponseModel GetAllBlogComment();

        ResponseModel deleteBlogComment(int? Id);
        ResponseModel GetBlogCommentById(int? Id);
        ResponseModel GetAllBlogCommentByBlogId(int? blogId);


        
    }
}
