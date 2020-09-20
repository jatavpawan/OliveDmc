using System;
using System.Collections.Generic;

namespace BusinessDataModel.DB
{
    public partial class UserGallery
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Title { get; set; }
        public string Gallery { get; set; }
        public int? LikeCount { get; set; }
        public string RecUpd { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Image { get; set; }
        public string Video { get; set; }
    }
}
