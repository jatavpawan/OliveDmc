using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface IUtilityService
    {
        ResponseModel AddUpdateUtility(vmUtility obj);

        ResponseModel GetAllUtility();
        ResponseModel deleteUtility(int? Id);
        ResponseModel fileUploadInUtility(vmfileInfo obj);

        ResponseModel getUtilityDetailByUtilityType(string UtilityType);
        ResponseModel videoUploadInUtility(vmfileInfo obj);
        ResponseModel deleteVideoInUtility(string oldVideoName);
        ResponseModel getUtilityDetailById(int? UtilityId);


    }
}
