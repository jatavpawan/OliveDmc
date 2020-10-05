using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface IBlogService
    {
        ResponseModel AddUpdateBlog(vmBlog obj);

        ResponseModel GetAllBlog();
        ResponseModel deleteBlog(int? Id);
        ResponseModel fileUploadInBlog(vmfileInfo obj);
        ResponseModel GetBlogDetailByBlogId(int? Id);
        ResponseModel setBlogPriority(List<BlogPriority> obj);

        ResponseModel AllBlogPriorityList();
        ResponseModel AllBlogPriorityListInUserPanel();

        ResponseModel AllBlogInUserPanel(int pageNo);
        ResponseModel RandomBlogList();
        ResponseModel RandomBlogListInDetail();

        ResponseModel BlogListByCategoryId(vmCategoriesBlog obj);
        ResponseModel userPostBlog(vmUserPostBlog obj);
        ResponseModel userReactOnBlog(BlogReaction obj);
        ResponseModel getPopularTag();
        ResponseModel searchBlog(vmSearchBlog obj);


        




    }
}
