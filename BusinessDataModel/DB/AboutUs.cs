using System;
using System.Collections.Generic;

namespace BusinessDataModel.DB
{
    public partial class AboutUs
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool? Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string RecUpd { get; set; }
    }
}
