using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface INewDestinationsInWhatsNewService
    {
        ResponseModel AddUpdateNewDestinationsInWhatsNew(vmNewDestinationsInWhatsNew obj);

        ResponseModel GetAllNewDestinationsInWhatsNew();
        ResponseModel deleteNewDestinationsInWhatsNew(int? Id);
        ResponseModel fileUploadInNewDestinationsInWhatsNew(vmfileInfo obj);

        ResponseModel GetNewDestinationsInWhatsNewDetailByDestinationsId(int? Id);
        ResponseModel videoUploadInNewDestinationsInWhatsNew(vmfileInfo obj);
        ResponseModel deleteVideoInNewDestinationsInWhatsNew(string oldVideoName);
        ResponseModel GetAllNewDestinationsInWhatsNewFrontEnd();
    }
}
