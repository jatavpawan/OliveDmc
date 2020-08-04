using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface IUpcommingNewsService
    {
        ResponseModel AddUpdateUpcommingNews(vmUpcommingNews obj);

        ResponseModel GetAllUpcommingNews();
        ResponseModel deleteUpcommingNews(int? Id);
        ResponseModel fileUploadInUpcommingNews(vmfileInfo obj);

        ResponseModel GetUpcommingNewsDetailByUpcommingNewsId(int? Id);
        ResponseModel videoUploadInUpcommingNews(vmfileInfo obj);
        ResponseModel deleteVideoInUpcommingNews(string oldVideoName);
    }
}
