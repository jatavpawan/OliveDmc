using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface IEventService
    {
        ResponseModel AddUpdateEvent(vmEvent obj);

        ResponseModel GetAllEvent();
        ResponseModel deleteEvent(int? Id);
        ResponseModel fileUploadInEvent(vmfileInfo obj);

        ResponseModel GetEventDetailByEventId(int? Id);
        ResponseModel videoUploadInEvent(vmfileInfo obj);
        ResponseModel deleteVideoInEvent(string oldVideoName);
        ResponseModel GetAllEventInFrontEnd();


    }
}
