using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface IFestivalService
    {
        ResponseModel AddUpdateFestival(vmFestival obj);

        ResponseModel GetAllFestival();
        ResponseModel deleteFestival(int? Id);
        ResponseModel fileUploadInFestival(vmfileInfo obj);

        ResponseModel GetFestivalDetailByFestivalId(int? Id);
        ResponseModel videoUploadInFestival(vmfileInfo obj);
        ResponseModel deleteVideoInFestival(string oldVideoName);
        ResponseModel GetAllFestivainFrontEnd();


    }
}
