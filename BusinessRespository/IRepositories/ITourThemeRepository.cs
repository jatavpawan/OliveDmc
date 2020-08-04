using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface ITourThemeRepository
    {
            ResponseModel AddUpdateTheme(vmTourTheme obj);

            ResponseModel GetAllTheme();

            ResponseModel deleteTourTheme(int? Id);
        string fileUploadInTourTheme(vmfileInfo obj);
        ResponseModel GetThemeDetailByThemeId(int? Id);
        string videoUploadInTheme(vmfileInfo obj);
        void deleteVideoInTheme(string oldVideoName);


    }
}
