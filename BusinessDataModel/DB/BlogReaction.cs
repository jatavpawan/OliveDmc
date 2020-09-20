using System;
using System.Collections.Generic;

namespace BusinessDataModel.DB
{
    public partial class BlogReaction
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? BlogId { get; set; }
        public int? ReactionId { get; set; }
        public bool? ReactionStatus { get; set; }
        public string RecUpd { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
