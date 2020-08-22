using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface IInterviewsInWhatsNewRepository
    {
        ResponseModel AddUpdateInterviewsInWhatsNew(vmInterviewsInWhatsNew obj);

        ResponseModel GetAllInterviewsInWhatsNew();

        ResponseModel deleteInterviewsInWhatsNew(int? Id);
        string fileUploadInInterviewsInWhatsNew(vmfileInfo obj);
        ResponseModel GetInterviewsInWhatsNewDetailByInterviewsId(int? Id);
        string videoUploadInInterviewsInWhatsNew(vmfileInfo obj);
        void deleteVideoInInterviewsInWhatsNew(string oldVideoName);
        ResponseModel GetAllInterviewsInWhatsNewFrontEnd();
    }
}
