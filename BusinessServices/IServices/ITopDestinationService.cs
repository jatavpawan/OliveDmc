using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface ITopDestinationService
    {
        ResponseModel AddUpdateTopDestination(VmTopDestination obj);

        ResponseModel GetAllTopDestination();
        ResponseModel deleteTopDestination(int? Id);
        ResponseModel fileUploadInTopDestination(vmfileInfo obj);

        ResponseModel GetTopDestinationDetailByTopDestinationId(int? Id);
        ResponseModel videoUploadInTopDestination(vmfileInfo obj);
        ResponseModel deleteVideoInTopDestination(string oldVideoName);
        ResponseModel GetTopDestinationByCountryId(int? CountryId);
    }
}
