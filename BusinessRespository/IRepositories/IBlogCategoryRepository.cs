using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
   public interface IBlogCategoryRepository
    {
        ResponseModel AddUpdateBlogCategory(BlogCategory obj);

        ResponseModel GetAllBlogCategory();

        ResponseModel deleteBlogCategory(int? Id);
        ResponseModel GetBlogCategoryById(int? Id);
    }
}
