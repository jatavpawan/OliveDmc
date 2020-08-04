using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace BusinessDataModel.ViewModel
{
    public partial class vmTourTheme
    {
        public int? Id { get; set; }
        public string ThemeName { get; set; }
        public IFormFile FeaturedImage { get; set; }
        public string Description { get; set; }
        public bool? Status { get; set; }
        public string Video { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    //public partial class vmDestinationCountry
    //{
    //    public int? Id { get; set; }
    //    public string ThemeName { get; set; }
    //    public IFormFile FeaturedImage { get; set; }
    //    public string Description { get; set; }
    //    public bool? Status { get; set; }
    //    public int? CreatedBy { get; set; }
    //    public DateTime? CreatedDate { get; set; }
    //    public int? UpdatedBy { get; set; }
    //    public DateTime? UpdatedDate { get; set; }
    //}

}
