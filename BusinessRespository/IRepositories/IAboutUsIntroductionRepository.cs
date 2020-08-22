using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{

    public interface IAboutUsIntroductionRepository
    {
        //void SaveAboutUsIntroductionDetail(AboutUsIntroduction obj);

        List<AboutUsIntroduction> GetAboutUsIntroductionDetail();
        ResponseModel AddUpdateAboutUsIntroductionDetail(vmAboutUsIntroduction obj);
        ResponseModel deleteAboutUsIntroductionInfo(int? Id);
        string fileUploadInAboutUsIntroduction(vmfileInfo obj);

    }
}
