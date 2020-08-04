using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface ITrendingNewsRepository
    {
        ResponseModel AddUpdateTrendingNews(VmTrendingNews obj);

        ResponseModel GetAllTrendingNews();

        ResponseModel deleteTrendingNews(int? Id);
        string fileUploadInTrendingNews(vmfileInfo obj);
        ResponseModel GetTrendingNewsDetailByTrendingNewsId(int? Id);
        string videoUploadInTrendingNews(vmfileInfo obj);
        void deleteVideoInTrendingNews(string oldVideoName);
    }
}
