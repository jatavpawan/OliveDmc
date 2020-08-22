using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface IUserCoverImageService
    {
        ResponseModel AddUpdateUserCoverImage(vmUserCoverImage obj);

        ResponseModel GetAllUserCoverImage();
        ResponseModel deleteUserCoverImage(int? Id);
        ResponseModel GetUserCoverImageByUserId(int? Id);
    }
}
