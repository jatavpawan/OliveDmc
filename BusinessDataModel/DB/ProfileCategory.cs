using System;
using System.Collections.Generic;

namespace BusinessDataModel.DB
{
    public partial class ProfileCategory
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public string RecUpd { get; set; }
    }
}
