using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface IAboutUsIntroductionService
    {
        ResponseModel AddUpdateAboutUsIntroductionDetail(vmAboutUsIntroduction obj);

        ResponseModel GetAboutUsIntroductionDetail();
        ResponseModel deleteAboutUsIntroductionInfo(int? Id);
        ResponseModel fileUploadInAboutUsIntroduction(vmfileInfo obj);
    }
}

