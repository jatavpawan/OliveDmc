using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using BusinessRespository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRespository.Repositories
{
    class ContactUsRepository : IContactUsRepository
    {
        private TravelOliveContext Context;

        public ContactUsRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateContactUs(ContactUs obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {

                if (obj.Id > 0)
                {
                    var ContactUsObj = Context.ContactUs.Where(z => z.Id == obj.Id).FirstOrDefault();
                    ContactUsObj.FirstName = obj.FirstName;
                    ContactUsObj.LastName= obj.LastName;
                    ContactUsObj.Mobile = obj.Mobile;
                    ContactUsObj.Message = obj.Message;
                    ContactUsObj.Email = obj.Email;
                    ContactUsObj.RecUpd = "U";
                    ContactUsObj.UpdatedBy = obj.UpdatedBy;
                    ContactUsObj.UpdatedDate = DateTime.Now;
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {
                    var ContactUsDetail = new ContactUs
                    {
                        FirstName= obj.FirstName,
                        LastName= obj.LastName,
                        Email = obj.Email,
                        Mobile = obj.Mobile,
                        Message = obj.Message,
                        RecUpd = "C",
                        CreatedBy = obj.CreatedBy,
                        CreatedDate = DateTime.Now,
                    };
                    Context.ContactUs.Add(ContactUsDetail);
                    Context.SaveChanges();
                    result.message = "Your Query Successfully Saved";
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


        public ResponseModel GetAllContactUs()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<ContactUs> resultValue = new List<ContactUs>();
                resultValue = Context.ContactUs.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for ContactUs";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteContactUs(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<ContactUs> lst = new List<ContactUs>();
                if (Id > 0)
                {
                    var ContactUsDetail = Context.ContactUs.Where(z => z.Id == Id).FirstOrDefault();
                    ContactUsDetail.RecUpd = "D";
                    //Context.ContactUs.Remove(ContactUsDetail);
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


        public ResponseModel GetContactUsDetailById(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var ContactUsDetail = new ContactUs();
                if (Id > 0)
                {
                    ContactUsDetail = Context.ContactUs.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = ContactUsDetail;
                result.status = Status.Success;
                result.message = "ContactUs Detail";
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
