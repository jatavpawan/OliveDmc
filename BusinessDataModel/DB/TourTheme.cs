using System;
using System.Collections.Generic;

namespace BusinessDataModel.DB
{
    public partial class TourTheme
    {
        public int Id { get; set; }
        public string ThemeName { get; set; }
        public string FeaturedImage { get; set; }
        public string Description { get; set; }
        public bool? Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string RecUpd { get; set; }
        public string Video { get; set; }
        public string ShortDescription { get; set; }
    }
}
