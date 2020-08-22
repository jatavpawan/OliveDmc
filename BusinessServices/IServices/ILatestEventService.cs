using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface ILatestEventService
    {
        ResponseModel AddUpdateLatestEvent(vmLatestEvent obj);

        ResponseModel GetAllLatestEvent();
        ResponseModel deleteLatestEvent(int? Id);
        ResponseModel fileUploadInLatestEvent(vmfileInfo obj);

        ResponseModel GetLatestEventDetailByEventId(int? Id);
        ResponseModel videoUploadInLatestEvent(vmfileInfo obj);
        ResponseModel deleteVideoInLatestEvent(string oldVideoName);

        ResponseModel GetAllLatestEventInFrontEnd();


    }
}
