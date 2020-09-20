using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using BusinessRespository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRespository.Repositories
{
    class UserNetworkRepository : IUserNetworkRepository
    {
        private TravelOliveContext Context;

        public UserNetworkRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateUserNetwork(ContactUs obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {

                if (obj.Id > 0)
                {
                    var UserNetworkObj = Context.ContactUs.Where(z => z.Id == obj.Id).FirstOrDefault();
                    UserNetworkObj.FirstName = obj.FirstName;
                    UserNetworkObj.LastName = obj.LastName;
                    UserNetworkObj.Mobile = obj.Mobile;
                    UserNetworkObj.Message = obj.Message;
                    UserNetworkObj.Email = obj.Email;
                    UserNetworkObj.RecUpd = "U";
                    UserNetworkObj.UpdatedBy = obj.UpdatedBy;
                    UserNetworkObj.UpdatedDate = DateTime.Now;
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {
                    var UserNetworkDetail = new ContactUs
                    {
                        FirstName = obj.FirstName,
                        LastName = obj.LastName,
                        Email = obj.Email,
                        Mobile = obj.Mobile,
                        Message = obj.Message,
                        RecUpd = "C",
                        CreatedBy = obj.CreatedBy,
                        CreatedDate = DateTime.Now,
                    };
                    Context.ContactUs.Add(UserNetworkDetail);
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


        public ResponseModel GetAllUserNetwork()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<ContactUs> resultValue = new List<ContactUs>();
                resultValue = Context.ContactUs.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for UserNetwork";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteUserNetwork(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<ContactUs> lst = new List<ContactUs>();
                if (Id > 0)
                {
                    var UserNetworkDetail = Context.ContactUs.Where(z => z.Id == Id).FirstOrDefault();
                    UserNetworkDetail.RecUpd = "D";
                    //Context.UserNetwork.Remove(UserNetworkDetail);
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


        public ResponseModel GetUserNetworkDetailById(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var UserNetworkDetail = new ContactUs();
                if (Id > 0)
                {
                    UserNetworkDetail = Context.ContactUs.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = UserNetworkDetail;
                result.status = Status.Success;
                result.message = "UserNetwork Detail";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }
      public ResponseModel sendFriendRequest(UserFriendsRequest obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                //if (obj.Id > 0)
                //{
                //    var UserNetworkObj = Context.ContactUs.Where(z => z.Id == obj.Id).FirstOrDefault();
                //    UserNetworkObj.FirstName = obj.FirstName;
                //    UserNetworkObj.LastName = obj.LastName;
                //    UserNetworkObj.Mobile = obj.Mobile;
                //    UserNetworkObj.Message = obj.Message;
                //    UserNetworkObj.Email = obj.Email;
                //    UserNetworkObj.RecUpd = "U";
                //    UserNetworkObj.UpdatedBy = obj.UpdatedBy;
                //    UserNetworkObj.UpdatedDate = DateTime.Now;
                //    Context.SaveChanges();
                //    result.message = "Successfully Updated";
                //    result.status = Status.Success;

                //}
                //else
                //{
                    var UserFriendsRequestObj = new UserFriendsRequest
                    {
                        UserId = obj.UserId,
                        RequestFriendId = obj.RequestFriendId,
                        Status = "Pending",
                        RecUpd = "C",
                        CreatedBy = obj.CreatedBy,
                        CreatedDate = DateTime.Now,
                    };
                    Context.UserFriendsRequest.Add(UserFriendsRequestObj);
                    Context.SaveChanges();
                    result.message = "Your Friend Request Send Successfully";
                    result.status = Status.Success;


                //}
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

        public ResponseModel getAddFriendRequestList(int? userid)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<UserFriendsRequest> UserFriendsRequestList = new List<UserFriendsRequest>();
                UserFriendsRequestList = Context.UserFriendsRequest.Where(z => z.RecUpd != "D" && z.RequestFriendId == userid && z.Status == "Pending").ToList();

                var FriendsRequestList = from request in UserFriendsRequestList
                                         join userInfo in Context.Registration
                                         on request.UserId equals userInfo.Id
                                         select new vmFriendRequestList
                                         {

                                             Id = request.Id,
                                             UserId = request.UserId,
                                             RequestFriendId = request.RequestFriendId,
                                             Status = request.Status,
                                             RecUpd = request.RecUpd,
                                             CreatedBy = request.CreatedBy,
                                             CreatedDate = request.CreatedDate,
                                             UpdatedBy = request.UpdatedBy,
                                             UpdatedDate = request.UpdatedDate,
                                             FirstName = userInfo.FirstName,
                                             LastName = userInfo.LastName,
                                             EmailId = userInfo.EmailId,
                                             MobileNo = userInfo.MobileNo,
                                             Category = userInfo.Category,
                                             TravelEnthuiast = userInfo.TravelEnthuiast,
                                             RoleId = userInfo.RoleId,
                                             Birthday = userInfo.Birthday,
                                             Occupation = userInfo.Occupation,
                                             Country = userInfo.Country,
                                             State = userInfo.State,
                                             City = userInfo.City,
                                             AboutDescription = userInfo.AboutDescription,
                                             ProfileImg = userInfo.ProfileImg,
                                             CoverImage = userInfo.CoverImage
                                         };



                result.data = FriendsRequestList;
                result.status = Status.Success;
                result.message = "List for Add Friend Request";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel actionOnFriendRequest(UserFriendsRequest obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                UserFriendsRequest UserFriendsRequestObj = new UserFriendsRequest();
                UserFriendsRequestObj = Context.UserFriendsRequest.Where(z => z.RecUpd != "D" && z.Id == obj.Id && z.Status == "pending").FirstOrDefault();

                if (UserFriendsRequestObj != null)
                {
                    UserFriendsRequestObj.Status = obj.Status;
                    UserFriendsRequestObj.RecUpd = "U";
                    UserFriendsRequestObj.UpdatedBy = obj.UpdatedBy;
                    UserFriendsRequestObj.UpdatedDate = DateTime.Now;
                    Context.SaveChanges();

                    if(obj.Status == "Accept")
                    {
                        var UserFriendsObj1 = new UserFriends
                        {
                            UserId = UserFriendsRequestObj.UserId,
                            FriendId = UserFriendsRequestObj.RequestFriendId,
                            RecUpd = "C",
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now,
                        };
                        Context.UserFriends.Add(UserFriendsObj1);
                        Context.SaveChanges();

                        var UserFriendsObj2 = new UserFriends
                        {
                            UserId = UserFriendsRequestObj.RequestFriendId,
                            FriendId = UserFriendsRequestObj.UserId,
                            RecUpd = "C",
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now,
                        };
                        Context.UserFriends.Add(UserFriendsObj2);
                        Context.SaveChanges();

                        result.message = "Your Friend Request Accept Successfully";
                        
                    }
                    else if (obj.Status == "Reject")
                    {
                        result.message = "Your Friend Request Reject Successfully";
                    }


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




        public ResponseModel userFriendList(int? userid)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                //List<UserFriendsRequest> resultValue = new List<UserFriendsRequest>();
                var userFriend = Context.UserFriends.Where(z =>  z.UserId == userid &&  z.RecUpd != "D"  ).ToList();

                var userFriendList = from friend in userFriend
                                     join userInfo in Context.Registration
                                         on friend.FriendId equals userInfo.Id
                                         select new vmUserFriendList
                                         {

                                             Id = friend.Id,
                                             UserId = friend.UserId,
                                             FriendId = friend.FriendId,
                                             RecUpd = friend.RecUpd,
                                             CreatedBy = friend.CreatedBy,
                                             CreatedDate = friend.CreatedDate,
                                             UpdatedBy = friend.UpdatedBy,
                                             UpdatedDate = friend.UpdatedDate,
                                             FirstName = userInfo.FirstName,
                                             LastName = userInfo.LastName,
                                             EmailId = userInfo.EmailId,
                                             MobileNo = userInfo.MobileNo,
                                             Category = userInfo.Category,
                                             TravelEnthuiast = userInfo.TravelEnthuiast,
                                             RoleId = userInfo.RoleId,
                                             Birthday = userInfo.Birthday,
                                             Occupation = userInfo.Occupation,
                                             Country = userInfo.Country,
                                             State = userInfo.State,
                                             City = userInfo.City,
                                             AboutDescription = userInfo.AboutDescription,
                                             ProfileImg = userInfo.ProfileImg,
                                             CoverImage = userInfo.CoverImage
                                         };

                result.data = userFriendList;
                result.status = Status.Success;
                result.message = "List for User Friend List";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel userPendingRequestList(int? userid)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<UserFriendsRequest> pendingFriendRequest = new List<UserFriendsRequest>();
                pendingFriendRequest = Context.UserFriendsRequest.Where(z => z.RecUpd != "D" && z.UserId == userid && z.Status == "Pending").ToList();


                var pendingFriendRequestList = from request in pendingFriendRequest
                                         join userInfo in Context.Registration
                                         on request.RequestFriendId equals userInfo.Id
                                         select new vmFriendRequestList
                                         {

                                             Id = request.Id,
                                             UserId = request.UserId,
                                             RequestFriendId = request.RequestFriendId,
                                             Status = request.Status,
                                             RecUpd = request.RecUpd,
                                             CreatedBy = request.CreatedBy,
                                             CreatedDate = request.CreatedDate,
                                             UpdatedBy = request.UpdatedBy,
                                             UpdatedDate = request.UpdatedDate,
                                             FirstName = userInfo.FirstName,
                                             LastName = userInfo.LastName,
                                             EmailId = userInfo.EmailId,
                                             MobileNo = userInfo.MobileNo,
                                             Category = userInfo.Category,
                                             TravelEnthuiast = userInfo.TravelEnthuiast,
                                             RoleId = userInfo.RoleId,
                                             Birthday = userInfo.Birthday,
                                             Occupation = userInfo.Occupation,
                                             Country = userInfo.Country,
                                             State = userInfo.State,
                                             City = userInfo.City,
                                             AboutDescription = userInfo.AboutDescription,
                                             ProfileImg = userInfo.ProfileImg,
                                             CoverImage = userInfo.CoverImage
                                         };

                result.data = pendingFriendRequestList;
                result.status = Status.Success;
                result.message = "List for User Friend List";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

        public ResponseModel GetAllUserInNetwork(int userid)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                //List<Registration> resultValue = new List<Registration>();
                //resultValue = Context.Registration.Where(z => z.RecUpd != "D" && z.RoleId == 2).ToList();
                result.data = Context.userNetworkConnection(userid);
                result.status = Status.Success;
                result.message = "List for UserPersonalInfo";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }
      

        public ResponseModel cancelSendFriendRequest(vmcancelSendFriendRequest obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
               
                if (obj.SendRequestFriendId > 0 && obj.UserId > 0)
                {
                    var friendRequestDetail = Context.UserFriendsRequest.Where(z => z.UserId == obj.UserId && z.RequestFriendId == obj.SendRequestFriendId).FirstOrDefault();
                    Context.UserFriendsRequest.Remove(friendRequestDetail);
                    Context.SaveChanges();
                }

             
                result.status = Status.Success;
                result.message = "Cancel Send Friend Request successfully";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

        public ResponseModel unfriend(vmUnFriend obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
             
                if (obj.FriendId > 0 && obj.UserId > 0)
                {
                    var userFriends = Context.UserFriends.Where(z => (z.UserId == obj.UserId && z.FriendId == obj.FriendId) || (z.UserId == obj.FriendId && z.FriendId == obj.UserId)   ).ToList();

                    foreach (var userFriend in userFriends)
                    {
                        Context.UserFriends.Remove(userFriend);
                        Context.SaveChanges();
                    }
                 
                }

           
                result.status = Status.Success;
                result.message = "Unfriend successfully";
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
