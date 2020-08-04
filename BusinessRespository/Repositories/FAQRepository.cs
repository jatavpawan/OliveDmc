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
    class FAQRepository: IFAQRepository
    {
        private TravelOliveContext Context;

        public FAQRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateFAQ(Faq obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                if (obj.Id > 0)
                {
                    var FAQObj = Context.Faq.Where(z => z.Id == obj.Id).FirstOrDefault();
                    FAQObj.Title = obj.Title;
                    FAQObj.Description = obj.Description;
                    FAQObj.ShowInFrontEnd = obj.ShowInFrontEnd;
                    FAQObj.RecUpd = "U";
                    FAQObj.UpdatedBy = obj.UpdatedBy;
                    FAQObj.UpdatedDate = DateTime.Now;
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {

                    //var result1 = Context.FAQ.Where(z => z.FAQName == obj.FAQName).Any();


                    if (!Context.Faq.Where(z => z.Title == obj.Title && z.RecUpd != "D").Any())
                    {
                        var FAQDetail = new Faq
                        {
                            Title = obj.Title,
                            Description = obj.Description,
                            ShowInFrontEnd = obj.ShowInFrontEnd,
                            RecUpd = "C",
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now,
                        };
                        Context.Faq.Add(FAQDetail);
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


        public ResponseModel GetAllFAQ()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<Faq> resultValue = new List<Faq>();
                resultValue = Context.Faq.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for FAQ";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteFAQ(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<Faq> lst = new List<Faq>();
                if (Id > 0)
                {
                    var FAQDetail = Context.Faq.Where(z => z.Id == Id).FirstOrDefault();
                    FAQDetail.RecUpd = "D";
                    //Context.FAQ.Remove(FAQDetail);
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

        public string fileUploadInFAQ(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                imageFile = obj.fileInfo != null ? obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\FAQ\image", imageFile);

            }

            return imageFile;
        }


        public ResponseModel GetFAQDetailByFAQId(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var FAQDetail = new Faq();
                if (Id > 0)
                {
                    FAQDetail = Context.Faq.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = FAQDetail;
                result.status = Status.Success;
                result.message = "FAQ Detail";
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
