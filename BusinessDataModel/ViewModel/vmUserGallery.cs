using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDataModel.ViewModel
{   
    public partial class vmUserGallery
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Title { get; set; }
        public List<IFormFile> Gallery { get; set; }

        //public List<IFormFile> Image { get; set; }
        public List<string> Video { get; set; }
        //public List<IFormFile> Gallery { get; set; }
        //public IFormFileCollection Gallery { get; set; }
        //public IFormFile[] Gallery { get; set; }
        public int? LikeCount { get; set; }
        public string RecUpd { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }


  
    public partial class vmUserGalleryList
    {

        public int Id { get; set; }
        public int? UserId { get; set; }
        //public string UserName { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string ProfileImg { get; set; }

        public string Title { get; set; }
        public string Gallery { get; set; }

        //public string Image { get; set; }
        public string Video { get; set; }

        public int? Likecount { get; set; }
        public int? Sharecount { get; set; }
        public int? Commentcount { get; set; }
        public List<vmGalleryCommentList> CommentList { get; set; }

        public int? ReactionId { get; set; }
        public string ReactionType { get; set; }
        public bool? ReactionStatus { get; set; }


        public string RecUpd { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public partial class vmUserGalleryReaction
    {
        public int? UserId { get; set; }
        public int? GalleryId { get; set; }
        public int? ReactionId { get; set; }
        public bool? ReactionStatus { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }


    public partial class vmGalleryComment
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? GalleryId { get; set; }
        public string Comment { get; set; }

    }

    public partial class vmGalleryCommentList
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        //public string CommentUserName { get; set; }
        public string CommentUserFirstName { get; set; }
        public string CommentUserLastName { get; set; }
        public string CommentUserProfileImg { get; set; }
        public int? GalleryId { get; set; }
        public string Comment { get; set; }
        public int? ReactionCount { get; set; }
        public int? UserCommentReactionId { get; set; }
        public string UserCommentReactionType { get; set; }
        public bool? UserCommentReactionStatus { get; set; }
        public string RecUpd { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }


    public partial class vmGalleryCommentReaction
    {
        public int? UserId { get; set; }
        public int? GalleryId { get; set; }
        public int? CommentId { get; set; }
        public int? ReactionId { get; set; }
        public bool? ReactionStatus { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
