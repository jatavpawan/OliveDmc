﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDataModel.ViewModel
{
    public partial class vmNews
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IFormFile FeaturedImage { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public bool? Status { get; set; }
        public bool? ImageShowInFront { get; set; }
        public bool? VideoShowInFront { get; set; }
        public string Video { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
