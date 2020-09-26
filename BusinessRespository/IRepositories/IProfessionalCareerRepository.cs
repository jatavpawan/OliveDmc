using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
   public interface IProfessionalCareerRepository
    {
        ResponseModel AddUpdateProfessionalCareer(vmProfessionalCareer obj);

        ResponseModel GetAllProfessionalCareer();

        ResponseModel deleteProfessionalCareer(int? Id);
        ResponseModel GetProfessionalCareerById(int? Id);
    }
}
