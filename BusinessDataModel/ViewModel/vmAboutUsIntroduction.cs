using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDataModel.ViewModel
{
    public partial class vmAboutUsIntroduction
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IFormFile FeaturedImageFirst { get; set; }
        public IFormFile FeaturedImageSecond { get; set; }
        public string Description { get; set; }
        public bool? ShowInFrontEnd { get; set; }
        public string RecUpd { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}

