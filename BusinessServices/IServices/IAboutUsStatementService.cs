using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface IAboutUsStatementService
    {
        ResponseModel AddUpdateAboutUsStatement(vmAboutUsStatement obj);

        ResponseModel GetAllAboutUsStatement();
        ResponseModel deleteAboutUsStatement(int? Id);
        ResponseModel fileUploadInAboutUsStatement(vmfileInfo obj);

        ResponseModel GetAboutUsStatementDetailByAboutUsStatementId(int? Id);
        ResponseModel videoUploadInAboutUsStatement(vmfileInfo obj);
        ResponseModel deleteVideoInAboutUsStatement(string oldVideoName);

        ResponseModel GetAllAboutUsStatementinFrontEnd();
    }
}
