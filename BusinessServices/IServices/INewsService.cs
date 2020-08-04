using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface INewsService
    {
        ResponseModel AddUpdateNews(vmNews obj);

        ResponseModel GetAllNews();
        ResponseModel deleteNews(int? Id);
        ResponseModel fileUploadInNews(vmfileInfo obj);

        ResponseModel GetNewsDetailByNewsId(int? Id);
        ResponseModel videoUploadInNews(vmfileInfo obj);
        ResponseModel deleteVideoInNews(string oldVideoName);
    }
}
