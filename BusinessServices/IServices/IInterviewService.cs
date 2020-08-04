using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface IInterviewService
    {
        ResponseModel AddUpdateInterview(VmInterview obj);

        ResponseModel GetAllInterview();
        ResponseModel deleteInterview(int? Id);
        ResponseModel fileUploadInInterview(vmfileInfo obj);

        ResponseModel GetInterviewDetailByInterviewId(int? Id);
        ResponseModel videoUploadInInterview(vmfileInfo obj);
        ResponseModel deleteVideoInInterview(string oldVideoName);
    }
}
