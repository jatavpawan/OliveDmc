using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface IUtilityRepository
    {
        ResponseModel AddUpdateUtility(vmUtility obj);

        ResponseModel GetAllUtility();

        ResponseModel deleteUtility(int? Id);
        string fileUploadInUtility(vmfileInfo obj);
        ResponseModel getUtilityDetailByUtilityType(string UtilityType);
        string videoUploadInUtility(vmfileInfo obj);
        void deleteVideoInUtility(string oldVideoName);

        
    }
}
