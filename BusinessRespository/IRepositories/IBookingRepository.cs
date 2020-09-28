using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface IBookingRepository
    {
        List<string> GetCityList(vmPredictCity obj);
 
    }
}
