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
    class UserGalleryRepository : IUserGalleryRepository
    {
        private TravelOliveContext Context;

        public UserGalleryRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateUserGallery(vmUserGallery obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                string Gallery = string.Empty;
               
                if (obj.Id > 0)
                {
                    //if (obj.Gallery != null)
                    //{
                    //    var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                    //    Gallery = obj.Gallery != null ? prefixpath + "_" + obj.Gallery.FileName : null;

                    //    FileUploadcls uploadcls = new FileUploadcls();
                    //    if (obj.Gallery != null) uploadcls.fileUpload(obj.Gallery, @"Uploads\UserGallery\image", Gallery);

                    //}

                    var UserGalleryObj = Context.UserGallery.Where(z => z.Id == obj.Id).FirstOrDefault();
                    UserGalleryObj.Title = obj.Title;
                    UserGalleryObj.LikeCount = 0;
                    UserGalleryObj.RecUpd = "U";
                    UserGalleryObj.UpdatedBy = obj.UpdatedBy;
                    UserGalleryObj.UpdatedDate = DateTime.Now;
                    if (obj.Gallery != null)
                    {
                        FileUploadcls uploadcls = new FileUploadcls();
                        uploadcls.fileDeleted(@"Uploads\UserGallery\image", UserGalleryObj.Gallery);
                        UserGalleryObj.Gallery = Gallery;
                    }

                    //if (obj.Image != null)
                    //{
                    //    FileUploadcls uploadcls = new FileUploadcls();
                    //    uploadcls.fileDeleted(@"Uploads\UserGallery\image", UserGalleryObj.Image);
                    //    UserGalleryObj.Gallery = Gallery;
                    //}

                    if (obj.Video != null)
                    {
                        FileUploadcls uploadcls = new FileUploadcls();
                        uploadcls.fileDeleted(@"Uploads\UserGallery\image", UserGalleryObj.Video);
                        UserGalleryObj.Gallery = Gallery;
                    }

                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {
                    if (obj.Gallery != null) {
                        obj.Gallery.ForEach(item =>
                        {
                            Gallery = string.Empty;
                            if (item != null)
                            {
                                var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                                Gallery = item != null ? prefixpath + "_" + item.FileName : null;

                                FileUploadcls uploadcls = new FileUploadcls();
                                if (item != null) uploadcls.fileUpload(item, @"Uploads\UserGallery\image", Gallery);

                                var UserGalleryDetail = new UserGallery
                                {
                                    UserId = obj.UserId,
                                    Title = obj.Title,
                                    LikeCount = 0,
                                    RecUpd = "C",
                                    CreatedBy = obj.CreatedBy,
                                    CreatedDate = DateTime.Now,
                                    Gallery = Gallery
                                };
                                Context.UserGallery.Add(UserGalleryDetail);
                                Context.SaveChanges();

                            }
                        });

                    }

                    if (obj.Video != null)
                    {
                        obj.Video.ForEach(item =>
                        {
                            if (item != null)
                            {
                                var UserGalleryDetail = new UserGallery
                                {
                                    UserId = obj.UserId,
                                    Title = obj.Title,
                                    LikeCount = 0,
                                    RecUpd = "C",
                                    CreatedBy = obj.CreatedBy,
                                    CreatedDate = DateTime.Now,
                                    Video = item
                                };
                                Context.UserGallery.Add(UserGalleryDetail);
                                Context.SaveChanges();

                            }
                        });

                    }

                    //var UserGalleryDetail = new UserGallery
                    //    {
                    //        UserId = obj.UserId,
                    //        Title = obj.Title,
                    //        LikeCount = 0,
                    //        RecUpd = "C",
                    //        CreatedBy = obj.CreatedBy,
                    //        CreatedDate = DateTime.Now,
                    //        Gallery = Gallery
                    //    };
                    //    Context.UserGallery.Add(UserGalleryDetail);
                    //    Context.SaveChanges();
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


        public ResponseModel GetAllUserGallery()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<UserGallery> resultValue = new List<UserGallery>();
                resultValue = Context.UserGallery.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for UserGallery";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteUserGallery(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<UserGallery> lst = new List<UserGallery>();
                if (Id > 0)
                {
                    var UserGalleryDetail = Context.UserGallery.Where(z => z.Id == Id).FirstOrDefault();
                    //FileUploadcls uploadcls = new FileUploadcls();
                    //uploadcls.fileDeleted(@"Uploads\UserGallery\image", UserGalleryDetail.Gallery);
                    UserGalleryDetail.RecUpd = "D";
                    //Context.UserGallery.Remove(UserGalleryDetail);
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

    
        public ResponseModel GetUserGalleryById(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var UserGalleryDetail = new UserGallery();
                if (Id > 0)
                {
                    UserGalleryDetail = Context.UserGallery.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = UserGalleryDetail;
                result.status = Status.Success;
                result.message = "User Gallery Detail";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

        public string videoUploadInUserGallery(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                imageFile = obj.fileInfo != null ? prefixpath + "_" + obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\UserGallery\Video", imageFile);

            }

            return imageFile;
        }

        public void deleteVideoInUserGallery(string oldVideoName)
        {

            if (oldVideoName != string.Empty)
            {

                FileUploadcls uploadcls = new FileUploadcls();
                uploadcls.fileDeleted(@"Uploads\UserGallery\Video", oldVideoName);

            }
        }

        public ResponseModel GetAllUserGalleryByUserId(int? userId)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<vmUserGalleryList> resultValue = new List<vmUserGalleryList>();

                var userGalleryObj = Context.UserGallery.Where(z => z.RecUpd != "D").Select(x => new vmUserGalleryList
                {
                    Id = x.Id,
                    Title = x.Title,
                    UserId = x.UserId,
                    ReactionId = Context.GalleryReaction.Where(y => y.GalleryId == x.Id && y.UserId == userId).FirstOrDefault().ReactionId,
                    ReactionStatus = Context.GalleryReaction.Where(y => y.GalleryId == x.Id && y.UserId == userId).FirstOrDefault().ReactionStatus,
                    //Image = x.Image,
                    Gallery = x.Gallery,
                    Video = x.Video,
                    Likecount = Context.GalleryReaction.Where(y => y.GalleryId == y.Id && y.ReactionStatus == true).Count(),
                    RecUpd = x.RecUpd,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,
                    UpdatedBy = x.UpdatedBy,
                    UpdatedDate = x.UpdatedDate,
                });

                var galleryCommentList = from gallerycomment in Context.GalleryComment
                                      join userInfo in Context.Registration
                                      on gallerycomment.UserId equals userInfo.Id
                                      select new vmGalleryCommentList
                                      {
                                          Id = gallerycomment.Id,
                                          UserId = gallerycomment.UserId,
                                          //CommentUserName = userInfo.Name,
                                          CommentUserFirstName = userInfo.FirstName,
                                          CommentUserLastName = userInfo.LastName,
                                          CommentUserProfileImg = userInfo.ProfileImg,
                                          ReactionCount = Context.GalleryCommentReaction.Where(x => x.CommentId == gallerycomment.Id && x.ReactionStatus == true).Count(),
                                          UserCommentReactionId = Context.GalleryCommentReaction.Where(x => x.CommentId == gallerycomment.Id && x.UserId == userId).FirstOrDefault().ReactionId,
                                          UserCommentReactionStatus = Context.GalleryCommentReaction.Where(x => x.CommentId == gallerycomment.Id && x.UserId == userId).FirstOrDefault().ReactionStatus,
                                          GalleryId = gallerycomment.GalleryId,
                                          Comment = gallerycomment.Comment,
                                          RecUpd = gallerycomment.RecUpd,
                                          CreatedBy = gallerycomment.CreatedBy,
                                          CreatedDate = gallerycomment.CreatedDate,
                                          UpdatedBy = gallerycomment.UpdatedBy,
                                          UpdatedDate = gallerycomment.UpdatedDate,

                                      };

                var newGalleryCommentList = from commentList in galleryCommentList
                                            join reaction in Context.Reaction
                                         on commentList.UserCommentReactionId equals reaction.Id
                                         into commenReactiontList
                                         from newCommenReactiontList
                                         in commenReactiontList.DefaultIfEmpty()
                                         select new vmGalleryCommentList
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
                                             GalleryId = commentList.GalleryId,
                                             Comment = commentList.Comment,
                                             RecUpd = commentList.RecUpd,
                                             CreatedBy = commentList.CreatedBy,
                                             CreatedDate = commentList.CreatedDate,
                                             UpdatedBy = commentList.UpdatedBy,
                                             UpdatedDate = commentList.UpdatedDate,
                                         };


                var innerJoin = from userGallery in userGalleryObj
                                join userInfo in Context.Registration
                                on userGallery.UserId equals userInfo.Id
                                join reaction in Context.Reaction
                                on userGallery.ReactionId equals reaction.Id
                                into zG
                                from y2 in zG.DefaultIfEmpty()
                                select new vmUserGalleryList
                                {
                                    Id = userGallery.Id,
                                    Title = userGallery.Title,
                                    UserId = userGallery.UserId,
                                    //UserName = userInfo.Name,
                                    UserFirstName = userInfo.FirstName,
                                    UserLastName = userInfo.LastName,
                                    ProfileImg = userInfo.ProfileImg,
                                    ReactionId = userGallery.ReactionId,
                                    ReactionStatus = userGallery.ReactionStatus,
                                    ReactionType = y2.Type,
                                    //Image = userGallery.Image,
                                    Gallery = userGallery.Gallery,
                                    Video = userGallery.Video,
                                    Likecount = Context.GalleryReaction.Where(x => x.GalleryId == userGallery.Id && x.ReactionStatus == true).Count(),
                                    Commentcount = Context.GalleryComment.Where(x => x.GalleryId == userGallery.Id && x.RecUpd != "D").Count(),
                                    CommentList = newGalleryCommentList.Where(x => x.GalleryId == userGallery.Id && x.RecUpd != "D").OrderByDescending(x => x.CreatedDate).Take(10).ToList<vmGalleryCommentList>(),
                                    Sharecount = userGallery.Sharecount,
                                    RecUpd = userGallery.RecUpd,
                                    CreatedBy = userGallery.CreatedBy,
                                    CreatedDate = userGallery.CreatedDate,
                                    UpdatedBy = userGallery.UpdatedBy,
                                    UpdatedDate = userGallery.UpdatedDate,
                                };

                resultValue = innerJoin.Where(z => z.RecUpd != "D" &&  z.UserId == userId).ToList<vmUserGalleryList>();


                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for User Gallery";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }



        public ResponseModel userReactOnGallery(vmUserGalleryReaction obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var GalleryReactionObj = Context.GalleryReaction.Where(z => z.UserId == obj.UserId && z.GalleryId == obj.GalleryId).FirstOrDefault();

                if (GalleryReactionObj != null)
                {

                    GalleryReactionObj.ReactionId = obj.ReactionId;
                    GalleryReactionObj.ReactionStatus = obj.ReactionStatus;
                    GalleryReactionObj.RecUpd = "U";
                    GalleryReactionObj.UpdatedDate = DateTime.Now;
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {

                    var UserGalleryReaction = new GalleryReaction
                    {
                        UserId = obj.UserId,
                        GalleryId = obj.GalleryId,
                        ReactionId = obj.ReactionId,
                        ReactionStatus = obj.ReactionStatus,
                        RecUpd = "C",
                        CreatedBy = obj.CreatedBy,
                        CreatedDate = DateTime.Now,
                    };
                    Context.GalleryReaction.Add(UserGalleryReaction);
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

        public ResponseModel userCommentOnGallery(vmGalleryComment obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var GalleryCommentObj = Context.GalleryComment.Where(z => z.UserId == obj.UserId && z.GalleryId == obj.GalleryId && z.Id == obj.Id).FirstOrDefault();

                if (GalleryCommentObj != null)
                {

                    GalleryCommentObj.Comment = obj.Comment;
                    GalleryCommentObj.RecUpd = "U";
                    GalleryCommentObj.UpdatedDate = DateTime.Now;
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {

                    var UserGalleryComment = new GalleryComment
                    {
                        UserId = obj.UserId,
                        GalleryId = obj.GalleryId,
                        Comment = obj.Comment,
                        RecUpd = "C",
                        CreatedDate = DateTime.Now,
                    };
                    Context.GalleryComment.Add(UserGalleryComment);
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

        public ResponseModel reactOnGalleryComment(vmGalleryCommentReaction obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var GalleryCommentReactionObj = Context.GalleryCommentReaction.Where(z => z.UserId == obj.UserId && z.GalleryId == obj.GalleryId && z.CommentId == obj.CommentId).FirstOrDefault();

                if (GalleryCommentReactionObj != null)
                {

                    GalleryCommentReactionObj.ReactionId = obj.ReactionId;
                    GalleryCommentReactionObj.ReactionStatus = obj.ReactionStatus;
                    GalleryCommentReactionObj.RecUpd = "U";
                    GalleryCommentReactionObj.UpdatedDate = DateTime.Now;
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {

                    var UserGalleryCommentReaction = new GalleryCommentReaction
                    {
                        UserId = obj.UserId,
                        GalleryId = obj.GalleryId,
                        CommentId = obj.CommentId,
                        ReactionId = obj.ReactionId,
                        ReactionStatus = obj.ReactionStatus,
                        RecUpd = "C",
                        CreatedBy = obj.CreatedBy,
                        CreatedDate = DateTime.Now,
                    };
                    Context.GalleryCommentReaction.Add(UserGalleryCommentReaction);
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


        public ResponseModel GalleryDetailByUserId(int? galleryId)
        {
            ResponseModel result = new ResponseModel();
            try
            {

                var userGalleryObj = Context.UserGallery.Where(z => z.RecUpd != "D" && z.Id == galleryId).Select(x => new vmUserGalleryList
                {
                    Id = x.Id,
                    Title = x.Title,
                    UserId = x.UserId,
                    Gallery = x.Gallery,
                    Video = x.Video,
                    Likecount = Context.GalleryReaction.Where(y => y.GalleryId == y.Id && y.ReactionStatus == true).Count(),
                    RecUpd = x.RecUpd,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,
                    UpdatedBy = x.UpdatedBy,
                    UpdatedDate = x.UpdatedDate,
                });

                var galleryCommentList = from gallerycomment in Context.GalleryComment
                                         join userInfo in Context.Registration
                                         on gallerycomment.UserId equals userInfo.Id
                                         select new vmGalleryCommentList
                                         {
                                             Id = gallerycomment.Id,
                                             UserId = gallerycomment.UserId,
                                             //CommentUserName = userInfo.Name,
                                             CommentUserFirstName = userInfo.FirstName,
                                             CommentUserLastName = userInfo.LastName,
                                             CommentUserProfileImg = userInfo.ProfileImg,
                                             ReactionCount = Context.GalleryCommentReaction.Where(x => x.CommentId == gallerycomment.Id && x.ReactionStatus == true).Count(),
                                             UserCommentReactionId = Context.GalleryCommentReaction.Where(x => x.CommentId == gallerycomment.Id).FirstOrDefault().ReactionId,
                                             UserCommentReactionStatus = Context.GalleryCommentReaction.Where(x => x.CommentId == gallerycomment.Id).FirstOrDefault().ReactionStatus,
                                             GalleryId = gallerycomment.GalleryId,
                                             Comment = gallerycomment.Comment,
                                             RecUpd = gallerycomment.RecUpd,
                                             CreatedBy = gallerycomment.CreatedBy,
                                             CreatedDate = gallerycomment.CreatedDate,
                                             UpdatedBy = gallerycomment.UpdatedBy,
                                             UpdatedDate = gallerycomment.UpdatedDate,

                                         };

                var newGalleryCommentList = from commentList in galleryCommentList
                                            join reaction in Context.Reaction
                                         on commentList.UserCommentReactionId equals reaction.Id
                                         into commenReactiontList
                                            from newCommenReactiontList
                                            in commenReactiontList.DefaultIfEmpty()
                                            select new vmGalleryCommentList
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
                                                GalleryId = commentList.GalleryId,
                                                Comment = commentList.Comment,
                                                RecUpd = commentList.RecUpd,
                                                CreatedBy = commentList.CreatedBy,
                                                CreatedDate = commentList.CreatedDate,
                                                UpdatedBy = commentList.UpdatedBy,
                                                UpdatedDate = commentList.UpdatedDate,
                                            };


                var innerJoin = from userGallery in userGalleryObj
                                join userInfo in Context.Registration
                                on userGallery.UserId equals userInfo.Id
                                join reaction in Context.Reaction
                                on userGallery.ReactionId equals reaction.Id
                                into zG
                                from y2 in zG.DefaultIfEmpty()
                                select new vmUserGalleryList
                                {
                                    Id = userGallery.Id,
                                    Title = userGallery.Title,
                                    UserId = userGallery.UserId,
                                    //UserName = userInfo.Name,
                                    UserFirstName = userInfo.FirstName,
                                    UserLastName = userInfo.LastName,
                                    ProfileImg = userInfo.ProfileImg,
                                    ReactionId = userGallery.ReactionId,
                                    ReactionStatus = userGallery.ReactionStatus,
                                    ReactionType = y2.Type,
                                    //Image = userGallery.Image,
                                    Gallery = userGallery.Gallery,
                                    Video = userGallery.Video,
                                    Likecount = Context.GalleryReaction.Where(x => x.GalleryId == userGallery.Id && x.ReactionStatus == true).Count(),
                                    Commentcount = Context.GalleryComment.Where(x => x.GalleryId == userGallery.Id && x.RecUpd != "D").Count(),
                                    CommentList = newGalleryCommentList.Where(x => x.GalleryId == userGallery.Id && x.RecUpd != "D").OrderByDescending(x => x.CreatedDate).Take(10).ToList<vmGalleryCommentList>(),
                                    Sharecount = userGallery.Sharecount,
                                    RecUpd = userGallery.RecUpd,
                                    CreatedBy = userGallery.CreatedBy,
                                    CreatedDate = userGallery.CreatedDate,
                                    UpdatedBy = userGallery.UpdatedBy,
                                    UpdatedDate = userGallery.UpdatedDate,
                                };

                var resultValue = innerJoin.Where(z => z.RecUpd != "D");


                result.data = resultValue;
                result.status = Status.Success;
                result.message = "Gallery Detail";
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
