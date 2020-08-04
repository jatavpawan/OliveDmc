using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface ITopDestinationRepository
    {
        ResponseModel AddUpdateTopDestination(VmTopDestination obj);

        ResponseModel GetAllTopDestination();

        ResponseModel deleteTopDestination(int? Id);
        string fileUploadInTopDestination(vmfileInfo obj);
        ResponseModel GetTopDestinationDetailByTopDestinationId(int? Id);
        string videoUploadInTopDestination(vmfileInfo obj);
        void deleteVideoInTopDestination(string oldVideoName);

        ResponseModel GetTopDestinationByCountryId(int? CountryId);
    }
}
