using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface IContactUsService
    {
        ResponseModel AddUpdateContactUs(ContactUs obj);

        ResponseModel GetAllContactUs();
        ResponseModel deleteContactUs(int? Id);
        ResponseModel GetContactUsDetailById(int? Id);

    }
}
