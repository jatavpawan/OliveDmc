using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface IUserCoverImageRepository
    {
        ResponseModel AddUpdateUserCoverImage(vmUserCoverImage obj);

        ResponseModel GetAllUserCoverImage();

        ResponseModel deleteUserCoverImage(int? Id);
        ResponseModel GetUserCoverImageByUserId(int? Id);
        
    }
}
