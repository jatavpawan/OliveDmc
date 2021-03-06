﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDataModel.ViewModel
{
    public partial class VmBlogPriority
    {
        //public int Id { get; set; }
        //public int? BlogId { get; set; }
        //public string Title { get; set; }
        //public DateTime? CreatedDate { get; set; }
        //public int? CreatedBy { get; set; }
        //public DateTime? UpdatedDate { get; set; }
        //public int? UpdatedBy { get; set; }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Title { get; set; }
        public string FeaturedImage { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public bool? Status { get; set; }
        public bool? ApprovalStatus { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string RecUpd { get; set; }
    }
}
