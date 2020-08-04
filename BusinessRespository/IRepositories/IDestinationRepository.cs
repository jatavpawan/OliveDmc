using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface IDestinationRepository
    {
        ResponseModel AddUpdateDestinationInCountry(Destination obj);

        ResponseModel GetCountryInfoByCountryCode(string countryCode);
        ResponseModel deleteCountryInfoById(int? Id);

        ResponseModel GetAllDestinationCountry();
        string fileUploadInDestination(vmfileInfo obj);
        string videoUploadInDestination(vmfileInfo obj);

    }
}
