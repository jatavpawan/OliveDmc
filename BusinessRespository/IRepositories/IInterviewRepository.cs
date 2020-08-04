using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface IInterviewRepository
    {
        ResponseModel AddUpdateInterview(VmInterview obj);

        ResponseModel GetAllInterview();

        ResponseModel deleteInterview(int? Id);
        string fileUploadInInterview(vmfileInfo obj);
        ResponseModel GetInterviewDetailByInterviewId(int? Id);
        string videoUploadInInterview(vmfileInfo obj);
        void deleteVideoInInterview(string oldVideoName);
    }
}
