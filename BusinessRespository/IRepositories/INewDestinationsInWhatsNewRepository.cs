using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface INewDestinationsInWhatsNewRepository
    {
        ResponseModel AddUpdateNewDestinationsInWhatsNew(vmNewDestinationsInWhatsNew obj);

        ResponseModel GetAllNewDestinationsInWhatsNew();

        ResponseModel deleteNewDestinationsInWhatsNew(int? Id);
        string fileUploadInNewDestinationsInWhatsNew(vmfileInfo obj);
        ResponseModel GetNewDestinationsInWhatsNewDetailByDestinationsId(int? Id);
        string videoUploadInNewDestinationsInWhatsNew(vmfileInfo obj);
        void deleteVideoInNewDestinationsInWhatsNew(string oldVideoName);
        ResponseModel GetAllNewDestinationsInWhatsNewFrontEnd();
    }
}
