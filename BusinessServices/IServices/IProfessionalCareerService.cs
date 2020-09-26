using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
  public interface IProfessionalCareerService
    {
        ResponseModel AddUpdateProfessionalCareer(vmProfessionalCareer obj);

        ResponseModel GetAllProfessionalCareer();
        ResponseModel deleteProfessionalCareer(int? Id);
        ResponseModel GetProfessionalCareerById(int? Id);
    }
}
