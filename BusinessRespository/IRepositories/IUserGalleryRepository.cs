using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface IUserGalleryRepository
    {
        ResponseModel AddUpdateUserGallery(vmUserGallery obj);

        ResponseModel GetAllUserGallery();

        ResponseModel deleteUserGallery(int? Id);
        ResponseModel GetUserGalleryById(int? Id);
        string videoUploadInUserGallery(vmfileInfo obj);
        void deleteVideoInUserGallery(string oldVideoName);
     
        ResponseModel GetAllUserGalleryByUserId(int? userId);
        ResponseModel userReactOnGallery(vmUserGalleryReaction obj);
        ResponseModel userCommentOnGallery(vmGalleryComment obj);

        ResponseModel reactOnGalleryComment(vmGalleryCommentReaction obj);
        ResponseModel GalleryDetailByUserId(int? galleryId);

    }
}


