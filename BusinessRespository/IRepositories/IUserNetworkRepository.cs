﻿using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface IUserNetworkRepository
    {
        ResponseModel AddUpdateUserNetwork(ContactUs obj);

        ResponseModel GetAllUserNetwork();

        ResponseModel deleteUserNetwork(int? Id);
        ResponseModel GetUserNetworkDetailById(int? Id);
        ResponseModel sendFriendRequest(UserFriendsRequest obj);
        ResponseModel getAddFriendRequestList(int? userid);
        ResponseModel actionOnFriendRequest(UserFriendsRequest obj);
        ResponseModel userFriendList(int? userid);
        ResponseModel userPendingRequestList(int? userid);

        ResponseModel GetAllUserInNetwork(int userid);
        ResponseModel cancelSendFriendRequest(vmcancelSendFriendRequest obj);
        ResponseModel unfriend(vmUnFriend obj);

    }
}