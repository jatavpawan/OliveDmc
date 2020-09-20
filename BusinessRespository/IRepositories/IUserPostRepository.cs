using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface IUserPostRepository
    {
        ResponseModel AddUpdateUserPost(vmUserPost obj);

        ResponseModel GetAllUserPost();

        ResponseModel deleteUserPost(int? Id);
        string fileUploadInUserPost(vmfileInfo obj);
        ResponseModel GetUserPostDetailByUserPostId(int? Id);
        string videoUploadInUserPost(vmfileInfo obj);
        void deleteVideoInUserPost(string oldVideoName);
        ResponseModel GetAllUserPostByUserId(int? userId);
        ResponseModel userReactOnPost(vmUserPostReaction obj);
        ResponseModel userCommentOnPost(vmPostComment obj);

        ResponseModel reactOnPostComment(vmPostCommentReaction obj);
        ResponseModel GetLoggedInUserPost(int? userId);
        ResponseModel GetLoggedInUserFriendPost(int? userId);
        
    }
}
