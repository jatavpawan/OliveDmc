﻿using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface ISkillsService
    {
        ResponseModel AddUpdateSkills(Skills obj);

        ResponseModel GetAllSkills();
        ResponseModel deleteSkills(int? Id);
        ResponseModel GetSkillsById(int? Id);
    }
}