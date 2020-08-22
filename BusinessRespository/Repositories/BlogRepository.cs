using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using BusinessRespository.IRepositories;
using BusinessRespository.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRespository.Repositories
{
    class BlogRepository : IBlogRepository
    {
        private TravelOliveContext Context;

        public BlogRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

            public ResponseModel AddUpdateBlog(vmBlog obj)
            {
                ResponseModel result = new ResponseModel();
                try
                {
                    string FeaturedImage = string.Empty;
                    if (obj.FeaturedImage != null || obj.FeaturedImage != null || obj.FeaturedImage != null || obj.FeaturedImage != null)
                    {
                        var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                        FeaturedImage = obj.FeaturedImage != null ? prefixpath + "_" + obj.FeaturedImage.FileName : null;

                        FileUploadcls uploadcls = new FileUploadcls();
                        if (obj.FeaturedImage != null) uploadcls.fileUpload(obj.FeaturedImage, @"Uploads\Blog\image", FeaturedImage);

                    }

                    if (obj.Id > 0)
                    {
                        var BlogObj = Context.Blog.Where(z => z.Id == obj.Id).FirstOrDefault();
                        BlogObj.UserId = obj.UserId;
                        BlogObj.Title = obj.Title;
                        BlogObj.Description = obj.Description;
                        BlogObj.ShortDescription = obj.ShortDescription;
                    BlogObj.Status = obj.Status;
                        BlogObj.ApprovalStatus = obj.ApprovalStatus;
                    BlogObj.RecUpd = "U";
                        
                        BlogObj.UpdatedBy = obj.UpdatedBy;
                        BlogObj.UpdatedDate = DateTime.Now;
                        if (obj.FeaturedImage != null)
                        {
                            FileUploadcls uploadcls = new FileUploadcls();
                            uploadcls.fileDeleted(@"Uploads\Blog\image", BlogObj.FeaturedImage);
                            BlogObj.FeaturedImage = FeaturedImage;
                        }
                        Context.SaveChanges();
                        result.message = "Successfully Updated";
                        result.status = Status.Success;

                    }
                    else
                    {

                        //var result1 = Context.Blog.Where(z => z.BlogName == obj.BlogName).Any();


                        //if (!Context.Blog.Where(z => z.Title == obj.Title && z.RecUpd != "D").Any())
                        //{
                            var BlogDetail = new Blog
                            {
                                UserId = obj.UserId,
                                Title = obj.Title,
                                ShortDescription = obj.ShortDescription,
                                Description = obj.Description,
                                Status = obj.Status,
                                ApprovalStatus = obj.ApprovalStatus,
                                RecUpd = "C",
                                CreatedBy = obj.CreatedBy,
                                CreatedDate = DateTime.Now,
                                FeaturedImage = FeaturedImage
                            };
                    
                            Context.Blog.Add(BlogDetail);
                            Context.SaveChanges();
                            result.message = "Successfully Saved";
                            result.status = Status.Success;
                        //}
                        //else
                        //{
                        //    result.message = "Record already Exists";
                        //    result.status = Status.Warning;
                        //}

                    }

                }
                catch (Exception ex)
                {
                    result.status = Status.Error;
                    result.error = ex.Message;
                }
                return result;
            }


            public ResponseModel GetAllBlog()
            {
                ResponseModel result = new ResponseModel();
                try
                {
                    List<Blog> resultValue = new List<Blog>();
                    resultValue = Context.Blog.Where(z => z.RecUpd != "D").OrderByDescending(x => x.CreatedDate).ToList();

                    result.data = resultValue;
                    result.status = Status.Success;
                    result.message = "List for Blog";
                }
                catch (Exception ex)
                {
                    result.status = Status.Error;
                    result.error = ex.Message;

                }
                return result;
            }


            public ResponseModel deleteBlog(int? Id)
            {
                ResponseModel result = new ResponseModel();
                try
                {
                    List<Blog> lst = new List<Blog>();
                    if (Id > 0)
                    {
                        var BlogDetail = Context.Blog.Where(z => z.Id == Id).FirstOrDefault();
                        //FileUploadcls uploadcls = new FileUploadcls();
                        //uploadcls.fileDeleted(@"Uploads\Blog\image", BlogDetail.FeaturedImage);
                        BlogDetail.RecUpd = "D";
                        //Context.Blog.Remove(BlogDetail);
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

            public string fileUploadInBlog(vmfileInfo obj)
            {

                string imageFile = string.Empty;
                if (obj.fileInfo != null)
                {
                    imageFile = obj.fileInfo != null ? obj.fileInfo.FileName : null;

                    FileUploadcls uploadcls = new FileUploadcls();
                    if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\Blog\image", imageFile);

                }

                return imageFile;
            }

        
        public ResponseModel GetBlogDetailByBlogId(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                //var BlogDetail = new Blog();
                //List<vmBlogDetail> resultValue = new List<vmBlogDetail>();
                vmBlogDetail resultValue = new vmBlogDetail();

                if (Id > 0)
                {
                    //BlogDetail = Context.Blog.Where(z => z.Id == Id).FirstOrDefault();



                   var innerJoin = from blog in Context.Blog
                                    join reg in Context.Registration
                                    on blog.UserId equals reg.Id
                                    select new vmBlogDetail
                                    {
                                        Id = blog.Id,
                                        UserId = blog.UserId,
                                        FirstName = reg.FirstName, 
                                        LastName = reg.LastName,
                                        Title = blog.Title,
                                        FeaturedImage = blog.FeaturedImage,
                                        ShortDescription = blog.ShortDescription,
                                        Description = blog.Description,
                                        Status = blog.Status,
                                        ApprovalStatus = blog.ApprovalStatus,
                                        CreatedBy = blog.CreatedBy,
                                        CreatedDate = blog.CreatedDate,
                                        UpdatedBy = blog.UpdatedBy,
                                        UpdatedDate = blog.UpdatedDate,
                                        
                                    };

                    //resultValue = innerJoin.ToList<vmBlogDetail>();
                    resultValue = innerJoin.Where(x => x.Id == Id).FirstOrDefault();
                }

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "Blog Detail";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }
        

        public ResponseModel setBlogPriority(List<BlogPriority> obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var BlogPriorityList = Context.BlogPriority.ToList();

                if(BlogPriorityList != null)
                {
                    Context.BlogPriority.RemoveRange(BlogPriorityList);
                    Context.SaveChanges();
                }

                foreach (BlogPriority blogPriorityObj in obj)
                {
                    var BlogPriority = new BlogPriority();
                    BlogPriority.BlogId = blogPriorityObj.BlogId;
                    BlogPriority.CreatedDate = DateTime.Now;
                    BlogPriority.CreatedBy = 1;
                    Context.BlogPriority.Add(BlogPriority);
                    Context.SaveChanges();
                }
                
                result.message = "Successfully Added";
                result.status = Status.Success;

               

            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;
            }
            return result;
        }

        public ResponseModel AllBlogPriorityList()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<VmBlogPriority> resultValue = new List<VmBlogPriority>();

                var innerJoin = from blogPriority in Context.BlogPriority
                                join blog in Context.Blog
                                on blogPriority.BlogId equals blog.Id
                                select new VmBlogPriority
                                {
                                    Id = blog.Id,
                                    UserId = blog.UserId,
                                    Title = blog.Title,
                                    FeaturedImage = blog.FeaturedImage,
                                    ShortDescription = blog.ShortDescription,
                                    Description = blog.Description,
                                    Status = blog.Status,
                                    ApprovalStatus = blog.ApprovalStatus,
                                    CreatedBy = blog.CreatedBy,
                                    CreatedDate = blog.CreatedDate,
                                    UpdatedBy = blog.UpdatedBy,
                                    UpdatedDate = blog.UpdatedDate,
                                    RecUpd = blog.RecUpd,
                                };

                resultValue = innerJoin.ToList<VmBlogPriority>();
                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for Blog Priority";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel AllBlogPriorityListInUserPanel()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<VmBlogPriority> resultValue = new List<VmBlogPriority>();

                var innerJoin = from blogPriority in Context.BlogPriority
                                join blog in Context.Blog
                                on blogPriority.BlogId equals blog.Id
                                select new VmBlogPriority
                                {
                                    Id = blog.Id,
                                    UserId = blog.UserId,
                                    Title = blog.Title,
                                    FeaturedImage = blog.FeaturedImage,
                                    ShortDescription = blog.ShortDescription,
                                    Description = blog.Description,
                                    Status = blog.Status,
                                    ApprovalStatus = blog.ApprovalStatus,
                                    CreatedBy = blog.CreatedBy,
                                    CreatedDate = blog.CreatedDate,
                                    UpdatedBy = blog.UpdatedBy,
                                    UpdatedDate = blog.UpdatedDate,
                                    RecUpd = blog.RecUpd,
                                };

                resultValue = innerJoin.Where(z =>  z.Status == true && z.ApprovalStatus == true).OrderByDescending(x => x.CreatedDate).ToList<VmBlogPriority>();
                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for Blog Priority";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }
        public ResponseModel AllBlogInUserPanel(int pageNo)
        {
            ResponseModel result = new ResponseModel();
            vmAllBlogInUserPanel blogResponse = new vmAllBlogInUserPanel();
            try
            {

                List<Blog> resultValue = new List<Blog>();
                resultValue = Context.Blog.Where(z => z.Status == true && z.ApprovalStatus == true && z.RecUpd != "D").OrderByDescending(x => x.CreatedDate).Skip(pageNo*4).Take(4).ToList();
                blogResponse.totalPage = resultValue.Count / 10;
                blogResponse.perPageRecord = 10;
                blogResponse.blogList = resultValue;
                result.data = blogResponse;
                result.status = Status.Success;
                result.message = "List for Blog";
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
