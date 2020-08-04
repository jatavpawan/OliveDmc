using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface ITourThemeService
    {
        ResponseModel AddUpdateTheme(vmTourTheme obj);

        ResponseModel GetAllTheme();
        ResponseModel deleteTourTheme(int? Id);
        ResponseModel fileUploadInTourTheme(vmfileInfo obj);

        ResponseModel GetThemeDetailByThemeId(int? Id);
        ResponseModel videoUploadInTheme(vmfileInfo obj);
        ResponseModel deleteVideoInTheme(string oldVideoName);

    }
}
