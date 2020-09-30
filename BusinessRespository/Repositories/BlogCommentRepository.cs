using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using BusinessRespository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRespository.Repositories
{
    class BlogCommentRepository : IBlogCommentRepository
    {
        private TravelOliveContext Context;

        public BlogCommentRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateBlogComment(BlogComment obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                if (obj.Id > 0)
                {
                    var BlogCommentObj = Context.BlogComment.Where(z => z.Id == obj.Id).FirstOrDefault();
                    BlogCommentObj.BlogId = obj.BlogId;
                    BlogCommentObj.UserId = obj.UserId;
                    BlogCommentObj.Comment = obj.Comment;
                    BlogCommentObj.Name = obj.Name;
                    BlogCommentObj.Email = obj.Email;
                    BlogCommentObj.RecUpd = "U";
                    BlogCommentObj.UpdatedBy = obj.UpdatedBy;
                    BlogCommentObj.UpdatedDate = DateTime.Now;
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {
                 
                        var BlogCommentDetail = new BlogComment
                        {
                            BlogId = obj.BlogId,
                            UserId = obj.UserId,
                            Comment = obj.Comment,
                            Name = obj.Name,
                            Email = obj.Email,
                            RecUpd = "C",
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now,
                        };

                        Context.BlogComment.Add(BlogCommentDetail);
                        Context.SaveChanges();
                        result.message = "Successfully Saved";
                        result.status = Status.Success;
                   
                }

            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;
            }
            return result;
        }


        public ResponseModel GetAllBlogComment()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<BlogComment> resultValue = new List<BlogComment>();
                resultValue = Context.BlogComment.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for BlogComment";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteBlogComment(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<BlogComment> lst = new List<BlogComment>();
                if (Id > 0)
                {
                    var BlogCommentDetail = Context.BlogComment.Where(z => z.Id == Id).FirstOrDefault();
                    BlogCommentDetail.RecUpd = "D";
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

        public ResponseModel GetBlogCommentById(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var BlogCommentObj = new BlogComment();

                if (Id > 0)
                {
                    BlogCommentObj = Context.BlogComment.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = BlogCommentObj;
                result.status = Status.Success;
                result.message = "BlogComment Detail";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

        public ResponseModel GetAllBlogCommentByBlogId(int? blogId)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<BlogComment> BlogCommentList = new List<BlogComment>();

                if (blogId > 0)
                {
                    BlogCommentList = Context.BlogComment.Where(z => z.BlogId == blogId).ToList();
                }

                result.data = BlogCommentList;
                result.status = Status.Success;
                result.message = "Blog Comment List ";
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
