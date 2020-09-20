using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using BusinessRespository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRespository.Repositories
{
    class TravelUtilityQueryRepository : ITravelUtilityQueryRepository
    {
        private TravelOliveContext Context;

        public TravelUtilityQueryRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateTravelUtilityQuery(TravelUtilityQuery obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {

                if (obj.Id > 0)
                {
                    var TravelUtilityQueryObj = Context.TravelUtilityQuery.Where(z => z.Id == obj.Id).FirstOrDefault();
                    TravelUtilityQueryObj.TravelUtilityTypeId = obj.TravelUtilityTypeId;
                    TravelUtilityQueryObj.Name = obj.Name;
                    TravelUtilityQueryObj.Mobile = obj.Mobile;
                    TravelUtilityQueryObj.Email = obj.Email;
                    TravelUtilityQueryObj.StartCountry = obj.StartCountry;
                    TravelUtilityQueryObj.DestinationCountry = obj.DestinationCountry;
                    TravelUtilityQueryObj.DateOfTravel = obj.DateOfTravel;
                    TravelUtilityQueryObj.RecUpd = "U";
                    TravelUtilityQueryObj.UpdatedBy = obj.UpdatedBy;
                    TravelUtilityQueryObj.UpdatedDate = DateTime.Now;
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {
                    var TravelUtilityQueryDetail = new TravelUtilityQuery
                    {
                        TravelUtilityTypeId = obj.TravelUtilityTypeId,
                        Name = obj.Name,
                        Email = obj.Email,
                        Mobile = obj.Mobile,
                        StartCountry = obj.StartCountry,
                        DestinationCountry = obj.DestinationCountry,
                        DateOfTravel = obj.DateOfTravel,
                        RecUpd = "C",
                        CreatedBy = obj.CreatedBy,
                        CreatedDate = DateTime.Now,
                    };
                    Context.TravelUtilityQuery.Add(TravelUtilityQueryDetail);
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


        public ResponseModel GetAllTravelUtilityQuery()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                //List<TravelUtilityQuery> resultValue = new List<TravelUtilityQuery>();
              


                var innerjoin  = from tu in Context.TravelUtility
                                      join tq in Context.TravelUtilityQuery
                                      on tu.Id equals tq.TravelUtilityTypeId
                                      select new vmTravelUtilityQuery
                                      {

                                          Id = tq.Id,
                                          TravelUtilityTypeId = tq.TravelUtilityTypeId,
                                          UtilityName = tu.UtilityType,
                                          Name = tq.Name,
                                          Mobile = tq.Mobile,
                                          Email = tq.Email,
                                          StartCountry = tq.StartCountry,
                                          DestinationCountry = tq.DestinationCountry,
                                          DateOfTravel = tq.DateOfTravel,
                                          RecUpd = tq.RecUpd,
                                          CreatedBy = tq.CreatedBy,
                                          CreatedDate = tq.CreatedDate,
                                          UpdatedBy = tq.UpdatedBy,
                                          UpdatedDate = tq.UpdatedDate
                                      };

                var resultValue = innerjoin.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for TravelUtilityQuery";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteTravelUtilityQuery(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<TravelUtilityQuery> lst = new List<TravelUtilityQuery>();
                if (Id > 0)
                {
                    var TravelUtilityQueryDetail = Context.TravelUtilityQuery.Where(z => z.Id == Id).FirstOrDefault();
                    TravelUtilityQueryDetail.RecUpd = "D";
                    //Context.TravelUtilityQuery.Remove(TravelUtilityQueryDetail);
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


        public ResponseModel GetTravelUtilityQueryDetailById(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var TravelUtilityQueryDetail = new TravelUtilityQuery();
                if (Id > 0)
                {
                    TravelUtilityQueryDetail = Context.TravelUtilityQuery.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = TravelUtilityQueryDetail;
                result.status = Status.Success;
                result.message = "TravelUtilityQuery Detail";
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
