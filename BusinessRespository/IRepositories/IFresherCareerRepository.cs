using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
   public interface IFresherCareerRepository
    {
        ResponseModel AddUpdateFresherCareer(vmFresherCareer obj);

        ResponseModel GetAllFresherCareer();

        ResponseModel deleteFresherCareer(int? Id);
        ResponseModel GetFresherCareerById(int? Id);
    }
}
