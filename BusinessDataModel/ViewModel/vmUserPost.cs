using BusinessDataModel.DB;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDataModel.ViewModel
{
  
    public partial class vmUserPost
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public string Video { get; set; }
        public int? Likecount { get; set; }
        public int? Sharecount { get; set; }
        public string RecUpd { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }


    public partial class vmUserPostList
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        //public string UserName { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string ProfileImg { get; set; }

        public string Description { get; set; }
        public string Image { get; set; }
        public string Video { get; set; }
        public int? Likecount { get; set; }
        public int? Sharecount { get; set; }
        public int? Commentcount { get; set; }
        public List<vmPostCommentList> CommentList { get; set; }

        public int? ReactionId { get; set; }
        public string ReactionType { get; set; }
        public bool? ReactionStatus { get; set; }


        public string RecUpd { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public partial class vmUserPostReaction
    {
        public int? UserId { get; set; }
        public int? PostId { get; set; }
        public int? ReactionId { get; set; }
        public bool? ReactionStatus { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }


    public partial class vmPostComment
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? PostId { get; set; }
        public string Comment { get; set; }
       
    }

    public partial class vmPostCommentList
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        //public string CommentUserName { get; set; }
        public string CommentUserFirstName { get; set; }
        public string CommentUserLastName { get; set; }
        public string CommentUserProfileImg { get; set; }
        public int? PostId { get; set; }
        public string Comment { get; set; }
        public int?  ReactionCount { get; set; }
        public int? UserCommentReactionId { get; set; }
        public string UserCommentReactionType { get; set; }
        public bool? UserCommentReactionStatus { get; set; }
        public string RecUpd { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }

    public partial class vmPostCommentReaction
    {
        public int? UserId { get; set; }
        public int? PostId { get; set; }
        public int? CommentId { get; set; }
        public int? ReactionId { get; set; }
        public bool? ReactionStatus { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }


    public partial class vmUserFriendPost
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Video { get; set; }
        public int? Sharecount { get; set; }
        public string RecUpd { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }




    }



}
