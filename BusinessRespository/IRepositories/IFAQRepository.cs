using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface IFAQRepository
    {
        ResponseModel AddUpdateFAQ( Faq obj);

        ResponseModel GetAllFAQ();

        ResponseModel deleteFAQ(int? Id);
        string fileUploadInFAQ(vmfileInfo obj);
        ResponseModel GetFAQDetailByFAQId(int? Id);
    }
}
