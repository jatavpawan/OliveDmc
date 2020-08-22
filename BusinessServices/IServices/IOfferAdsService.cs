using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
 
    public interface IOfferAdsService
    {
        ResponseModel AddUpdateOfferAds(vmOfferAds obj);

        ResponseModel GetAllOfferAds();
        ResponseModel deleteOfferAds(int? Id);
        ResponseModel fileUploadInOfferAds(vmfileInfo obj);
        ResponseModel GetOfferAdsDetailByOfferAdsId(int? Id);

        ResponseModel GetAllOfferAdsInFrontEnd();
        ResponseModel GetAllOfferAdsByPageId(int? Id);
    }
}
