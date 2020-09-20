using BusinessDataModel.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface IUserGalleryService
    {
        ResponseModel AddUpdateUserGallery(vmUserGallery obj);

        ResponseModel GetAllUserGallery();
        ResponseModel deleteUserGallery(int? Id);
        ResponseModel GetUserGalleryById(int? Id);
        ResponseModel videoUploadInUserGallery(vmfileInfo obj);
        ResponseModel deleteVideoInUserGallery(string oldVideoName);

        ResponseModel GetAllUserGalleryByUserId(int? userId);
        ResponseModel userReactOnGallery(vmUserGalleryReaction obj);
        ResponseModel userCommentOnGallery(vmGalleryComment obj);

        ResponseModel reactOnGalleryComment(vmGalleryCommentReaction obj);
        ResponseModel GalleryDetailByUserId(int? galleryId);
    }
}
