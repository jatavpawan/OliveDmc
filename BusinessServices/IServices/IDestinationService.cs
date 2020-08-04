using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface IDestinationService
    {
        ResponseModel AddUpdateDestinationInCountry(Destination obj);
        ResponseModel GetCountryInfoByCountryCode(string countryCode);
        ResponseModel deleteCountryInfoById(int? Id);

        ResponseModel GetAllDestinationCountry();
        ResponseModel fileUploadInDestination(vmfileInfo obj);
        ResponseModel videoUploadInDestination(vmfileInfo obj);

    }
}
