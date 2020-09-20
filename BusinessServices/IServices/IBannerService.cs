using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface IBannerService
    {
        ResponseModel AddUpdateBanner(vmBanner obj);

        ResponseModel GetAllBanner();
        ResponseModel deleteBanner(int? Id);
        ResponseModel fileUploadInBanner(vmfileInfo obj);

        ResponseModel GetBannerDetailByPageId(int? Id);
        ResponseModel GetAllPage(); 
        ResponseModel GetBannerDetailByBannerId(int? Id);
        ResponseModel GetBannerAtHome();


    }
}
