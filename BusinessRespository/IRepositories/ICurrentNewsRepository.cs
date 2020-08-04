using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface ICurrentNewsRepository
    {
        ResponseModel AddUpdateCurrentNews(vmCurrentNews obj);

        ResponseModel GetAllCurrentNews();

        ResponseModel deleteCurrentNews(int? Id);
        string fileUploadInCurrentNews(vmfileInfo obj);
        ResponseModel GetCurrentNewsDetailByCurrentNewsId(int? Id);
        string videoUploadInCurrentNews(vmfileInfo obj);
        void deleteVideoInCurrentNews(string oldVideoName);
    }
}
