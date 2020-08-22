using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface IPrivacyPolicyRepository
    {
        List<PrivacyPolicy> GetPrivacyPolicyDetail();
        ResponseModel AddUpdatePrivacyPolicyDetail(PrivacyPolicy obj);
        ResponseModel deletePrivacyPolicyInfo(int? Id);
        string fileUploadInPrivacyPolicy(vmfileInfo obj);

    }
}
