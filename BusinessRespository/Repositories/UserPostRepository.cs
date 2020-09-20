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
   class UserPostRepository : IUserPostRepository
    {
        private TravelOliveContext Context;

        public UserPostRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateUserPost(vmUserPost obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                string Image = string.Empty;
                if (obj.Image != null)
                {
                    var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                    Image = obj.Image != null ? prefixpath + "_" + obj.Image.FileName : null;

                    FileUploadcls uploadcls = new FileUploadcls();
                    if (obj.Image != null) uploadcls.fileUpload(obj.Image, @"Uploads\UserPost\image", Image);

                }

                if (obj.Id > 0)
                {
                    var UserPostObj = Context.UserPost.Where(z => z.Id == obj.Id).FirstOrDefault();
                    UserPostObj.Description = obj.Description;
                    UserPostObj.Sharecount = obj.Sharecount;
                    UserPostObj.RecUpd = "U";
                    UserPostObj.Video = obj.Video;
                    UserPostObj.UpdatedBy = obj.UpdatedBy;
                    UserPostObj.UpdatedDate = DateTime.Now;
                    if (obj.Image != null)
                    {
                        FileUploadcls uploadcls = new FileUploadcls();
                        uploadcls.fileDeleted(@"Uploads\UserPost\image", UserPostObj.Image);
                        UserPostObj.Image = Image;
                    }
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {

                    //var result1 = Context.UserPost.Where(z => z.UserPostName == obj.UserPostName).Any();


                       var UserPostDetail = new UserPost
                        {
                            UserId = obj.UserId,
                            Description = obj.Description,
                            Sharecount = 0,
                            RecUpd = "C",
                            Video = obj.Video,
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now,
                            Image = Image
                        };
                        Context.UserPost.Add(UserPostDetail);
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


        public ResponseModel GetAllUserPost()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<UserPost> resultValue = new List<UserPost>();
                resultValue = Context.UserPost.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for UserPost";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteUserPost(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<UserPost> lst = new List<UserPost>();
                if (Id > 0)
                {
                    var UserPostDetail = Context.UserPost.Where(z => z.Id == Id).FirstOrDefault();
                    //FileUploadcls uploadcls = new FileUploadcls();
                    //uploadcls.fileDeleted(@"Uploads\UserPost\image", UserPostDetail.Image);
                    UserPostDetail.RecUpd = "D";
                    //Context.UserPost.Remove(UserPostDetail);
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

        public string fileUploadInUserPost(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                imageFile = obj.fileInfo != null ? obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\UserPost\image", imageFile);

            }

            return imageFile;
        }


        public ResponseModel GetUserPostDetailByUserPostId(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var UserPostDetail = new UserPost();
                if (Id > 0)
                {
                    UserPostDetail = Context.UserPost.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = UserPostDetail;
                result.status = Status.Success;
                result.message = "UserPost Detail";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

        public string videoUploadInUserPost(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                imageFile = obj.fileInfo != null ? prefixpath + "_" + obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\UserPost\Video", imageFile);

            }

            return imageFile;
        }

        public void deleteVideoInUserPost(string oldVideoName)
        {

            if (oldVideoName != string.Empty)
            {

                FileUploadcls uploadcls = new FileUploadcls();
                uploadcls.fileDeleted(@"Uploads\UserPost\Video", oldVideoName);

            }
        }

       
        public ResponseModel GetAllUserPostByUserId(int? userId)
        {
            ResponseModel result = new ResponseModel();
            try
            {


                List<vmUserPostList> resultValue = new List<vmUserPostList>();

                var userPostObj = Context.UserPost.Where(z => z.RecUpd != "D").Select(x => new vmUserPostList
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    ReactionId = Context.PostReaction.Where(y => y.PostId == x.Id && y.UserId == userId).FirstOrDefault().ReactionId,
                    ReactionStatus = Context.PostReaction.Where(y => y.PostId == x.Id && y.UserId == userId).FirstOrDefault().ReactionStatus,
                    Description = x.Description,
                    Image = x.Image,
                    Video = x.Video,
                    Likecount = Context.PostReaction.Where(y => y.PostId == y.Id && y.ReactionStatus == true).Count(),
                    Sharecount = x.Sharecount,
                    RecUpd = x.RecUpd,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,
                    UpdatedBy = x.UpdatedBy,
                    UpdatedDate = x.UpdatedDate,
                });

               var postCommentList = from postcomment in Context.PostComment
                            join userInfo in Context.Registration
                            on postcomment.UserId equals userInfo.Id 
                            select new vmPostCommentList
                            {
                                Id = postcomment.Id,
                                UserId = postcomment.UserId,
                                CommentUserFirstName = userInfo.FirstName,
                                CommentUserLastName = userInfo.LastName,
                                CommentUserProfileImg = userInfo.ProfileImg,
                                ReactionCount = Context.PostCommentReaction.Where(x => x.CommentId == postcomment.Id && x.ReactionStatus == true).Count(),
                                UserCommentReactionId = Context.PostCommentReaction.Where(x => x.CommentId == postcomment.Id && x.UserId == userId).FirstOrDefault().ReactionId,
                                UserCommentReactionStatus = Context.PostCommentReaction.Where(x => x.CommentId == postcomment.Id && x.UserId == userId).FirstOrDefault().ReactionStatus,
                                PostId = postcomment.PostId,
                                Comment = postcomment.Comment,
                                RecUpd = postcomment.RecUpd,
                                CreatedBy = postcomment.CreatedBy,
                                CreatedDate = postcomment.CreatedDate,
                                UpdatedBy = postcomment.UpdatedBy,
                                UpdatedDate = postcomment.UpdatedDate,
                            };

             
                var newPostCommentList = from commentList in postCommentList
                                         join reaction in Context.Reaction
                                         on commentList.UserCommentReactionId equals reaction.Id
                                         into commenReactiontList
                                         from newCommenReactiontList
                                         in commenReactiontList.DefaultIfEmpty()
                                         select new vmPostCommentList
                                         {
                                             Id = commentList.Id,
                                             UserId = commentList.UserId,
                                             CommentUserFirstName = commentList.CommentUserFirstName,
                                             CommentUserLastName = commentList.CommentUserLastName,
                                             //CommentUserName = commentList.CommentUserName,
                                             CommentUserProfileImg = commentList.CommentUserProfileImg,
                                             ReactionCount = commentList.ReactionCount,
                                             UserCommentReactionId = commentList.UserCommentReactionId,
                                             UserCommentReactionStatus = commentList.UserCommentReactionStatus,
                                             UserCommentReactionType = newCommenReactiontList.Type,
                                             PostId = commentList.PostId,
                                             Comment = commentList.Comment,
                                             RecUpd = commentList.RecUpd,
                                             CreatedBy = commentList.CreatedBy,
                                             CreatedDate = commentList.CreatedDate,
                                             UpdatedBy = commentList.UpdatedBy,
                                             UpdatedDate = commentList.UpdatedDate,
                                         };

               var innerJoin = from userPost in userPostObj
                                join userInfo in Context.Registration
                                on userPost.UserId equals userInfo.Id
                                join reaction in Context.Reaction
                                on userPost.ReactionId equals reaction.Id
                                into zG
                                from y2 in zG.DefaultIfEmpty()
                                select new vmUserPostList
                                {
                                    Id = userPost.Id,
                                    UserId = userPost.UserId,
                                    //UserName = userInfo.Name,
                                    UserFirstName = userInfo.FirstName,
                                    UserLastName = userInfo.LastName,
                                    ProfileImg = userInfo.ProfileImg,
                                    ReactionId = userPost.ReactionId,
                                    ReactionStatus = userPost.ReactionStatus,
                                    ReactionType = y2.Type,
                                    Description = userPost.Description,
                                    Image = userPost.Image,
                                    Video = userPost.Video,
                                    Likecount = Context.PostReaction.Where(x => x.PostId == userPost.Id && x.ReactionStatus == true).Count(),
                                    Commentcount = Context.PostComment.Where(x => x.PostId == userPost.Id && x.RecUpd != "D").Count(),
                                    CommentList = newPostCommentList.Where(x => x.PostId == userPost.Id && x.RecUpd != "D").OrderByDescending(x => x.CreatedDate).Take(10).ToList<vmPostCommentList>(),
                                    Sharecount = userPost.Sharecount,
                                    RecUpd = userPost.RecUpd,
                                    CreatedBy = userPost.CreatedBy,
                                    CreatedDate = userPost.CreatedDate,
                                    UpdatedBy = userPost.UpdatedBy,
                                    UpdatedDate = userPost.UpdatedDate,
                                };

                resultValue = innerJoin.Where(z => z.RecUpd != "D").ToList<vmUserPostList>();


                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for User Post";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

        

        public ResponseModel userReactOnPost(vmUserPostReaction obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var PostReactionObj = Context.PostReaction.Where(z => z.UserId == obj.UserId && z.PostId == obj.PostId).FirstOrDefault();

                if (PostReactionObj != null)
                {
                  
                    PostReactionObj.ReactionId = obj.ReactionId;
                    PostReactionObj.ReactionStatus = obj.ReactionStatus;
                    PostReactionObj.RecUpd = "U";
                    PostReactionObj.UpdatedDate = DateTime.Now;
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {

                    var UserPostReaction = new PostReaction
                    {
                        UserId = obj.UserId,
                        PostId = obj.PostId,
                        ReactionId = obj.ReactionId,
                        ReactionStatus = obj.ReactionStatus,
                        RecUpd = "C",
                        CreatedBy = obj.CreatedBy,
                        CreatedDate = DateTime.Now,
                    };
                    Context.PostReaction.Add(UserPostReaction);
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

        public ResponseModel userCommentOnPost(vmPostComment obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var PostCommentObj = Context.PostComment.Where(z => z.UserId == obj.UserId && z.PostId == obj.PostId && z.Id == obj.Id).FirstOrDefault();

                if (PostCommentObj != null)
                {

                    PostCommentObj.Comment = obj.Comment;
                    PostCommentObj.RecUpd = "U";
                    PostCommentObj.UpdatedDate = DateTime.Now;
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {

                    var UserPostComment = new PostComment
                    {
                        UserId = obj.UserId,
                        PostId = obj.PostId,
                        Comment = obj.Comment,
                        RecUpd = "C",
                        CreatedDate = DateTime.Now,
                    };
                    Context.PostComment.Add(UserPostComment);
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

        public ResponseModel reactOnPostComment(vmPostCommentReaction obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var PostCommentReactionObj = Context.PostCommentReaction.Where(z => z.UserId == obj.UserId && z.PostId == obj.PostId && z.CommentId == obj.CommentId).FirstOrDefault();

                if (PostCommentReactionObj != null)
                {

                    PostCommentReactionObj.ReactionId = obj.ReactionId;
                    PostCommentReactionObj.ReactionStatus = obj.ReactionStatus;
                    PostCommentReactionObj.RecUpd = "U";
                    PostCommentReactionObj.UpdatedDate = DateTime.Now;
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {

                    var UserPostCommentReaction = new PostCommentReaction
                    {
                        UserId = obj.UserId,
                        PostId = obj.PostId,
                        CommentId = obj.CommentId,
                        ReactionId = obj.ReactionId,
                        ReactionStatus = obj.ReactionStatus,
                        RecUpd = "C",
                        CreatedBy = obj.CreatedBy,
                        CreatedDate = DateTime.Now,
                    };
                    Context.PostCommentReaction.Add(UserPostCommentReaction);
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

        public ResponseModel GetLoggedInUserPost(int? userId)
        {
            ResponseModel result = new ResponseModel();
            try
            {


                List<vmUserPostList> resultValue = new List<vmUserPostList>();

                var userPostObj = Context.UserPost.Where(z => z.UserId == userId && z.RecUpd != "D").Select(x => new vmUserPostList
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    ReactionId = Context.PostReaction.Where(y => y.PostId == x.Id && y.UserId == userId).FirstOrDefault().ReactionId,
                    ReactionStatus = Context.PostReaction.Where(y => y.PostId == x.Id && y.UserId == userId).FirstOrDefault().ReactionStatus,
                    Description = x.Description,
                    Image = x.Image,
                    Video = x.Video,
                    Likecount = Context.PostReaction.Where(y => y.PostId == y.Id && y.ReactionStatus == true).Count(),
                    Sharecount = x.Sharecount,
                    RecUpd = x.RecUpd,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,
                    UpdatedBy = x.UpdatedBy,
                    UpdatedDate = x.UpdatedDate,
                });

                var postCommentList = from postcomment in Context.PostComment
                                      join userInfo in Context.Registration
                                      on postcomment.UserId equals userInfo.Id
                                      select new vmPostCommentList
                                      {
                                          Id = postcomment.Id,
                                          UserId = postcomment.UserId,
                                          //CommentUserName = userInfo.Name,
                                          CommentUserFirstName = userInfo.FirstName,
                                          CommentUserLastName = userInfo.LastName,
                                          CommentUserProfileImg = userInfo.ProfileImg,
                                          ReactionCount = Context.PostCommentReaction.Where(x => x.CommentId == postcomment.Id && x.ReactionStatus == true).Count(),
                                          UserCommentReactionId = Context.PostCommentReaction.Where(x => x.CommentId == postcomment.Id && x.UserId == userId).FirstOrDefault().ReactionId,
                                          UserCommentReactionStatus = Context.PostCommentReaction.Where(x => x.CommentId == postcomment.Id && x.UserId == userId).FirstOrDefault().ReactionStatus,
                                          PostId = postcomment.PostId,
                                          Comment = postcomment.Comment,
                                          RecUpd = postcomment.RecUpd,
                                          CreatedBy = postcomment.CreatedBy,
                                          CreatedDate = postcomment.CreatedDate,
                                          UpdatedBy = postcomment.UpdatedBy,
                                          UpdatedDate = postcomment.UpdatedDate,
                                      };


                var newPostCommentList = from commentList in postCommentList
                                         join reaction in Context.Reaction
                                         on commentList.UserCommentReactionId equals reaction.Id
                                         into commenReactiontList
                                         from newCommenReactiontList
                                         in commenReactiontList.DefaultIfEmpty()
                                         select new vmPostCommentList
                                         {
                                             Id = commentList.Id,
                                             UserId = commentList.UserId,
                                             //CommentUserName = commentList.CommentUserName,
                                             CommentUserFirstName = commentList.CommentUserFirstName,
                                             CommentUserLastName = commentList.CommentUserLastName,
                                             CommentUserProfileImg = commentList.CommentUserProfileImg,
                                             ReactionCount = commentList.ReactionCount,
                                             UserCommentReactionId = commentList.UserCommentReactionId,
                                             UserCommentReactionStatus = commentList.UserCommentReactionStatus,
                                             UserCommentReactionType = newCommenReactiontList.Type,
                                             PostId = commentList.PostId,
                                             Comment = commentList.Comment,
                                             RecUpd = commentList.RecUpd,
                                             CreatedBy = commentList.CreatedBy,
                                             CreatedDate = commentList.CreatedDate,
                                             UpdatedBy = commentList.UpdatedBy,
                                             UpdatedDate = commentList.UpdatedDate,
                                         };

                var innerJoin = from userPost in userPostObj
                                join userInfo in Context.Registration
                                on userPost.UserId equals userInfo.Id
                                join reaction in Context.Reaction
                                on userPost.ReactionId equals reaction.Id
                                into zG
                                from y2 in zG.DefaultIfEmpty()
                                select new vmUserPostList
                                {
                                    Id = userPost.Id,
                                    UserId = userPost.UserId,
                                    //UserName = userInfo.Name,
                                    UserFirstName = userInfo.FirstName,
                                    UserLastName = userInfo.LastName,
                                    ProfileImg = userInfo.ProfileImg,
                                    ReactionId = userPost.ReactionId,
                                    ReactionStatus = userPost.ReactionStatus,
                                    ReactionType = y2.Type,
                                    Description = userPost.Description,
                                    Image = userPost.Image,
                                    Video = userPost.Video,
                                    Likecount = Context.PostReaction.Where(x => x.PostId == userPost.Id && x.ReactionStatus == true).Count(),
                                    Commentcount = Context.PostComment.Where(x => x.PostId == userPost.Id && x.RecUpd != "D").Count(),
                                    CommentList = newPostCommentList.Where(x => x.PostId == userPost.Id && x.RecUpd != "D").OrderByDescending(x => x.CreatedDate).Take(10).ToList<vmPostCommentList>(),
                                    Sharecount = userPost.Sharecount,
                                    RecUpd = userPost.RecUpd,
                                    CreatedBy = userPost.CreatedBy,
                                    CreatedDate = userPost.CreatedDate,
                                    UpdatedBy = userPost.UpdatedBy,
                                    UpdatedDate = userPost.UpdatedDate,
                                };

                resultValue = innerJoin.Where(z => z.RecUpd != "D").ToList<vmUserPostList>();


                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for User Post";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

        public ResponseModel GetLoggedInUserFriendPost(int? userId)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<vmUserPostList> resultValue = new List<vmUserPostList>();

                var friendPostObj = Context.userFriendPost(userId);

                var userPostObj = friendPostObj.Where(z => z.UserId == userId && z.RecUpd != "D").Select(x => new vmUserPostList
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    ReactionId = Context.PostReaction.Where(y => y.PostId == x.Id && y.UserId == userId).FirstOrDefault().ReactionId,
                    ReactionStatus = Context.PostReaction.Where(y => y.PostId == x.Id && y.UserId == userId).FirstOrDefault().ReactionStatus,
                    Description = x.Description,
                    Image = x.Image,
                    Video = x.Video,
                    Likecount = Context.PostReaction.Where(y => y.PostId == y.Id && y.ReactionStatus == true).Count(),
                    Sharecount = x.Sharecount,
                    RecUpd = x.RecUpd,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,
                    UpdatedBy = x.UpdatedBy,
                    UpdatedDate = x.UpdatedDate,
                });

                var postCommentList = from postcomment in Context.PostComment
                                      join userInfo in Context.Registration
                                      on postcomment.UserId equals userInfo.Id
                                      select new vmPostCommentList
                                      {
                                          Id = postcomment.Id,
                                          UserId = postcomment.UserId,
                                          //CommentUserName = userInfo.Name,
                                          CommentUserFirstName = userInfo.FirstName,
                                          CommentUserLastName = userInfo.LastName,
                                          CommentUserProfileImg = userInfo.ProfileImg,
                                          ReactionCount = Context.PostCommentReaction.Where(x => x.CommentId == postcomment.Id && x.ReactionStatus == true).Count(),
                                          UserCommentReactionId = Context.PostCommentReaction.Where(x => x.CommentId == postcomment.Id && x.UserId == userId).FirstOrDefault().ReactionId,
                                          UserCommentReactionStatus = Context.PostCommentReaction.Where(x => x.CommentId == postcomment.Id && x.UserId == userId).FirstOrDefault().ReactionStatus,
                                          PostId = postcomment.PostId,
                                          Comment = postcomment.Comment,
                                          RecUpd = postcomment.RecUpd,
                                          CreatedBy = postcomment.CreatedBy,
                                          CreatedDate = postcomment.CreatedDate,
                                          UpdatedBy = postcomment.UpdatedBy,
                                          UpdatedDate = postcomment.UpdatedDate,
                                      };


                var newPostCommentList = from commentList in postCommentList
                                         join reaction in Context.Reaction
                                         on commentList.UserCommentReactionId equals reaction.Id
                                         into commenReactiontList
                                         from newCommenReactiontList
                                         in commenReactiontList.DefaultIfEmpty()
                                         select new vmPostCommentList
                                         {
                                             Id = commentList.Id,
                                             UserId = commentList.UserId,
                                             //CommentUserName = commentList.CommentUserName,
                                             CommentUserFirstName = commentList.CommentUserFirstName,
                                             CommentUserLastName = commentList.CommentUserLastName,
                                             CommentUserProfileImg = commentList.CommentUserProfileImg,
                                             ReactionCount = commentList.ReactionCount,
                                             UserCommentReactionId = commentList.UserCommentReactionId,
                                             UserCommentReactionStatus = commentList.UserCommentReactionStatus,
                                             UserCommentReactionType = newCommenReactiontList.Type,
                                             PostId = commentList.PostId,
                                             Comment = commentList.Comment,
                                             RecUpd = commentList.RecUpd,
                                             CreatedBy = commentList.CreatedBy,
                                             CreatedDate = commentList.CreatedDate,
                                             UpdatedBy = commentList.UpdatedBy,
                                             UpdatedDate = commentList.UpdatedDate,
                                         };

                var innerJoin = from userPost in userPostObj
                                join userInfo in Context.Registration
                                on userPost.UserId equals userInfo.Id
                                //join reaction in Context.Reaction
                                //on userPost.ReactionId equals reaction.Id
                               // into zG
                              //  from y2 in zG.DefaultIfEmpty()
                                select new vmUserPostList
                                {
                                    Id = userPost.Id,
                                    UserId = userPost.UserId,
                                    //UserName = userInfo.Name,
                                    UserFirstName = userInfo.FirstName,
                                    UserLastName = userInfo.LastName,
                                    ProfileImg = userInfo.ProfileImg,
                                    ReactionId = userPost.ReactionId,
                                    ReactionStatus = userPost.ReactionStatus,
                                   // ReactionType = y2.Type,
                                    Description = userPost.Description,
                                    Image = userPost.Image,
                                    Video = userPost.Video,
                                    Likecount = Context.PostReaction.Where(x => x.PostId == userPost.Id && x.ReactionStatus == true).Count(),
                                    Commentcount = Context.PostComment.Where(x => x.PostId == userPost.Id && x.RecUpd != "D").Count(),
                                    CommentList = newPostCommentList.Where(x => x.PostId == userPost.Id && x.RecUpd != "D").OrderByDescending(x => x.CreatedDate).Take(10).ToList<vmPostCommentList>(),
                                    Sharecount = userPost.Sharecount,
                                    RecUpd = userPost.RecUpd,
                                    CreatedBy = userPost.CreatedBy,
                                    CreatedDate = userPost.CreatedDate,
                                    UpdatedBy = userPost.UpdatedBy,
                                    UpdatedDate = userPost.UpdatedDate,
                                };

                resultValue = innerJoin.Where(z => z.RecUpd != "D").ToList<vmUserPostList>();


                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for User Post";
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
