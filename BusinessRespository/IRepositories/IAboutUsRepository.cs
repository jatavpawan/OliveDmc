using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface IAboutUsRepository
    {
        //void SaveAboutUsDetail(AboutUs obj);

        List<vmGetAboutUsDetail> GetAboutUsDetail();
        ResponseModel AddUpdateAboutUsDetail(AboutUs obj);
        ResponseModel deleteAboutUsInfo(int? Id);
        string fileUploadInAboutUs(vmfileInfo obj);
        ResponseModel forgotpassword();
    }
}
