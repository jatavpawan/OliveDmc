using System;
using System.Collections.Generic;

namespace BusinessDataModel.DB
{
    public partial class UserCoverImage
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Image { get; set; }
        public string RecUpd { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
