using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDataModel.ViewModel
{
    public partial class vmBlog
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Title { get; set; }
        public IFormFile FeaturedImage { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public int? Category { get; set; }
        public bool? Status { get; set; }
        public bool? ApprovalStatus { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public partial class vmCategoriesBlog
    {
        public int CategoryId { get; set; }
        public int PageNo { get; set; }
   
    }

    public partial class vmUserPostBlog
    {
        public int UserId { get; set; }
        public int PageNo { get; set; }

    }

    public partial class vmUserPostBlogList
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Title { get; set; }
        public string FeaturedImage { get; set; }
        public string Description { get; set; }
        public bool? Status { get; set; }
        public bool? ApprovalStatus { get; set; }

        public string ShortDescription { get; set; }
        public int? Category { get; set; }
        public int? Likecount { get; set; }

        public int? ReactionId { get; set; }
        public string ReactionType { get; set; }
        public bool? ReactionStatus { get; set; }
        public string RecUpd { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
      
      
    }

    public partial class vmPopularTag
    {
        public int? Category { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
       
    }



}
