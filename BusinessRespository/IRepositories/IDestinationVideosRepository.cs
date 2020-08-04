using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories
{
    public interface IDestinationVideosRepository
    {
        ResponseModel AddUpdateDestinationVideos(VmDestinationVideos obj);

        ResponseModel GetAllDestinationVideos();

        ResponseModel deleteDestinationVideos(int? Id);
        ResponseModel GetDestinationVideosDetailByDestinationVideosId(int? Id);
        string videoUploadInDestinationVideos(vmfileInfo obj);
        void deleteVideoInDestinationVideos(string oldVideoName);
    }
}
