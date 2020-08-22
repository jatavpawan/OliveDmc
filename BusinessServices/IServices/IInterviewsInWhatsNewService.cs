using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface IInterviewsInWhatsNewService
    {
        ResponseModel AddUpdateInterviewsInWhatsNew(vmInterviewsInWhatsNew obj);

        ResponseModel GetAllInterviewsInWhatsNew();
        ResponseModel deleteInterviewsInWhatsNew(int? Id);
        ResponseModel fileUploadInInterviewsInWhatsNew(vmfileInfo obj);

        ResponseModel GetInterviewsInWhatsNewDetailByInterviewsId(int? Id);
        ResponseModel videoUploadInInterviewsInWhatsNew(vmfileInfo obj);
        ResponseModel deleteVideoInInterviewsInWhatsNew(string oldVideoName);
        ResponseModel GetAllInterviewsInWhatsNewFrontEnd();
    }
}
