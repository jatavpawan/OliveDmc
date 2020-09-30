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
                        BlogObj.Category = obj.Category;
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
                                Category = obj.Category,
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
                                        Category = blog.Category,
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
                                    Category = blog.Category,
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
                                    Category = blog.Category,
                                    Status = blog.Status,
                                    ApprovalStatus = blog.ApprovalStatus,
                                    CreatedBy = blog.CreatedBy,
                                    CreatedDate = blog.CreatedDate,
                                    UpdatedBy = blog.UpdatedBy,
                                    UpdatedDate = blog.UpdatedDate,
                                    RecUpd = blog.RecUpd,
                                    CommentCount = Context.BlogComment.Where(z => z.BlogId == blog.Id).Count(),
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

                List<AllBlog> AllBlog = new List<AllBlog>();
                AllBlog = Context.Blog.Where(z => z.Status == true && z.ApprovalStatus == true && z.RecUpd != "D").Select(x => new AllBlog
                {

                    Id = x.Id,
                    UserId = x.UserId,
                    Title = x.Title,
                    FeaturedImage = x.FeaturedImage,
                    Description = x.Description,
                    Status = x.Status,
                    ApprovalStatus = x.ApprovalStatus,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,
                    UpdatedBy = x.UpdatedBy,
                    UpdatedDate = x.UpdatedDate,
                    RecUpd = x.RecUpd,
                    ShortDescription = x.ShortDescription,
                    Category = x.Category,
                    CommentCount = Context.BlogComment.Where(z => z.BlogId == x.Id).Count()

                }).ToList();
               
                var blogList = AllBlog.OrderByDescending(x => x.CreatedDate).Skip(pageNo*4).Take(4);
                if(AllBlog.Count % 4 == 0)
                {
                    blogResponse.totalPage = AllBlog.Count / 4;

                }
                else
                {
                    blogResponse.totalPage = (AllBlog.Count / 4) + 1;

                }
                blogResponse.perPageRecord = 4;
                blogResponse.blogList = blogList;
                blogResponse.totalRecord = AllBlog.Count;
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

        
        public ResponseModel RandomBlogList()
        {
            ResponseModel result = new ResponseModel();

            try
            {
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
                                    Category = blog.Category,
                                    Status = blog.Status,
                                    ApprovalStatus = blog.ApprovalStatus,
                                    RecUpd = blog.RecUpd,
                                    CreatedBy = blog.CreatedBy,
                                    CreatedDate = blog.CreatedDate,
                                    UpdatedBy = blog.UpdatedBy,
                                    UpdatedDate = blog.UpdatedDate,

                                };

                var randomBlogList = innerJoin.Where(z => z.Status == true && z.ApprovalStatus == true && z.RecUpd != "D").OrderBy(x => Guid.NewGuid()).Take(4).ToList();
                //var randomBlogList = Context.Blog.Where(z => z.Status == true && z.ApprovalStatus == true && z.RecUpd != "D").Take(4).ToList();

                result.data = randomBlogList;
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


        public ResponseModel RandomBlogListInDetail()
        {
            ResponseModel result = new ResponseModel();

            try
            {
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
                                    Category = blog.Category,
                                    Status = blog.Status,
                                    ApprovalStatus = blog.ApprovalStatus,
                                    RecUpd = blog.RecUpd,
                                    CreatedBy = blog.CreatedBy,
                                    CreatedDate = blog.CreatedDate,
                                    UpdatedBy = blog.UpdatedBy,
                                    UpdatedDate = blog.UpdatedDate,

                                };

                var randomBlogList = innerJoin.Where(z => z.Status == true && z.ApprovalStatus == true && z.RecUpd != "D").OrderBy(x => Guid.NewGuid()).Take(6).ToList();
                //var randomBlogList = Context.Blog.Where(z => z.Status == true && z.ApprovalStatus == true && z.RecUpd != "D").Take(4).ToList();

                result.data = randomBlogList;
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

        public ResponseModel BlogListByCategoryId(vmCategoriesBlog obj)
        {
            ResponseModel result = new ResponseModel();
            vmAllBlogInUserPanel blogResponse = new vmAllBlogInUserPanel();
            try
            {

                List<AllBlog> AllBlog = new List<AllBlog>();
                AllBlog = Context.Blog.Where(z => z.Status == true && z.ApprovalStatus == true && z.RecUpd != "D" && z.Category == obj.CategoryId).Select(x => new AllBlog
                {

                    Id = x.Id,
                    UserId = x.UserId,
                    Title = x.Title,
                    FeaturedImage = x.FeaturedImage,
                    Description = x.Description,
                    Status = x.Status,
                    ApprovalStatus = x.ApprovalStatus,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,
                    UpdatedBy = x.UpdatedBy,
                    UpdatedDate = x.UpdatedDate,
                    RecUpd = x.RecUpd,
                    ShortDescription = x.ShortDescription,
                    Category = x.Category,
                    CommentCount = Context.BlogComment.Where(z => z.BlogId == x.Id).Count()

                }).ToList();

                var blogList = AllBlog.OrderByDescending(x => x.CreatedDate).Skip(obj.PageNo * 4).Take(4);
                //if (AllBlog.Count % 4 == 0)
                //{
                blogResponse.totalPage = AllBlog.Count % 4 == 0 ?  AllBlog.Count / 4 : (AllBlog.Count / 4) + 1;

                //}
                //else
                //{
                //    blogResponse.totalPage = (AllBlog.Count / 4) + 1;

                //}
                blogResponse.perPageRecord = 4;
                blogResponse.blogList = blogList;
                blogResponse.totalRecord = AllBlog.Count;
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

        public ResponseModel userPostBlog(vmUserPostBlog obj)
        {
            ResponseModel result = new ResponseModel();
            vmUserPostBlogResponse blogResponse = new vmUserPostBlogResponse();
            try
            {

                //vmUserPostBlogList AllBlog = new vmUserPostBlogList();
                var AllBlog = Context.Blog.Where(z => z.UserId == obj.UserId && z.RecUpd != "D").Select(x => new vmUserPostBlogList
                {

                    Id = x.Id,
                    UserId = x.UserId,
                    Title = x.Title,
                    FeaturedImage = x.FeaturedImage,
                    Description = x.Description,
                    Status = x.Status,
                    ApprovalStatus = x.ApprovalStatus,
                    ShortDescription = x.ShortDescription,
                    Category = x.Category,
                    Likecount = Context.BlogReaction.Where(y => y.BlogId == x.Id && y.ReactionStatus == true).Count(),
                    Commentcount = Context.BlogComment.Where(y => y.BlogId == x.Id).Count(),
                    ReactionId = Context.BlogReaction.Where(y => y.BlogId == x.Id && y.UserId == obj.UserId).FirstOrDefault().ReactionId,
                    ReactionStatus = Context.BlogReaction.Where(y => y.BlogId == x.Id && y.UserId == obj.UserId).FirstOrDefault().ReactionStatus,
                    RecUpd = x.RecUpd,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,
                    UpdatedBy = x.UpdatedBy,
                    UpdatedDate = x.UpdatedDate,

                });

                var innerJoin = from blog in AllBlog
                                join reaction in Context.Reaction
                                on blog.ReactionId equals reaction.Id
                                into zG
                                from y2 in zG.DefaultIfEmpty()
                                select new vmUserPostBlogList
                                {
                                    Id = blog.Id,
                                    UserId = blog.UserId,
                                    Title = blog.Title,
                                    FeaturedImage = blog.FeaturedImage,
                                    Description = blog.Description,
                                    Status = blog.Status,
                                    ApprovalStatus = blog.ApprovalStatus,
                                    ShortDescription = blog.ShortDescription,
                                    Category = blog.Category,
                                    Likecount = blog.Likecount,
                                    Commentcount = blog.Commentcount,
                                    ReactionId = blog.ReactionId,
                                    ReactionStatus = blog.ReactionStatus,
                                    ReactionType = y2.Type,
                                    RecUpd = blog.RecUpd,
                                    CreatedBy = blog.CreatedBy,
                                    CreatedDate = blog.CreatedDate,
                                    UpdatedBy = blog.UpdatedBy,
                                    UpdatedDate = blog.UpdatedDate,
                                   
                                };

                var blogList = innerJoin.OrderByDescending(x => x.CreatedDate).Skip(obj.PageNo * 6).Take(6).ToList<vmUserPostBlogList>();
              
                blogResponse.totalPage = AllBlog.ToList().Count % 6 == 0 ? AllBlog.ToList().Count / 6 : (AllBlog.ToList().Count / 6) + 1;

                blogResponse.perPageRecord = 6;
                blogResponse.blogList = blogList;
                blogResponse.totalRecord = AllBlog.ToList().Count;
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


        public ResponseModel userReactOnBlog(BlogReaction obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var BlogReactionObj = Context.BlogReaction.Where(z => z.UserId == obj.UserId && z.BlogId == obj.BlogId).FirstOrDefault();

                if (BlogReactionObj != null)
                {

                    BlogReactionObj.ReactionId = obj.ReactionId;
                    BlogReactionObj.ReactionStatus = obj.ReactionStatus;
                    BlogReactionObj.RecUpd = "U";
                    BlogReactionObj.UpdatedDate = DateTime.Now;
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {

                    var UserBlogReaction = new BlogReaction
                    {
                        UserId = obj.UserId,
                        BlogId = obj.BlogId,
                        ReactionId = obj.ReactionId,
                        ReactionStatus = obj.ReactionStatus,
                        RecUpd = "C",
                        CreatedBy = obj.CreatedBy,
                        CreatedDate = DateTime.Now,
                    };
                    Context.BlogReaction.Add(UserBlogReaction);
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

        public ResponseModel getPopularTag()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var innerJoin = from b in Context.Blog
                                join bc in Context.BlogCategory
                                on b.Category equals bc.Id
                                select new vmPopularTag
                                {
                                    Category = b.Category,
                                    CategoryId = bc.Id,
                                    CategoryName = bc.CategoryName,
                                };

                var PopularTagList = innerJoin.GroupBy(x => new { x.CategoryId, x.CategoryName }, (key, group) => new
                {
                    CategoryId = key.CategoryId,
                    CategoryName = key.CategoryName,
                    PopularCategory = group.Count(),
                    Result = group.ToList()
                }).OrderByDescending(x => x.PopularCategory);

                result.data = PopularTagList;
                result.message = "List For Popular Category Tag";
                result.status = Status.Success;


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
