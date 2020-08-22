using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface IFestivalRepository
    {
        ResponseModel AddUpdateFestival(vmFestival obj);

        ResponseModel GetAllFestival();

        ResponseModel deleteFestival(int? Id);
        string fileUploadInFestival(vmfileInfo obj);
        ResponseModel GetFestivalDetailByFestivalId(int? Id);
        string videoUploadInFestival(vmfileInfo obj);
        void deleteVideoInFestival(string oldVideoName);

        ResponseModel GetAllFestivainFrontEnd();
    }
}
