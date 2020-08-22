using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface ITravelUtilityQueryRepository
    {
        ResponseModel AddUpdateTravelUtilityQuery(TravelUtilityQuery obj);

        ResponseModel GetAllTravelUtilityQuery();

        ResponseModel deleteTravelUtilityQuery(int? Id);
        ResponseModel GetTravelUtilityQueryDetailById(int? Id);
        
    }
}

