using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface IUserPersonalInfoRepository
    {
        ResponseModel AddUpdateUserPersonalInfo(vmUserPersonalInfo obj);
        ResponseModel GetAllUserPersonalInfo();
        ResponseModel deleteUserPersonalInfo(int? Id);
        ResponseModel GetUserPersonalInfoByUserId(int? Id);
        ResponseModel AddUpdateUserProfileImage(vmUserProfileImage obj);
        ResponseModel AddUpdateUserAboutDescription(vmUserAboutDescription obj);
        ResponseModel AddUpdateUserCoverImage(vmUserCoverImg obj);

    }
}
