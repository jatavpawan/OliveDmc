using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface IBookingService
    {
        ResponseModel GetCityList(vmPredictCity vm);

    }
}
