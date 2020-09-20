using System;
using System.Collections.Generic;

namespace BusinessDataModel.DB
{
    public partial class UserFriendsRequest
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? RequestFriendId { get; set; }
        public string Status { get; set; }
        public string RecUpd { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }


    public partial class vmcancelSendFriendRequest
    {
        public int? UserId { get; set; }
        public int? SendRequestFriendId { get; set; }
    }

    public partial class vmUnFriend
    {
        public int? UserId { get; set; }
        public int? FriendId { get; set; }
    }

}
