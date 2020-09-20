using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    
    public interface IBlogCategoryService
    {
        ResponseModel AddUpdateBlogCategory(BlogCategory obj);

        ResponseModel GetAllBlogCategory();
        ResponseModel deleteBlogCategory(int? Id);
        ResponseModel GetBlogCategoryById(int? Id);
    }
}
