using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.IServices
{
    public interface IDestinationVideosService
    {
        ResponseModel AddUpdateDestinationVideos(VmDestinationVideos obj);

        ResponseModel GetAllDestinationVideos();
        ResponseModel deleteDestinationVideos(int? Id);

        ResponseModel GetDestinationVideosDetailByDestinationVideosId(int? Id);
        ResponseModel videoUploadInDestinationVideos(vmfileInfo obj);
        ResponseModel deleteVideoInDestinationVideos(string oldVideoName);
    }
}
