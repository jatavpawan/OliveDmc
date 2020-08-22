using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    
    public interface IOfferAdsRepository
    {
        ResponseModel AddUpdateOfferAds(vmOfferAds obj);

        ResponseModel GetAllOfferAds();

        ResponseModel deleteOfferAds(int? Id);
        string fileUploadInOfferAds(vmfileInfo obj);
        ResponseModel GetOfferAdsDetailByOfferAdsId(int? Id);
        ResponseModel GetAllOfferAdsInFrontEnd();
        ResponseModel GetAllOfferAdsByPageId(int? Id);
    }
}
