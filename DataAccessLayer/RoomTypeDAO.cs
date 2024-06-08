using BussinessObjects;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoomTypeDAO : DBUtils
    {
        
        public List<RoomType> GetAllRoomTypes()
        {
            List<RoomType> roomTypes = new List<RoomType>();
            string query = "select * from RoomType";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    roomTypes.Add(new RoomType()
                    {
                        RoomTypeID = reader.GetInt32(0),
                        RoomTypeName = reader.GetString(1),
                        TypeDescription = reader.GetString(2),
                        TypeNote = reader.GetString(3),
                    });
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return roomTypes;
        }

    }
}
