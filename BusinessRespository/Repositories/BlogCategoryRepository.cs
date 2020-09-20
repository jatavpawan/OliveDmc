using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using BusinessRespository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRespository.Repositories
{
    class BlogCategoryRepository : IBlogCategoryRepository
    {
        private TravelOliveContext Context;

        public BlogCategoryRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateBlogCategory(BlogCategory obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                if (obj.Id > 0)
                {
                    var BlogCategoryObj = Context.BlogCategory.Where(z => z.Id == obj.Id).FirstOrDefault();
                    BlogCategoryObj.CategoryName = obj.CategoryName;
                    BlogCategoryObj.RecUpd = "U";

                    BlogCategoryObj.UpdatedBy = obj.UpdatedBy;
                    BlogCategoryObj.UpdatedDate = DateTime.Now;
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {
                    if (!Context.BlogCategory.Where(z => z.CategoryName == obj.CategoryName && z.RecUpd != "D").Any())
                    {
                        var BlogCategoryDetail = new BlogCategory
                        {
                            CategoryName = obj.CategoryName,
                            RecUpd = "C",
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now,
                        };

                        Context.BlogCategory.Add(BlogCategoryDetail);
                        Context.SaveChanges();
                        result.message = "Successfully Saved";
                        result.status = Status.Success;
                    }
                    else
                    {
                        result.message = "Record already Exists";
                        result.status = Status.Warning;
                    }

                }

            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;
            }
            return result;
        }


        public ResponseModel GetAllBlogCategory()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<BlogCategory> resultValue = new List<BlogCategory>();
                resultValue = Context.BlogCategory.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for BlogCategory";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteBlogCategory(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<BlogCategory> lst = new List<BlogCategory>();
                if (Id > 0)
                {
                    var BlogCategoryDetail = Context.BlogCategory.Where(z => z.Id == Id).FirstOrDefault();
                    BlogCategoryDetail.RecUpd = "D";
                    Context.SaveChanges();
                }

                result.data = lst;
                result.status = Status.Success;
                result.message = "delete successfully";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

        public ResponseModel GetBlogCategoryById(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var BlogCategoryObj = new BlogCategory();

                if (Id > 0)
                {
                    BlogCategoryObj = Context.BlogCategory.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = BlogCategoryObj;
                result.status = Status.Success;
                result.message = "BlogCategory Detail";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }
    }
}
