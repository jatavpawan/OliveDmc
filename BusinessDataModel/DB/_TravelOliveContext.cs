using BusinessDataModel.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BusinessDataModel.DB
{
  public partial class TravelOliveContext : DbContext
    {

        protected void OnModelCreating_1(ModelBuilder modelBuilder)
        {
            modelBuilder.Query<vmNetworkConnection_result>();
            modelBuilder.Query<vmUserFriendPost>();

        }

        public List<vmNetworkConnection_result> userNetworkConnection(int? UserID)
        {
            try{
               
                SqlParameter pramUserID = new SqlParameter("@userid", UserID?? (object)DBNull.Value);
              

                // Processing.  
                string sqlQuery = "EXEC [FriendNetwork] " + "@userid";

                var result = this.Query<vmNetworkConnection_result>().FromSql(sqlQuery, pramUserID).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<vmUserFriendPost> userFriendPost(int? UserID)
        {
            try
            {

                SqlParameter pramUserID = new SqlParameter("@userid", UserID ?? (object)DBNull.Value);

                // Processing.  
                string sqlQuery = "EXEC [BuzzWallPost] " + "@userid";

                var result = this.Query<vmUserFriendPost>().FromSql(sqlQuery, pramUserID).ToList();



                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



    }
}
