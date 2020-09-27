using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface IAreaOfExpertiseRepository
    {
        ResponseModel AddUpdateAreaOfExpertise(AreaOfExpertise obj);

        ResponseModel GetAllAreaOfExpertise();

        ResponseModel deleteAreaOfExpertise(int? Id);
        ResponseModel GetAreaOfExpertiseById(int? Id);
    }
}
