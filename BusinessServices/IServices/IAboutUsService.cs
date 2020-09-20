using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface IAboutUsService
    {
        ResponseModel AddUpdateAboutUsDetail(AboutUs obj);

        ResponseModel GetAboutUsDetail();
        ResponseModel deleteAboutUsInfo(int? Id);
        ResponseModel fileUploadInAboutUs(vmfileInfo obj);
        ResponseModel forgotpassword();
    }
}
