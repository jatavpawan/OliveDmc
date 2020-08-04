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
        public string Description { get; set; }
        public bool? Status { get; set; }
        public bool? ApprovalStatus { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
