using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface IStudentCareerService
    {
        ResponseModel AddUpdateStudentCareer(StudentCareer obj);

        ResponseModel GetAllStudentCareer();
        ResponseModel deleteStudentCareer(int? Id);
        ResponseModel GetStudentCareerById(int? Id);
    }
}
