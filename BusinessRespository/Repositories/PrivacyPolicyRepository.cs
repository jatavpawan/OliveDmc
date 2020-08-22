using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using BusinessRespository.IRepositories;
using BusinessRespository.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRespository.Repositories
{
        class PrivacyPolicyRepository : IPrivacyPolicyRepository
        {
            private TravelOliveContext Context;

            public PrivacyPolicyRepository(TravelOliveContext _context)
            {
                Context = _context;
            }

       
            public ResponseModel AddUpdatePrivacyPolicyDetail(PrivacyPolicy obj)
            {
                ResponseModel result = new ResponseModel();
                try
                {
                    if (obj.Id > 0)
                    {
                        var PrivacyPolicyObj = Context.PrivacyPolicy.Where(z => z.Id == obj.Id).FirstOrDefault();
                        PrivacyPolicyObj.Description = obj.Description;
                        PrivacyPolicyObj.ShowInFrontEnd = obj.ShowInFrontEnd;
                        PrivacyPolicyObj.RecUpd = "U";
                        PrivacyPolicyObj.UpdatedBy = obj.UpdatedBy;
                        PrivacyPolicyObj.UpdatedDate = DateTime.Now;
                        Context.SaveChanges();
                        result.message = "Successfully Updated";
                        result.status = Status.Success;
                    }
                    else
                    {
                        var PrivacyPolicyObj = Context.PrivacyPolicy.FirstOrDefault();

                        if (PrivacyPolicyObj == null)
                        {
                            obj.CreatedDate = DateTime.Now;
                            obj.CreatedBy = obj.CreatedBy;
                            obj.RecUpd = "C";
                            Context.PrivacyPolicy.Add(obj);
                            result.message = "Successfully Saved";

                        }
                        else
                        {
                            PrivacyPolicyObj.Description = obj.Description;
                            PrivacyPolicyObj.ShowInFrontEnd = obj.ShowInFrontEnd;
                            PrivacyPolicyObj.RecUpd = "U";
                            PrivacyPolicyObj.UpdatedBy = obj.UpdatedBy;
                            PrivacyPolicyObj.UpdatedDate = DateTime.Now;
                            result.message = "Successfully Added";
                        }

                        Context.SaveChanges();

                        result.status = Status.Success;

                    }




                }
                catch (Exception ex)
                {
                    result.status = Status.Error;
                    result.error = ex.Message;

                }
                return result;
            }


            public List<PrivacyPolicy> GetPrivacyPolicyDetail()
            {
                List<PrivacyPolicy> PrivacyPolicyObj;
                PrivacyPolicyObj = Context.PrivacyPolicy.Where(z => z.RecUpd != "D").Select(x => new PrivacyPolicy
                {
                    Id = x.Id,
                    ShowInFrontEnd = x.ShowInFrontEnd,
                    Description = x.Description

                }).ToList();

                return PrivacyPolicyObj;
            }


            public ResponseModel deletePrivacyPolicyInfo(int? Id)
            {
                ResponseModel result = new ResponseModel();
                try
                {
                    List<PrivacyPolicy> lst = new List<PrivacyPolicy>();
                    if (Id > 0)
                    {
                        var PrivacyPolicyDetail = Context.PrivacyPolicy.Where(z => z.Id == Id).FirstOrDefault();
                        PrivacyPolicyDetail.RecUpd = "D";
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

            public string fileUploadInPrivacyPolicy(vmfileInfo obj)
            {

                string imageFile = string.Empty;
                if (obj.fileInfo != null)
                {
                    imageFile = obj.fileInfo != null ? obj.fileInfo.FileName : null;

                    FileUploadcls uploadcls = new FileUploadcls();
                    if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\PrivacyPolicy\image", imageFile);

                }

                return imageFile;
            }



        }


    }
