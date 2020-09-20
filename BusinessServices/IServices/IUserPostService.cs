using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface IUserPostService
    {
        ResponseModel AddUpdateUserPost(vmUserPost obj);

        ResponseModel GetAllUserPost();
        ResponseModel deleteUserPost(int? Id);
        ResponseModel fileUploadInUserPost(vmfileInfo obj);

        ResponseModel GetUserPostDetailByUserPostId(int? Id);
        ResponseModel videoUploadInUserPost(vmfileInfo obj);
        ResponseModel deleteVideoInUserPost(string oldVideoName);

        ResponseModel GetAllUserPostByUserId(int? userId);
        ResponseModel userReactOnPost(vmUserPostReaction obj);
        ResponseModel userCommentOnPost(vmPostComment obj);
        ResponseModel reactOnPostComment(vmPostCommentReaction obj);

        ResponseModel GetLoggedInUserPost(int? userId);
        ResponseModel GetLoggedInUserFriendPost(int? userId);

    }
}
