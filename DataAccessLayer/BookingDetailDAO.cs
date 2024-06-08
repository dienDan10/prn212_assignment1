using BussinessObjects;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BookingDetailDAO : DBUtils
    {
        public List<BookingDetail> GetAllBookingDetail()
        {
            List<BookingDetail> list = new List<BookingDetail>();
            string query = "select * from BookingDetail";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new BookingDetail
                    {
                        BookingReservationID = reader.GetInt32(0),
                        RoomID = reader.GetInt32(1),
                        StartDate = reader.GetDateTime(2).ToString(),
                        EndDate = reader.GetDateTime(3).ToString(),
                        ActualPrice = reader.GetDecimal(4),
                    });
                    
                }

            } catch (Exception ex)
            {

            } finally
            {
                con.Close();
            }

            return list;
        }


    }
}
