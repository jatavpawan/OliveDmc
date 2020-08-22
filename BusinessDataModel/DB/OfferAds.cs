using System;
using System.Collections.Generic;

namespace BusinessDataModel.DB
{
    public partial class OfferAds
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string RecUpd { get; set; }
        public bool? ShowInFrontEnd { get; set; }
        public string PageId { get; set; }
    }
}
