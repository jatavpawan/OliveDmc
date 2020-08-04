using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface ICurrentNewsService
    {
        ResponseModel AddUpdateCurrentNews(vmCurrentNews obj);

        ResponseModel GetAllCurrentNews();
        ResponseModel deleteCurrentNews(int? Id);
        ResponseModel fileUploadInCurrentNews(vmfileInfo obj);

        ResponseModel GetCurrentNewsDetailByCurrentNewsId(int? Id);
        ResponseModel videoUploadInCurrentNews(vmfileInfo obj);
        ResponseModel deleteVideoInCurrentNews(string oldVideoName);
    }
}
