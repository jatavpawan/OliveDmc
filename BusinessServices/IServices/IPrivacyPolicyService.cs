using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface IPrivacyPolicyService
    {
        ResponseModel AddUpdatePrivacyPolicyDetail(PrivacyPolicy obj);

        ResponseModel GetPrivacyPolicyDetail();
        ResponseModel deletePrivacyPolicyInfo(int? Id);
        ResponseModel fileUploadInPrivacyPolicy(vmfileInfo obj);
    }
}
