using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface IProfileCategoryRepository
    {
        ResponseModel AddUpdateProfileCategory(ProfileCategory obj);

        ResponseModel GetAllProfileCategory();

        ResponseModel deleteProfileCategory(int? Id);
        ResponseModel GetProfileCategoryById(int? Id);
    }
}
