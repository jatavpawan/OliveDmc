using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface ILatestEventRepository
    {
        ResponseModel AddUpdateLatestEvent(vmLatestEvent obj);

        ResponseModel GetAllLatestEvent();

        ResponseModel deleteLatestEvent(int? Id);
        string fileUploadInLatestEvent(vmfileInfo obj);
        ResponseModel GetLatestEventDetailByEventId(int? Id);

        string videoUploadInLatestEvent(vmfileInfo obj);
        void deleteVideoInLatestEvent(string oldVideoName);

        ResponseModel GetAllLatestEventInFrontEnd();
    }
}
