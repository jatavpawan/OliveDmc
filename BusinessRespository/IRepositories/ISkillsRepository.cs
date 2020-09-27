using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface ISkillsRepository
    {
        ResponseModel AddUpdateSkills(Skills obj);

        ResponseModel GetAllSkills();

        ResponseModel deleteSkills(int? Id);
        ResponseModel GetSkillsById(int? Id);
    }
}
