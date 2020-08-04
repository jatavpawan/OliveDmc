using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessDataModel.ViewModel;
using BusinessServices.IServices;
using CookApp.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OLiveDMC.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomException))]
    public class OfferAdsController : ControllerBase
    {
        private IOfferAdsService _OfferAdsService;
        public OfferAdsController(IOfferAdsService OfferAdsService)
        {
            _OfferAdsService = OfferAdsService;
        }

        [HttpPost]
        [Route("AddUpdateOfferAds")]
        public async Task<ResponseModel> AddUpdateOfferAds([FromForm]vmOfferAds obj)
        {
            var Data = _OfferAdsService.AddUpdateOfferAds(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllOfferAds")]
        public async Task<ResponseModel> GetAllOfferAds()
        {
            var Data = _OfferAdsService.GetAllOfferAds();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteOfferAds")]
        public async Task<ResponseModel> deleteOfferAds(int? Id)
        {
            var Data = _OfferAdsService.deleteOfferAds(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("fileUploadInOfferAds")]
        public async Task<ResponseModel> fileUploadInOfferAds([FromForm] vmfileInfo obj)
        {
            var Data = _OfferAdsService.fileUploadInOfferAds(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("GetOfferAdsDetailByOfferAdsId")]
        public async Task<ResponseModel> GetOfferAdsDetailByOfferAdsId(int? Id)
        {
            var Data = _OfferAdsService.GetOfferAdsDetailByOfferAdsId(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }
    }
}