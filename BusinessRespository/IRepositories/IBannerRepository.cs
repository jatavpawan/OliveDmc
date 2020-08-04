using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface IBannerRepository
    {
        ResponseModel AddUpdateBanner(vmBanner obj);

        ResponseModel GetAllBanner();

        ResponseModel deleteBanner(int? Id);
        string fileUploadInBanner(vmfileInfo obj);
        ResponseModel GetBannerDetailByBannerId(int? Id);


    }
}
