using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
   public interface IFresherCareerService
    {
        ResponseModel AddUpdateFresherCareer(vmFresherCareer obj);

        ResponseModel GetAllFresherCareer();
        ResponseModel deleteFresherCareer(int? Id);
        ResponseModel GetFresherCareerById(int? Id);
    }
}
