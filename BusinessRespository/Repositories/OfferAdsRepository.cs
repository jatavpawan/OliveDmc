﻿using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using BusinessRespository.IRepositories;
using BusinessRespository.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRespository.Repositories
{
    class OfferAdsRepository: IOfferAdsRepository
    {
        private TravelOliveContext Context;

        public OfferAdsRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateOfferAds(vmOfferAds obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                string Image = string.Empty;
                if (obj.Image != null || obj.Image != null || obj.Image != null || obj.Image != null)
                {
                    var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                    Image = obj.Image != null ? prefixpath + "_" + obj.Image.FileName : null;

                    FileUploadcls uploadcls = new FileUploadcls();
                    if (obj.Image != null) uploadcls.fileUpload(obj.Image, @"Uploads\OfferAds\image", Image);

                }

                if (obj.Id > 0)
                {
                    var OfferAdsObj = Context.OfferAds.Where(z => z.Id == obj.Id).FirstOrDefault();
                    OfferAdsObj.Title = obj.Title;
                    OfferAdsObj.PageId = obj.PageId;
                    OfferAdsObj.ShowInFrontEnd = obj.ShowInFrontEnd;
                    OfferAdsObj.RecUpd = "U";
                    OfferAdsObj.UpdatedBy = obj.UpdatedBy;
                    OfferAdsObj.UpdatedDate = DateTime.Now;
                    if (obj.Image != null)
                    {
                        FileUploadcls uploadcls = new FileUploadcls();
                        uploadcls.fileDeleted(@"Uploads\OfferAds\image", OfferAdsObj.Image);
                        OfferAdsObj.Image = Image;
                    }
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {

                    //var result1 = Context.OfferAds.Where(z => z.OfferAdsName == obj.OfferAdsName).Any();


                    if (!Context.OfferAds.Where(z => z.Title == obj.Title && z.RecUpd != "D").Any())
                    {
                        var OfferAdsDetail = new OfferAds
                        {
                            Title = obj.Title,
                            PageId = obj.PageId,
                            RecUpd = "C",
                            ShowInFrontEnd = obj.ShowInFrontEnd,
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now,
                            Image = Image
                        };

                        Context.OfferAds.Add(OfferAdsDetail);
                        Context.SaveChanges();
                        result.message = "Successfully Saved";
                        result.status = Status.Success;
                    }
                    else
                    {
                        result.message = "Record already Exists";
                        result.status = Status.Warning;
                    }

                }

            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;
            }
            return result;
        }


        public ResponseModel GetAllOfferAds()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                //List<OfferAds> resultValue = new List<OfferAds>();
                //resultValue = Context.OfferAds.Where(z => z.RecUpd != "D").ToList();

                //string s1 = "1;2;3;4;5;6;7;8;9;10;11;12";
                //int[] ints = s1.Split(';').Select(int.Parse).ToArray();
                //Array.Exists(language, element => element == "Ruby"));

                List<vmGetAllOfferAds> resultValue = new List<vmGetAllOfferAds>();

                resultValue = Context.OfferAds.Where(z => z.RecUpd != "D" && z.ShowInFrontEnd == true).Select(x => new vmGetAllOfferAds
                {
                    Id = x.Id,
                    Title = x.Title,
                    Image = x.Image,
                    PageId = x.PageId,
                    Pages = Context.Page.Where(z => x.PageId.Contains(z.PageId.ToString())).Select(y => new vmPageNameList { pageName = y.PageTitle }).ToList(),
                    //Pages = Context.Page.Where( z => Array.Exists(  (x.PageId.Split(',').Select(int.Parse).ToArray() ), element => element == z.PageId) ).Select(y => new vmPageNameList { pageName = y.PageTitle } ).ToList(),
                    //Pages = Context.Page.Where(z => Array.Exists( x.PageId.Split(','), element => element.Contains(z.PageId.ToString()))).Select(y => new vmPageNameList { pageName = y.PageTitle }).ToList(),
                    //Pages = Context.Page.Where(z => Array.IndexOf(x.PageId.Split(','), z.PageId.ToString()) > -1).Select(y => new vmPageNameList { pageName = y.PageTitle }).ToList(),

                }).ToList();



                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for Offer And  Ads";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteOfferAds(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<OfferAds> lst = new List<OfferAds>();
                if (Id > 0)
                {
                    var OfferAdsDetail = Context.OfferAds.Where(z => z.Id == Id).FirstOrDefault();
                    //FileUploadcls uploadcls = new FileUploadcls();
                    //uploadcls.fileDeleted(@"Uploads\OfferAds\image", OfferAdsDetail.Image);
                    OfferAdsDetail.RecUpd = "D";
                    //Context.OfferAds.Remove(OfferAdsDetail);
                    Context.SaveChanges();
                }

                result.data = lst;
                result.status = Status.Success;
                result.message = "delete successfully";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

        public string fileUploadInOfferAds(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                imageFile = obj.fileInfo != null ? obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\OfferAds\image", imageFile);

            }

            return imageFile;
        }


        public ResponseModel GetOfferAdsDetailByOfferAdsId(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var OfferAdsDetail = new OfferAds();

                if (Id > 0)
                {
                    OfferAdsDetail = Context.OfferAds.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = OfferAdsDetail;
                result.status = Status.Success;
                result.message = "OfferAds Detail";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

        public ResponseModel GetAllOfferAdsInFrontEnd()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<OfferAds> resultValue = new List<OfferAds>();
                resultValue = Context.OfferAds.Where(z => z.RecUpd != "D" && z.ShowInFrontEnd ==  true).ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for Offer And Ads";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

        
         public ResponseModel GetAllOfferAdsByPageId(int? Id)
        {
            string pageid = Id.ToString();
            ResponseModel result = new ResponseModel();
            try
            {
                List<OfferAds> OfferAdsList = new List<OfferAds>();


                OfferAdsList = Context.OfferAds.Where(z => z.PageId.Contains(pageid)).ToList();
                

                result.data = OfferAdsList;
                result.status = Status.Success;
                result.message = "OfferAds Detail";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

    }
}
