using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface IEventRepository
    {
        ResponseModel AddUpdateEvent(vmEvent obj);

        ResponseModel GetAllEvent();

        ResponseModel deleteEvent(int? Id);
        string fileUploadInEvent(vmfileInfo obj);
        ResponseModel GetEventDetailByEventId(int? Id);

        string videoUploadInEvent(vmfileInfo obj);
        void deleteVideoInEvent(string oldVideoName);
        ResponseModel GetAllEventInFrontEnd();

    }
}
