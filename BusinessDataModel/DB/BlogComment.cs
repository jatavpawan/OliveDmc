using System;
using System.Collections.Generic;

namespace BusinessDataModel.DB
{
    public partial class BlogComment
    {
        public int Id { get; set; }
        public int? BlogId { get; set; }
        public int? UserId { get; set; }
        public string Comment { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string RecUpd { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
