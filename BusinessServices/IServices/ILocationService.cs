using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface ILocationService
    {
        //-----------------------------Country------------------------------------------
        ResponseModel AddUpdateCountry(Country obj);

        ResponseModel GetAllCountry();
        ResponseModel deleteCountry(int? Id);
        ResponseModel GetCountryDetailByCountryId(int? Id);

        //--------------------------------State-------------------------------------------
        ResponseModel AddUpdateState(State obj);

        ResponseModel GetAllState();
        ResponseModel deleteState(int? Id);
        ResponseModel GetStateDetailByStateId(int? Id);

        //------------------------------------City----------------------------------------

        ResponseModel AddUpdateCity(City obj);

        ResponseModel GetAllCity();
        ResponseModel deleteCity(int? Id);
        ResponseModel GetCityDetailByCityId(int? Id);
        ResponseModel GetStateByCountryId(int? countryId);

        ResponseModel GetCityByStateId(int? stateId);

    }
}
