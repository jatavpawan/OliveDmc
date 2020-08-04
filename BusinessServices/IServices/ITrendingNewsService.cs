using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface ITrendingNewsService
    {
        ResponseModel AddUpdateTrendingNews(VmTrendingNews obj);

        ResponseModel GetAllTrendingNews();
        ResponseModel deleteTrendingNews(int? Id);
        ResponseModel fileUploadInTrendingNews(vmfileInfo obj);

        ResponseModel GetTrendingNewsDetailByTrendingNewsId(int? Id);
        ResponseModel videoUploadInTrendingNews(vmfileInfo obj);
        ResponseModel deleteVideoInTrendingNews(string oldVideoName);
    }
}
