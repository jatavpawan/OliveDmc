using System;
using System.Collections.Generic;

namespace BusinessDataModel.DB
{
    public partial class BlogPriority
    {
        public int Id { get; set; }
        public int? BlogId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public int? Category { get; set; }
    }
}
