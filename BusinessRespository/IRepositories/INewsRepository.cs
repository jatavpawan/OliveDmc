using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface INewsRepository
    {
        ResponseModel AddUpdateNews(vmNews obj);

        ResponseModel GetAllNews();

        ResponseModel deleteNews(int? Id);
        string fileUploadInNews(vmfileInfo obj);
        ResponseModel GetNewsDetailByNewsId(int? Id);
        string videoUploadInNews(vmfileInfo obj);
        void deleteVideoInNews(string oldVideoName);
        ResponseModel GetAllNewsinFrontEnd();

    }
}
