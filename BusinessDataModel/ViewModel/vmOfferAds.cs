using BusinessDataModel.DB;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDataModel.ViewModel
{
    public partial class vmOfferAds
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IFormFile Image { get; set; }
        public string PageId { get; set; }
        public bool? ShowInFrontEnd { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }


    public partial class vmGetAllOfferAds
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string PageId { get; set; }

        public List<Page> Pages { get; set; }
        public bool? ShowInFrontEnd { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public partial class vmPageNameList
    {
        public string pageName { get; set; }
        
    }
}
