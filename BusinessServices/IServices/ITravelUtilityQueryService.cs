using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface ITravelUtilityQueryService
    {
        ResponseModel AddUpdateTravelUtilityQuery(TravelUtilityQuery obj);

        ResponseModel GetAllTravelUtilityQuery();
        ResponseModel deleteTravelUtilityQuery(int? Id);
        ResponseModel GetTravelUtilityQueryDetailById(int? Id);
        
    }
}
