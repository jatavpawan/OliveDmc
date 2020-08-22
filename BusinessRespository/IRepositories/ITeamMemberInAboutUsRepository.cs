using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface ITeamMemberInAboutUsRepository
    {
        ResponseModel AddUpdateTeamMemberInAboutUs(vmTeamMemberInAboutUs obj);

        ResponseModel GetAllTeamMemberInAboutUs();

        ResponseModel deleteTeamMemberInAboutUs(int? Id);
        string fileUploadInTeamMemberInAboutUs(vmfileInfo obj);
        ResponseModel GetTeamMemberInAboutUsDetailByTeamMemberInAboutUsId(int? Id);
        string videoUploadInTeamMemberInAboutUs(vmfileInfo obj);
        void deleteVideoInTeamMemberInAboutUs(string oldVideoName);
        ResponseModel GetAllTeamMemberinFrontEnd();
    }
}
