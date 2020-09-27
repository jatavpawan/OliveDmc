using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDataModel.ViewModel
{
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
