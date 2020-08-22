using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface IAboutUsStatementRepository
    {
        ResponseModel AddUpdateAboutUsStatement(vmAboutUsStatement obj);

        ResponseModel GetAllAboutUsStatement();

        ResponseModel deleteAboutUsStatement(int? Id);
        string fileUploadInAboutUsStatement(vmfileInfo obj);
        ResponseModel GetAboutUsStatementDetailByAboutUsStatementId(int? Id);
        string videoUploadInAboutUsStatement(vmfileInfo obj);
        void deleteVideoInAboutUsStatement(string oldVideoName);
        ResponseModel GetAllAboutUsStatementinFrontEnd();

    }
}
