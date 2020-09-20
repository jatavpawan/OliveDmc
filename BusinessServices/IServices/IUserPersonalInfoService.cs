using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{

    public interface IUserPersonalInfoService
    {
        ResponseModel AddUpdateUserPersonalInfo(Registration obj);

        ResponseModel GetAllUserPersonalInfo();
        ResponseModel deleteUserPersonalInfo(int? Id);

        ResponseModel GetUserPersonalInfoByUserId(int? Id);

        ResponseModel AddUpdateUserProfileImage(vmUserProfileImage obj);
        ResponseModel AddUpdateUserAboutDescription(vmUserAboutDescription obj);
        ResponseModel AddUpdateUserCoverImage(vmUserCoverImg obj);

        ResponseModel increamentInVisitCount(int? profleUserId);
    }
}
