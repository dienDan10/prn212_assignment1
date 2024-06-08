using BussinessObjects;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BookingReservationDAO : DBUtils
    {

        public List<BookingReservation> GetBookingReservationByCustomerID(int id) { 
            List<BookingReservation> list = new List<BookingReservation>();
            string query = "select * from BookingReservation where CustomerID = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new BookingReservation() {
                        BookingReservationID = reader.GetInt32(0),
                        BookingDate = reader.GetDateTime(1).ToString(),
                        TotalPrice = reader.GetDecimal(2),
                        CustomerID = reader.GetInt32(3),
                        BookingStatus = reader.GetByte(4)
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
