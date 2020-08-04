using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface IUpcommingNewsRepository
    {
        ResponseModel AddUpdateUpcommingNews(vmUpcommingNews obj);

        ResponseModel GetAllUpcommingNews();

        ResponseModel deleteUpcommingNews(int? Id);
        string fileUploadInUpcommingNews(vmfileInfo obj);
        ResponseModel GetUpcommingNewsDetailByUpcommingNewsId(int? Id);
        string videoUploadInUpcommingNews(vmfileInfo obj);
        void deleteVideoInUpcommingNews(string oldVideoName);
    }
}
