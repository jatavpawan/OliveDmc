using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface ITeamMemberInAboutUsService
    {
        ResponseModel AddUpdateTeamMemberInAboutUs(vmTeamMemberInAboutUs obj);

        ResponseModel GetAllTeamMemberInAboutUs();
        ResponseModel deleteTeamMemberInAboutUs(int? Id);
        ResponseModel fileUploadInTeamMemberInAboutUs(vmfileInfo obj);

        ResponseModel GetTeamMemberInAboutUsDetailByTeamMemberInAboutUsId(int? Id);
        ResponseModel videoUploadInTeamMemberInAboutUs(vmfileInfo obj);
        ResponseModel deleteVideoInTeamMemberInAboutUs(string oldVideoName);
        ResponseModel GetAllTeamMemberinFrontEnd();
    }
}
