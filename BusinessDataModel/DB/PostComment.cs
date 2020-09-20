using System;
using System.Collections.Generic;

namespace BusinessDataModel.DB
{
    public partial class PostComment
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? PostId { get; set; }
        public string Comment { get; set; }
        public string RecUpd { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UserReactionId { get; set; }
    }
}
