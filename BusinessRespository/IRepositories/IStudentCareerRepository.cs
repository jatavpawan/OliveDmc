using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
   public interface IStudentCareerRepository
    {
        ResponseModel AddUpdateStudentCareer(StudentCareer obj);

        ResponseModel GetAllStudentCareer();

        ResponseModel deleteStudentCareer(int? Id);
        ResponseModel GetStudentCareerById(int? Id);
    }
}
