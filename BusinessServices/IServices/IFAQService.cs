using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface IFAQService
    {
        ResponseModel AddUpdateFAQ(Faq obj);

        ResponseModel GetAllFAQ();
        ResponseModel deleteFAQ(int? Id);
        ResponseModel fileUploadInFAQ(vmfileInfo obj);

        ResponseModel GetFAQDetailByFAQId(int? Id);
    }
}
